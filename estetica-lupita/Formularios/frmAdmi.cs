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

namespace estetica_lupita.Formularios
{
    public partial class frmAdmi : Form
    {
        userController userCtrl = new userController();
        public bool existe { get; set; }
        public frmAdmi()
        {
            InitializeComponent();
        }
        private async void cargarUsuarios()
        {
            var usuarios = await userCtrl.obtenerTodos();
            dgvbase.DataSource = usuarios;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre de usuario";
            dgvbase.Columns[2].Visible = false;
        }
        private void frmAdmi_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

        private async void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtusuario.Text.Length < 4)
                {
                    MessageBox.Show("El nombre de usuario debe tener como minimo 4 caracteres.",
                                                                "Usuario invalido",
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
                    return;
                }
                var user = await userCtrl.verificarExistencia(txtusuario.Text.Trim());
                if (user != null)
                {
                  var r = MessageBox.Show("El nombre de usuario introducida ya se encuentra ocupado. desea editarlo?",
                                    "Usuario existente",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);
                    if(r == DialogResult.No) return;
                    existe = true;
                    doStuffTouserControls();
                }
                else
                {
                    existe = false;
                    doStuffTouserControls();
                }
            }
        }

        private void doStuffTouserControls()
        {
            txtpass1.Enabled = true;
            txtpass2.Enabled = true;
            txtusuario.Enabled = false;
            btnagregar.Enabled = true;
            txtpass1.Focus();
        }

        private  void frmAdmi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
               var r = MessageBox.Show("¿Reestablecer el formulario?",
                                        "Borrar formulario",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
                if(r == DialogResult.Yes)
                {
                    this.Refresh();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    cargarUsuarios();
                    txtusuario.Focus();
                }
            }
        }

        private async void btnagregar_Click(object sender, EventArgs e)
        {
            if( txtpass1.Text.Length < 5 || txtpass2.Text.Length < 5 )
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.",
                                 "Verifique los campos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                return;
            }
            if(txtpass1.Text.Trim() != txtpass2.Text.Trim())
            {
                MessageBox.Show("Las contraseñas no coinciden",
                                 "Verifique los campos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                return;
            }
            if(existe == true)
            {
                var rr = MessageBox.Show($"¿Actualizar el administrador {txtusuario.Text}  ?",
                 "Confirmar",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
                    if (rr == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        // Actualizar usuario & limpiar controles.
                       var result = await userCtrl.editarUsuario(new Modelos.EF.usuarios
                        {
                            usuario_name = txtusuario.Text.Trim().ToUpper(),
                            usuario_pass = clases.encriptacion.encriptar(txtpass1.Text.Trim())
                        });
                    if (result != null)
                    {
                        MessageBox.Show("Usuario actualizado con exito.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadForm();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error en el sistema, contacte con el administrador del sistema.", "Operacion sin exito", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        reloadForm();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
            }
            var r = MessageBox.Show($"¿Agregar el administrador {txtusuario.Text} al sistema ?",
                         "Confirmar",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                // Agregar usuario al sistema & limpiar controles.
                await userCtrl.crearNuevoUsuario(new Modelos.EF.usuarios
                {
                    usuario_name = txtusuario.Text.Trim().ToUpper(),
                    usuario_pass = clases.encriptacion.encriptar(txtpass1.Text.Trim())
                });
                reloadForm();
                this.Cursor = Cursors.Default;
            }

        }

        private void reloadForm()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            cargarUsuarios();
            txtusuario.Focus();
        }

        private void txtpass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtpass2.Focus();
            }
        }

        private void txtpass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnagregar.Focus();
            }
        }

        private async void dgvbase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string idUsuario = dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreUsuario = dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                var r = MessageBox.Show($"¿Eliminar el administrador {nombreUsuario} del sistema ?",
                                         "Confirmar",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                if( r == DialogResult.Yes)
                {
                    if(dgvbase.Rows.Count == 1)
                    {
                        MessageBox.Show("Solo hay un administrador, no se puede borrar el unico administrador en el sistema.",
                                         "Accion erronea",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    await userCtrl.eliminarUsuario( Convert.ToInt32( idUsuario ));
                    reloadForm();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tecla ESC:\nPresione esta tecla para reiniciar el estado del formulario.\n" +
                            "Tecla ENTER:\n La tecla enter puede ser usada en los 3 textboxes.");
        }
    }
}
