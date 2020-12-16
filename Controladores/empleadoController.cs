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
    public class empleadoController
    {
        public async Task<empleadoModel> obtenerPorId(int empleadoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var query = await (from empleado in db.empleados.Where(c => c.idempleado == empleadoId)
                                   join puesto in db.puestos on empleado.emp_puesto equals puesto.idpuesto
                                   select new empleadoModel
                                   {
                                       Id = empleado.idempleado,
                                       NombreCompleto = empleado.emp_nombrecompleto,
                                       Puesto = puesto.pst_descripcion,
                                       Sueldo = empleado.emp_sueldo,
                                       Telefono = empleado.emp_telefono,
                                       Estatus = empleado.emp_estatus
                                   }).ToListAsync();
                return query[0];
            }
        }
        public async Task<List<empleadoModel>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var empleados = await (from empleado in db.empleados.Take(100)
                                   join puesto in db.puestos on empleado.emp_puesto equals puesto.idpuesto
                                   select new empleadoModel
                                   {
                                       Id = empleado.idempleado,
                                       NombreCompleto = empleado.emp_nombrecompleto,
                                       Puesto = puesto.pst_descripcion,
                                       Sueldo = empleado.emp_sueldo,
                                       Telefono = empleado.emp_telefono,
                                       Estatus = empleado.emp_estatus
                                   }).ToListAsync();
                return empleados.OrderByDescending(o => o.Id).ToList();
            }
        }

        public async Task<empleados> crearNuevo(empleados empleado)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var res = db.empleados.Add(empleado);
                await db.SaveChangesAsync();
                return res;
            }
        }

        public async Task<empleados> actualizar(empleados empleado)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var res = await db.empleados.FindAsync(empleado.idempleado);
                res.emp_nombrecompleto = empleado.emp_nombrecompleto;
                res.emp_puesto = empleado.emp_puesto;
                res.emp_sueldo = empleado.emp_sueldo;
                res.emp_telefono = empleado.emp_telefono;
                await db.SaveChangesAsync();
                return res;
            }
        }

        public async Task<empleados> darDeBaja(int empleadoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var empleado = await db.empleados.FindAsync(empleadoId);
                empleado.emp_estatus = 0;
                await db.SaveChangesAsync();
                return empleado;
            }
        }
    }
}
