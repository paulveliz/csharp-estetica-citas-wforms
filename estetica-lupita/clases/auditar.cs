using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estetica_lupita.clases
{
    class auditar
    {
        public static void audi(string descripcion, string fecha, string hora, int usuario)
        {
            string query = "INSERT INTO auditorias(descripcion, fecha, hora, usuario) VALUES (@descripcion, @fecha, @hora, @usuario)";
            MySqlCommand cmd = new MySqlCommand(query, clases.conexion.conectar());
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@hora", hora);
            cmd.ExecuteNonQuery();
        }
    }
}

