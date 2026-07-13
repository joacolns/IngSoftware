namespace GUI
{
    partial class FormUsuarios
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
            this.labelSelectUsuario = new System.Windows.Forms.Label();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.txtNuevoUsuario = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.buttonRegistrarUsuario = new System.Windows.Forms.Button();
            this.buttonModificarUsuario = new System.Windows.Forms.Button();
            this.labelTreePermisos = new System.Windows.Forms.Label();
            this.treePermisos = new System.Windows.Forms.TreeView();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.labelPermisosUsuario = new System.Windows.Forms.Label();
            this.listBoxPermisosUsuario = new System.Windows.Forms.ListBox();
            this.labelNuevoRol = new System.Windows.Forms.Label();
            this.textBoxNuevoRol = new System.Windows.Forms.TextBox();
            this.buttonCrearRol = new System.Windows.Forms.Button();
            this.labelSelectRol = new System.Windows.Forms.Label();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.listBoxPermisosRol = new System.Windows.Forms.ListBox();
            this.comboBoxPermisosTodos = new System.Windows.Forms.ComboBox();
            this.btnAsignarARol = new System.Windows.Forms.Button();
            this.btnQuitarDeRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSelectUsuario
            // 
            this.labelSelectUsuario.AutoSize = true;
            this.labelSelectUsuario.Location = new System.Drawing.Point(200, 16);
            this.labelSelectUsuario.Name = "labelSelectUsuario";
            this.labelSelectUsuario.Size = new System.Drawing.Size(105, 13);
            this.labelSelectUsuario.TabIndex = 22;
            this.labelSelectUsuario.Text = "Seleccionar Usuario:";
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(200, 31);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(112, 21);
            this.comboBoxUsuarios.TabIndex = 23;
            this.comboBoxUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(18, 29);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 6;
            this.labelUsuario.Text = "Usuario";
            // 
            // txtNuevoUsuario
            // 
            this.txtNuevoUsuario.Location = new System.Drawing.Point(22, 45);
            this.txtNuevoUsuario.Name = "txtNuevoUsuario";
            this.txtNuevoUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoUsuario.TabIndex = 3;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(18, 73);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 7;
            this.labelContraseña.Text = "Contraseña";
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(22, 89);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaPassword.TabIndex = 5;
            // 
            // buttonRegistrarUsuario
            // 
            this.buttonRegistrarUsuario.Location = new System.Drawing.Point(21, 171);
            this.buttonRegistrarUsuario.Name = "buttonRegistrarUsuario";
            this.buttonRegistrarUsuario.Size = new System.Drawing.Size(101, 38);
            this.buttonRegistrarUsuario.TabIndex = 8;
            this.buttonRegistrarUsuario.Text = "Registrar";
            this.buttonRegistrarUsuario.UseVisualStyleBackColor = true;
            this.buttonRegistrarUsuario.Click += new System.EventHandler(this.buttonRegistrarUsuario_Click);
            // 
            // buttonModificarUsuario
            // 
            this.buttonModificarUsuario.Location = new System.Drawing.Point(130, 171);
            this.buttonModificarUsuario.Name = "buttonModificarUsuario";
            this.buttonModificarUsuario.Size = new System.Drawing.Size(101, 38);
            this.buttonModificarUsuario.TabIndex = 33;
            this.buttonModificarUsuario.Text = "Modificar";
            this.buttonModificarUsuario.UseVisualStyleBackColor = true;
            this.buttonModificarUsuario.Click += new System.EventHandler(this.buttonModificarUsuario_Click);
            // 
            // labelTreePermisos
            // 
            this.labelTreePermisos.AutoSize = true;
            this.labelTreePermisos.Location = new System.Drawing.Point(325, 16);
            this.labelTreePermisos.Name = "labelTreePermisos";
            this.labelTreePermisos.Size = new System.Drawing.Size(151, 13);
            this.labelTreePermisos.TabIndex = 24;
            this.labelTreePermisos.Text = "Árbol de Permisos Disponibles:";
            // 
            // treePermisos
            // 
            this.treePermisos.Location = new System.Drawing.Point(325, 31);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(177, 158);
            this.treePermisos.TabIndex = 25;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(510, 52);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(65, 23);
            this.btnAsignar.TabIndex = 26;
            this.btnAsignar.Text = "Asignar >>";
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(510, 83);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(65, 23);
            this.btnQuitar.TabIndex = 27;
            this.btnQuitar.Text = "<< Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // labelPermisosUsuario
            // 
            this.labelPermisosUsuario.AutoSize = true;
            this.labelPermisosUsuario.Location = new System.Drawing.Point(581, 16);
            this.labelPermisosUsuario.Name = "labelPermisosUsuario";
            this.labelPermisosUsuario.Size = new System.Drawing.Size(150, 13);
            this.labelPermisosUsuario.TabIndex = 28;
            this.labelPermisosUsuario.Text = "Permisos Directos del Usuario:";
            // 
            // listBoxPermisosUsuario
            // 
            this.listBoxPermisosUsuario.Location = new System.Drawing.Point(585, 31);
            this.listBoxPermisosUsuario.Name = "listBoxPermisosUsuario";
            this.listBoxPermisosUsuario.Size = new System.Drawing.Size(127, 147);
            this.listBoxPermisosUsuario.TabIndex = 29;
            // 
            // labelNuevoRol
            // 
            this.labelNuevoRol.AutoSize = true;
            this.labelNuevoRol.Location = new System.Drawing.Point(325, 200);
            this.labelNuevoRol.Name = "labelNuevoRol";
            this.labelNuevoRol.Size = new System.Drawing.Size(61, 13);
            this.labelNuevoRol.TabIndex = 47;
            this.labelNuevoRol.Text = "Nuevo Rol:";
            // 
            // textBoxNuevoRol
            // 
            this.textBoxNuevoRol.Location = new System.Drawing.Point(325, 220);
            this.textBoxNuevoRol.Name = "textBoxNuevoRol";
            this.textBoxNuevoRol.Size = new System.Drawing.Size(100, 20);
            this.textBoxNuevoRol.TabIndex = 48;
            // 
            // buttonCrearRol
            // 
            this.buttonCrearRol.Location = new System.Drawing.Point(430, 218);
            this.buttonCrearRol.Name = "buttonCrearRol";
            this.buttonCrearRol.Size = new System.Drawing.Size(70, 23);
            this.buttonCrearRol.TabIndex = 49;
            this.buttonCrearRol.Text = "Crear";
            this.buttonCrearRol.UseVisualStyleBackColor = true;
            this.buttonCrearRol.Click += new System.EventHandler(this.buttonCrearRol_Click);
            // 
            // labelSelectRol
            // 
            this.labelSelectRol.AutoSize = true;
            this.labelSelectRol.Location = new System.Drawing.Point(585, 200);
            this.labelSelectRol.Name = "labelSelectRol";
            this.labelSelectRol.Size = new System.Drawing.Size(56, 13);
            this.labelSelectRol.TabIndex = 50;
            this.labelSelectRol.Text = "Editar Rol:";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.Location = new System.Drawing.Point(585, 220);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(127, 21);
            this.comboBoxRoles.TabIndex = 51;
            this.comboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoles_SelectedIndexChanged);
            // 
            // listBoxPermisosRol
            // 
            this.listBoxPermisosRol.Location = new System.Drawing.Point(585, 250);
            this.listBoxPermisosRol.Name = "listBoxPermisosRol";
            this.listBoxPermisosRol.Size = new System.Drawing.Size(127, 69);
            this.listBoxPermisosRol.TabIndex = 52;
            // 
            // comboBoxPermisosTodos
            // 
            this.comboBoxPermisosTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermisosTodos.Location = new System.Drawing.Point(450, 250);
            this.comboBoxPermisosTodos.Name = "comboBoxPermisosTodos";
            this.comboBoxPermisosTodos.Size = new System.Drawing.Size(125, 21);
            this.comboBoxPermisosTodos.TabIndex = 53;
            // 
            // btnAsignarARol
            // 
            this.btnAsignarARol.Location = new System.Drawing.Point(510, 275);
            this.btnAsignarARol.Name = "btnAsignarARol";
            this.btnAsignarARol.Size = new System.Drawing.Size(65, 23);
            this.btnAsignarARol.TabIndex = 54;
            this.btnAsignarARol.Text = "Asig. Rol";
            this.btnAsignarARol.UseVisualStyleBackColor = true;
            this.btnAsignarARol.Click += new System.EventHandler(this.btnAsignarARol_Click);
            // 
            // btnQuitarDeRol
            // 
            this.btnQuitarDeRol.Location = new System.Drawing.Point(510, 305);
            this.btnQuitarDeRol.Name = "btnQuitarDeRol";
            this.btnQuitarDeRol.Size = new System.Drawing.Size(65, 23);
            this.btnQuitarDeRol.TabIndex = 55;
            this.btnQuitarDeRol.Text = "Quit. Rol";
            this.btnQuitarDeRol.UseVisualStyleBackColor = true;
            this.btnQuitarDeRol.Click += new System.EventHandler(this.btnQuitarDeRol_Click);
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(730, 350);
            this.Controls.Add(this.labelSelectUsuario);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.txtNuevoUsuario);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.buttonRegistrarUsuario);
            this.Controls.Add(this.buttonModificarUsuario);
            this.Controls.Add(this.labelTreePermisos);
            this.Controls.Add(this.treePermisos);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.labelPermisosUsuario);
            this.Controls.Add(this.listBoxPermisosUsuario);
            this.Controls.Add(this.labelNuevoRol);
            this.Controls.Add(this.textBoxNuevoRol);
            this.Controls.Add(this.buttonCrearRol);
            this.Controls.Add(this.labelSelectRol);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.listBoxPermisosRol);
            this.Controls.Add(this.comboBoxPermisosTodos);
            this.Controls.Add(this.btnAsignarARol);
            this.Controls.Add(this.btnQuitarDeRol);
            this.Name = "FormUsuarios";
            this.Text = "Usuarios y Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUsuarios_FormClosing);
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectUsuario;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox txtNuevoUsuario;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Button buttonRegistrarUsuario;
        private System.Windows.Forms.Button buttonModificarUsuario;
        private System.Windows.Forms.Label labelTreePermisos;
        private System.Windows.Forms.TreeView treePermisos;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label labelPermisosUsuario;
        private System.Windows.Forms.ListBox listBoxPermisosUsuario;
        private System.Windows.Forms.Label labelNuevoRol;
        private System.Windows.Forms.TextBox textBoxNuevoRol;
        private System.Windows.Forms.Button buttonCrearRol;
        private System.Windows.Forms.Label labelSelectRol;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.ListBox listBoxPermisosRol;
        private System.Windows.Forms.ComboBox comboBoxPermisosTodos;
        private System.Windows.Forms.Button btnAsignarARol;
        private System.Windows.Forms.Button btnQuitarDeRol;
    }
}
