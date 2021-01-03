using Modelos.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class clienteController
    {
        auditController auditCtrl = new auditController();

        public async Task<List<clientes>> getclienteByNameMatching(String text)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var empleados = await db.clientes.Where(d => d.cl_nombrecompleto.Contains(text)).ToListAsync();
                return empleados
                        .OrderByDescending(o => o.idcliente)
                        .ToList()
                        .Where(f => f.cl_estatus != 0)
                        .ToList();
            }
        }

        public async Task<clientes> obtenerPorId(int clienteId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var cliente = await db.clientes.FirstOrDefaultAsync(c => c.idcliente == clienteId);
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener cliente por su id {clienteId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return cliente;
            }
        }
        public async Task<clientes> verificarNombre(String clienteNombre)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var cliente = await db.clientes.FirstOrDefaultAsync(c => c.cl_nombrecompleto == clienteNombre);
                return cliente;
            }
        }

        public async Task<List<clientes>> obtenerTodos()
        {
            using (var db = new estetica_lupitaEntities())
            {
                var clientes = await db.clientes.Take(100).ToListAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Obtener todos los clientes existentes.",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return clientes
                        .OrderByDescending(o => o.idcliente)
                        .ToList()
                        .Where(c => c.cl_estatus != 0)
                        .ToList();
            }
        }

        public async Task<clientes> crearNuevo(clientes cliente)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var response = db.clientes.Add(cliente);
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Creo al cliente llamado {cliente.cl_nombrecompleto}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return response;
            }
        }

        public async Task<clientes> editar(clientes cliente)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var client = await db.clientes.FindAsync(cliente.idcliente);
                client.cl_sexo = cliente.cl_sexo;
                client.cl_nombrecompleto = cliente.cl_nombrecompleto;
                client.cl_telefono = cliente.cl_telefono;
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Edito al cliente {cliente.cl_nombrecompleto}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return client;
            }
        }
        public async Task<clientes> darDeBaja(int clienteId)
        {
            using (var db = new estetica_lupitaEntities())
            {
                var client = await db.clientes.FindAsync(clienteId);
                client.cl_estatus = 0;
                await db.SaveChangesAsync();
                await auditCtrl.auditar(new auditorias
                {
                    descripcion = $"Dio de baja al cliente con id {clienteId}",
                    fecha = DateTime.Now,
                    hora = DateTime.Now.TimeOfDay,
                    usuario = global.LoggedUser.usuario_name
                });
                return client;
            }
        }
    }
}
