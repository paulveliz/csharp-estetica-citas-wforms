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
        public async Task<FullVenta> crearNueva(notaventa nota, notaventa_detalle detalle)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var notaventa = db.notaventa.Add(nota);
                await db.SaveChangesAsync();
                detalle.idnotaventa = notaventa.idnotaventa;
                var notadetalle = db.notaventa_detalle.Add(detalle);
                await db.SaveChangesAsync();
                var newNota = await obtenerPorId(notaventa.idnotaventa);
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
                return nota;
            }
        }

    }
}
