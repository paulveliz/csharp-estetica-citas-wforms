namespace estetica_lupita.Formularios
{
    partial class frmAdmi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRegistroConfirmar = new System.Windows.Forms.TextBox();
            this.labelRegistroConfirmar = new System.Windows.Forms.Label();
            this.txtRegistroContra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRegistroUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtRegistroConfirmar);
            this.groupBox1.Controls.Add(this.labelRegistroConfirmar);
            this.groupBox1.Controls.Add(this.txtRegistroContra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtRegistroUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(50, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(620, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un nuevo Administrador";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 279);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 52);
            this.button1.TabIndex = 39;
            this.button1.Text = "Agregar administrador";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtRegistroConfirmar
            // 
            this.txtRegistroConfirmar.Location = new System.Drawing.Point(177, 217);
            this.txtRegistroConfirmar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRegistroConfirmar.MaxLength = 10;
            this.txtRegistroConfirmar.Name = "txtRegistroConfirmar";
            this.txtRegistroConfirmar.PasswordChar = '*';
            this.txtRegistroConfirmar.Size = new System.Drawing.Size(265, 26);
            this.txtRegistroConfirmar.TabIndex = 38;
            this.txtRegistroConfirmar.Visible = false;
            // 
            // labelRegistroConfirmar
            // 
            this.labelRegistroConfirmar.AutoSize = true;
            this.labelRegistroConfirmar.Location = new System.Drawing.Point(173, 192);
            this.labelRegistroConfirmar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRegistroConfirmar.Name = "labelRegistroConfirmar";
            this.labelRegistroConfirmar.Size = new System.Drawing.Size(142, 20);
            this.labelRegistroConfirmar.TabIndex = 37;
            this.labelRegistroConfirmar.Text = "Número telefónico:";
            this.labelRegistroConfirmar.Visible = false;
            // 
            // txtRegistroContra
            // 
            this.txtRegistroContra.Enabled = false;
            this.txtRegistroContra.Location = new System.Drawing.Point(177, 140);
            this.txtRegistroContra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRegistroContra.MaxLength = 10;
            this.txtRegistroContra.Name = "txtRegistroContra";
            this.txtRegistroContra.PasswordChar = '*';
            this.txtRegistroContra.Size = new System.Drawing.Size(265, 26);
            this.txtRegistroContra.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Contraseña:";
            // 
            // TxtRegistroUsuario
            // 
            this.TxtRegistroUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRegistroUsuario.Location = new System.Drawing.Point(177, 63);
            this.TxtRegistroUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtRegistroUsuario.MaxLength = 100;
            this.TxtRegistroUsuario.Multiline = true;
            this.TxtRegistroUsuario.Name = "TxtRegistroUsuario";
            this.TxtRegistroUsuario.Size = new System.Drawing.Size(265, 29);
            this.TxtRegistroUsuario.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(50, 403);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(620, 271);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Administradores actuales. (Doble click para dar de baja)";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(620, 131);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre de Usuario";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Telefono";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // frmAdmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(815, 692);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdmi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Administradores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRegistroConfirmar;
        private System.Windows.Forms.Label labelRegistroConfirmar;
        private System.Windows.Forms.TextBox txtRegistroContra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRegistroUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}