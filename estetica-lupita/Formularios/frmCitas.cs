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
using Modelos;
using Modelos.EF;

namespace estetica_lupita.Formularios
{
    public partial class frmCitas : Form
    {
        citaController ctCtrl = new citaController();
        servicioController svCtrl = new servicioController();
        public empleadoModel Empleado { get; set; }
        public clientes Cliente { get; set; }
        public servicios Servicio { get; set; }
        public frmCitas()
        {
            InitializeComponent();
        }

        private async void obtenerCitas()
        {
            var citas = await ctCtrl.obtenerTodasLasCitas();
            dgvbase.DataSource = citas;
            ajustarDgv();
        }

        private async void obtenerServicios()
        {
            var servicios = await svCtrl.obtenerTodos();
            this.cboxservicio.DataSource = servicios;
            this.cboxservicio.DisplayMember = "sv_descripcion";
            this.cboxservicio.ValueMember = "idservicio";
        }

        private void validarClienteEmpleado()
        {
            if(txtempleado.Text != "" && txtcliente.Text != "")
            {
                enableControls(true);
            }
        }

        private void enableControls(bool t)
        {
            cboxservicio.Enabled = t;
            txtcantservicios.Enabled = t;
            txtfecha.Enabled = t;
            txthora.Enabled = t;
            txtminuto.Enabled = t;
            btnagendar.Enabled = t;
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            obtenerServicios();
            obtenerCitas();
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            using( var empForm = new utilidades.frm_empleado_picker())
            {
                var result = empForm.ShowDialog();
                if(result == DialogResult.Yes)
                {
                    this.Empleado = empForm.Empleado;
                    this.txtempleado.Text = Empleado.NombreCompleto;
                }
                validarClienteEmpleado();
            }
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            using (var empForm = new utilidades.frm_cliente_picker())
            {
                var result = empForm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    this.Cliente = empForm.Cliente;
                    this.txtcliente.Text = Cliente.cl_nombrecompleto;
                    validarClienteEmpleado();
                }
            }
        }

