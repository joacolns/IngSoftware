namespace GUI
{
    partial class FormBitacora
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
            this.labelBitacora = new System.Windows.Forms.Label();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFinal = new System.Windows.Forms.Label();
            this.dateTimePickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.labelNombredeusuario = new System.Windows.Forms.Label();
            this.textBoxUsuarioBuscar = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewBitacora = new System.Windows.Forms.DataGridView();
            this.btn_LimpiarBitacora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBitacora
            // 
            this.labelBitacora.AutoSize = true;
            this.labelBitacora.Location = new System.Drawing.Point(18, 29);
            this.labelBitacora.Name = "labelBitacora";
            this.labelBitacora.Size = new System.Drawing.Size(46, 13);
            this.labelBitacora.TabIndex = 11;
            this.labelBitacora.Text = "Bitacora";
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(108, 9);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(65, 13);
            this.labelFechaInicio.TabIndex = 19;
            this.labelFechaInicio.Text = "Fecha Inicio";
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(111, 29);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(102, 20);
            this.dateTimePickerFechaInicio.TabIndex = 15;
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Location = new System.Drawing.Point(224, 12);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(62, 13);
            this.labelFechaFinal.TabIndex = 20;
            this.labelFechaFinal.Text = "Fecha Final";
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(221, 29);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(102, 20);
            this.dateTimePickerFechaFinal.TabIndex = 16;
            // 
            // labelNombredeusuario
            // 
            this.labelNombredeusuario.AutoSize = true;
            this.labelNombredeusuario.Location = new System.Drawing.Point(331, 6);
            this.labelNombredeusuario.Name = "labelNombredeusuario";
            this.labelNombredeusuario.Size = new System.Drawing.Size(96, 13);
            this.labelNombredeusuario.TabIndex = 21;
            this.labelNombredeusuario.Text = "Nombre de usuario";
            // 
            // textBoxUsuarioBuscar
            // 
            this.textBoxUsuarioBuscar.Location = new System.Drawing.Point(334, 28);
            this.textBoxUsuarioBuscar.Name = "textBoxUsuarioBuscar";
            this.textBoxUsuarioBuscar.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsuarioBuscar.TabIndex = 17;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(444, 7);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(101, 38);
            this.buttonBuscar.TabIndex = 18;
            this.buttonBuscar.Text = "Filtrar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewBitacora
            // 
            this.dataGridViewBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBitacora.Location = new System.Drawing.Point(21, 51);
            this.dataGridViewBitacora.Name = "dataGridViewBitacora";
            this.dataGridViewBitacora.RowHeadersWidth = 82;
            this.dataGridViewBitacora.RowTemplate.Height = 33;
            this.dataGridViewBitacora.Size = new System.Drawing.Size(861, 199);
            this.dataGridViewBitacora.TabIndex = 10;
            // 
            // btn_LimpiarBitacora
            // 
            this.btn_LimpiarBitacora.Location = new System.Drawing.Point(20, 255);
            this.btn_LimpiarBitacora.Name = "btn_LimpiarBitacora";
            this.btn_LimpiarBitacora.Size = new System.Drawing.Size(109, 38);
            this.btn_LimpiarBitacora.TabIndex = 14;
            this.btn_LimpiarBitacora.Text = "Limpiar";
            this.btn_LimpiarBitacora.UseVisualStyleBackColor = true;
            this.btn_LimpiarBitacora.Click += new System.EventHandler(this.btn_LimpiarBitacora_Click);
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(900, 310);
            this.Controls.Add(this.labelBitacora);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.dateTimePickerFechaInicio);
            this.Controls.Add(this.labelFechaFinal);
            this.Controls.Add(this.dateTimePickerFechaFinal);
            this.Controls.Add(this.labelNombredeusuario);
            this.Controls.Add(this.textBoxUsuarioBuscar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.dataGridViewBitacora);
            this.Controls.Add(this.btn_LimpiarBitacora);
            this.Name = "FormBitacora";
            this.Text = "Bitácora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBitacora_FormClosing);
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBitacora;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.Label labelFechaFinal;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinal;
        private System.Windows.Forms.Label labelNombredeusuario;
        private System.Windows.Forms.TextBox textBoxUsuarioBuscar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dataGridViewBitacora;
        private System.Windows.Forms.Button btn_LimpiarBitacora;
    }
}
