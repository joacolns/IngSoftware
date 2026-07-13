namespace GUI
{
    partial class PanelAdmin
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
            this.labelNOMBREUSER = new System.Windows.Forms.Label();
            this.labelUSER = new System.Windows.Forms.Label();
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.buttonCerrarSesion = new System.Windows.Forms.Button();
            this.comboBoxIdiomaMostrar = new System.Windows.Forms.ComboBox();
            this.buttonActualizarIdiomaMostrar = new System.Windows.Forms.Button();
            this.buttonAbrirUsuarios = new System.Windows.Forms.Button();
            this.buttonAbrirBitacora = new System.Windows.Forms.Button();
            this.buttonAbrirControlCambios = new System.Windows.Forms.Button();
            this.buttonAbrirIdiomas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNOMBREUSER
            // 
            this.labelNOMBREUSER.AutoSize = true;
            this.labelNOMBREUSER.Location = new System.Drawing.Point(719, 9);
            this.labelNOMBREUSER.Name = "labelNOMBREUSER";
            this.labelNOMBREUSER.Size = new System.Drawing.Size(0, 13);
            this.labelNOMBREUSER.TabIndex = 0;
            // 
            // labelUSER
            // 
            this.labelUSER.AutoSize = true;
            this.labelUSER.Location = new System.Drawing.Point(719, 27);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(0, 13);
            this.labelUSER.TabIndex = 1;
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenido.Location = new System.Drawing.Point(16, 9);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(102, 20);
            this.labelBienvenido.TabIndex = 2;
            this.labelBienvenido.Text = "Bienvenido";
            // 
            // buttonCerrarSesion
            // 
            this.buttonCerrarSesion.Location = new System.Drawing.Point(823, 9);
            this.buttonCerrarSesion.Name = "buttonCerrarSesion";
            this.buttonCerrarSesion.Size = new System.Drawing.Size(91, 23);
            this.buttonCerrarSesion.TabIndex = 9;
            this.buttonCerrarSesion.Text = "Cerrar sesion";
            this.buttonCerrarSesion.UseVisualStyleBackColor = true;
            this.buttonCerrarSesion.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxIdiomaMostrar
            // 
            this.comboBoxIdiomaMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdiomaMostrar.FormattingEnabled = true;
            this.comboBoxIdiomaMostrar.Location = new System.Drawing.Point(20, 40);
            this.comboBoxIdiomaMostrar.Name = "comboBoxIdiomaMostrar";
            this.comboBoxIdiomaMostrar.Size = new System.Drawing.Size(150, 21);
            this.comboBoxIdiomaMostrar.TabIndex = 45;
            // 
            // buttonActualizarIdiomaMostrar
            // 
            this.buttonActualizarIdiomaMostrar.Location = new System.Drawing.Point(180, 38);
            this.buttonActualizarIdiomaMostrar.Name = "buttonActualizarIdiomaMostrar";
            this.buttonActualizarIdiomaMostrar.Size = new System.Drawing.Size(100, 23);
            this.buttonActualizarIdiomaMostrar.TabIndex = 46;
            this.buttonActualizarIdiomaMostrar.Text = "Actualizar";
            this.buttonActualizarIdiomaMostrar.UseVisualStyleBackColor = true;
            this.buttonActualizarIdiomaMostrar.Click += new System.EventHandler(this.buttonActualizarIdiomaMostrar_Click);
            // 
            // buttonAbrirUsuarios
            // 
            this.buttonAbrirUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbrirUsuarios.Location = new System.Drawing.Point(20, 80);
            this.buttonAbrirUsuarios.Name = "buttonAbrirUsuarios";
            this.buttonAbrirUsuarios.Size = new System.Drawing.Size(430, 50);
            this.buttonAbrirUsuarios.TabIndex = 47;
            this.buttonAbrirUsuarios.Text = "Usuarios y Permisos";
            this.buttonAbrirUsuarios.UseVisualStyleBackColor = true;
            this.buttonAbrirUsuarios.Click += new System.EventHandler(this.buttonAbrirUsuarios_Click);
            // 
            // buttonAbrirBitacora
            // 
            this.buttonAbrirBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbrirBitacora.Location = new System.Drawing.Point(470, 80);
            this.buttonAbrirBitacora.Name = "buttonAbrirBitacora";
            this.buttonAbrirBitacora.Size = new System.Drawing.Size(430, 50);
            this.buttonAbrirBitacora.TabIndex = 48;
            this.buttonAbrirBitacora.Text = "Bitácora";
            this.buttonAbrirBitacora.UseVisualStyleBackColor = true;
            this.buttonAbrirBitacora.Click += new System.EventHandler(this.buttonAbrirBitacora_Click);
            // 
            // buttonAbrirControlCambios
            // 
            this.buttonAbrirControlCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbrirControlCambios.Location = new System.Drawing.Point(20, 145);
            this.buttonAbrirControlCambios.Name = "buttonAbrirControlCambios";
            this.buttonAbrirControlCambios.Size = new System.Drawing.Size(430, 50);
            this.buttonAbrirControlCambios.TabIndex = 49;
            this.buttonAbrirControlCambios.Text = "Control de Cambios";
            this.buttonAbrirControlCambios.UseVisualStyleBackColor = true;
            this.buttonAbrirControlCambios.Click += new System.EventHandler(this.buttonAbrirControlCambios_Click);
            // 
            // buttonAbrirIdiomas
            // 
            this.buttonAbrirIdiomas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbrirIdiomas.Location = new System.Drawing.Point(470, 145);
            this.buttonAbrirIdiomas.Name = "buttonAbrirIdiomas";
            this.buttonAbrirIdiomas.Size = new System.Drawing.Size(430, 50);
            this.buttonAbrirIdiomas.TabIndex = 50;
            this.buttonAbrirIdiomas.Text = "Idiomas";
            this.buttonAbrirIdiomas.UseVisualStyleBackColor = true;
            this.buttonAbrirIdiomas.Click += new System.EventHandler(this.buttonAbrirIdiomas_Click);
            // 
            // PanelAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(924, 215);
            this.Controls.Add(this.buttonAbrirIdiomas);
            this.Controls.Add(this.buttonAbrirControlCambios);
            this.Controls.Add(this.buttonAbrirBitacora);
            this.Controls.Add(this.buttonAbrirUsuarios);
            this.Controls.Add(this.comboBoxIdiomaMostrar);
            this.Controls.Add(this.buttonActualizarIdiomaMostrar);
            this.Controls.Add(this.buttonCerrarSesion);
            this.Controls.Add(this.labelBienvenido);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.labelNOMBREUSER);
            this.Name = "PanelAdmin";
            this.Text = "Panel de Administración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PanelAdmin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Principal_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNOMBREUSER;
        private System.Windows.Forms.Label labelUSER;
        private System.Windows.Forms.Label labelBienvenido;
        private System.Windows.Forms.Button buttonCerrarSesion;
        private System.Windows.Forms.ComboBox comboBoxIdiomaMostrar;
        private System.Windows.Forms.Button buttonActualizarIdiomaMostrar;
        private System.Windows.Forms.Button buttonAbrirUsuarios;
        private System.Windows.Forms.Button buttonAbrirBitacora;
        private System.Windows.Forms.Button buttonAbrirControlCambios;
        private System.Windows.Forms.Button buttonAbrirIdiomas;
    }
}