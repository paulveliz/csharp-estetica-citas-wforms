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
    public partial class frm_usuario_picker : Form
    {
        userController usrCtrl = new userController();
        public usuarios Usuario { get; set; }
        public frm_usuario_picker()
        {
            InitializeComponent();
        }

        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idEmpleado = this.dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string nombreEmpleado = this.dgvbase.SelectedRows[0].Cells[1].Value.ToString();
                var r = MessageBox.Show($"Seleccionar {nombreEmpleado} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                this.Usuario = await usrCtrl.obtenerPorId(Convert.ToInt32(idEmpleado));
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                return;
            }
        }

        private async void frm_usuario_picker_Load(object sender, EventArgs e)
        {
            this.dgvbase.DataSource = await usrCtrl.obtenerTodos();
            this.dgvbase.Columns[0].Visible = false;
            this.dgvbase.Columns[2].Visible = false;
            this.dgvbase.Columns[1].HeaderText = "Nombre de usuario";
        }
    }
}
