namespace estetica_lupita.Formularios
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.lblbuscar = new System.Windows.Forms.Label();
            this.cboxgenero = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvbase = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbuscar
            // 
            this.lblbuscar.AutoSize = true;
            this.lblbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblbuscar.Location = new System.Drawing.Point(236, 11);
            this.lblbuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbuscar.Name = "lblbuscar";
            this.lblbuscar.Size = new System.Drawing.Size(0, 17);
            this.lblbuscar.TabIndex = 41;
            this.lblbuscar.Visible = false;
            // 
            // cboxgenero
            // 
            this.cboxgenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxgenero.Enabled = false;
            this.cboxgenero.FormattingEnabled = true;
            this.cboxgenero.Location = new System.Drawing.Point(371, 124);
            this.cboxgenero.Margin = new System.Windows.Forms.Padding(4);
            this.cboxgenero.Name = "cboxgenero";
            this.cboxgenero.Size = new System.Drawing.Size(162, 24);
            this.cboxgenero.TabIndex = 2;
            this.cboxgenero.SelectedIndexChanged += new System.EventHandler(this.cboxgenero_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(367, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Género:";
            // 
            // txttelefono
            // 
            this.txttelefono.Enabled = false;
            this.txttelefono.Location = new System.Drawing.Point(14, 124);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txttelefono.MaxLength = 10;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(281, 22);
            this.txttelefono.TabIndex = 1;
            this.txttelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttelefono_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombre.Location = new System.Drawing.Point(11, 53);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.MaxLength = 55;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(285, 22);
            this.txtnombre.TabIndex = 0;
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(7, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Teléfono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nombre completo:";
            // 
            // btnagregar
            // 
            this.btnagregar.Enabled = false;
            this.btnagregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnagregar.Location = new System.Drawing.Point(421, 156);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(112, 42);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "Agregar ";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.lblbuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxgenero);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(842, 215);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un nuevo Cliente";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(667, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 31);
            this.button1.TabIndex = 42;
            this.button1.Text = "IMPORTANTE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvbase);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(842, 428);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes actuales. (Doble click para dar de baja)";
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
            this.dgvbase.Size = new System.Drawing.Size(834, 405);
            this.dgvbase.TabIndex = 1;
            this.dgvbase.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvbase_CellMouseDoubleClick);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(867, 670);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Registro de Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientes_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblbuscar;
        private System.Windows.Forms.ComboBox cboxgenero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvbase;
        private System.Windows.Forms.Button button1;
    }
}