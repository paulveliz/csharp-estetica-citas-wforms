using CrystalDecisions.CrystalReports.Engine;
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

namespace estetica_lupita.Reportes.Tickets
{
    public partial class frmticketcita : Form
    {
        public frmticketcita(List<citaDetalleModel> cita, DateTime fecha, int folio)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\Users\PaulVeliz\Documents\Proyectos\estetica\src\estetica-lupita\Reportes\Tickets\ticketCita.rpt";
            rptH.Load();
            rptH.SetDataSource(cita);

            rptH.SetParameterValue("folio", folio);
            rptH.SetParameterValue("fechacita", fecha.ToString("d"));

            this.crvticketcita.ReportSource = rptH;
            this.crvticketcita.Refresh();
        }
    }
}
