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
        auditController auditCtrl = new auditController();
        public async Task<FullCita> getFullCita(int citaId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var citaM = await (from cita in db.citas.Where(c => c.idcita == citaId)
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                       Estatus = cita.ct_estatus
                                   }).FirstOrDefaultAsync();
                var citaD = await (from citaDetail in db.cita_detalle.Where(c => c.sv_cita == citaId)
                                   join servicio in db.servicios on citaDetail.sv_id equals servicio.idservicio
                                   select new citaDetalleModel
                                   {
                                       Id = citaDetail.idserviciodetalle,
                                       Cantidad = citaDetail.sv_cant,
                                       Precio = citaDetail.sv_precio,
                                       Servicio = servicio.sv_descripcion,
                                       ServicioId = servicio.idservicio,
                                       Importe = citaDetail.sv_importe
                                   }).ToListAsync();
                var fullCita = new FullCita(citaM, citaD);
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener una cita completa con folio {citaId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return fullCita;
            }
        }

        public async Task<List<citaModel>> getcitaByClientNameMatching(String text)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   where cliente.cl_nombrecompleto.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
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
                                   where cita.idcita.ToString().Contains(folio) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
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
                                   join detalle in db.cita_detalle on cita.idcita equals detalle.sv_cita
                                   join servicios in db.servicios on detalle.sv_id equals servicios.idservicio
                                   where servicios.sv_descripcion.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
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
                                   where empleado.emp_nombrecompleto.Contains(text) && cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
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
                                   where cita.ct_estatus != 0 && cita.ct_estatus != 3
                                    select new citaModel
                                    {
                                        Id = cita.idcita,
                                        Fecha = cita.ct_fecha,
                                        Hora = cita.ct_hora,
                                        NombreCliente = cliente.cl_nombrecompleto,
                                        NombreEmpleado = empleado.emp_nombrecompleto,
                                    }).FirstOrDefaultAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener una cita completa con folio {citaId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return query;
            }
        }
        public async Task<citas> obtenerCitaPorIdOriginal(int citaId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var cita = await db.citas.FirstOrDefaultAsync(c => c.idcita == citaId);
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener una cita completa con folio {citaId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   where cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener Todas las citas",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   where cita.ct_estatus != 0
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener Todas las citas por lapso de fechas entre {from:d} Y {to:d}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }

        public async Task<citas> crearCita(citas cita, List<cita_detalle> detalle)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var result = db.citas.Add(cita);
                await db.SaveChangesAsync();
                detalle.ForEach(e =>
                    e.sv_cita = result.idcita
                );
                db.cita_detalle.AddRange(detalle);
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Creo una nueva cita con Folio {result.idcita}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return result;
            }
        }

        public async Task<citas> editarCita(citas cita)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var res = await db.citas.FindAsync(cita.idcita);
                res.ct_cliente = cita.ct_cliente;
                res.ct_empleado = cita.ct_empleado;
                res.ct_fecha = cita.ct_fecha;
                res.ct_hora = cita.ct_hora;
                res.ct_estatus = cita.ct_estatus;
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Edito la informacion de una cita con folio {cita.idcita}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Cambio el estado de la cita con folio {citaId} al estado {nuevoEstado}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener citas en progreso",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener citas satisfactorias",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener citas pendientes",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener citas canceladas",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }


        /**
         * 
         *  REPORTS
         * 
         * **/

        public async Task<List<citaModel>> obtenerCitasPorCliente(DateTime from, DateTime to, int clienteId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c =>
                                        c.ct_fecha >= @from &&
                                        c.ct_fecha <= @to
                                    )
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   where cita.ct_estatus != 0 && cliente.idcliente == clienteId
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener Todas las citas del cliente {query[0].NombreCliente}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
        public async Task<List<citaModel>> obtenerCitasPorEmpleado(DateTime from, DateTime to, int empleadoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from cita in db.citas.Where(c =>
                                        c.ct_fecha >= @from &&
                                        c.ct_fecha <= @to
                                    )
                                   join empleado in db.empleados on cita.ct_empleado equals empleado.idempleado
                                   join cliente in db.clientes on cita.ct_cliente equals cliente.idcliente
                                   where cita.ct_estatus != 0 && empleado.idempleado == empleadoId
                                   select new citaModel
                                   {
                                       Id = cita.idcita,
                                       Fecha = cita.ct_fecha,
                                       Hora = cita.ct_hora,
                                       NombreCliente = cliente.cl_nombrecompleto,
                                       NombreEmpleado = empleado.emp_nombrecompleto,
                                   }).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener Todas las citas del empleado {query[0].NombreEmpleado}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return query.OrderByDescending(o => o.Id).ToList();
            }
        }
    }
}
