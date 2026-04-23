namespace GUI
{
    partial class Menu_Principal
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
            this.SuspendLayout();
            // 
            // labelNOMBREUSER
            // 
            this.labelNOMBREUSER.AutoSize = true;
            this.labelNOMBREUSER.Location = new System.Drawing.Point(739, 5);
            this.labelNOMBREUSER.Name = "labelNOMBREUSER";
            this.labelNOMBREUSER.Size = new System.Drawing.Size(0, 13);
            this.labelNOMBREUSER.TabIndex = 0;
            this.labelNOMBREUSER.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelUSER
            // 
            this.labelUSER.AutoSize = true;
            this.labelUSER.Location = new System.Drawing.Point(704, 18);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(35, 13);
            this.labelUSER.TabIndex = 1;
            this.labelUSER.Text = "label1";
            this.labelUSER.Click += new System.EventHandler(this.labelUSER_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtNuevoUsuario
            // 
            this.txtNuevoUsuario.Location = new System.Drawing.Point(64, 59);
            this.txtNuevoUsuario.Name = "txtNuevoUsuario";
            this.txtNuevoUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoUsuario.TabIndex = 3;
            this.txtNuevoUsuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(64, 103);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaPassword.TabIndex = 5;
            this.txtNuevaPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "UsuarioBLL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(697, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cerrar sesion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.txtNuevoUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.labelNOMBREUSER);
            this.Name = "Menu_Principal";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Menu_Principal_Load_1);
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
    }
}