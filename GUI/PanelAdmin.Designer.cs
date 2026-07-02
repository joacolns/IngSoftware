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
            this.labelNuevoRol = new System.Windows.Forms.Label();
            this.textBoxNuevoRol = new System.Windows.Forms.TextBox();
            this.buttonCrearRol = new System.Windows.Forms.Button();
            this.labelSelectRol = new System.Windows.Forms.Label();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.listBoxPermisosRol = new System.Windows.Forms.ListBox();
            this.comboBoxPermisosTodos = new System.Windows.Forms.ComboBox();
            this.btnAsignarARol = new System.Windows.Forms.Button();
            this.btnQuitarDeRol = new System.Windows.Forms.Button();
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
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPageUsuarios = new System.Windows.Forms.TabPage();
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
            this.tabPageBitacora = new System.Windows.Forms.TabPage();
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
            this.tabPageControlCambios = new System.Windows.Forms.TabPage();
            this.labelControldecambios = new System.Windows.Forms.Label();
            this.dataGridViewControldecambios = new System.Windows.Forms.DataGridView();
            this.buttonRecomponerEstadoAnterior = new System.Windows.Forms.Button();
            this.tabPageIdiomas = new System.Windows.Forms.TabPage();
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
            this.comboBoxIdiomaMostrar = new System.Windows.Forms.ComboBox();
            this.buttonActualizarIdiomaMostrar = new System.Windows.Forms.Button();
            this.labelNOMBREUSER = new System.Windows.Forms.Label();
            this.labelUSER = new System.Windows.Forms.Label();
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.buttonCerrarSesion = new System.Windows.Forms.Button();
            this.tabControlAdmin.SuspendLayout();
            this.tabPageUsuarios.SuspendLayout();
            this.tabPageBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).BeginInit();
            this.tabPageControlCambios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).BeginInit();
            this.tabPageIdiomas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraducirControl)).BeginInit();
            this.SuspendLayout();
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
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPageUsuarios);
            this.tabControlAdmin.Controls.Add(this.tabPageBitacora);
            this.tabControlAdmin.Controls.Add(this.tabPageControlCambios);
            this.tabControlAdmin.Controls.Add(this.tabPageIdiomas);
            this.tabControlAdmin.Location = new System.Drawing.Point(10, 57);
            this.tabControlAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(904, 364);
            this.tabControlAdmin.TabIndex = 44;
            // 
            // tabPageUsuarios
            // 
            this.tabPageUsuarios.BackColor = System.Drawing.SystemColors.Info;
            this.tabPageUsuarios.Controls.Add(this.labelSelectUsuario);
            this.tabPageUsuarios.Controls.Add(this.comboBoxUsuarios);
            this.tabPageUsuarios.Controls.Add(this.labelUsuario);
            this.tabPageUsuarios.Controls.Add(this.txtNuevoUsuario);
            this.tabPageUsuarios.Controls.Add(this.labelContraseña);
            this.tabPageUsuarios.Controls.Add(this.txtNuevaPassword);
            this.tabPageUsuarios.Controls.Add(this.buttonRegistrarUsuario);
            this.tabPageUsuarios.Controls.Add(this.buttonModificarUsuario);
            this.tabPageUsuarios.Controls.Add(this.labelTreePermisos);
            this.tabPageUsuarios.Controls.Add(this.treePermisos);
            this.tabPageUsuarios.Controls.Add(this.btnAsignar);
            this.tabPageUsuarios.Controls.Add(this.btnQuitar);
            this.tabPageUsuarios.Controls.Add(this.labelPermisosUsuario);
            this.tabPageUsuarios.Controls.Add(this.listBoxPermisosUsuario);
            this.tabPageUsuarios.Controls.Add(this.labelNuevoRol);
            this.tabPageUsuarios.Controls.Add(this.textBoxNuevoRol);
            this.tabPageUsuarios.Controls.Add(this.buttonCrearRol);
            this.tabPageUsuarios.Controls.Add(this.labelSelectRol);
            this.tabPageUsuarios.Controls.Add(this.comboBoxRoles);
            this.tabPageUsuarios.Controls.Add(this.listBoxPermisosRol);
            this.tabPageUsuarios.Controls.Add(this.comboBoxPermisosTodos);
            this.tabPageUsuarios.Controls.Add(this.btnAsignarARol);
            this.tabPageUsuarios.Controls.Add(this.btnQuitarDeRol);
            this.tabPageUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageUsuarios.Name = "tabPageUsuarios";
            this.tabPageUsuarios.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageUsuarios.Size = new System.Drawing.Size(896, 338);
            this.tabPageUsuarios.TabIndex = 0;
            this.tabPageUsuarios.Text = "Usuarios y Permisos";
            // 
            // labelSelectUsuario
            // 
            this.labelSelectUsuario.AutoSize = true;
            this.labelSelectUsuario.Location = new System.Drawing.Point(200, 16);
            this.labelSelectUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectUsuario.Name = "labelSelectUsuario";
            this.labelSelectUsuario.Size = new System.Drawing.Size(105, 13);
            this.labelSelectUsuario.TabIndex = 22;
            this.labelSelectUsuario.Text = "Seleccionar Usuario:";
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(200, 31);
            this.comboBoxUsuarios.Margin = new System.Windows.Forms.Padding(2);
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
            this.txtNuevoUsuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(18, 73);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 7;
            this.labelContraseña.Text = "Contraseña";
            this.labelContraseña.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(22, 89);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaPassword.TabIndex = 5;
            this.txtNuevaPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonRegistrarUsuario
            // 
            this.buttonRegistrarUsuario.Location = new System.Drawing.Point(21, 171);
            this.buttonRegistrarUsuario.Name = "buttonRegistrarUsuario";
            this.buttonRegistrarUsuario.Size = new System.Drawing.Size(101, 38);
            this.buttonRegistrarUsuario.TabIndex = 8;
            this.buttonRegistrarUsuario.Text = "Registrar";
            this.buttonRegistrarUsuario.UseVisualStyleBackColor = true;
            this.buttonRegistrarUsuario.Click += new System.EventHandler(this.button1_Click);
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
            this.labelTreePermisos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTreePermisos.Name = "labelTreePermisos";
            this.labelTreePermisos.Size = new System.Drawing.Size(151, 13);
            this.labelTreePermisos.TabIndex = 24;
            this.labelTreePermisos.Text = "Árbol de Permisos Disponibles:";
            // 
            // treePermisos
            // 
            this.treePermisos.Location = new System.Drawing.Point(325, 31);
            this.treePermisos.Margin = new System.Windows.Forms.Padding(2);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(177, 158);
            this.treePermisos.TabIndex = 25;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(510, 52);
            this.btnAsignar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(65, 23);
            this.btnAsignar.TabIndex = 26;
            this.btnAsignar.Text = "Asignar >>";
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(510, 83);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(2);
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
            this.labelPermisosUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPermisosUsuario.Name = "labelPermisosUsuario";
            this.labelPermisosUsuario.Size = new System.Drawing.Size(150, 13);
            this.labelPermisosUsuario.TabIndex = 28;
            this.labelPermisosUsuario.Text = "Permisos Directos del Usuario:";
            // 
            // listBoxPermisosUsuario
            // 
            this.listBoxPermisosUsuario.Location = new System.Drawing.Point(585, 31);
            this.listBoxPermisosUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPermisosUsuario.Name = "listBoxPermisosUsuario";
            this.listBoxPermisosUsuario.Size = new System.Drawing.Size(127, 147);
            this.listBoxPermisosUsuario.TabIndex = 29;
            // 
            // tabPageBitacora
            // 
            this.tabPageBitacora.BackColor = System.Drawing.SystemColors.Info;
            this.tabPageBitacora.Controls.Add(this.labelBitacora);
            this.tabPageBitacora.Controls.Add(this.labelFechaInicio);
            this.tabPageBitacora.Controls.Add(this.dateTimePickerFechaInicio);
            this.tabPageBitacora.Controls.Add(this.labelFechaFinal);
            this.tabPageBitacora.Controls.Add(this.dateTimePickerFechaFinal);
            this.tabPageBitacora.Controls.Add(this.labelNombredeusuario);
            this.tabPageBitacora.Controls.Add(this.textBoxUsuarioBuscar);
            this.tabPageBitacora.Controls.Add(this.buttonBuscar);
            this.tabPageBitacora.Controls.Add(this.dataGridViewBitacora);
            this.tabPageBitacora.Controls.Add(this.btn_LimpiarBitacora);
            this.tabPageBitacora.Location = new System.Drawing.Point(4, 22);
            this.tabPageBitacora.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageBitacora.Name = "tabPageBitacora";
            this.tabPageBitacora.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageBitacora.Size = new System.Drawing.Size(896, 338);
            this.tabPageBitacora.TabIndex = 1;
            this.tabPageBitacora.Text = "Bitácora";
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
            this.labelFechaInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(65, 13);
            this.labelFechaInicio.TabIndex = 19;
            this.labelFechaInicio.Text = "Fecha Inicio";
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(111, 29);
            this.dateTimePickerFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(102, 20);
            this.dateTimePickerFechaInicio.TabIndex = 15;
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Location = new System.Drawing.Point(224, 12);
            this.labelFechaFinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(62, 13);
            this.labelFechaFinal.TabIndex = 20;
            this.labelFechaFinal.Text = "Fecha Final";
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(221, 29);
            this.dateTimePickerFechaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(102, 20);
            this.dateTimePickerFechaFinal.TabIndex = 16;
            // 
            // labelNombredeusuario
            // 
            this.labelNombredeusuario.AutoSize = true;
            this.labelNombredeusuario.Location = new System.Drawing.Point(331, 6);
            this.labelNombredeusuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombredeusuario.Name = "labelNombredeusuario";
            this.labelNombredeusuario.Size = new System.Drawing.Size(96, 13);
            this.labelNombredeusuario.TabIndex = 21;
            this.labelNombredeusuario.Text = "Nombre de usuario";
            this.labelNombredeusuario.Click += new System.EventHandler(this.label8_Click);
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
            this.dataGridViewBitacora.Margin = new System.Windows.Forms.Padding(2);
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
            // tabPageControlCambios
            // 
            this.tabPageControlCambios.BackColor = System.Drawing.SystemColors.Info;
            this.tabPageControlCambios.Controls.Add(this.labelControldecambios);
            this.tabPageControlCambios.Controls.Add(this.dataGridViewControldecambios);
            this.tabPageControlCambios.Controls.Add(this.buttonRecomponerEstadoAnterior);
            this.tabPageControlCambios.Controls.Add(this.labelSelectUsuarioCambio);
            this.tabPageControlCambios.Controls.Add(this.comboBoxUsuarioCambio);
            this.tabPageControlCambios.Controls.Add(this.labelFechaInicioCambio);
            this.tabPageControlCambios.Controls.Add(this.dateTimePickerInicioCambio);
            this.tabPageControlCambios.Controls.Add(this.labelFechaFinCambio);
            this.tabPageControlCambios.Controls.Add(this.dateTimePickerFinCambio);
            this.tabPageControlCambios.Controls.Add(this.labelTipoCambio);
            this.tabPageControlCambios.Controls.Add(this.comboBoxTipoCambio);
            this.tabPageControlCambios.Controls.Add(this.btnFiltrarCambio);
            this.tabPageControlCambios.Controls.Add(this.btnLimpiarFiltrosCambio);
            this.tabPageControlCambios.Location = new System.Drawing.Point(4, 22);
            this.tabPageControlCambios.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageControlCambios.Name = "tabPageControlCambios";
            this.tabPageControlCambios.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageControlCambios.Size = new System.Drawing.Size(896, 338);
            this.tabPageControlCambios.TabIndex = 2;
            this.tabPageControlCambios.Text = "Control de Cambios";
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
            this.dataGridViewControldecambios.Margin = new System.Windows.Forms.Padding(2);
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
            // 
            // tabPageIdiomas
            // 
            this.tabPageIdiomas.BackColor = System.Drawing.SystemColors.Info;
            this.tabPageIdiomas.Controls.Add(this.labelManejodeidiomas);
            this.tabPageIdiomas.Controls.Add(this.labelIdioma);
            this.tabPageIdiomas.Controls.Add(this.comboBoxIdioma);
            this.tabPageIdiomas.Controls.Add(this.buttonActivarIdioma);
            this.tabPageIdiomas.Controls.Add(this.buttonDesactivarIdioma);
            this.tabPageIdiomas.Controls.Add(this.labelNombredelidioma);
            this.tabPageIdiomas.Controls.Add(this.textBoxAgregarNombreIdioma);
            this.tabPageIdiomas.Controls.Add(this.buttonAgregarIdioma);
            this.tabPageIdiomas.Controls.Add(this.buttonAplicarCambiosIdioma);
            this.tabPageIdiomas.Controls.Add(this.dataGridViewTraducirControl);
            this.tabPageIdiomas.Location = new System.Drawing.Point(4, 22);
            this.tabPageIdiomas.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageIdiomas.Name = "tabPageIdiomas";
            this.tabPageIdiomas.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageIdiomas.Size = new System.Drawing.Size(896, 338);
            this.tabPageIdiomas.TabIndex = 3;
            this.tabPageIdiomas.Text = "Idiomas";
            // 
            // labelManejodeidiomas
            // 
            this.labelManejodeidiomas.AutoSize = true;
            this.labelManejodeidiomas.Location = new System.Drawing.Point(19, 15);
            this.labelManejodeidiomas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.comboBoxIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxIdioma.Name = "comboBoxIdioma";
            this.comboBoxIdioma.Size = new System.Drawing.Size(162, 21);
            this.comboBoxIdioma.TabIndex = 36;
            // 
            // buttonActivarIdioma
            // 
            this.buttonActivarIdioma.Location = new System.Drawing.Point(264, 35);
            this.buttonActivarIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActivarIdioma.Name = "buttonActivarIdioma";
            this.buttonActivarIdioma.Size = new System.Drawing.Size(93, 52);
            this.buttonActivarIdioma.TabIndex = 38;
            this.buttonActivarIdioma.Text = "Activar idioma";
            this.buttonActivarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonDesactivarIdioma
            // 
            this.buttonDesactivarIdioma.Location = new System.Drawing.Point(360, 35);
            this.buttonDesactivarIdioma.Margin = new System.Windows.Forms.Padding(2);
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
            this.labelNombredelidioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombredelidioma.Name = "labelNombredelidioma";
            this.labelNombredelidioma.Size = new System.Drawing.Size(94, 13);
            this.labelNombredelidioma.TabIndex = 40;
            this.labelNombredelidioma.Text = "Nombre del idioma";
            this.labelNombredelidioma.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxAgregarNombreIdioma
            // 
            this.textBoxAgregarNombreIdioma.Location = new System.Drawing.Point(622, 62);
            this.textBoxAgregarNombreIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAgregarNombreIdioma.Name = "textBoxAgregarNombreIdioma";
            this.textBoxAgregarNombreIdioma.Size = new System.Drawing.Size(141, 20);
            this.textBoxAgregarNombreIdioma.TabIndex = 41;
            // 
            // buttonAgregarIdioma
            // 
            this.buttonAgregarIdioma.Location = new System.Drawing.Point(764, 62);
            this.buttonAgregarIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgregarIdioma.Name = "buttonAgregarIdioma";
            this.buttonAgregarIdioma.Size = new System.Drawing.Size(120, 52);
            this.buttonAgregarIdioma.TabIndex = 42;
            this.buttonAgregarIdioma.Text = "Agregar";
            this.buttonAgregarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonAplicarCambiosIdioma
            // 
            this.buttonAplicarCambiosIdioma.Location = new System.Drawing.Point(264, 87);
            this.buttonAplicarCambiosIdioma.Margin = new System.Windows.Forms.Padding(2);
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
            this.dataGridViewTraducirControl.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTraducirControl.Name = "dataGridViewTraducirControl";
            this.dataGridViewTraducirControl.RowHeadersWidth = 82;
            this.dataGridViewTraducirControl.RowTemplate.Height = 33;
            this.dataGridViewTraducirControl.Size = new System.Drawing.Size(863, 188);
            this.dataGridViewTraducirControl.TabIndex = 34;
            // 
            // comboBoxIdiomaMostrar
            // 
            this.comboBoxIdiomaMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdiomaMostrar.FormattingEnabled = true;
            this.comboBoxIdiomaMostrar.Location = new System.Drawing.Point(20, 20);
            this.comboBoxIdiomaMostrar.Name = "comboBoxIdiomaMostrar";
            this.comboBoxIdiomaMostrar.Size = new System.Drawing.Size(150, 21);
            this.comboBoxIdiomaMostrar.TabIndex = 45;
            // 
            // buttonActualizarIdiomaMostrar
            // 
            this.buttonActualizarIdiomaMostrar.Location = new System.Drawing.Point(180, 18);
            this.buttonActualizarIdiomaMostrar.Name = "buttonActualizarIdiomaMostrar";
            this.buttonActualizarIdiomaMostrar.Size = new System.Drawing.Size(100, 23);
            this.buttonActualizarIdiomaMostrar.TabIndex = 46;
            this.buttonActualizarIdiomaMostrar.Text = "Actualizar";
            this.buttonActualizarIdiomaMostrar.UseVisualStyleBackColor = true;
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
            this.labelUSER.Location = new System.Drawing.Point(878, 11);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(35, 13);
            this.labelUSER.TabIndex = 1;
            this.labelUSER.Text = "label1";
            this.labelUSER.Click += new System.EventHandler(this.labelUSER_Click);
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Location = new System.Drawing.Point(812, 11);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(60, 13);
            this.labelBienvenido.TabIndex = 2;
            this.labelBienvenido.Text = "Bienvenido";
            this.labelBienvenido.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // buttonCerrarSesion
            // 
            this.buttonCerrarSesion.Location = new System.Drawing.Point(822, 29);
            this.buttonCerrarSesion.Name = "buttonCerrarSesion";
            this.buttonCerrarSesion.Size = new System.Drawing.Size(91, 23);
            this.buttonCerrarSesion.TabIndex = 9;
            this.buttonCerrarSesion.Text = "Cerrar sesion";
            this.buttonCerrarSesion.UseVisualStyleBackColor = true;
            this.buttonCerrarSesion.Click += new System.EventHandler(this.button2_Click);
            // 
            // PanelAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(924, 442);
            this.Controls.Add(this.comboBoxIdiomaMostrar);
            this.Controls.Add(this.buttonActualizarIdiomaMostrar);
            this.Controls.Add(this.tabControlAdmin);
            this.Controls.Add(this.buttonCerrarSesion);
            this.Controls.Add(this.labelBienvenido);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.labelNOMBREUSER);
            this.Name = "PanelAdmin";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PanelAdmin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Principal_Load_1);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabPageUsuarios.ResumeLayout(false);
            this.tabPageUsuarios.PerformLayout();
            this.tabPageBitacora.ResumeLayout(false);
            this.tabPageBitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).EndInit();
            this.tabPageControlCambios.ResumeLayout(false);
            this.tabPageControlCambios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).EndInit();
            this.tabPageIdiomas.ResumeLayout(false);
            this.tabPageIdiomas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraducirControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
 
        #endregion
 
        private System.Windows.Forms.Label labelNOMBREUSER;
        private System.Windows.Forms.Label labelUSER;
        private System.Windows.Forms.Label labelBienvenido;
        private System.Windows.Forms.TextBox txtNuevoUsuario;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Button buttonRegistrarUsuario;
        private System.Windows.Forms.Button buttonCerrarSesion;
        private System.Windows.Forms.DataGridView dataGridViewBitacora;
        private System.Windows.Forms.Label labelBitacora;
        private System.Windows.Forms.Button btn_LimpiarBitacora;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinal;
        private System.Windows.Forms.TextBox textBoxUsuarioBuscar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.Label labelFechaFinal;
        private System.Windows.Forms.Label labelNombredeusuario;
        private System.Windows.Forms.Label labelSelectUsuario;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Label labelTreePermisos;
        private System.Windows.Forms.TreeView treePermisos;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label labelPermisosUsuario;
        private System.Windows.Forms.ListBox listBoxPermisosUsuario;
        private System.Windows.Forms.DataGridView dataGridViewControldecambios;
        private System.Windows.Forms.Label labelControldecambios;
        private System.Windows.Forms.Button buttonRecomponerEstadoAnterior;
        private System.Windows.Forms.Button buttonModificarUsuario;
        private System.Windows.Forms.DataGridView dataGridViewTraducirControl;
        private System.Windows.Forms.Label labelManejodeidiomas;
        private System.Windows.Forms.ComboBox comboBoxIdioma;
        private System.Windows.Forms.Label labelIdioma;
        private System.Windows.Forms.Button buttonActivarIdioma;
        private System.Windows.Forms.Button buttonDesactivarIdioma;
        private System.Windows.Forms.Label labelNombredelidioma;
        private System.Windows.Forms.TextBox textBoxAgregarNombreIdioma;
        private System.Windows.Forms.Button buttonAgregarIdioma;
        private System.Windows.Forms.Button buttonAplicarCambiosIdioma;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPageUsuarios;
        private System.Windows.Forms.TabPage tabPageBitacora;
        private System.Windows.Forms.TabPage tabPageControlCambios;
        private System.Windows.Forms.TabPage tabPageIdiomas;
        private System.Windows.Forms.ComboBox comboBoxIdiomaMostrar;
        private System.Windows.Forms.Button buttonActualizarIdiomaMostrar;
        private System.Windows.Forms.Label labelNuevoRol;
        private System.Windows.Forms.TextBox textBoxNuevoRol;
        private System.Windows.Forms.Button buttonCrearRol;
        private System.Windows.Forms.Label labelSelectRol;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button btnAsignarARol;
        private System.Windows.Forms.Button btnQuitarDeRol;
        private System.Windows.Forms.ListBox listBoxPermisosRol;
        private System.Windows.Forms.ComboBox comboBoxPermisosTodos;
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