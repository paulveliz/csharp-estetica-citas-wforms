using CrystalDecisions.CrystalReports.Engine;
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

namespace estetica_lupita.Reportes.Auditorias
{
    public partial class frmreporteauditorias : Form
    {
        public frmreporteauditorias(List<auditorias> audits, DateTime from, DateTime to, String titulo)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\Users\PaulVeliz\Documents\Proyectos\estetica\src\estetica-lupita\Reportes\Auditorias\rptauditorias.rpt";
            rptH.Load();
            rptH.SetDataSource(audits);

            rptH.SetParameterValue("fecha1", from.ToString("d"));
            rptH.SetParameterValue("fecha2", to.ToString("d"));
            rptH.SetParameterValue("titulo", titulo.ToUpper());

            crvauditorias.ReportSource = rptH;
            crvauditorias.Refresh();
        }
    }
}
