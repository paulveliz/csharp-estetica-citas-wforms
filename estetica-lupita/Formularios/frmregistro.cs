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
    public partial class frmregistro : Form
    {
        public frmregistro()
        {
            InitializeComponent();
        }
        private Boolean registrarUsuario(string username, string password)
        {
            string query = "INSERT INTO usuarios(usuario_name, usuario_pass) VALUES (@username, @password)";
            MySqlCommand cmd = new MySqlCommand(query, clases.conexion.conectar());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            else { return false; }
        }

        private void encryptAndRegister()
        {
            string passwordEncrypted = clases.encriptacion.encriptar(txtpassword.Text);
            if (registrarUsuario(txtusuario.Text, passwordEncrypted))
            {
                MessageBox.Show("Usuario creado");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encryptAndRegister();
        }
    }
}
