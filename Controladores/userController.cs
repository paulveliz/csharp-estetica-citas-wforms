using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class userController
    {
        public async Task<usuarios> valdiarLogin(usuarios usuario)
        {
            using(var db = new estetica_lupitaEntities())
            {
                var user = await db.usuarios.FirstAsync(u =>
                    u.usuario_name == usuario.usuario_name &&
                    u.usuario_pass == usuario.usuario_pass
                );
                return user != null ? user : null;
            }
        }

        public async Task<usuarios> verificarExistencia(String nombreUsuario)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var user = await db.usuarios.FirstOrDefaultAsync(u =>
                    u.usuario_name == nombreUsuario
                );
                return user != null ? user : null;
            }
        }

        public async Task<usuarios> crearNuevoUsuario(usuarios usuario)
        {
            using(var db = new estetica_lupitaEntities())
            {
                var newUser = db.usuarios.Add(usuario);
                await db.SaveChangesAsync();
                return newUser;
            }
        }

        public async Task<usuarios> editarUsuario(usuarios usuario)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var newUser = await db.usuarios.FindAsync(usuario.idusuario);
                newUser.usuario_name = usuario.usuario_name;
                newUser.usuario_pass = usuario.usuario_pass;
                await db.SaveChangesAsync();
                return newUser;
            }
        }

        public async Task<usuarios> eliminarUsuario(int usuarioId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var usuario = await db.usuarios.FirstOrDefaultAsync(f => f.idusuario == usuarioId);
                var user = db.usuarios.Remove(usuario);
                await db.SaveChangesAsync();
                return user;
            }
        }

        public async Task<List<usuarios>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var usuarios = await db.usuarios.Take(100).ToListAsync();
                return usuarios.OrderByDescending(o => o.idusuario).ToList();
            }
        }
    }
}
