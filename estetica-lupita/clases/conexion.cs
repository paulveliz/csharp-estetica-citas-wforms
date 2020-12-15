using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estetica_lupita.clases
{
    class conexion
    {
        public static MySqlConnection conectar()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Server=127.0.0.1;Database=estetica-lupita; Uid=local;Pwd=1234;";
            cn.Open();
            return cn;
        }
    }
}
