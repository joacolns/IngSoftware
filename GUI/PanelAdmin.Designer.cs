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
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.txtNuevoUsuario = new System.Windows.Forms.TextBox();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.buttonRegistrarUsuario = new System.Windows.Forms.Button();
            this.buttonCerrarSesion = new System.Windows.Forms.Button();
            this.dataGridViewBitacora = new System.Windows.Forms.DataGridView();
            this.labelBitacora = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelRol = new System.Windows.Forms.Label();
            this.btn_LimpiarBitacora = new System.Windows.Forms.Button();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.textBoxUsuarioBuscar = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.labelFechaFinal = new System.Windows.Forms.Label();
            this.labelNombredeusuario = new System.Windows.Forms.Label();
            this.labelSelectUsuario = new System.Windows.Forms.Label();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.labelTreePermisos = new System.Windows.Forms.Label();
            this.treePermisos = new System.Windows.Forms.TreeView();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.labelPermisosUsuario = new System.Windows.Forms.Label();
            this.listBoxPermisosUsuario = new System.Windows.Forms.ListBox();
            this.dataGridViewControldecambios = new System.Windows.Forms.DataGridView();
            this.labelControldecambios = new System.Windows.Forms.Label();
            this.buttonRecomponerEstadoAnterior = new System.Windows.Forms.Button();
            this.buttonModificarUsuario = new System.Windows.Forms.Button();
            this.dataGridViewTraducirControl = new System.Windows.Forms.DataGridView();
            this.labelManejodeidiomas = new System.Windows.Forms.Label();
            this.comboBoxIdioma = new System.Windows.Forms.ComboBox();
            this.labelIdioma = new System.Windows.Forms.Label();
            this.buttonActivarIdioma = new System.Windows.Forms.Button();
            this.buttonDesactivarIdioma = new System.Windows.Forms.Button();
            this.labelNombredelidioma = new System.Windows.Forms.Label();
            this.textBoxAgregarNombreIdioma = new System.Windows.Forms.TextBox();
            this.buttonAgregarIdioma = new System.Windows.Forms.Button();
            this.buttonAplicarCambiosIdioma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraducirControl)).BeginInit();
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
            this.labelUSER.Location = new System.Drawing.Point(1755, 21);
            this.labelUSER.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(70, 25);
            this.labelUSER.TabIndex = 1;
            this.labelUSER.Text = "label1";
            this.labelUSER.Click += new System.EventHandler(this.labelUSER_Click);
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Location = new System.Drawing.Point(1624, 21);
            this.labelBienvenido.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(119, 25);
            this.labelBienvenido.TabIndex = 2;
            this.labelBienvenido.Text = "Bienvenido";
            this.labelBienvenido.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtNuevoUsuario
            // 
            this.txtNuevoUsuario.Location = new System.Drawing.Point(44, 87);
            this.txtNuevoUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtNuevoUsuario.Name = "txtNuevoUsuario";
            this.txtNuevoUsuario.Size = new System.Drawing.Size(196, 31);
            this.txtNuevoUsuario.TabIndex = 3;
            this.txtNuevoUsuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(44, 171);
            this.txtNuevaPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(196, 31);
            this.txtNuevaPassword.TabIndex = 5;
            this.txtNuevaPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(36, 56);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(86, 25);
            this.labelUsuario.TabIndex = 6;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(36, 140);
            this.labelContraseña.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(123, 25);
            this.labelContraseña.TabIndex = 7;
            this.labelContraseña.Text = "Contraseña";
            this.labelContraseña.Click += new System.EventHandler(this.label3_Click);
            // 
            // buttonRegistrarUsuario
            // 
            this.buttonRegistrarUsuario.Location = new System.Drawing.Point(42, 329);
            this.buttonRegistrarUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRegistrarUsuario.Name = "buttonRegistrarUsuario";
            this.buttonRegistrarUsuario.Size = new System.Drawing.Size(202, 73);
            this.buttonRegistrarUsuario.TabIndex = 8;
            this.buttonRegistrarUsuario.Text = "Registrar";
            this.buttonRegistrarUsuario.UseVisualStyleBackColor = true;
            this.buttonRegistrarUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCerrarSesion
            // 
            this.buttonCerrarSesion.Location = new System.Drawing.Point(1643, 56);
            this.buttonCerrarSesion.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCerrarSesion.Name = "buttonCerrarSesion";
            this.buttonCerrarSesion.Size = new System.Drawing.Size(182, 44);
            this.buttonCerrarSesion.TabIndex = 9;
            this.buttonCerrarSesion.Text = "Cerrar sesion";
            this.buttonCerrarSesion.UseVisualStyleBackColor = true;
            this.buttonCerrarSesion.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewBitacora
            // 
            this.dataGridViewBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBitacora.Location = new System.Drawing.Point(42, 498);
            this.dataGridViewBitacora.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBitacora.Name = "dataGridViewBitacora";
            this.dataGridViewBitacora.RowHeadersWidth = 82;
            this.dataGridViewBitacora.RowTemplate.Height = 33;
            this.dataGridViewBitacora.Size = new System.Drawing.Size(893, 383);
            this.dataGridViewBitacora.TabIndex = 10;
            // 
            // labelBitacora
            // 
            this.labelBitacora.AutoSize = true;
            this.labelBitacora.Location = new System.Drawing.Point(36, 456);
            this.labelBitacora.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBitacora.Name = "labelBitacora";
            this.labelBitacora.Size = new System.Drawing.Size(91, 25);
            this.labelBitacora.TabIndex = 11;
            this.labelBitacora.Text = "Bitacora";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "usuario",
            "admin"});
            this.comboBox1.Location = new System.Drawing.Point(44, 258);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 33);
            this.comboBox1.TabIndex = 12;
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Location = new System.Drawing.Point(38, 227);
            this.labelRol.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(44, 25);
            this.labelRol.TabIndex = 13;
            this.labelRol.Text = "Rol";
            // 
            // btn_LimpiarBitacora
            // 
            this.btn_LimpiarBitacora.Location = new System.Drawing.Point(41, 891);
            this.btn_LimpiarBitacora.Margin = new System.Windows.Forms.Padding(6);
            this.btn_LimpiarBitacora.Name = "btn_LimpiarBitacora";
            this.btn_LimpiarBitacora.Size = new System.Drawing.Size(218, 73);
            this.btn_LimpiarBitacora.TabIndex = 14;
            this.btn_LimpiarBitacora.Text = "Limpiar";
            this.btn_LimpiarBitacora.UseVisualStyleBackColor = true;
            this.btn_LimpiarBitacora.Click += new System.EventHandler(this.btn_LimpiarBitacora_Click);
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(222, 456);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerFechaInicio.TabIndex = 15;
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(442, 456);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerFechaFinal.TabIndex = 16;
            // 
            // textBoxUsuarioBuscar
            // 
            this.textBoxUsuarioBuscar.Location = new System.Drawing.Point(667, 453);
            this.textBoxUsuarioBuscar.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxUsuarioBuscar.Name = "textBoxUsuarioBuscar";
            this.textBoxUsuarioBuscar.Size = new System.Drawing.Size(196, 31);
            this.textBoxUsuarioBuscar.TabIndex = 17;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(887, 414);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(202, 73);
            this.buttonBuscar.TabIndex = 18;
            this.buttonBuscar.Text = "Filtrar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(217, 417);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(128, 25);
            this.labelFechaInicio.TabIndex = 19;
            this.labelFechaInicio.Text = "Fecha Inicio";
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Location = new System.Drawing.Point(447, 423);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(125, 25);
            this.labelFechaFinal.TabIndex = 20;
            this.labelFechaFinal.Text = "Fecha Final";
            // 
            // labelNombredeusuario
            // 
            this.labelNombredeusuario.AutoSize = true;
            this.labelNombredeusuario.Location = new System.Drawing.Point(662, 411);
            this.labelNombredeusuario.Name = "labelNombredeusuario";
            this.labelNombredeusuario.Size = new System.Drawing.Size(194, 25);
            this.labelNombredeusuario.TabIndex = 21;
            this.labelNombredeusuario.Text = "Nombre de usuario";
            this.labelNombredeusuario.Click += new System.EventHandler(this.label8_Click);
            // 
            // labelSelectUsuario
            // 
            this.labelSelectUsuario.AutoSize = true;
            this.labelSelectUsuario.Location = new System.Drawing.Point(400, 30);
            this.labelSelectUsuario.Name = "labelSelectUsuario";
            this.labelSelectUsuario.Size = new System.Drawing.Size(211, 25);
            this.labelSelectUsuario.TabIndex = 22;
            this.labelSelectUsuario.Text = "Seleccionar Usuario:";
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(400, 60);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(220, 33);
            this.comboBoxUsuarios.TabIndex = 23;
            this.comboBoxUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // labelTreePermisos
            // 
            this.labelTreePermisos.AutoSize = true;
            this.labelTreePermisos.Location = new System.Drawing.Point(650, 30);
            this.labelTreePermisos.Name = "labelTreePermisos";
            this.labelTreePermisos.Size = new System.Drawing.Size(311, 25);
            this.labelTreePermisos.TabIndex = 24;
            this.labelTreePermisos.Text = "Árbol de Permisos Disponibles:";
            // 
            // treePermisos
            // 
            this.treePermisos.Location = new System.Drawing.Point(650, 60);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(350, 300);
            this.treePermisos.TabIndex = 25;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(1020, 100);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(130, 45);
            this.btnAsignar.TabIndex = 26;
            this.btnAsignar.Text = "Asignar >>";
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(1020, 160);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(130, 45);
            this.btnQuitar.TabIndex = 27;
            this.btnQuitar.Text = "<< Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // labelPermisosUsuario
            // 
            this.labelPermisosUsuario.AutoSize = true;
            this.labelPermisosUsuario.Location = new System.Drawing.Point(1162, 30);
            this.labelPermisosUsuario.Name = "labelPermisosUsuario";
            this.labelPermisosUsuario.Size = new System.Drawing.Size(307, 25);
            this.labelPermisosUsuario.TabIndex = 28;
            this.labelPermisosUsuario.Text = "Permisos Directos del Usuario:";
            // 
            // listBoxPermisosUsuario
            // 
            this.listBoxPermisosUsuario.ItemHeight = 25;
            this.listBoxPermisosUsuario.Location = new System.Drawing.Point(1170, 60);
            this.listBoxPermisosUsuario.Name = "listBoxPermisosUsuario";
            this.listBoxPermisosUsuario.Size = new System.Drawing.Size(250, 279);
            this.listBoxPermisosUsuario.TabIndex = 29;
            // 
            // dataGridViewControldecambios
            // 
            this.dataGridViewControldecambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewControldecambios.Location = new System.Drawing.Point(1182, 498);
            this.dataGridViewControldecambios.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewControldecambios.Name = "dataGridViewControldecambios";
            this.dataGridViewControldecambios.RowHeadersWidth = 82;
            this.dataGridViewControldecambios.RowTemplate.Height = 33;
            this.dataGridViewControldecambios.Size = new System.Drawing.Size(587, 383);
            this.dataGridViewControldecambios.TabIndex = 30;
            // 
            // labelControldecambios
            // 
            this.labelControldecambios.AutoSize = true;
            this.labelControldecambios.Location = new System.Drawing.Point(1177, 456);
            this.labelControldecambios.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelControldecambios.Name = "labelControldecambios";
            this.labelControldecambios.Size = new System.Drawing.Size(197, 25);
            this.labelControldecambios.TabIndex = 31;
            this.labelControldecambios.Text = "Control de cambios";
            // 
            // buttonRecomponerEstadoAnterior
            // 
            this.buttonRecomponerEstadoAnterior.Location = new System.Drawing.Point(1182, 891);
            this.buttonRecomponerEstadoAnterior.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRecomponerEstadoAnterior.Name = "buttonRecomponerEstadoAnterior";
            this.buttonRecomponerEstadoAnterior.Size = new System.Drawing.Size(393, 73);
            this.buttonRecomponerEstadoAnterior.TabIndex = 32;
            this.buttonRecomponerEstadoAnterior.Text = "Recomponer estado anterior";
            this.buttonRecomponerEstadoAnterior.UseVisualStyleBackColor = true;
            // 
            // buttonModificarUsuario
            // 
            this.buttonModificarUsuario.Location = new System.Drawing.Point(260, 329);
            this.buttonModificarUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.buttonModificarUsuario.Name = "buttonModificarUsuario";
            this.buttonModificarUsuario.Size = new System.Drawing.Size(202, 73);
            this.buttonModificarUsuario.TabIndex = 33;
            this.buttonModificarUsuario.Text = "Modificar";
            this.buttonModificarUsuario.UseVisualStyleBackColor = true;
            this.buttonModificarUsuario.Click += new System.EventHandler(this.buttonModificarUsuario_Click);
            // 
            // dataGridViewTraducirControl
            // 
            this.dataGridViewTraducirControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTraducirControl.Location = new System.Drawing.Point(43, 1196);
            this.dataGridViewTraducirControl.Name = "dataGridViewTraducirControl";
            this.dataGridViewTraducirControl.RowHeadersWidth = 82;
            this.dataGridViewTraducirControl.RowTemplate.Height = 33;
            this.dataGridViewTraducirControl.Size = new System.Drawing.Size(1726, 293);
            this.dataGridViewTraducirControl.TabIndex = 34;
            // 
            // labelManejodeidiomas
            // 
            this.labelManejodeidiomas.AutoSize = true;
            this.labelManejodeidiomas.Location = new System.Drawing.Point(37, 1040);
            this.labelManejodeidiomas.Name = "labelManejodeidiomas";
            this.labelManejodeidiomas.Size = new System.Drawing.Size(193, 25);
            this.labelManejodeidiomas.TabIndex = 35;
            this.labelManejodeidiomas.Text = "Manejo de idiomas";
            // 
            // comboBoxIdioma
            // 
            this.comboBoxIdioma.FormattingEnabled = true;
            this.comboBoxIdioma.Location = new System.Drawing.Point(122, 1084);
            this.comboBoxIdioma.Name = "comboBoxIdioma";
            this.comboBoxIdioma.Size = new System.Drawing.Size(388, 33);
            this.comboBoxIdioma.TabIndex = 36;
            // 
            // labelIdioma
            // 
            this.labelIdioma.AutoSize = true;
            this.labelIdioma.Location = new System.Drawing.Point(38, 1087);
            this.labelIdioma.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelIdioma.Name = "labelIdioma";
            this.labelIdioma.Size = new System.Drawing.Size(75, 25);
            this.labelIdioma.TabIndex = 37;
            this.labelIdioma.Text = "Idioma";
            // 
            // buttonActivarIdioma
            // 
            this.buttonActivarIdioma.Location = new System.Drawing.Point(529, 1017);
            this.buttonActivarIdioma.Name = "buttonActivarIdioma";
            this.buttonActivarIdioma.Size = new System.Drawing.Size(186, 100);
            this.buttonActivarIdioma.TabIndex = 38;
            this.buttonActivarIdioma.Text = "Activar idioma";
            this.buttonActivarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonDesactivarIdioma
            // 
            this.buttonDesactivarIdioma.Location = new System.Drawing.Point(721, 1017);
            this.buttonDesactivarIdioma.Name = "buttonDesactivarIdioma";
            this.buttonDesactivarIdioma.Size = new System.Drawing.Size(214, 100);
            this.buttonDesactivarIdioma.TabIndex = 39;
            this.buttonDesactivarIdioma.Text = "Desactivar idioma";
            this.buttonDesactivarIdioma.UseVisualStyleBackColor = true;
            // 
            // labelNombredelidioma
            // 
            this.labelNombredelidioma.AutoSize = true;
            this.labelNombredelidioma.Location = new System.Drawing.Point(1047, 1069);
            this.labelNombredelidioma.Name = "labelNombredelidioma";
            this.labelNombredelidioma.Size = new System.Drawing.Size(191, 25);
            this.labelNombredelidioma.TabIndex = 40;
            this.labelNombredelidioma.Text = "Nombre del idioma";
            this.labelNombredelidioma.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxAgregarNombreIdioma
            // 
            this.textBoxAgregarNombreIdioma.Location = new System.Drawing.Point(1244, 1069);
            this.textBoxAgregarNombreIdioma.Name = "textBoxAgregarNombreIdioma";
            this.textBoxAgregarNombreIdioma.Size = new System.Drawing.Size(278, 31);
            this.textBoxAgregarNombreIdioma.TabIndex = 41;
            // 
            // buttonAgregarIdioma
            // 
            this.buttonAgregarIdioma.Location = new System.Drawing.Point(1528, 1069);
            this.buttonAgregarIdioma.Name = "buttonAgregarIdioma";
            this.buttonAgregarIdioma.Size = new System.Drawing.Size(241, 100);
            this.buttonAgregarIdioma.TabIndex = 42;
            this.buttonAgregarIdioma.Text = "Agregar";
            this.buttonAgregarIdioma.UseVisualStyleBackColor = true;
            // 
            // buttonAplicarCambiosIdioma
            // 
            this.buttonAplicarCambiosIdioma.Location = new System.Drawing.Point(1571, 973);
            this.buttonAplicarCambiosIdioma.Name = "buttonAplicarCambiosIdioma";
            this.buttonAplicarCambiosIdioma.Size = new System.Drawing.Size(214, 100);
            this.buttonAplicarCambiosIdioma.TabIndex = 43;
            this.buttonAplicarCambiosIdioma.Text = "Aplicar Cambios";
            this.buttonAplicarCambiosIdioma.UseVisualStyleBackColor = true;
            // 
            // PanelAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1848, 1662);
            this.Controls.Add(this.buttonAplicarCambiosIdioma);
            this.Controls.Add(this.buttonAgregarIdioma);
            this.Controls.Add(this.textBoxAgregarNombreIdioma);
            this.Controls.Add(this.labelNombredelidioma);
            this.Controls.Add(this.buttonDesactivarIdioma);
            this.Controls.Add(this.buttonActivarIdioma);
            this.Controls.Add(this.labelIdioma);
            this.Controls.Add(this.comboBoxIdioma);
            this.Controls.Add(this.labelManejodeidiomas);
            this.Controls.Add(this.dataGridViewTraducirControl);
            this.Controls.Add(this.buttonModificarUsuario);
            this.Controls.Add(this.buttonRecomponerEstadoAnterior);
            this.Controls.Add(this.labelControldecambios);
            this.Controls.Add(this.dataGridViewControldecambios);
            this.Controls.Add(this.labelNombredeusuario);
            this.Controls.Add(this.labelFechaFinal);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxUsuarioBuscar);
            this.Controls.Add(this.dateTimePickerFechaFinal);
            this.Controls.Add(this.dateTimePickerFechaInicio);
            this.Controls.Add(this.btn_LimpiarBitacora);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelBitacora);
            this.Controls.Add(this.dataGridViewBitacora);
            this.Controls.Add(this.buttonCerrarSesion);
            this.Controls.Add(this.buttonRegistrarUsuario);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.txtNuevoUsuario);
            this.Controls.Add(this.labelBienvenido);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.labelNOMBREUSER);
            this.Controls.Add(this.labelSelectUsuario);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.labelTreePermisos);
            this.Controls.Add(this.treePermisos);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.labelPermisosUsuario);
            this.Controls.Add(this.listBoxPermisosUsuario);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PanelAdmin";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PanelAdmin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Principal_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControldecambios)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelRol;
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
    }
}