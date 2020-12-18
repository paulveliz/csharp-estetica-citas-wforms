using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class servicioController
    {

        public async Task<servicios> obtenerPorId(int servicioId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var servicio = await db.servicios.FindAsync(servicioId);
                return servicio;
            }
        }
        public async Task<servicios> verificarNombre(string servicioNombre)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var servicio = await db.servicios.FirstOrDefaultAsync(f => 
                    f.sv_descripcion == servicioNombre &&
                    f.sv_estatus != 0
                );
                return servicio;
            }
        }
        public async Task<List<servicios>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var servicios = await db.servicios.Take(100).ToListAsync();
                return servicios.OrderByDescending(o => o.idservicio)
                                .ToList()
                                .Where(s => s.sv_estatus != 0)
                                .ToList();
            }
        }
        public async Task<servicios> crearNuevo(servicios servicio)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = db.servicios.Add(servicio);
                await db.SaveChangesAsync();
                return response;
            }
        }
        public async Task<servicios> actualizar(servicios servicio)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = await db.servicios.FindAsync(servicio.idservicio);
                response.sv_descripcion = servicio.sv_descripcion;
                response.sv_precio = servicio.sv_precio;
                await db.SaveChangesAsync();
                return response;
            }
        }
        public async Task<servicios> darDeBaja(int servicioId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = await db.servicios.FindAsync(servicioId);
                response.sv_estatus = 0;
                await db.SaveChangesAsync();
                return response;
            }
        }
    }
}