        private void txthora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtminuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void btnagendar_Click(object sender, EventArgs e)
        {
            if (txthora.Text.Length < 1 || txtminuto.Text.Length < 1)
            {
                MessageBox.Show("La cita debe tener hora y minutos.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtcantservicios.Value == 0)
            {
                MessageBox.Show("No puede hacer 0 servicios.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                
            var r = MessageBox.Show("Agendar cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            this.Cursor = Cursors.WaitCursor;
            var cita = await ctCtrl.crearCita(new citas
            {
                ct_estatus = 1,
                ct_cantservicios = (short)Convert.ToInt32( txtcantservicios.Value ),
                ct_cliente = this.Cliente.idcliente,
                ct_empleado = this.Empleado.Id,
                ct_fecha = this.txtfecha.Value,
                ct_hora =  Convert.ToDateTime( $"{txthora.Text}:{txtminuto.Text}:00" ).TimeOfDay,
                ct_servicio = (short)cboxservicio.SelectedValue,
            });
            this.Cursor = Cursors.Default;
            if(cita != null)
            {
                MessageBox.Show($"Se creo una cita con folio {cita.idcita}, para el cliente {this.Cliente.cl_nombrecompleto} para el dia {this.txtfecha.Value.Day}/{this.txtfecha.Value.Month}/{this.txtfecha.Value.Year} a las {this.txthora.Text}:{this.txtminuto.Text}",
                    "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadForm();
            }
            else
            {
                MessageBox.Show("Ocurrio un error creando la cita, comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void reloadForm()
        {
            this.Refresh();
            this.Controls.Clear();
            this.InitializeComponent();
            this.Cliente = new clientes();
            this.Empleado = new empleadoModel();
            obtenerCitas();
            obtenerServicios();
        }

        private async void btnvisualizar_Click(object sender, EventArgs e)
        {
            if (rdbprogreso.Checked)
            {
                var citas = await ctCtrl.obtenerCitasEnProgreso();
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                if (citas.Count == 0)
                {
                    MessageBox.Show("No se encontraron citas en la opcion especificada.", "Citas en progreso");
                }
            }

            if (rdbpendientes.Checked)
            {
                var citas = await ctCtrl.obtenerCitasPendientes();
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                if (citas.Count == 0)
                {
                    MessageBox.Show("No se encontraron citas en la opcion especificada.", "Citas pendientes");
                }
            }

            if (rdbsatisfactorias.Checked)
            {
                var citas = await ctCtrl.obtenerCitasSatisfactorias();
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                if (citas.Count == 0)
                {
                    MessageBox.Show("No se encontraron citas en la opcion especificada.", "Citas satisfactorias");
                }
            }

            if (rdbcanceladas.Checked)
            {
                var citas = await ctCtrl.obtenerCitasCanceladas();
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                if (citas.Count == 0)
                {
                    MessageBox.Show("No se encontraron citas en la opcion especificada.", "Citas canceladas");
                }
            }
        }
        
        private async void calcularImporte()
        {
            Servicio = (servicios)cboxservicio.SelectedItem;
            var svCtrl = new servicioController();
            var servicio = await svCtrl.obtenerPorId(Servicio.idservicio);
            this.txtimporte.Text = (servicio.sv_precio * Convert.ToInt32( txtcantservicios.Value)).ToString();
        }
        private void ajustarDgv()
        {
            dgvbase.Columns[0].Visible = true;
            dgvbase.Columns[0].HeaderText = "Folio";
            dgvbase.Columns[1].HeaderText = "Empleado";
            dgvbase.Columns[2].HeaderText = "Cliente";
            dgvbase.Columns[3].HeaderText = "Servicio";
            dgvbase.Columns[4].HeaderText = "Cantidad";
            dgvbase.Columns[5].HeaderText = "Fecha";
            dgvbase.Columns[6].HeaderText = "Hora";
        }

        private async void txtbusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbncliente.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                var citas = await ctCtrl.getcitaByClientNameMatching(txtbusqueda.Text);
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                this.Cursor = Cursors.Default;
            }

            if (rbnempleado.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                var citas = await ctCtrl.getcitaByEmpleadoNameMatching(txtbusqueda.Text);
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                this.Cursor = Cursors.Default;
            }

            if (rbnfolio.Checked)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (string.IsNullOrEmpty(txtbusqueda.Text) || string.IsNullOrWhiteSpace(txtbusqueda.Text)) return;
                this.Cursor = Cursors.WaitCursor;
                var citas = await ctCtrl.getcitaByFolioMatching( txtbusqueda.Text );
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                this.Cursor = Cursors.Default;
            }

            if (rbnservicio.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                var citas = await ctCtrl.getcitaByServiceNameMatching(txtbusqueda.Text);
                this.dgvbase.DataSource = citas;
                ajustarDgv();
                this.Cursor = Cursors.Default;
            }

        }

        private async void dgvbase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idcita = this.dgvbase.SelectedRows[0].Cells[0].Value.ToString();
                string citacliente = this.dgvbase.SelectedRows[0].Cells[2].Value.ToString();
                string citaempleado = this.dgvbase.SelectedRows[0].Cells[1].Value.ToString();

                var r = MessageBox.Show($"Dar de baja la cita con folio {idcita} del cliente  {citacliente} operada por {citaempleado}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;
                var baja = await ctCtrl.cambiarEstadoDeCita( Convert.ToInt32(idcita), 0 );
                reloadForm();
            }
            catch (Exception)
            {
                return;
            }
        }

        private async void btnporfechas_Click(object sender, EventArgs e)
        {
            var citas = await ctCtrl.obtenerCitasPorFecha(txtfechaorder1.Value, txtfechaorder2.Value);
            this.dgvbase.DataSource = citas;
            ajustarDgv();
            if(citas.Count == 0)
            {
                MessageBox.Show("No se encontraron citas en el rango especificado.", "Busqueda por fechas");
            }
        }

        private void txtcantservicios_ValueChanged(object sender, EventArgs e)
        {
           calcularImporte();
        }

        private void cboxservicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularImporte();
        }
    }
}
