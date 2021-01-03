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
    public partial class frmgenerarreporteauditoriausuario : Form
    {
        public frmgenerarreporteauditoriausuario()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var selection = new utilidades.frm_usuario_picker())
            {
                auditController audits = new auditController();
                var result = selection.ShowDialog();
                if(result == DialogResult.Yes)
                {
                    var auditorias = await audits.obtenerAuditoriasPorUsuario(selection.Usuario.usuario_name, this.dateTimePicker1.Value, this.dateTimePicker2.Value);
                    var report = new frmreporteauditorias(auditorias, this.dateTimePicker1.Value, this.dateTimePicker2.Value, $"Auditorias del usuario: {selection.Usuario.usuario_name}");
                    report.ShowDialog();
                }
            }
        }
    }
}
