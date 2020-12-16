using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data.Entity;

namespace Controladores
{
    public class ventaController
    {
        public async Task<notaventaModel> obtenerPorId(int notaventaId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var detalles = await (from nvd in db.notaventa_detalle.Where(nv => nv.idnotaventa == notaventaId)
                                        join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new ventaDetalle
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

                var query = await (from notaventa in db.notaventa.Where(n => n.idnotaventa == notaventaId)
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
                                       Detalle = detalles
                                   }).ToListAsync();
                return query[0];
            }
        }

        public async Task<List<notaventaModel>> obtenerTodas()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new ventaDetalle
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

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
                                       Detalle = detalles.Where(nvd => nvd.Id == notaventa.idnotaventa).ToList()
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }

        // TODO: Modificar DB para obtener por fechas. 
        public async Task<List<notaventaModel>> obtenerPorFechas(DateTime from, DateTime to)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var detalles = await (from nvd in db.notaventa_detalle
                                      join servicio in db.servicios on nvd.nvd_servicio equals servicio.idservicio
                                      select new ventaDetalle
                                      {
                                          Id = nvd.idnotaventa,
                                          Servicio = servicio.sv_descripcion,
                                          Precio = nvd.nvd_precio,
                                          Cantidad = nvd.nvd_cantidad
                                      }).ToListAsync();

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
                                       Detalle = detalles.Where(nvd => nvd.Id == notaventa.idnotaventa).ToList()
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<notaventaModel> crearNueva(notaventa nota, notaventa_detalle detalle)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var notaventa = db.notaventa.Add(nota);
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
                var nota = await db.notaventa.FindAsync(notaId);
                nota.nv_estatus = 0;
                var nvd = await db.notaventa_detalle.Where(nv => nv.idnotaventa == notaId).ToListAsync();
                nvd[0].nvd_estatus = 0;
                await db.SaveChangesAsync();
                return nota;
            }
        }

    }
}
