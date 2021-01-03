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
        auditController auditCtrl = new auditController();

        public async Task<usuarios> obtenerPorId(int usuarioId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var user = await db.usuarios.FirstAsync(u => u.idusuario == usuarioId);
                return user;
            }
        }
        public async Task<usuarios> valdiarLogin(usuarios usuario)
        {
            using(var db = new estetica_lupitaEntities())
            {
                var user = await db.usuarios.FirstAsync(u =>
                    u.usuario_name == usuario.usuario_name &&
                    u.usuario_pass == usuario.usuario_pass
                );

                if (user != null)
                {
                    await auditCtrl.auditar(new auditorias
                    {
                        descripcion = $"Accedio al sistema {usuario.usuario_name}",
                        fecha = DateTime.Now,
                        hora = DateTime.Now.TimeOfDay,
                        usuario = usuario.usuario_name
                    });
                }
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
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Se creo un nuevo usuario {usuario.usuario_name}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Actualizo al usuario {usuario.usuario_name}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
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
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Elimino al usuario con id {usuarioId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return user;
            }
        }

        public async Task<List<usuarios>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var usuarios = await db.usuarios.Take(100).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener todos los usuarios",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return usuarios.OrderByDescending(o => o.idusuario).ToList();
            }
        }
    }
}
