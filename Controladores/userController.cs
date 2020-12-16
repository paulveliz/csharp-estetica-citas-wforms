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
                var user = await db.usuarios.Where(u =>
                    u.usuario_pass == usuario.usuario_pass &&
                    u.usuario_name == usuario.usuario_name
                ).ToListAsync();

                return user[0];
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

        public async Task<usuarios> eliminarUsuario(usuarios usuario)
        {
            using (var db = new estetica_lupitaEntities())
            {
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
