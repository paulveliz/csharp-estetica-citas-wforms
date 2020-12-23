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

namespace estetica_lupita.Reportes.Citas
{
    public partial class frmrptcitas : Form
    {
        public frmrptcitas(List<citaModel> citas, DateTime from, DateTime to, String tipo)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\Users\PaulVeliz\Documents\Proyectos\estetica\src\estetica-lupita\Reportes\Citas\rptcitas.rpt";
            rptH.Load();
            rptH.SetDataSource(citas);

            rptH.SetParameterValue("fecha1", from.ToString("d"));
            rptH.SetParameterValue("fecha2", to.ToString("d"));
            rptH.SetParameterValue("tiporeporte", tipo.ToUpper());

            this.rptctas.ReportSource = rptH;
            this.rptctas.Refresh();
        }
    }
}
