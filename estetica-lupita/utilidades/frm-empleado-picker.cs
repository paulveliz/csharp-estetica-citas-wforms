using Controladores;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estetica_lupita.utilidades
{
    public partial class frm_empleado_picker : Form
    {
        empleadoController emCtrl = new empleadoController();
        public empleadoModel Empleado { get; set; }
        public frm_empleado_picker()
        {
            InitializeComponent();
        }

        private async void cargarEmpleados()
        {
            var empleados = await emCtrl.obtenerTodos();
            this.dgvbase.DataSource = empleados;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre completo";
        }
        private void frm_empleado_picker_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
        }

        private async void txtempleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var empleados = await emCtrl.getempleadoByNameMatching(txtempleado.Text);
            this.dgvbase.DataSource = empleados;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre completo";

            this.Cursor = Cursors.Default;
        }

        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idEmpleado = this.dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreEmpleado = this.dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                var r = MessageBox.Show($"Seleccionar {nombreEmpleado} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                this.Empleado = await emCtrl.obtenerPorId(Convert.ToInt32(idEmpleado));
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
