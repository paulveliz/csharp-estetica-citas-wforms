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
    public partial class frmticketventa : Form
    {
        public frmticketventa(List<citaDetalleModel> venta, DateTime fecha, int folio)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\Users\PaulVeliz\Documents\Proyectos\estetica\src\estetica-lupita\Reportes\Tickets\ticketVenta.rpt";
            rptH.Load();
            rptH.SetDataSource(venta);

            rptH.SetParameterValue("folioventa", folio);

            this.crvticketventa.ReportSource = rptH;
            this.crvticketventa.Refresh();
        }
    }
}
