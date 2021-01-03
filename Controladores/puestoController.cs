using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class puestoController
    {
        auditController auditCtrl = new auditController();
        public async Task<puestos> obtenerPorId(int puestoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var puesto = await db.puestos.FindAsync(puestoId);
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener puesto por su id {puestoId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return puesto;
            }
        }
        public async Task<puestos> verificarNombre(String puestoNombre)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var puesto = await db.puestos.FirstOrDefaultAsync(f => 
                    f.pst_descripcion == puestoNombre &&
                    f.pst_estatus != 0
                );
                return puesto;
            }
        }
        public async Task<List<puestos>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var puestos = await db.puestos.Take(100).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener todos los puestos de trabajo.",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return puestos
                        .OrderByDescending(o => o.idpuesto)
                        .ToList()
                        .Where(p => p.pst_estatus != 0)
                        .ToList();
            }
        }
        public async Task<puestos> crearNuevo(puestos puesto)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = db.puestos.Add(puesto);
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Creo el puesto {puesto.pst_descripcion}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return response;
            }
        }
        public async Task<puestos> actualizar(puestos puesto)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = await db.puestos.FindAsync(puesto.idpuesto);
                response.pst_descripcion = puesto.pst_descripcion;
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Actualizo el puesto {puesto.pst_descripcion}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return response;
            }
        }
        public async Task<puestos> darDeBaja(int puestoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var puesto = await db.puestos.FindAsync(puestoId);
                puesto.pst_estatus = 0;
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Dio de baja el puesto {puestoId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return puesto;
            }
        }
    }
}
