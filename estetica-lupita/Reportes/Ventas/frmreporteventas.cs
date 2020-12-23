using CrystalDecisions.CrystalReports.Engine;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estetica_lupita.Reportes
{
    public partial class frmreporteventas : Form
    {
        public frmreporteventas(List<notaventaModel> ventas, DateTime from, DateTime to, String tipo)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\Users\PaulVeliz\Documents\Proyectos\estetica\src\estetica-lupita\Reportes\Ventas\rptventas.rpt";
            rptH.Load();
            rptH.SetDataSource(ventas);

            rptH.SetParameterValue("fecha1", from.ToString("d") );
            rptH.SetParameterValue("fecha2", to.ToString("d") );
            rptH.SetParameterValue("tiporeporte", tipo.ToUpper() );

            this.rptventas.ReportSource = rptH;   
            this.rptventas.Refresh();
        }
    }
}
