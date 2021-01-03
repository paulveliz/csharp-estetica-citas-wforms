using Controladores;
using estetica_lupita.Reportes.Auditorias;
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
    public partial class frmgenerarreporteauditoria : Form
    {
        public frmgenerarreporteauditoria()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var audits = await new auditController().obtenerAuditoriasPorFecha(dateTimePicker1.Value, dateTimePicker2.Value);
            var frmAuditReport = new frmreporteauditorias(audits: audits, from: dateTimePicker1.Value, to: dateTimePicker2.Value, titulo: "Reporte general por fechas");
            frmAuditReport.ShowDialog();
        }
    }
}
