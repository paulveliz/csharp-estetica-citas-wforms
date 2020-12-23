namespace estetica_lupita.Formularios.sub
{
    partial class frmgenerarreporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgenerarreporte));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtntodas = new System.Windows.Forms.RadioButton();
            this.rbtncliente = new System.Windows.Forms.RadioButton();
            this.rbtnempelado = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(288, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(12, 89);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(288, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtntodas
            // 
            this.rbtntodas.AutoSize = true;
            this.rbtntodas.Checked = true;
            this.rbtntodas.Location = new System.Drawing.Point(96, 132);
            this.rbtntodas.Name = "rbtntodas";
            this.rbtntodas.Size = new System.Drawing.Size(137, 21);
            this.rbtntodas.TabIndex = 5;
            this.rbtntodas.TabStop = true;
            this.rbtntodas.Text = "Todas las ventas";
            this.rbtntodas.UseVisualStyleBackColor = true;
            // 
            // rbtncliente
            // 
            this.rbtncliente.AutoSize = true;
            this.rbtncliente.Location = new System.Drawing.Point(96, 159);
            this.rbtncliente.Name = "rbtncliente";
            this.rbtncliente.Size = new System.Drawing.Size(96, 21);
            this.rbtncliente.TabIndex = 6;
            this.rbtncliente.Text = "Por cliente";
            this.rbtncliente.UseVisualStyleBackColor = true;
            // 
            // rbtnempelado
            // 
            this.rbtnempelado.AutoSize = true;
            this.rbtnempelado.Location = new System.Drawing.Point(96, 186);
            this.rbtnempelado.Name = "rbtnempelado";
            this.rbtnempelado.Size = new System.Drawing.Size(117, 21);
            this.rbtnempelado.TabIndex = 7;
            this.rbtnempelado.Text = "Por empleado";
            this.rbtnempelado.UseVisualStyleBackColor = true;
            // 
            // frmgenerarreporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 285);
            this.Controls.Add(this.rbtnempelado);
            this.Controls.Add(this.rbtncliente);
            this.Controls.Add(this.rbtntodas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmgenerarreporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar reporte de ventas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtntodas;
        private System.Windows.Forms.RadioButton rbtncliente;
        private System.Windows.Forms.RadioButton rbtnempelado;
    }
}