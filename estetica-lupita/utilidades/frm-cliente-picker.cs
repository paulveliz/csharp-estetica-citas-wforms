using Controladores;
using Modelos.EF;
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
    public partial class frm_cliente_picker : Form
    {
        clienteController clCtrl = new clienteController();
        public clientes Cliente { get; set; }
        public frm_cliente_picker()
        {
            InitializeComponent();
        }

        private async void cargarClientes()
        {
            var clientes = await clCtrl.obtenerTodos();
            this.dgvbase.DataSource = clientes;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[4].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[6].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre del cliente";
            dgvbase.Columns[2].HeaderText = "Telefono";
            dgvbase.Columns[3].HeaderText = "Genero";
        }
        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idCliente = this.dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreCliente = this.dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                var r = MessageBox.Show($"Seleccionar {nombreCliente} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                this.Cliente = await clCtrl.obtenerPorId(Convert.ToInt32(idCliente));
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void frm_cliente_picker_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private async void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var clientes = await clCtrl.getclienteByNameMatching(txtcliente.Text);
            this.dgvbase.DataSource = clientes;
            dgvbase.Columns[0].Visible = false;
            dgvbase.Columns[4].Visible = false;
            dgvbase.Columns[5].Visible = false;
            dgvbase.Columns[6].Visible = false;
            dgvbase.Columns[1].HeaderText = "Nombre del cliente";
            dgvbase.Columns[2].HeaderText = "Telefono";
            dgvbase.Columns[3].HeaderText = "Genero";

            this.Cursor = Cursors.Default;

        }
    }
}
