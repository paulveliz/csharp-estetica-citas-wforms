using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class auditController
    {
        public async Task<auditorias> auditar(auditorias auditoria)
        {
            using(var db = new estetica_lupitaEntities())
            {
                db.auditorias.Add(auditoria);
                await db.SaveChangesAsync();
                return auditoria;
            }
        }

        public async Task<bool> depurar()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var allAudits = await (from c in db.auditorias select c).ToListAsync();
                db.auditorias.RemoveRange(allAudits);
                var rows = await db.SaveChangesAsync();
                return rows > 0;
            }
        }

        public async Task<List<auditorias>> obtenerAuditoriasPorFecha(DateTime fromt, DateTime to)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var auditorias = await db.auditorias.Where(c =>
                   c.fecha >= fromt &&
                   c.fecha <= to
                ).ToListAsync();
                return auditorias;
            }
        }

        public async Task<List<auditorias>> obtenerAuditoriasPorUsuario(string nombreUsuario, DateTime fromt, DateTime to)
        {
            using (var db =  new estetica_lupitaEntities())
            {
                var auditorias = await db.auditorias.Where(u =>
                   u.usuario == nombreUsuario &&
                   u.fecha >= fromt &&
                   u.fecha <= to
                ).ToListAsync();
                return auditorias;
            }
        }
    }
}
