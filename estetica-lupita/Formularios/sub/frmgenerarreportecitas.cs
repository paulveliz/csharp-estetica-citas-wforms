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
using estetica_lupita.Reportes;
using estetica_lupita.Reportes.Citas;

namespace estetica_lupita.Formularios.sub
{
    public partial class frmgenerarreportecitas : Form
    {
        public frmgenerarreportecitas()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (rbtntodas.Checked)
            {
                this.button1.Enabled = false;
                var ctCtrl = new citaController();
                var citas = await ctCtrl.obtenerCitasPorFecha(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
                generarReporte(citas, "reporte de solo citas");
                this.button1.Enabled = true;
            }

            if (rbtncliente.Checked)
            {
                using (var pickCl = new utilidades.frm_cliente_picker())
                {
                    var result = pickCl.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        var cliente = pickCl.Cliente;
                        var r = MessageBox.Show(
                            $"Generar reporte en base las citas hechas al cliente {cliente.cl_nombrecompleto} ?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (r == DialogResult.No) return;
                        this.button1.Enabled = false;
                        var ctCtrl = new citaController();
                        var citas = await ctCtrl.obtenerCitasPorCliente(this.dateTimePicker1.Value, this.dateTimePicker2.Value, cliente.idcliente); // cita por clientes
                        generarReporte(citas, "reporte de solo cliente");
                        this.button1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Para generar este reporte necesita seleccionar un cliente.");
                    }
                }
            }

            if (rbtnempelado.Checked)
            {
                using (var pickCl = new utilidades.frm_empleado_picker())
                {
                    var result = pickCl.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        var emp = pickCl.Empleado;
                        var r = MessageBox.Show(
                            $"Generar reporte en base las citas hechas al cliente {emp.NombreCompleto} ?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (r == DialogResult.No) return;
                        this.button1.Enabled = false;
                        var ctCtrl = new citaController();
                        var citas = await ctCtrl.obtenerCitasPorEmpleado(this.dateTimePicker1.Value, this.dateTimePicker2.Value, emp.Id); // cita por empleados
                        generarReporte(citas, "reporte de solo empleado");
                        this.button1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Para generar este reporte necesita seleccionar un cliente.");
                    }
                }
            }
        }

        private void generarReporte(List<citaModel> citas, String tipoReporte)
        {
            // abrir frmreportecitas y inyectar datos.
            using (var rptcitas = new frmrptcitas(citas, this.dateTimePicker1.Value, this.dateTimePicker2.Value, tipoReporte))
            {
                rptcitas.ShowDialog();
            }
        }

    }
}
