namespace estetica_lupita.Formularios
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.labelRegistroConfirmar = new System.Windows.Forms.Label();
            this.txtsueldo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombrecompleto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvbase = new System.Windows.Forms.DataGridView();
            this.cboxpuestos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboxpuestos);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.labelRegistroConfirmar);
            this.groupBox1.Controls.Add(this.txtsueldo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtnombrecompleto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(28, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(731, 242);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un nuevo empleado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "$";
            // 
            // btnagregar
            // 
            this.btnagregar.Enabled = false;
            this.btnagregar.Location = new System.Drawing.Point(507, 169);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(135, 42);
            this.btnagregar.TabIndex = 4;
            this.btnagregar.Text = "Agregar ";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // txttelefono
            // 
            this.txttelefono.Enabled = false;
            this.txttelefono.Location = new System.Drawing.Point(85, 126);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttelefono.MaxLength = 10;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(203, 22);
            this.txttelefono.TabIndex = 1;
            this.txttelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttelefono_KeyPress);
            // 
            // labelRegistroConfirmar
            // 
            this.labelRegistroConfirmar.AutoSize = true;
            this.labelRegistroConfirmar.Location = new System.Drawing.Point(82, 103);
            this.labelRegistroConfirmar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRegistroConfirmar.Name = "labelRegistroConfirmar";
            this.labelRegistroConfirmar.Size = new System.Drawing.Size(68, 17);
            this.labelRegistroConfirmar.TabIndex = 37;
            this.labelRegistroConfirmar.Text = "Telefono:";
            // 
            // txtsueldo
            // 
            this.txtsueldo.Enabled = false;
            this.txtsueldo.Location = new System.Drawing.Point(85, 179);
            this.txtsueldo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsueldo.MaxLength = 3;
            this.txtsueldo.Name = "txtsueldo";
            this.txtsueldo.Size = new System.Drawing.Size(184, 22);
            this.txtsueldo.TabIndex = 2;
            this.txtsueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsueldo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Sueldo que recibira:";
            // 
            // txtnombrecompleto
            // 
            this.txtnombrecompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombrecompleto.Location = new System.Drawing.Point(85, 68);
            this.txtnombrecompleto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtnombrecompleto.MaxLength = 55;
            this.txtnombrecompleto.Name = "txtnombrecompleto";
            this.txtnombrecompleto.Size = new System.Drawing.Size(296, 22);
            this.txtnombrecompleto.TabIndex = 0;
            this.txtnombrecompleto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombrecompleto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Nombre completo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvbase);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(28, 302);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(731, 294);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empleados actuales. (Doble click para dar de baja)";
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
            this.dgvbase.Size = new System.Drawing.Size(723, 271);
            this.dgvbase.TabIndex = 1;
            this.dgvbase.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvbase_CellMouseDoubleClick);
            // 
            // cboxpuestos
            // 
            this.cboxpuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxpuestos.Enabled = false;
            this.cboxpuestos.FormattingEnabled = true;
            this.cboxpuestos.Location = new System.Drawing.Point(315, 178);
            this.cboxpuestos.Margin = new System.Windows.Forms.Padding(4);
            this.cboxpuestos.Name = "cboxpuestos";
            this.cboxpuestos.Size = new System.Drawing.Size(160, 24);
            this.cboxpuestos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Puesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "(diario)";
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(811, 601);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Registro de Empleado";
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label labelRegistroConfirmar;
        private System.Windows.Forms.TextBox txtsueldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombrecompleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvbase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxpuestos;
        private System.Windows.Forms.Label label5;
    }
}