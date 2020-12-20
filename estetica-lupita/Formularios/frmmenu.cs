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
            InitializeComponent();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
            this.Text = "Estetica lupita version 1.0 Usuario:" + Usuario.usuario_name + " Nivel: " + "Administrador";
        }

        private void btnauditorias_Click(object sender, EventArgs e)
        {
            frmaditorias cs = new frmaditorias();
            cs.Show();
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
            Formularios.frmRespaldo Cs = new Formularios.frmRespaldo();
            Cs.Show();
        }

        private void informeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmreporte Cs = new Formularios.frmreporte();
            Cs.Show();
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmPuntoventa Cs = new Formularios.frmPuntoventa();
            Cs.Show();
        }
    }
}
