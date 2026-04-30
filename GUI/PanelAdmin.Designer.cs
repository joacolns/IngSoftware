namespace GUI
{
    partial class PanelAdmin
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
            this.labelNOMBREUSER = new System.Windows.Forms.Label();
            this.labelUSER = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevoUsuario = new System.Windows.Forms.TextBox();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewBitacora = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_LimpiarBitacora = new System.Windows.Forms.Button();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.textBoxUsuarioBuscar = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNOMBREUSER
            // 
            this.labelNOMBREUSER.AutoSize = true;
            this.labelNOMBREUSER.Location = new System.Drawing.Point(1478, 10);
            this.labelNOMBREUSER.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelNOMBREUSER.Name = "labelNOMBREUSER";
            this.labelNOMBREUSER.Size = new System.Drawing.Size(0, 25);
            this.labelNOMBREUSER.TabIndex = 0;
            this.labelNOMBREUSER.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelUSER
            // 
            this.labelUSER.AutoSize = true;
            this.labelUSER.Location = new System.Drawing.Point(1408, 35);
            this.labelUSER.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(70, 25);
            this.labelUSER.TabIndex = 1;
            this.labelUSER.Text = "label1";
            this.labelUSER.Click += new System.EventHandler(this.labelUSER_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1266, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtNuevoUsuario
            // 
            this.txtNuevoUsuario.Location = new System.Drawing.Point(44, 87);
            this.txtNuevoUsuario.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtNuevoUsuario.Name = "txtNuevoUsuario";
            this.txtNuevoUsuario.Size = new System.Drawing.Size(196, 31);
            this.txtNuevoUsuario.TabIndex = 3;
            this.txtNuevoUsuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(44, 171);
            this.txtNuevaPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(196, 31);
            this.txtNuevaPassword.TabIndex = 5;
            this.txtNuevaPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 329);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 73);
            this.button1.TabIndex = 8;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1394, 73);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cerrar sesion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewBitacora
            // 
            this.dataGridViewBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBitacora.Location = new System.Drawing.Point(42, 498);
            this.dataGridViewBitacora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewBitacora.Name = "dataGridViewBitacora";
            this.dataGridViewBitacora.RowHeadersWidth = 82;
            this.dataGridViewBitacora.RowTemplate.Height = 33;
            this.dataGridViewBitacora.Size = new System.Drawing.Size(1532, 383);
            this.dataGridViewBitacora.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 456);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bitacora";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "usuario",
            "admin"});
            this.comboBox1.Location = new System.Drawing.Point(44, 258);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 33);
            this.comboBox1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Rol";
            // 
            // btn_LimpiarBitacora
            // 
            this.btn_LimpiarBitacora.Location = new System.Drawing.Point(1584, 498);
            this.btn_LimpiarBitacora.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_LimpiarBitacora.Name = "btn_LimpiarBitacora";
            this.btn_LimpiarBitacora.Size = new System.Drawing.Size(218, 73);
            this.btn_LimpiarBitacora.TabIndex = 14;
            this.btn_LimpiarBitacora.Text = "Limpiar";
            this.btn_LimpiarBitacora.UseVisualStyleBackColor = true;
            this.btn_LimpiarBitacora.Click += new System.EventHandler(this.btn_LimpiarBitacora_Click);
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(273, 450);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerFechaInicio.TabIndex = 15;
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(509, 450);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerFechaFinal.TabIndex = 16;
            // 
            // textBoxUsuarioBuscar
            // 
            this.textBoxUsuarioBuscar.Location = new System.Drawing.Point(731, 450);
            this.textBoxUsuarioBuscar.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxUsuarioBuscar.Name = "textBoxUsuarioBuscar";
            this.textBoxUsuarioBuscar.Size = new System.Drawing.Size(196, 31);
            this.textBoxUsuarioBuscar.TabIndex = 17;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(939, 408);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(202, 73);
            this.buttonBuscar.TabIndex = 18;
            this.buttonBuscar.Text = "Filtrar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fecha Inicio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 408);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Fecha Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(726, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Fecha Final";
            // 
            // PanelAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1848, 946);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxUsuarioBuscar);
            this.Controls.Add(this.dateTimePickerFechaFinal);
            this.Controls.Add(this.dateTimePickerFechaInicio);
            this.Controls.Add(this.btn_LimpiarBitacora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewBitacora);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.txtNuevoUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.labelNOMBREUSER);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PanelAdmin";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PanelAdmin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Principal_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNOMBREUSER;
        private System.Windows.Forms.Label labelUSER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevoUsuario;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewBitacora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_LimpiarBitacora;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinal;
        private System.Windows.Forms.TextBox textBoxUsuarioBuscar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}