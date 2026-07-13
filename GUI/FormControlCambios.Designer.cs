namespace GUI
{
    partial class FormControlCambios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; de lo contrario, false.</param>
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
            this.labelControldecambios = new System.Windows.Forms.Label();
            this.dataGridViewControldecambios = new System.Windows.Forms.DataGridView();
            this.buttonRecomponerEstadoAnterior = new System.Windows.Forms.Button();
            this.labelSelectUsuarioCambio = new System.Windows.Forms.Label();
            this.comboBoxUsuarioCambio = new System.Windows.Forms.ComboBox();
            this.labelFechaInicioCambio = new System.Windows.Forms.Label();
            this.dateTimePickerInicioCambio = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFinCambio = new System.Windows.Forms.Label();
            this.dateTimePickerFinCambio = new System.Windows.Forms.DateTimePicker();
            this.labelTipoCambio = new System.Windows.Forms.Label();
            this.comboBoxTipoCambio = new System.Windows.Forms.ComboBox();
            this.btnFiltrarCambio = new System.Windows.Forms.Button();
            this.btnLimpiarFiltrosCambio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControldecambios
            // 
            this.labelControldecambios.AutoSize = true;
            this.labelControldecambios.Location = new System.Drawing.Point(18, 10);
            this.labelControldecambios.Name = "labelControldecambios";
            this.labelControldecambios.Size = new System.Drawing.Size(97, 13);
            this.labelControldecambios.TabIndex = 31;
            this.labelControldecambios.Text = "Control de cambios";
            // 
            // dataGridViewControldecambios
            // 
            this.dataGridViewControldecambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewControldecambios.Location = new System.Drawing.Point(21, 80);
            this.dataGridViewControldecambios.Name = "dataGridViewControldecambios";
            this.dataGridViewControldecambios.RowHeadersWidth = 82;
            this.dataGridViewControldecambios.RowTemplate.Height = 33;
            this.dataGridViewControldecambios.Size = new System.Drawing.Size(850, 170);
            this.dataGridViewControldecambios.TabIndex = 30;
            // 
            // buttonRecomponerEstadoAnterior
            // 
            this.buttonRecomponerEstadoAnterior.Location = new System.Drawing.Point(21, 255);
            this.buttonRecomponerEstadoAnterior.Name = "buttonRecomponerEstadoAnterior";
            this.buttonRecomponerEstadoAnterior.Size = new System.Drawing.Size(196, 38);
            this.buttonRecomponerEstadoAnterior.TabIndex = 32;
            this.buttonRecomponerEstadoAnterior.Text = "Recomponer estado anterior";
            this.buttonRecomponerEstadoAnterior.UseVisualStyleBackColor = true;
            this.buttonRecomponerEstadoAnterior.Click += new System.EventHandler(this.buttonRecomponerEstadoAnterior_Click);
            // 
            // labelSelectUsuarioCambio
            // 
            this.labelSelectUsuarioCambio.AutoSize = true;
            this.labelSelectUsuarioCambio.Location = new System.Drawing.Point(18, 48);
            this.labelSelectUsuarioCambio.Name = "labelSelectUsuarioCambio";
            this.labelSelectUsuarioCambio.Size = new System.Drawing.Size(46, 13);
            this.labelSelectUsuarioCambio.TabIndex = 56;
            this.labelSelectUsuarioCambio.Text = "Usuario:";
            // 
            // comboBoxUsuarioCambio
            // 
            this.comboBoxUsuarioCambio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarioCambio.Location = new System.Drawing.Point(75, 45);
            this.comboBoxUsuarioCambio.Name = "comboBoxUsuarioCambio";
            this.comboBoxUsuarioCambio.Size = new System.Drawing.Size(120, 21);
            this.comboBoxUsuarioCambio.TabIndex = 57;
            this.comboBoxUsuarioCambio.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarioCambio_SelectedIndexChanged);
            // 
            // labelFechaInicioCambio
            // 
            this.labelFechaInicioCambio.AutoSize = true;
            this.labelFechaInicioCambio.Location = new System.Drawing.Point(210, 48);
            this.labelFechaInicioCambio.Name = "labelFechaInicioCambio";
            this.labelFechaInicioCambio.Size = new System.Drawing.Size(41, 13);
            this.labelFechaInicioCambio.TabIndex = 58;
            this.labelFechaInicioCambio.Text = "Desde:";
            // 
            // dateTimePickerInicioCambio
            // 
            this.dateTimePickerInicioCambio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicioCambio.Location = new System.Drawing.Point(260, 45);
            this.dateTimePickerInicioCambio.Name = "dateTimePickerInicioCambio";
            this.dateTimePickerInicioCambio.Size = new System.Drawing.Size(110, 20);
            this.dateTimePickerInicioCambio.TabIndex = 59;
            this.dateTimePickerInicioCambio.Value = new System.DateTime(2026, 7, 2, 0, 0, 0, 0);
            // 
            // labelFechaFinCambio
            // 
            this.labelFechaFinCambio.AutoSize = true;
            this.labelFechaFinCambio.Location = new System.Drawing.Point(385, 48);
            this.labelFechaFinCambio.Name = "labelFechaFinCambio";
            this.labelFechaFinCambio.Size = new System.Drawing.Size(38, 13);
            this.labelFechaFinCambio.TabIndex = 60;
            this.labelFechaFinCambio.Text = "Hasta:";
            // 
            // dateTimePickerFinCambio
            // 
            this.dateTimePickerFinCambio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFinCambio.Location = new System.Drawing.Point(435, 45);
            this.dateTimePickerFinCambio.Name = "dateTimePickerFinCambio";
            this.dateTimePickerFinCambio.Size = new System.Drawing.Size(110, 20);
            this.dateTimePickerFinCambio.TabIndex = 61;
            this.dateTimePickerFinCambio.Value = new System.DateTime(2026, 7, 2, 0, 0, 0, 0);
            // 
            // labelTipoCambio
            // 
            this.labelTipoCambio.AutoSize = true;
            this.labelTipoCambio.Location = new System.Drawing.Point(560, 48);
            this.labelTipoCambio.Name = "labelTipoCambio";
            this.labelTipoCambio.Size = new System.Drawing.Size(31, 13);
            this.labelTipoCambio.TabIndex = 62;
            this.labelTipoCambio.Text = "Tipo:";
            // 
            // comboBoxTipoCambio
            // 
            this.comboBoxTipoCambio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCambio.Items.AddRange(new object[] {
            "Todos",
            "Registro",
            "Modificacion",
            "Recomposicion"});
            this.comboBoxTipoCambio.Location = new System.Drawing.Point(600, 45);
            this.comboBoxTipoCambio.Name = "comboBoxTipoCambio";
            this.comboBoxTipoCambio.Size = new System.Drawing.Size(110, 21);
            this.comboBoxTipoCambio.TabIndex = 63;
            this.comboBoxTipoCambio.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoCambio_SelectedIndexChanged);
            // 
            // btnFiltrarCambio
            // 
            this.btnFiltrarCambio.Location = new System.Drawing.Point(720, 43);
            this.btnFiltrarCambio.Name = "btnFiltrarCambio";
            this.btnFiltrarCambio.Size = new System.Drawing.Size(70, 25);
            this.btnFiltrarCambio.TabIndex = 64;
            this.btnFiltrarCambio.Text = "Filtrar";
            this.btnFiltrarCambio.UseVisualStyleBackColor = true;
            this.btnFiltrarCambio.Click += new System.EventHandler(this.btnFiltrarCambio_Click);
            // 
            // btnLimpiarFiltrosCambio
            // 
            this.btnLimpiarFiltrosCambio.Location = new System.Drawing.Point(800, 43);
            this.btnLimpiarFiltrosCambio.Name = "btnLimpiarFiltrosCambio";
            this.btnLimpiarFiltrosCambio.Size = new System.Drawing.Size(70, 25);
            this.btnLimpiarFiltrosCambio.TabIndex = 65;
            this.btnLimpiarFiltrosCambio.Text = "Limpiar";
            this.btnLimpiarFiltrosCambio.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltrosCambio.Click += new System.EventHandler(this.btnLimpiarFiltrosCambio_Click);
            // 
            // FormControlCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(900, 310);
            this.Controls.Add(this.labelControldecambios);
            this.Controls.Add(this.dataGridViewControldecambios);
            this.Controls.Add(this.buttonRecomponerEstadoAnterior);
            this.Controls.Add(this.labelSelectUsuarioCambio);
            this.Controls.Add(this.comboBoxUsuarioCambio);
            this.Controls.Add(this.labelFechaInicioCambio);
            this.Controls.Add(this.dateTimePickerInicioCambio);
            this.Controls.Add(this.labelFechaFinCambio);
            this.Controls.Add(this.dateTimePickerFinCambio);
            this.Controls.Add(this.labelTipoCambio);
            this.Controls.Add(this.comboBoxTipoCambio);
            this.Controls.Add(this.btnFiltrarCambio);
            this.Controls.Add(this.btnLimpiarFiltrosCambio);
            this.Name = "FormControlCambios";
            this.Text = "Control de Cambios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormControlCambios_FormClosing);
            this.Load += new System.EventHandler(this.FormControlCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelControldecambios;
        private System.Windows.Forms.DataGridView dataGridViewControldecambios;
        private System.Windows.Forms.Button buttonRecomponerEstadoAnterior;
        private System.Windows.Forms.Label labelSelectUsuarioCambio;
        private System.Windows.Forms.ComboBox comboBoxUsuarioCambio;
        private System.Windows.Forms.Label labelFechaInicioCambio;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicioCambio;
        private System.Windows.Forms.Label labelFechaFinCambio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinCambio;
        private System.Windows.Forms.Label labelTipoCambio;
        private System.Windows.Forms.ComboBox comboBoxTipoCambio;
        private System.Windows.Forms.Button btnFiltrarCambio;
        private System.Windows.Forms.Button btnLimpiarFiltrosCambio;
    }
}
