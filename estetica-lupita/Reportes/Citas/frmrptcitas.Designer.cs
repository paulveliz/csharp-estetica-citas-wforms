namespace estetica_lupita.Reportes.Citas
{
    partial class frmrptcitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptcitas));
            this.rptctas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptcitas1 = new estetica_lupita.Reportes.Citas.rptcitas();
            this.SuspendLayout();
            // 
            // rptctas
            // 
            this.rptctas.ActiveViewIndex = 0;
            this.rptctas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptctas.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptctas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptctas.Location = new System.Drawing.Point(0, 0);
            this.rptctas.Name = "rptctas";
            this.rptctas.ReportSource = this.rptcitas1;
            this.rptctas.ShowCloseButton = false;
            this.rptctas.ShowCopyButton = false;
            this.rptctas.ShowGotoPageButton = false;
            this.rptctas.ShowGroupTreeButton = false;
            this.rptctas.ShowLogo = false;
            this.rptctas.ShowParameterPanelButton = false;
            this.rptctas.ShowTextSearchButton = false;
            this.rptctas.Size = new System.Drawing.Size(800, 450);
            this.rptctas.TabIndex = 1;
            // 
            // frmrptcitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptctas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrptcitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE CITAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptctas;
        private rptcitas rptcitas1;
    }
}