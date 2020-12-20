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
using Modelos.EF;

namespace estetica_lupita.Formularios
{
    public partial class frmPuntoventa : Form
    {
        citaController ctCtrl = new citaController();
        ventaController vtCtrl = new ventaController();
        public citaModel Cita { get; set; }
        public citas CitaBase { get; set; }
        public servicios Servicio { get; set; }
        public frmPuntoventa()
        {
            InitializeComponent();
        }
        private async void calcularImporte()
        {
            var citaOriginal = await ctCtrl.obtenerCitaPorIdOriginal(this.Cita.Id);
            this.CitaBase = citaOriginal;
            var svCtrl = new servicioController();
            var servicio = await svCtrl.obtenerPorId( citaOriginal.ct_servicio );
            this.Servicio = servicio;
            this.txtimporte.Text = (servicio.sv_precio * Convert.ToInt32(Cita.CantidadServicios)).ToString();
        }
        private async void btncapturar_Click(object sender, EventArgs e)
        {
            await capturarCita();
        }

        private async Task capturarCita()
        {
            List<citaModel> lst = new List<citaModel>();
            int citaId = Convert.ToInt32(txtcita.Text);
            var cita = await ctCtrl.obtenerCitaPorId(citaId);
            if (cita != null)
            {
                this.Cita = cita;
                lst.Add(cita);
                this.dgvbase.DataSource = lst;
                dgvbase.Columns[0].Visible = true;
                dgvbase.Columns[0].Width = 40;
                dgvbase.Columns[0].HeaderText = "Folio";
                dgvbase.Columns[1].Visible = false;
                dgvbase.Columns[2].HeaderText = "Cliente";
                dgvbase.Columns[3].HeaderText = "Servicio";
                dgvbase.Columns[4].HeaderText = "Cantidad";
                dgvbase.Columns[4].Width = 50;
                dgvbase.Columns[5].Visible = false;
                dgvbase.Columns[6].Visible = false;
                calcularImporte();
            }
            else
            {
                MessageBox.Show(
                    "La cita introducida no puede ser encontrada, verifique que esta no este completada, ni cancelada.",
                    "Cita no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private async void frmPuntoventa_Load(object sender, EventArgs e)
        {
            var ventas = await vtCtrl.obtenerTodas();
            if(ventas.Count == 0)
            {
                txtfolio.Text = "1";
                return;
            }
            txtfolio.Text = (ventas.Max(v => v.NotaVenta.Id) + 1).ToString();
        }

        private async void frmPuntoventa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                txtcita.Focus();
            }

            if(e.KeyCode == Keys.F2)
            {
                await capturarCita();
            }

            if(e.KeyCode == Keys.F3)
            {
                await crearVenta();
            }

            if(e.KeyCode == Keys.Escape)
            {
                var r = MessageBox.Show($"Reiniciar formulario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
                if (r == DialogResult.No) return;
                reiniciarFormulario();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await crearVenta();
        }

        private async Task crearVenta()
        {
            var venta = await vtCtrl.crearNueva(new notaventa
            {
                nv_cita = this.Cita.Id,
                nv_cliente = this.CitaBase.ct_cliente,
                nv_empleado = this.CitaBase.ct_empleado,
                nv_estatus = 1,
                nv_total = Convert.ToDecimal(txtimporte.Text)
            },
            new notaventa_detalle
            {
                nvd_cantidad = this.CitaBase.ct_cantservicios,
                nvd_precio = this.Servicio.sv_precio,
                nvd_servicio = this.Servicio.idservicio,
                nvd_estatus = 1
            });

            if (venta != null)
            {
                var r = MessageBox.Show($"La venta se realizo exitosamente, desea imprimir el ticket?",
                                "Confirmar",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                                );
                if (r == DialogResult.No) return;
                reiniciarFormulario();
                // TODO: IMPRIMIR TICKET.
            }
        }

        private void reiniciarFormulario()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            this.Cita = new citaModel();
            CitaBase = new citas();
            Servicio = new servicios();
            txtcita.Focus();
        }
    }
}
