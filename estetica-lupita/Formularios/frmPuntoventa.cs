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
using estetica_lupita.Reportes.Tickets;

namespace estetica_lupita.Formularios
{
    public partial class frmPuntoventa : Form
    {
        citaController ctCtrl = new citaController();
        ventaController vtCtrl = new ventaController();
        public citaModel Cita { get; set; }
        public citas CitaBase { get; set; }
        public servicios Servicio { get; set; }
        public List<citaDetalleModel> CitaDetalle { get; set; }
        public frmPuntoventa()
        {
            InitializeComponent();
        }
        private async void calcularImporte()
        {
            this.CitaBase = await ctCtrl.obtenerCitaPorIdOriginal(this.Cita.Id);
            var svCtrl = new servicioController();
            var servicio = await svCtrl.obtenerPorId(CitaDetalle[0].ServicioId );
            this.Servicio = servicio;
            decimal total = CitaDetalle.Sum(d => d.Importe);
            this.txtimporte.Text = total.ToString();
        }
        private async void btncapturar_Click(object sender, EventArgs e)
        {
            await capturarCita();
        }

        private async Task capturarCita()
        {
            int citaId = Convert.ToInt32(txtcita.Text);
            var cita = await ctCtrl.getFullCita(citaId);
            if (cita.Cita != null)
            {
                if(cita.Cita.Estatus == 3)
                {
                    MessageBox.Show(
                    "La cita introducida esta catalogada como satisfactoria.",
                    "Cita no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    return;
                }
                this.Cita = cita.Cita;
                CitaDetalle = cita.CitaDetalle;
                this.dgvbase.DataSource = CitaDetalle;
                dgvbase.Columns[0].Visible = false;
                dgvbase.Columns[1].Visible = false;
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
            await obtenerMaxFolio();
        }

        private async Task obtenerMaxFolio()
        {
            var ventas = await vtCtrl.obtenerTodas();
            if (ventas.Count == 0)
            {
                txtfolio.Text = "1";
                return;
            }
            txtfolio.Text = (ventas.Max(v => v.NotaVenta.Id)  +2 ).ToString();
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
            if (dgvbase.Rows.Count < 1)
            {
                MessageBox.Show("No puede realizar la venta con 0 servicios a capturar.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var rc = MessageBox.Show($"Desea completar la venta?",
                                "Confirmar",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                                );
            if (rc == DialogResult.No) return;

            List<notaventa_detalle> nvd = new List<notaventa_detalle>();
            nvd = CitaDetalle.Select(citadetalle => 
                new notaventa_detalle
                {
                    nvd_cantidad = (short)citadetalle.Cantidad,
                    nvd_precio = citadetalle.Precio,
                    nvd_servicio = (short)citadetalle.ServicioId,
                    nvd_estatus = 1
                }
            ).ToList();

            var venta = await vtCtrl.crearNueva(new notaventa
            {
                nv_cita = this.Cita.Id,
                nv_cliente = this.CitaBase.ct_cliente,
                nv_empleado = this.CitaBase.ct_empleado,
                nv_estatus = 1,
                nv_total = Convert.ToDecimal(txtimporte.Text)
            },
            nvd);

            if (venta != null)
            {
                var r = MessageBox.Show($"La venta se realizo exitosamente, desea imprimir el ticket?",
                                "Confirmar",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                                );
                if (r == DialogResult.No) {
                    reiniciarFormulario();
                    return;
                }
                // TODO: IMPRIMIR TICKET.
                var frmticketVenta = new frmticketcita(this.CitaDetalle, DateTime.Now, Convert.ToInt32(txtfolio.Text) );
                frmticketVenta.ShowDialog();
                reiniciarFormulario();
            }
        }

        private async void reiniciarFormulario()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            this.Cita = new citaModel();
            CitaBase = new citas();
            Servicio = new servicios();
            await obtenerMaxFolio();
            txtcita.Focus();
        }
    }
}
