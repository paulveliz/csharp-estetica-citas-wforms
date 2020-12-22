using Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estetica_lupita.Formularios.sub
{
    public partial class frmgenerarreporte : Form
    {
        public frmgenerarreporte()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var vtCtrl = new ventaController();
            var ventas = await vtCtrl.obtenerPorFechas(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
            var notaventas = ventas.Select(venta => venta.NotaVenta).ToList();

            using (var rptventas = new Reportes.frmreporteventas(notaventas, this.dateTimePicker1.Value, this.dateTimePicker2.Value))
            {
                rptventas.ShowDialog();
            }
        }
    }
}
