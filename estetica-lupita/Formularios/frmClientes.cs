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
    public partial class frmClientes : Form
    {
        clienteController clienteCtrl = new clienteController();
        public bool existe { get; set; }
        public char Genero { get; set; }
        public frmClientes()
        {
            InitializeComponent();
        }
        private void cargarGeneros()
        {
            cboxgenero.Items.Add("Hombre");
            cboxgenero.Items.Add("Mujer");
            cboxgenero.SelectedIndex = 0;
            Genero = 'h';
        }
        private async void cargarClientes()
        {
            var clientes = await clienteCtrl.obtenerTodos();
            this.dgvbase.DataSource = clientes;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[4].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[6].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre del cliente";
            dgvbase.Columns[2].HeaderText = "Telefono";
            dgvbase.Columns[3].HeaderText = "Genero";
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarGeneros();
            cargarClientes();
        }

        private void cboxgenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboxgenero.SelectedIndex == 0)
            {
                Genero = 'h';
            }

            if(cboxgenero.SelectedIndex == 1)
            {
                Genero = 'm';
            }
        }

        private async void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if(txtnombre.Text.Length < 5)
                {
                    MessageBox.Show("Nombre demasiado corto, debe tener al menos 5 caracteres de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var user = await clienteCtrl.verificarNombre(txtnombre.Text.Trim());
                if( user != null)
                {
                    var r = MessageBox.Show($"Ya existe un cliente con ese nombre en el sistema ¿Desea actualizar los datos del cliente {txtnombre.Text.Trim()}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.No) return;
                    existe = true;
                    txtnombre.Enabled = false;
                    txttelefono.Enabled = true;
                    txttelefono.Focus();
                    return;
                }
                existe = false;
                txtnombre.Enabled = false;
                txttelefono.Enabled = true;
                txttelefono.Focus();
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txttelefono.Text.Length < 10)
                {
                    MessageBox.Show("Telefono demasiado corto, debe tener al menos 10 digitos.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                cboxgenero.Enabled = true;
                cboxgenero.Focus();
                btnagregar.Enabled = true;
            }
        }
        private void reloadForm()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            cargarClientes();
            cargarGeneros();
            this.Genero = 'h';
            txtnombre.Focus();
        }
        private async void btnagregar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txttelefono.Text.Length < 10)
            {
                MessageBox.Show("Telefono demasiado corto, debe tener al menos 10 digitos.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(existe == true)
            {
                var rr = MessageBox.Show($"¿Desea actualizar los datos del cliente {txtnombre.Text.Trim()}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rr == DialogResult.No) return;
                var clienteActualizado = await clienteCtrl.editar(new clientes
                {
                    cl_estatus = 1,
                    cl_nombrecompleto = txtnombre.Text.Trim(),
                    cl_telefono = txttelefono.Text.Trim(),
                    cl_sexo = Genero.ToString()
                });
                if (clienteActualizado != null)
                {
                    MessageBox.Show("Cliente actualizado con exito.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error agregando el cliente en el sistema, contacte con el administrador del sistema.", "Operacion sin exito", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            var r = MessageBox.Show($"¿Desea agregar el nuevo cliente {txtnombre.Text.Trim()}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;
            var nuevocliente = await clienteCtrl.crearNuevo(new clientes {
                cl_estatus = 1,
                cl_nombrecompleto = txtnombre.Text.Trim(),
                cl_telefono = txttelefono.Text.Trim(),
                cl_sexo = Genero.ToString()
            });
            if( nuevocliente != null)
            {
                MessageBox.Show("Cliente agregado al sistema con exito.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un error agregando el cliente en el sistema, contacte con el administrador del sistema.", "Operacion sin exito", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.Cursor = Cursors.Default;
            reloadForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tecla ESC:\nPresione esta tecla para reiniciar el estado del formulario.\n" +
                "Tecla ENTER:\n La tecla enter puede ser usada en los 3 textboxes.");
        }

        private async void dgvbase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string clienteNombre = dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                string clienteId = dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                var r = MessageBox.Show($"¿Desea dar de baja al cliente {clienteNombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                await clienteCtrl.darDeBaja( Convert.ToInt32( clienteId ));
                reloadForm();
            }
            catch (Exception)
            {
                return;
            }


        }

        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var r = MessageBox.Show("¿Reestablecer el formulario?",
                                         "Borrar formulario",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    reloadForm();
                }
            }
        }
    }
}
