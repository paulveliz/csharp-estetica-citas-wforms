using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladores;
using Modelos.EF;

namespace estetica_lupita.Formularios
{
    public partial class frmEmpleado : Form
    {
        empleadoController empCtrl = new empleadoController();
        puestoController pstCtrl = new puestoController();
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private async void cargarEmpleados()
        {
            var empleados = await empCtrl.obtenerTodos();
            dgvbase.DataSource = empleados;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre completo";
        }
        private async void cargarPuestos()
        {
            var puestos = await pstCtrl.obtenerTodos();
            cboxpuestos.DataSource = puestos;
            cboxpuestos.DisplayMember = "pst_descripcion";
            cboxpuestos.ValueMember = "idpuesto";
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
            cargarPuestos();
        }

        private async void txtnombrecompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (txtnombrecompleto.Text.Length < 5)
                {
                    MessageBox.Show("El nombre debe tener al menos 5 caracteres de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                    return;
                }

                var verifyEmp = await empCtrl.verificarNombre(txtnombrecompleto.Text.Trim());
                if (verifyEmp != null)
                {
                    MessageBox.Show("Ya existe un empleado con el nombre introducido.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                    return;
                }

                txtnombrecompleto.Enabled = false;
                setControls(true);
                txttelefono.Focus();
            }
        }

        private void setControls(bool t)
        {
            txttelefono.Enabled = t;
            txtsueldo.Enabled = t;
            cboxpuestos.Enabled = t;
            btnagregar.Enabled = t;
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if(e.KeyChar == 13)
            {
                if (txttelefono.Text.Length < 10)
                {
                    MessageBox.Show("El telefono debe tener almenos 10 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                    return;
                }

                txtsueldo.Focus();
            }
        }

        private void txtsueldo_KeyPress(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == 13)
            {
                if (txtsueldo.Text.Length < 3)
                {
                    MessageBox.Show("El sueldo debe tener almenos 3 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                btnagregar.Focus();

            }
        }
        private void reloadForm()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            txtnombrecompleto.Focus();
        }
        private async void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtsueldo.Text.Length < 3)
            {
                MessageBox.Show("El sueldo debe tener almenos 3 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txttelefono.Text.Length < 10)
            {
                MessageBox.Show("El telefono debe tener almenos 10 digitos de longitud.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var r = MessageBox.Show($"¿Agregar nuevo empelado {txtnombrecompleto.Text.Trim()}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                var newEmp = await empCtrl.crearNuevo(new empleados
                {
                    emp_estatus = 1,
                    emp_nombrecompleto = txtnombrecompleto.Text.Trim(),
                    emp_puesto = (short)cboxpuestos.SelectedValue,
                    emp_telefono = txttelefono.Text.Trim(),
                    emp_sueldo =  Convert.ToDecimal( txtsueldo.Text.Trim() )
                });
                if (newEmp != null)
                {
                    MessageBox.Show("El empelado fue agregado con exito!", "Operacion exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarEmpleados();
                    cargarPuestos();
                    reloadForm();
                    txtnombrecompleto.Focus();
                }
            }
        }

        private async void dgvbase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string idEmpleado = dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreEmpleado = dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                var r = MessageBox.Show($"¿Dar de baja empleado {nombreEmpleado}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                this.Cursor = Cursors.WaitCursor;
                await empCtrl.darDeBaja( Convert.ToInt32( idEmpleado ) );
                cargarEmpleados();
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
