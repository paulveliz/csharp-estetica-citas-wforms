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
using Controladores;
using Modelos.EF;

namespace estetica_lupita
{
    public partial class frmacceso : Form
    {
        public frmacceso()
        {
            InitializeComponent();
        }

        private async void btnacceder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.btnacceder.Enabled = false;
            try
            {
                var userController = new userController();
                var user = await userController.valdiarLogin(new usuarios
                {
                    idusuario = 0,
                    usuario_name = txtusuario.Text.Trim(),
                    usuario_pass = clases.encriptacion.encriptar(txtpassword.Text.Trim())
                });
                if (user != null)
                {
                    frmmenu menu = new frmmenu(user);
                    this.Hide();
                    menu.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
            this.btnacceder.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
