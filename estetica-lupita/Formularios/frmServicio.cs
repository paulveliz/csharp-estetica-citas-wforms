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

namespace estetica_lupita.Formularios
{
    public partial class frmServicio : Form
    {
        servicioController svCtrl = new servicioController();
        public frmServicio()
        {
            InitializeComponent();
        }

        private async void cargarServicios()
        {
            var servicios = await svCtrl.obtenerTodos();
            dgvbase.DataSource = servicios;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[3].Visible = false;
            dgvbase.Columns[4].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[1].HeaderText = "Descripcion del servicio";
            dgvbase.Columns[2].HeaderText = "Precio";
        }
        private void frmServicio_Load(object sender, EventArgs e)
        {
            cargarServicios();
        }

        private async void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if(txtdescripcion.Text.Length < 5)
                {
                    MessageBox.Show("La descripcion debe tener almenos 5 caracteres de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var verifyServicio = await svCtrl.verificarNombre(txtdescripcion.Text.Trim());
                if(verifyServicio != null)
                {
                    MessageBox.Show("El servicio que intenta agregar ya existe en el sistema.", "Servicio existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.txtdescripcion.Enabled = false;
                txtprecio.Enabled = true;
                btnagregar.Enabled = true;
                txtprecio.Focus();
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if(e.KeyChar == 13)
            {
                if (txtprecio.Text.Length < 3)
                {
                    MessageBox.Show("El precio debe tener almenos 3 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                btnagregar.Focus();
            }
        }

        private async void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtprecio.Text.Length < 3)
            {
                MessageBox.Show("El precio debe tener almenos 3 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var r = MessageBox.Show(
                    $"Desea agregar el servicio {txtdescripcion.Text.Trim()}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (r == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            var newSv = await svCtrl.crearNuevo(new servicios
            {
                sv_descripcion = txtdescripcion.Text.Trim(),
                sv_precio =  Convert.ToDecimal( txtprecio.Text.Trim() ),
                sv_estatus = 1
            });
            if(newSv != null)
            {
                MessageBox.Show($"El servicio {txtdescripcion.Text.Trim()} fue agregado con exito. ", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadForm();
            }
            else
            {
                MessageBox.Show("Ocurrio un error agregando el nuevo servicio comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.Cursor = Cursors.Default;

        }

        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idServicio = dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreServicio = dgvbase.SelectedRows[0].Cells[1].Value.ToString();

                var r = MessageBox.Show(
                        $"Desea dar de baja el servicio {nombreServicio}?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                if (r == DialogResult.No) return;
                var deletedSv = await svCtrl.darDeBaja(Convert.ToInt32(idServicio));
                reloadForm();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void reloadForm()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            this.txtdescripcion.Focus();
            cargarServicios();
        }

        private void frmServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                var r = MessageBox.Show(
                    $"Desea borrar el formulario?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (r == DialogResult.No) return;
                reloadForm();
            }
        }
    }
}
