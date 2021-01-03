using Controladores;
using estetica_lupita.Formularios.sub;
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

namespace estetica_lupita
{
    public partial class frmmenu : Form
    {
        usuarios Usuario { get; set; }
        public frmmenu(usuarios usuario)
        {
            Usuario = usuario;
            Controladores.global.LoggedUser = usuario;
            InitializeComponent();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
            this.Text = "Estetica lupita version 1.0 Usuario:" + Usuario.usuario_name + " Nivel: " + "Administrador";
        }

        private void btnauditorias_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmClientes Cs = new Formularios.frmClientes();
            Cs.Show();
        }

        private void administradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmAdmi Cs = new Formularios.frmAdmi();
            Cs.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmCitas Cs = new Formularios.frmCitas();
            Cs.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmPuesto Cs = new Formularios.frmPuesto();
            Cs.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmEmpleado Cs = new Formularios.frmEmpleado();
            Cs.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmServicio Cs = new Formularios.frmServicio();
            Cs.Show();
        }

        private void respaldoDeSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void informeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmPuntoventa Cs = new Formularios.frmPuntoventa();
            Cs.Show();
        }

        private async void respaldarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Desea depurar las auditorias?", "Depurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            auditController auCtrl = new auditController();
            await auCtrl.depurar();
            this.Cursor = Cursors.Default;
            MessageBox.Show("Auditorias depuradas con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.sub.frmgenerarreporte Cs = new Formularios.sub.frmgenerarreporte();
            Cs.Show();
        }

        private void gestionarCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmCitas Cs = new Formularios.frmCitas();
            Cs.Show();
        }

        private void reporteDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.sub.frmgenerarreportecitas Cs = new Formularios.sub.frmgenerarreportecitas();
            Cs.Show();
        }

        private void reporteGeneralDeAuditoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var genR = new frmgenerarreporteauditoria();
            genR.Show();
        }

        private void reportePorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.sub.frmgenerarreporteauditoriausuario Cs = new frmgenerarreporteauditoriausuario();
            Cs.ShowDialog();
        }
    }
}
