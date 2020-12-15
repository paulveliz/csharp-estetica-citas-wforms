using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estetica_lupita
{
    public partial class frmeliminarusuario : Form
    {
        public frmeliminarusuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM usuarios WHERE usuario_name = @name";
            MySqlCommand cmd = new MySqlCommand(query, clases.conexion.conectar());
            cmd.Parameters.AddWithValue("@name", txtusuario.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuario eliminado con exito");
            this.Close();
        }
    }
}
