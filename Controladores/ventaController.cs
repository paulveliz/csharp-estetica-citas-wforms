using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelos;
using System.Data.Entity;

namespace Controladores
{
    public class ventaController
    {
        auditController auditCtrl = new auditController();
        public async Task<FullVenta> obtenerPorId(int notaventaId)
        {

            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from notaventa in db.notaventa
                                   join cita in db.citas on notaventa.nv_cita equals cita.idcita
                                   join cliente in db.clientes on notaventa.nv_cliente equals cliente.idcliente
                                   join empleado in db.empleados on notaventa.nv_cliente equals empleado.idempleado
                                   where notaventa.idnotaventa == notaventaId
                                   select new notaventaModel
                                   {
                                       Id = notaventa.idnotaventa,
                                       Cita = cita.idcita,
                                       Cliente = cliente.cl_nombrecompleto,
                                       Empleado = empleado.emp_nombrecompleto,
                                       Total = notaventa.nv_total,
                                       Estatus = notaventa.nv_estatus,
                                   }).FirstOrDefaultAsync();

                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      where nvd.idnotaventa == notaventaId
                                      select new notaventaDetalleModel
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                // Retornar venta con su lista de detalles
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener una venta con id {notaventaId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return new FullVenta(nota: query, detalle: detalles);
            }
        }

        public async Task<List<FullVenta>> obtenerTodas()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from notaventa in db.notaventa
                                   join cita in db.citas on notaventa.nv_cita equals cita.idcita
                                   join cliente in db.clientes on notaventa.nv_cliente equals cliente.idcliente
                                   join empleado in db.empleados on notaventa.nv_cliente equals empleado.idempleado
                                   select new notaventaModel
                                   {
                                       Id = notaventa.idnotaventa,
                                       Cita = cita.idcita,
                                       Cliente = cliente.cl_nombrecompleto,
                                       Empleado = empleado.emp_nombrecompleto,
                                       Total = notaventa.nv_total,
                                       Estatus = notaventa.nv_estatus,
                                   }).ToListAsync();

                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new notaventaDetalleModel
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                // Retornar lista de ventas con su lista de detalles
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener todas las ventas",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                var fv = query.Select(v => {
                    return new FullVenta(
                        nota: v, 
                        detalle: detalles.Where(d => d.Id == v.Id).ToList());
                }).ToList();

                return fv;
            }
        }

        public async Task<List<FullVenta>> obtenerPorFechas(DateTime fromt, DateTime to)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from notaventa in db.notaventa
                                   join cita in db.citas on notaventa.nv_cita equals cita.idcita
                                   join cliente in db.clientes on notaventa.nv_cliente equals cliente.idcliente
                                   join empleado in db.empleados on notaventa.nv_cliente equals empleado.idempleado
                                   where cita.ct_fecha >= fromt && cita.ct_fecha <= to
                                   select new notaventaModel
                                   {
                                       Id = notaventa.idnotaventa,
                                       Cita = cita.idcita,
                                       Cliente = cliente.cl_nombrecompleto,
                                       Empleado = empleado.emp_nombrecompleto,
                                       Total = notaventa.nv_total,
                                       Estatus = notaventa.nv_estatus,
                                   }).ToListAsync();

                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new notaventaDetalleModel
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                // Retornar lista de ventas con su lista de detalles
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener ventas entre fecha {fromt:d} y {to:d}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                var fv = query.Select(v => {
                    return new FullVenta(
                        nota: v,
                        detalle: detalles.Where(d => d.Id == v.Id).ToList());
                }).ToList().OrderByDescending(o =>
                    o.NotaVenta.Id
                ).ToList();

                return fv;
            }
        }
        public async Task<FullVenta> crearNueva(notaventa nota, List<notaventa_detalle> detalle)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var notaventa = db.notaventa.Add(nota);
                await db.SaveChangesAsync();
                detalle.ForEach(d =>
                    d.idnotaventa = notaventa.idnotaventa
                );
                db.notaventa_detalle.AddRange(detalle);
                await db.SaveChangesAsync();
                var newNota = await obtenerPorId(notaventa.idnotaventa);
                var ctCtrl = new citaController();
                await ctCtrl.cambiarEstadoDeCita(notaventa.nv_cita, 3);
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Crear una nueva venta con folio {notaventa.idnotaventa}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return newNota;
            }
        }

        public async Task<notaventa> darDeBaja(int notaId)
        {
            using (var db =  new estetica_lupitaEntities())
            {
                var nota = await db.notaventa.FirstOrDefaultAsync(c => c.idnotaventa == notaId);
                nota.nv_estatus = 0;
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Dar de baja venta con folio {notaId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return nota;
            }
        }

        /**
         *  REPORTS
         * 
         * **/

        public async Task<List<FullVenta>> obtenerPorCliente(DateTime fromt, DateTime to, int clienteId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from notaventa in db.notaventa
                                   join cita in db.citas on notaventa.nv_cita equals cita.idcita
                                   join cliente in db.clientes on notaventa.nv_cliente equals cliente.idcliente
                                   join empleado in db.empleados on notaventa.nv_cliente equals empleado.idempleado
                                   where cita.ct_fecha >= fromt && cita.ct_fecha <= to && cliente.idcliente == clienteId
                                   select new notaventaModel
                                   {
                                       Id = notaventa.idnotaventa,
                                       Cita = cita.idcita,
                                       Cliente = cliente.cl_nombrecompleto,
                                       Empleado = empleado.emp_nombrecompleto,
                                       Total = notaventa.nv_total,
                                       Estatus = notaventa.nv_estatus,
                                   }).ToListAsync();

                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new notaventaDetalleModel
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                // Retornar lista de ventas con su lista de detalles
                var fv = query.Select(v => {
                    return new FullVenta(
                        nota: v,
                        detalle: detalles.Where(d => d.Id == v.Id).ToList());
                }).ToList().OrderByDescending(o =>
                    o.NotaVenta.Id
                ).ToList();

                return fv;
            }
        }
        public async Task<List<FullVenta>> obtenerPorEmpleado(DateTime fromt, DateTime to, int empleadoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from notaventa in db.notaventa
                                   join cita in db.citas on notaventa.nv_cita equals cita.idcita
                                   join cliente in db.clientes on notaventa.nv_cliente equals cliente.idcliente
                                   join empleado in db.empleados on notaventa.nv_cliente equals empleado.idempleado
                                   where cita.ct_fecha >= fromt && cita.ct_fecha <= to && empleado.idempleado == empleadoId
                                   select new notaventaModel
                                   {
                                       Id = notaventa.idnotaventa,
                                       Cita = cita.idcita,
                                       Cliente = cliente.cl_nombrecompleto,
                                       Empleado = empleado.emp_nombrecompleto,
                                       Total = notaventa.nv_total,
                                       Estatus = notaventa.nv_estatus,
                                   }).ToListAsync();

                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new notaventaDetalleModel
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                // Retornar lista de ventas con su lista de detalles
                var fv = query.Select(v => {
                    return new FullVenta(
                        nota: v,
                        detalle: detalles.Where(d => d.Id == v.Id).ToList());
                }).ToList().OrderByDescending(o =>
                    o.NotaVenta.Id
                ).ToList();

                return fv;
            }
        }

    }
}
