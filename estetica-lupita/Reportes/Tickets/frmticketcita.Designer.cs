namespace estetica_lupita.Reportes.Tickets
{
    partial class frmticketcita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmticketcita));
            this.crvticketcita = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ticketCita1 = new estetica_lupita.Reportes.Tickets.ticketCita();
            this.SuspendLayout();
            // 
            // crvticketcita
            // 
            this.crvticketcita.ActiveViewIndex = 0;
            this.crvticketcita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvticketcita.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvticketcita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvticketcita.Location = new System.Drawing.Point(0, 0);
            this.crvticketcita.Name = "crvticketcita";
            this.crvticketcita.ReportSource = this.ticketCita1;
            this.crvticketcita.Size = new System.Drawing.Size(834, 756);
            this.crvticketcita.TabIndex = 0;
            // 
            // frmticketcita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 756);
            this.Controls.Add(this.crvticketcita);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmticketcita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TICKET DE CITA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvticketcita;
        private ticketCita ticketCita1;
    }
}