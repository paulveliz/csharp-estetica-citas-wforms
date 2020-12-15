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
    public partial class frmacceso : Form
    {
        public frmacceso()
        {
            InitializeComponent();
        }
        private Boolean userVerify(string usuario, string pass)
        {
            string query = "SELECT idusuario FROM usuarios WHERE usuario_name = @usuario AND usuario_pass = @password";
            MySqlCommand cmd = new MySqlCommand(query, clases.conexion.conectar());
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@password", clases.encriptacion.encriptar(pass));
            int exists = Convert.ToInt32(cmd.ExecuteScalar());
            if (exists > 0)
            {
                clases.auditar.audi(
                    "Entro al sistema",
                    DateTime.Now.ToString("dd/MM/yyyy"),
                    DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                    exists
                    );
                return true;
            }
            else 
            { 
                return false; 
            }

        }

        private void btnacceder_Click(object sender, EventArgs e)
        {  //userVerify(txtusuario.Text, txtpassword.Text))
            if (true)
            {
                frmmenu menu = new frmmenu(txtusuario.Text, "administrador");
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
