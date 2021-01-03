namespace estetica_lupita.Reportes.Tickets
{
    partial class frmticketventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmticketventa));
            this.crvticketventa = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvticketventa
            // 
            this.crvticketventa.ActiveViewIndex = -1;
            this.crvticketventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvticketventa.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvticketventa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvticketventa.Location = new System.Drawing.Point(0, 0);
            this.crvticketventa.Name = "crvticketventa";
            this.crvticketventa.Size = new System.Drawing.Size(854, 547);
            this.crvticketventa.TabIndex = 0;
            // 
            // frmticketventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 547);
            this.Controls.Add(this.crvticketventa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmticketventa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TICKET DE VENTA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvticketventa;
    }
}