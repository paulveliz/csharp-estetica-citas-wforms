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
    public partial class frmPuesto : Form
    {
        puestoController puestoCtrl = new puestoController();
        public frmPuesto()
        {
            InitializeComponent();
        }
        private async void cargarPuestos()
        {
            var puestos = await puestoCtrl.obtenerTodos();
            this.dgvbase.DataSource = puestos;
            this.dgvbase.Columns[0].Visible = false;
            this.dgvbase.Columns[2].Visible = false;
            this.dgvbase.Columns[3].Visible = false;
            this.dgvbase.Columns[1].HeaderText = "Descripcion del puesto";
        }
        private void frmPuesto_Load(object sender, EventArgs e)
        {
            cargarPuestos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tecla ESC:\nPresione esta tecla para reiniciar el estado del formulario.\n" +
                            "Tecla ENTER:\n La tecla enter puede ser usada en los 3 textboxes.");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if(txtpuesto.Text.Length < 5)
            {
                MessageBox.Show("Descripcion del puesto demasiado corta, debe tener al menos 5 caracteres.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
                return;
            }
            var r = MessageBox.Show($"¿Desea agregar el nuevo puesto {txtpuesto.Text.Trim()}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Cursor = Cursors.Default;
            if (r == DialogResult.No) return;
            var verificarPuesto = await puestoCtrl.verificarNombre(txtpuesto.Text.Trim());
            if( verificarPuesto != null)
            {
                MessageBox.Show("El nombre de puesto ya esta ocupado y existe en el sistema.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
                return;
            }

            var nuevoPuesto = await puestoCtrl.crearNuevo(new puestos { 
                pst_descripcion = txtpuesto.Text.Trim(),
                pst_estatus = 1
            });
            if (nuevoPuesto != null)
            {
                MessageBox.Show("El puesto fue agregado con exito al sistema.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarPuestos();
                txtpuesto.Clear();
                txtpuesto.Focus();
            }
            else
            {
                MessageBox.Show("Ocurrio un error intentando insertar el puesto en el sistema pongase en contacto con el administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.Cursor = Cursors.Default;
        }

        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nombrePuesto = dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                string idPuesto = dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                var r = MessageBox.Show($"¿Desea dar de baja el puesto {nombrePuesto}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                this.Cursor = Cursors.WaitCursor;

                await puestoCtrl.darDeBaja( Convert.ToInt32( idPuesto ) );
                cargarPuestos();
                txtpuesto.Clear();
                txtpuesto.Focus();
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void txtpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                button1.Focus();
            }
        }
    }
}
