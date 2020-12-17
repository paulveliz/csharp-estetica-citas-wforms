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
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtpass2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txtpass1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvbase = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtusuario);
            this.groupBox1.Controls.Add(this.txtpass2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.txtpass1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(44, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(551, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un nuevo Administrador";
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(157, 50);
            this.txtusuario.MaxLength = 20;
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(236, 22);
            this.txtusuario.TabIndex = 0;
            this.txtusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusuario_KeyPress);
            // 
            // txtpass2
            // 
            this.txtpass2.Enabled = false;
            this.txtpass2.Location = new System.Drawing.Point(157, 170);
            this.txtpass2.Margin = new System.Windows.Forms.Padding(4);
            this.txtpass2.MaxLength = 25;
            this.txtpass2.Name = "txtpass2";
            this.txtpass2.PasswordChar = '*';
            this.txtpass2.Size = new System.Drawing.Size(236, 22);
            this.txtpass2.TabIndex = 2;
            this.txtpass2.UseSystemPasswordChar = true;
            this.txtpass2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Contraseña:";
            // 
            // btnagregar
            // 
            this.btnagregar.Enabled = false;
            this.btnagregar.Location = new System.Drawing.Point(210, 200);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(112, 42);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "Agregar administrador";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // txtpass1
            // 
            this.txtpass1.Enabled = false;
            this.txtpass1.Location = new System.Drawing.Point(157, 112);
            this.txtpass1.Margin = new System.Windows.Forms.Padding(4);
            this.txtpass1.MaxLength = 25;
            this.txtpass1.Name = "txtpass1";
            this.txtpass1.PasswordChar = '*';
            this.txtpass1.Size = new System.Drawing.Size(236, 22);
            this.txtpass1.TabIndex = 1;
            this.txtpass1.UseSystemPasswordChar = true;
            this.txtpass1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvbase);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(44, 325);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(551, 291);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Administradores actuales. (Doble click para dar de baja)";
            // 
            // dgvbase
            // 
            this.dgvbase.AllowUserToAddRows = false;
            this.dgvbase.AllowUserToDeleteRows = false;
            this.dgvbase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvbase.Location = new System.Drawing.Point(4, 19);
            this.dgvbase.Margin = new System.Windows.Forms.Padding(4);
            this.dgvbase.Name = "dgvbase";
            this.dgvbase.ReadOnly = true;
            this.dgvbase.RowHeadersVisible = false;
            this.dgvbase.RowHeadersWidth = 62;
            this.dgvbase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbase.Size = new System.Drawing.Size(543, 268);
            this.dgvbase.TabIndex = 0;
            this.dgvbase.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvbase_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(475, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "IMPORTANTE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAdmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(655, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdmi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Administradores";
            this.Load += new System.EventHandler(this.frmAdmi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdmi_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TextBox txtpass1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvbase;
        private System.Windows.Forms.TextBox txtpass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Button button1;
    }
}