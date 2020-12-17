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

        public async Task<puestos> obtenerPorId(int puestoId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var puesto = await db.puestos.FindAsync(puestoId);
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
                return response;
            }
        }
        public async Task<puestos> actualizar(puestos puesto)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = await db.puestos.FindAsync(puesto.idpuesto);
                response.pst_descripcion = puesto.pst_descripcion;
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
                return puesto;
            }
        }
    }
}
