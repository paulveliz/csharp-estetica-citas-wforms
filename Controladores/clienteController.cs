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
                return client;
            }
        }
    }
}
