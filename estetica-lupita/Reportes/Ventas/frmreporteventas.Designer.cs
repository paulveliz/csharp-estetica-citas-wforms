using estetica_lupita.Reportes.Ventas;

namespace estetica_lupita.Reportes
{
    partial class frmreporteventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptventas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptventas1 = new estetica_lupita.Reportes.Ventas.rptventas();
            this.rptventas2 = new estetica_lupita.Reportes.Ventas.rptventas();
            this.rptventas3 = new estetica_lupita.Reportes.Ventas.rptventas();
            this.SuspendLayout();
            // 
            // rptventas
            // 
            this.rptventas.ActiveViewIndex = 0;
            this.rptventas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptventas.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptventas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptventas.Location = new System.Drawing.Point(0, 0);
            this.rptventas.Name = "rptventas";
            this.rptventas.ReportSource = this.rptventas3;
            this.rptventas.ShowCloseButton = false;
            this.rptventas.ShowCopyButton = false;
            this.rptventas.ShowGotoPageButton = false;
            this.rptventas.ShowGroupTreeButton = false;
            this.rptventas.ShowLogo = false;
            this.rptventas.ShowParameterPanelButton = false;
            this.rptventas.ShowTextSearchButton = false;
            this.rptventas.Size = new System.Drawing.Size(853, 440);
            this.rptventas.TabIndex = 0;
            // 
            // frmreporteventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 440);
            this.Controls.Add(this.rptventas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmreporteventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptventas;
        private rptventas rptventas1;
        private rptventas rptventas3;
        private rptventas rptventas2;
    }
}