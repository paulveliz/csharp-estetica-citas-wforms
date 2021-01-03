namespace estetica_lupita.Reportes.Auditorias
{
    partial class frmreporteauditorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmreporteauditorias));
            this.crvauditorias = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptauditorias1 = new estetica_lupita.Reportes.Auditorias.rptauditorias();
            this.SuspendLayout();
            // 
            // crvauditorias
            // 
            this.crvauditorias.ActiveViewIndex = 0;
            this.crvauditorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvauditorias.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvauditorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvauditorias.Location = new System.Drawing.Point(0, 0);
            this.crvauditorias.Name = "crvauditorias";
            this.crvauditorias.ReportSource = this.rptauditorias1;
            this.crvauditorias.Size = new System.Drawing.Size(913, 639);
            this.crvauditorias.TabIndex = 0;
            // 
            // frmreporteauditorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 639);
            this.Controls.Add(this.crvauditorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmreporteauditorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE DE AUDITORIA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvauditorias;
        private rptauditorias rptauditorias1;
    }
}