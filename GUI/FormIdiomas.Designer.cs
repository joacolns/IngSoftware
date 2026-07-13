namespace GUI
{
    partial class FormIdiomas
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
            this.labelManejodeidiomas = new System.Windows.Forms.Label();
            this.labelIdioma = new System.Windows.Forms.Label();
            this.comboBoxIdioma = new System.Windows.Forms.ComboBox();
            this.buttonActivarIdioma = new System.Windows.Forms.Button();
            this.buttonDesactivarIdioma = new System.Windows.Forms.Button();
            this.labelNombredelidioma = new System.Windows.Forms.Label();
            this.textBoxAgregarNombreIdioma = new System.Windows.Forms.TextBox();
            this.buttonAgregarIdioma = new System.Windows.Forms.Button();
            this.buttonAplicarCambiosIdioma = new System.Windows.Forms.Button();
            this.dataGridViewTraducirControl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraducirControl)).BeginInit();
            this.SuspendLayout();
            // 
            // labelManejodeidiomas
            // 
            this.labelManejodeidiomas.AutoSize = true;
            this.labelManejodeidiomas.Location = new System.Drawing.Point(19, 15);
            this.labelManejodeidiomas.Name = "labelManejodeidiomas";
            this.labelManejodeidiomas.Size = new System.Drawing.Size(95, 13);
            this.labelManejodeidiomas.TabIndex = 35;
            this.labelManejodeidiomas.Text = "Manejo de idiomas";
            // 
            // labelIdioma
            // 
            this.labelIdioma.AutoSize = true;
            this.labelIdioma.Location = new System.Drawing.Point(19, 71);
            this.labelIdioma.Name = "labelIdioma";
            this.labelIdioma.Size = new System.Drawing.Size(38, 13);
            this.labelIdioma.TabIndex = 37;
            this.labelIdioma.Text = "Idioma";
            // 
            // comboBoxIdioma
            // 
            this.comboBoxIdioma.FormattingEnabled = true;
            this.comboBoxIdioma.Location = new System.Drawing.Point(98, 71);
            this.comboBoxIdioma.Name = "comboBoxIdioma";
            this.comboBoxIdioma.Size = new System.Drawing.Size(162, 21);
            this.comboBoxIdioma.TabIndex = 36;
            // 
            // buttonActivarIdioma
            // 
            this.buttonActivarIdioma.Location = new System.Drawing.Point(264, 35);
            this.buttonActivarIdioma.Name = "buttonActivarIdioma";
            this.buttonActivarIdioma.Size = new System.Drawing.Size(93, 52);
            this.buttonActivarIdioma.TabIndex = 38;
            this.buttonActivarIdioma.Text = "Activar idioma";
            this.buttonActivarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonDesactivarIdioma
            // 
            this.buttonDesactivarIdioma.Location = new System.Drawing.Point(360, 35);
            this.buttonDesactivarIdioma.Name = "buttonDesactivarIdioma";
            this.buttonDesactivarIdioma.Size = new System.Drawing.Size(107, 52);
            this.buttonDesactivarIdioma.TabIndex = 39;
            this.buttonDesactivarIdioma.Text = "Desactivar idioma";
            this.buttonDesactivarIdioma.UseVisualStyleBackColor = true;
            // 
            // labelNombredelidioma
            // 
            this.labelNombredelidioma.AutoSize = true;
            this.labelNombredelidioma.Location = new System.Drawing.Point(524, 62);
            this.labelNombredelidioma.Name = "labelNombredelidioma";
            this.labelNombredelidioma.Size = new System.Drawing.Size(94, 13);
            this.labelNombredelidioma.TabIndex = 40;
            this.labelNombredelidioma.Text = "Nombre del idioma";
            this.labelNombredelidioma.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxAgregarNombreIdioma
            // 
            this.textBoxAgregarNombreIdioma.Location = new System.Drawing.Point(622, 62);
            this.textBoxAgregarNombreIdioma.Name = "textBoxAgregarNombreIdioma";
            this.textBoxAgregarNombreIdioma.Size = new System.Drawing.Size(141, 20);
            this.textBoxAgregarNombreIdioma.TabIndex = 41;
            // 
            // buttonAgregarIdioma
            // 
            this.buttonAgregarIdioma.Location = new System.Drawing.Point(764, 62);
            this.buttonAgregarIdioma.Name = "buttonAgregarIdioma";
            this.buttonAgregarIdioma.Size = new System.Drawing.Size(120, 52);
            this.buttonAgregarIdioma.TabIndex = 42;
            this.buttonAgregarIdioma.Text = "Agregar";
            this.buttonAgregarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonAplicarCambiosIdioma
            // 
            this.buttonAplicarCambiosIdioma.Location = new System.Drawing.Point(264, 87);
            this.buttonAplicarCambiosIdioma.Name = "buttonAplicarCambiosIdioma";
            this.buttonAplicarCambiosIdioma.Size = new System.Drawing.Size(203, 37);
            this.buttonAplicarCambiosIdioma.TabIndex = 43;
            this.buttonAplicarCambiosIdioma.Text = "Aplicar Cambios";
            this.buttonAplicarCambiosIdioma.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTraducirControl
            // 
            this.dataGridViewTraducirControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTraducirControl.Location = new System.Drawing.Point(22, 128);
            this.dataGridViewTraducirControl.Name = "dataGridViewTraducirControl";
            this.dataGridViewTraducirControl.RowHeadersWidth = 82;
            this.dataGridViewTraducirControl.RowTemplate.Height = 33;
            this.dataGridViewTraducirControl.Size = new System.Drawing.Size(863, 188);
            this.dataGridViewTraducirControl.TabIndex = 34;
            // 
            // FormIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(900, 340);
            this.Controls.Add(this.labelManejodeidiomas);
            this.Controls.Add(this.labelIdioma);
            this.Controls.Add(this.comboBoxIdioma);
            this.Controls.Add(this.buttonActivarIdioma);
            this.Controls.Add(this.buttonDesactivarIdioma);
            this.Controls.Add(this.labelNombredelidioma);
            this.Controls.Add(this.textBoxAgregarNombreIdioma);
            this.Controls.Add(this.buttonAgregarIdioma);
            this.Controls.Add(this.buttonAplicarCambiosIdioma);
            this.Controls.Add(this.dataGridViewTraducirControl);
            this.Name = "FormIdiomas";
            this.Text = "Idiomas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIdiomas_FormClosing);
            this.Load += new System.EventHandler(this.FormIdiomas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraducirControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelManejodeidiomas;
        private System.Windows.Forms.Label labelIdioma;
        private System.Windows.Forms.ComboBox comboBoxIdioma;
        private System.Windows.Forms.Button buttonActivarIdioma;
        private System.Windows.Forms.Button buttonDesactivarIdioma;
        private System.Windows.Forms.Label labelNombredelidioma;
        private System.Windows.Forms.TextBox textBoxAgregarNombreIdioma;
        private System.Windows.Forms.Button buttonAgregarIdioma;
        private System.Windows.Forms.Button buttonAplicarCambiosIdioma;
        private System.Windows.Forms.DataGridView dataGridViewTraducirControl;
    }
}
