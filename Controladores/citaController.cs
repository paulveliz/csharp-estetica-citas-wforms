using Modelos;
using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class citaController
    {
        public async Task<List<citaModel>> getcitaByClientNameMatching(String text)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where cliente.cl_nombrecompleto.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<List<citaModel>> getcitaByFolioMatching(string folio)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where cita.idcita.ToString().Contains(folio) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<List<citaModel>> getcitaByServiceNameMatching(String text)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where servicio.sv_descripcion.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<List<citaModel>> getcitaByEmpleadoNameMatching(String text)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where empleado.emp_nombrecompleto.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }

        public async Task<citaModel> obtenerCitaPorId(int citaId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => c.idcita == citaId)
                                    join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                    join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                    join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where cita.ct_estatus != 0 && cita.ct_estatus != 3
                                    select new citaModel
                                    {
                                        Id = cita.idcita,
                                        CantidadServicios = cita.ct_cantservicios,
                                        Fecha = cita.ct_fecha,
                                        Hora = cita.ct_hora,
                                        NombreCliente = cliente.cl_nombrecompleto,
                                        NombreEmpleado = empleado.emp_nombrecompleto,
                                        NombreServicio = servicio.sv_descripcion
                                    }).FirstOrDefaultAsync();
                return query;
            }
        }
        public async Task<citas> obtenerCitaPorIdOriginal(int citaId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var cita = await db.citas.FirstOrDefaultAsync(c => c.idcita == citaId);
                return cita;
            }
        }

        public async Task<List<citaModel>> obtenerTodasLasCitas()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Take(100)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id)
                            .ToList();
            }
        }
        public async Task<List<citaModel>> obtenerCitasPorFecha(DateTime from, DateTime to)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => 
                                        c.ct_fecha >= @from &&
                                        c.ct_fecha <= @to
                                    )
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   where cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }

        public async Task<citas> crearCita(citas cita)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var result = db.citas.Add(cita);
                await db.SaveChangesAsync();
                return result;
            }
        }

        public async Task<citas> editarCita(citas cita)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var res = await db.citas.FindAsync(cita.idcita);
                res.ct_cantservicios = cita.ct_cantservicios;
                res.ct_cliente = cita.ct_cliente;
                res.ct_empleado = cita.ct_empleado;
                res.ct_fecha = cita.ct_fecha;
                res.ct_hora = cita.ct_hora;
                res.ct_servicio = cita.ct_servicio;
                res.ct_estatus = cita.ct_estatus;
                await db.SaveChangesAsync();
                return res;
            }
        }

        /**
         * 
         * ESTADO DE LA CITA
         *  0 baja
         *  1 pendiente
         *  2 en progreso
         *  3 satisfactorias
         * */
        public async Task<citas> cambiarEstadoDeCita(int citaId, short nuevoEstado)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var result = await db.citas.FirstOrDefaultAsync(w => w.idcita == citaId);
                result.ct_estatus = nuevoEstado;
                await db.SaveChangesAsync();
                return result;
            }
        }

        public async Task<List<citaModel>> obtenerCitasEnProgreso() 
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => c.ct_estatus == 2)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }

        public async Task<List<citaModel>> obtenerCitasSatisfactorias() 
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => c.ct_estatus == 3)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query;
            }
        }

        public async Task<List<citaModel>> obtenerCitasPendientes() 
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => c.ct_estatus == 1)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<List<citaModel>> obtenerCitasCanceladas() 
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c => c.ct_estatus == 0)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   join servicio in db.servicios on cita.ct_servicio equals servicio.idservicio
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       CantidadServicios = cita.ct_cantservicios,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       NombreServicio = servicio.sv_descripcion
                                   }).ToListAsync();
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
    }
}
