using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PanelAdmin : Form, Servicio.IObserver
    {

        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();
        public BLL.BLL_Usuario BLLusuario = new BLL.BLL_Usuario();
        public BE.BE_Usuario BEUsuario;
        private BLL.BLL_Permiso bllPermiso = new BLL.BLL_Permiso();

        public PanelAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUSER_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Principal_Load_1(object sender, EventArgs e)
        {
            if (BLL.BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                labelUSER.Text = BLL.BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
            }

            EnlazarBitacora();

            listBoxPermisosUsuario.DisplayMember = "Nombre";
            InicializarPermisosYAdministrador();
            InicializarControlesRol();
            InicializarControlesControlCambios();
            CargarUsuarios();
            CargarArbolPermisos();
            ConfigurarPermisos();

            dataGridViewControldecambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewControldecambios.MultiSelect = false;
            buttonRecomponerEstadoAnterior.Click += buttonRecomponerEstadoAnterior_Click;

            BLL_Multilenguaje.Instancia.Registrar(this);

            comboBoxIdioma.SelectedIndexChanged += comboBoxIdioma_SelectedIndexChanged;
            buttonActivarIdioma.Click += buttonActivarIdioma_Click;
            buttonDesactivarIdioma.Click += buttonDesactivarIdioma_Click;
            buttonAgregarIdioma.Click += buttonAgregarIdioma_Click;
            buttonAplicarCambiosIdioma.Click += buttonAplicarCambiosIdioma_Click;
            buttonActualizarIdiomaMostrar.Click += buttonActualizarIdiomaMostrar_Click;

            CargarIdiomas();
            ActualizarLenguaje();

            // Recalcular dígitos verificadores al iniciar
            try
            {
                BLL.BLL_DigitoVerificador bllDigVer = new BLL.BLL_DigitoVerificador();
                bllDigVer.RecalcularTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recalcular dígitos verificadores: " + ex.Message);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNuevoUsuario.Text.Trim();
            string nuevaClave = txtNuevaPassword.Text.Trim(); 
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();

            if (string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrEmpty(nuevaClave))
            {
                MessageBox.Show("El nombre y la contraseña no pueden estar vacíos.");
                return;
            }

            bool registrado = gestorUsuario.RegistrarUsuario(nuevoNombre, nuevaClave);

            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (registrado)
            {
                MessageBox.Show("Usuario creado y encriptado con éxito");
                
                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Registro", "El administrador ha creado un nuevo usuario", DateTime.Now);
                }
                
                CargarUsuarios();
                txtNuevoUsuario.Text = "";
                txtNuevaPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Error al registrar");
                
                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Registro", "El administrador ha intentado crear un nuevo usuario", DateTime.Now);
                }
                
                EnlazarBitacora();
            }
        }

        private void CerrarSesion()
        {
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
                    
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (usuarioSesion != null)
            {
                BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Logout", "El administrador ha cerrado sesión", DateTime.Now);
            }
            
            gestorUsuario.Logout();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            CerrarSesion();
            Application.Restart();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            EnlazarBitacora();
        }

        private void EnlazarBitacora()
        {
            try
            {
                BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();
                dataGridViewBitacora.DataSource = "";
                dataGridViewBitacora.DataSource = gestorBitacora.ObtenerBitacora();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Menu_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void PanelAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLL_Multilenguaje.Instancia.Desregistrar(this);
            CerrarSesion();
        }

        private void btn_LimpiarBitacora_Click(object sender, EventArgs e)
        {
            BLLBitacora.LimpiarBitacora();
            
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (usuarioSesion != null)
            {
                BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Bitacora", "El administrador ha limpiado la bitacora", DateTime.Now);
            }
            
            EnlazarBitacora();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            FiltrarBitacora();
        }


        private void FiltrarBitacora()
        {
            try
            {
                DateTime fechaInicio = dateTimePickerFechaInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFechaFinal.Value.Date.AddDays(1).AddTicks(-1);
                string filtroUsuario = textBoxUsuarioBuscar.Text.Trim().ToLower();

                DataTable dtCompleto = BLLBitacora.ObtenerBitacora();

                if (dtCompleto != null)
                {
                    // Consulta LINQ 
                    var consultaFiltro = 
                        from row in dtCompleto.AsEnumerable()
                        let fecha = Convert.ToDateTime(row["FechaHora"])
                        let usuario = row["Username"].ToString().ToLower()
                        where fecha >= fechaInicio && fecha <= fechaFin && usuario.Contains(filtroUsuario)
                        select row;

                    dataGridViewBitacora.DataSource = consultaFiltro.Any() ? consultaFiltro.CopyToDataTable() : dtCompleto.Clone();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar la bitácora: " + ex.Message);
            }
        }

        // --- Permission Management and Composite Rendering Helpers ---

        private BE_Componente BuscarComponentePorNombre(List<BE_Componente> lista, string nombre)
        {
            foreach (var item in lista)
            {
                if (item.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        private void InicializarPermisosYAdministrador()
        {
            try
            {
                var todos = bllPermiso.ObtenerTodos();

                // Buscar o crear hojas
                BE_Componente h1 = BuscarComponentePorNombre(todos, "Ver Bitacora");
                if (h1 == null)
                {
                    h1 = new BE_Componente { Nombre = "Ver Bitacora", Tipo = "Hoja" };
                }
                if (h1.ID_Componente == 0) bllPermiso.GuardarComponente(h1);

                BE_Componente h2 = BuscarComponentePorNombre(todos, "Limpiar Bitacora");
                if (h2 == null)
                {
                    h2 = new BE_Componente { Nombre = "Limpiar Bitacora", Tipo = "Hoja" };
                }
                if (h2.ID_Componente == 0) bllPermiso.GuardarComponente(h2);

                BE_Componente h3 = BuscarComponentePorNombre(todos, "Registrar Usuario");
                if (h3 == null)
                {
                    h3 = new BE_Componente { Nombre = "Registrar Usuario", Tipo = "Hoja" };
                }
                if (h3.ID_Componente == 0) bllPermiso.GuardarComponente(h3);

                BE_Componente h4 = BuscarComponentePorNombre(todos, "Gestionar Permisos");
                if (h4 == null)
                {
                    h4 = new BE_Componente { Nombre = "Gestionar Permisos", Tipo = "Hoja" };
                }
                if (h4.ID_Componente == 0) bllPermiso.GuardarComponente(h4);

                BE_Componente h5 = BuscarComponentePorNombre(todos, "Ver control de cambios");
                if (h5 == null)
                {
                    h5 = new BE_Componente { Nombre = "Ver control de cambios", Tipo = "Hoja" };
                }
                if (h5.ID_Componente == 0) bllPermiso.GuardarComponente(h5);

                BE_Componente h6 = BuscarComponentePorNombre(todos, "Gestionar idiomas");
                if (h6 == null)
                {
                    h6 = new BE_Componente { Nombre = "Gestionar idiomas", Tipo = "Hoja" };
                }
                if (h6.ID_Componente == 0) bllPermiso.GuardarComponente(h6);

                // Buscar o crear composites
                BE_Componente rAdmin = BuscarComponentePorNombre(todos, "Rol Admin");
                if (rAdmin == null)
                {
                    rAdmin = new BE_Componente { Nombre = "Rol Admin", Tipo = "Composite" };
                }
                if (rAdmin.ID_Componente == 0) bllPermiso.GuardarComponente(rAdmin);

                BE_Componente rUser = BuscarComponentePorNombre(todos, "Rol Usuario");
                if (rUser == null)
                {
                    rUser = new BE_Componente { Nombre = "Rol Usuario", Tipo = "Composite" };
                }
                if (rUser.ID_Componente == 0) bllPermiso.GuardarComponente(rUser);

                // Asegurar relaciones
                // Rol Usuario debe tener como hijo a Ver Bitacora (h1)
                bool tieneH1 = false;
                foreach (var x in rUser.Hijos)
                {
                    if (x.ID_Componente == h1.ID_Componente)
                    {
                        tieneH1 = true;
                        break;
                    }
                }
                if (!tieneH1)
                {
                    rUser.Hijos.Add(h1);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Rol Admin debe tener como hijos a rUser, h2, h3, h4, h5, h6
                bool modificadoAdmin = false;
                
                // Si Rol Admin tenía asignado directamente Ver Bitacora (h1), quitarlo para que no esté repetido, ya que lo heredará por rUser
                BE_Componente duplicado = null;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h1.ID_Componente)
                    {
                        duplicado = x;
                        break;
                    }
                }
                if (duplicado != null)
                {
                    rAdmin.Hijos.Remove(duplicado);
                    modificadoAdmin = true;
                }

                bool tieneRUser = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == rUser.ID_Componente)
                    {
                        tieneRUser = true;
                        break;
                    }
                }
                if (!tieneRUser)
                {
                    rAdmin.Hijos.Add(rUser);
                    modificadoAdmin = true;
                }

                bool tieneH2 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h2.ID_Componente)
                    {
                        tieneH2 = true;
                        break;
                    }
                }
                if (!tieneH2)
                {
                    rAdmin.Hijos.Add(h2);
                    modificadoAdmin = true;
                }

                bool tieneH3 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h3.ID_Componente)
                    {
                        tieneH3 = true;
                        break;
                    }
                }
                if (!tieneH3)
                {
                    rAdmin.Hijos.Add(h3);
                    modificadoAdmin = true;
                }

                bool tieneH4 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h4.ID_Componente)
                    {
                        tieneH4 = true;
                        break;
                    }
                }
                if (!tieneH4)
                {
                    rAdmin.Hijos.Add(h4);
                    modificadoAdmin = true;
                }

                bool tieneH5 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h5.ID_Componente)
                    {
                        tieneH5 = true;
                        break;
                    }
                }
                if (!tieneH5)
                {
                    rAdmin.Hijos.Add(h5);
                    modificadoAdmin = true;
                }

                bool tieneH6 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h6.ID_Componente)
                    {
                        tieneH6 = true;
                        break;
                    }
                }
                if (!tieneH6)
                {
                    rAdmin.Hijos.Add(h6);
                    modificadoAdmin = true;
                }

                if (modificadoAdmin)
                {
                    bllPermiso.GuardarComponente(rAdmin);
                }

                // Seed Admin User if not exists
                var usuarios = BLLusuario.ObtenerUsuarios();
                bool existeAdmin = false;
                foreach (var u in usuarios)
                {
                    if (u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        existeAdmin = true;
                        break;
                    }
                }
                if (!existeAdmin)
                {
                    BLLusuario.RegistrarUsuario("admin", "1234567");
                    
                    usuarios = BLLusuario.ObtenerUsuarios();
                    BE_Usuario adminUser = null;
                    foreach (var u in usuarios)
                    {
                        if (u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            adminUser = u;
                            break;
                        }
                    }
                    
                    if (adminUser != null)
                    {
                        var allPerms = bllPermiso.ObtenerTodos();
                        BE_Componente rolAdmin = null;
                        foreach (var p in allPerms)
                        {
                            if (p.Nombre.Equals("Rol Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                rolAdmin = p;
                                break;
                            }
                        }
                        if (rolAdmin != null)
                        {
                            bllPermiso.GuardarPermisosUsuario(adminUser, new List<BE_Componente> { rolAdmin });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error seeding default data: " + ex.Message);
            }
        }


        private void CargarUsuarios()
        {
            try
            {
                comboBoxUsuarios.SelectedIndexChanged -= comboBoxUsuarios_SelectedIndexChanged;
                
                var usuarios = BLLusuario.ObtenerUsuarios();
                comboBoxUsuarios.DataSource = null;
                comboBoxUsuarios.DataSource = usuarios;
                comboBoxUsuarios.DisplayMember = "Nombre";

                comboBoxUsuarios.SelectedIndexChanged += comboBoxUsuarios_SelectedIndexChanged;
                
                if (usuarios.Count > 0)
                {
                    comboBoxUsuarios.SelectedIndex = 0;
                    CargarPermisosUsuario();
                    CargarControlCambiosUsuario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }



        private void CargarArbolPermisos()
        {
            try
            {
                treePermisos.Nodes.Clear();
                var todos = bllPermiso.ObtenerTodos();
                
                // Find roots (components with no parents)
                HashSet<int> hijosIds = new HashSet<int>();
                foreach (var c in todos)
                {
                    foreach (var h in c.Hijos)
                    {
                        hijosIds.Add(h.ID_Componente);
                    }
                }

                List<BE_Componente> raices = new List<BE_Componente>();
                foreach (var c in todos)
                {
                    if (!hijosIds.Contains(c.ID_Componente))
                    {
                        raices.Add(c);
                    }
                }

                foreach (var raiz in raices)
                {
                    LlenarNodo(treePermisos.Nodes, raiz);
                }

                treePermisos.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar árbol de permisos: " + ex.Message);
            }
        }

        private void LlenarNodo(TreeNodeCollection nodos, BE_Componente comp)
        {
            TreeNode nuevoNodo = new TreeNode(comp.Nombre);
            nuevoNodo.Tag = comp;
            nodos.Add(nuevoNodo);

            foreach (var hijo in comp.Hijos)
            {
                LlenarNodo(nuevoNodo.Nodes, hijo);
            }
        }

        private void CargarPermisosUsuario()
        {
            try
            {
                listBoxPermisosUsuario.Items.Clear();
                var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
                if (usuarioSelected != null)
                {
                    usuarioSelected.Permisos = bllPermiso.ObtenerPermisosUsuario(usuarioSelected);
                    foreach (var p in usuarioSelected.Permisos)
                    {
                        listBoxPermisosUsuario.Items.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos del usuario: " + ex.Message);
            }
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermisosUsuario();
            CargarControlCambiosUsuario();

            var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
            if (usuarioSelected != null)
            {
                txtNuevoUsuario.Text = usuarioSelected.Nombre;
                txtNuevaPassword.Text = "";
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
                if (usuarioSelected == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                var selectedNode = treePermisos.SelectedNode;
                if (selectedNode == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso del árbol.");
                    return;
                }

                var permiso = selectedNode.Tag as BE_Componente;
                if (permiso == null) return;

                // Check for duplicates in direct assignments
                if (usuarioSelected.Permisos.Any(p => p.ID_Componente == permiso.ID_Componente))
                {
                    MessageBox.Show("El usuario ya cuenta con este permiso asignado directamente.");
                    return;
                }

                // Assign
                usuarioSelected.Permisos.Add(permiso);
                bllPermiso.GuardarPermisosUsuario(usuarioSelected, usuarioSelected.Permisos);

                // Log bitacora
                var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Permisos", 
                        $"El administrador asignó el permiso '{permiso.Nombre}' al usuario '{usuarioSelected.Nombre}'", DateTime.Now);
                }

                MessageBox.Show("Permiso asignado correctamente.");
                CargarPermisosUsuario();
                EnlazarBitacora();

                if (usuarioSelected.ID_Usuario == BLL_GestorDeSesion.Instancia.UsuarioActual.ID_Usuario)
                {
                    BLL_GestorDeSesion.Instancia.UsuarioActual.Permisos = usuarioSelected.Permisos;
                    ConfigurarPermisos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar permiso: " + ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
                if (usuarioSelected == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                var permiso = listBoxPermisosUsuario.SelectedItem as BE_Componente;
                if (permiso == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso de la lista de permisos directos.");
                    return;
                }

                // Prevent removing admin permission from the admin itself (safety check)
                if (usuarioSelected.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase) && permiso.Nombre.Equals("Rol Admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No se puede quitar el rol de administrador al usuario principal admin.");
                    return;
                }

                // Remove
                var aEliminar = usuarioSelected.Permisos.FirstOrDefault(p => p.ID_Componente == permiso.ID_Componente);
                if (aEliminar != null)
                {
                    usuarioSelected.Permisos.Remove(aEliminar);
                    bllPermiso.GuardarPermisosUsuario(usuarioSelected, usuarioSelected.Permisos);

                    // Log bitacora
                    var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
                    if (usuarioSesion != null)
                    {
                        BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Permisos", 
                            $"El administrador removió el permiso '{permiso.Nombre}' al usuario '{usuarioSelected.Nombre}'", DateTime.Now);
                    }

                    MessageBox.Show("Permiso removido correctamente.");
                    CargarPermisosUsuario();
                    EnlazarBitacora();

                    if (usuarioSelected.ID_Usuario == BLL_GestorDeSesion.Instancia.UsuarioActual.ID_Usuario)
                    {
                        BLL_GestorDeSesion.Instancia.UsuarioActual.Permisos = usuarioSelected.Permisos;
                        ConfigurarPermisos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar permiso: " + ex.Message);
            }
        }

        private void ConfigurarPermisos()
        {
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (usuarioSesion != null)
            {
                BLL_Permiso bllPermisoEval = new BLL_Permiso();

                // 1. Limpiar Bitacora
                btn_LimpiarBitacora.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Limpiar Bitacora");

                // 2. Registrar Usuario
                buttonRegistrarUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevoUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevaPassword.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");

                // 3. Gestionar Permisos
                comboBoxUsuarios.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                treePermisos.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                listBoxPermisosUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                btnAsignar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                btnQuitar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");

                if (textBoxNuevoRol != null)
                {
                    textBoxNuevoRol.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    buttonCrearRol.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    comboBoxRoles.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    listBoxPermisosRol.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    comboBoxPermisosTodos.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    btnAsignarARol.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                    btnQuitarDeRol.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                }

                // 4. Ver Bitacora
                dataGridViewBitacora.Visible = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                buttonBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                textBoxUsuarioBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaInicio.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaFinal.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");

                // 5. Ver control de cambios
                tabPageControlCambios.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver control de cambios");

                // 6. Gestionar idiomas
                tabPageIdiomas.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar idiomas");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CargarControlCambiosUsuario()
        {
            CargarUsuariosCambios();
            FiltrarControlCambios();
        }

        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
                if (usuarioSelected == null)
                {
                    MessageBox.Show("Seleccione un usuario para modificar.");
                    return;
                }

                string nuevoNombre = txtNuevoUsuario.Text.Trim();
                string nuevaClave = txtNuevaPassword.Text.Trim();

                if (string.IsNullOrEmpty(nuevoNombre))
                {
                    MessageBox.Show("El nombre del usuario no puede estar vacío.");
                    return;
                }

                // If password is not empty, hashear it. Otherwise keep the original.
                string passwordHasheada = usuarioSelected.Password;
                if (!string.IsNullOrEmpty(nuevaClave))
                {
                    passwordHasheada = BLL_Seguridad.HashearPassword(nuevaClave);
                }

                // Update in database using MP_UsuarioCambio
                BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                int filas = bllCambio.ActualizarUsuario(usuarioSelected.ID_Usuario, nuevoNombre, passwordHasheada);

                if (filas > 0)
                {
                    MessageBox.Show("Usuario modificado con éxito.");

                    // Recalcular dígitos verificadores
                    BLL_DigitoVerificador bllDigVer = new BLL_DigitoVerificador();
                    bllDigVer.RecalcularTodo();

                    // Log the change
                    BE_Usuario usuarioModificado = new BE_Usuario();
                    usuarioModificado.ID_Usuario = usuarioSelected.ID_Usuario;
                    usuarioModificado.Nombre = nuevoNombre;
                    usuarioModificado.Password = passwordHasheada;

                    string modificadoPor = "admin";
                    if (BLL_GestorDeSesion.Instancia.EstaLogeado)
                    {
                        modificadoPor = BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
                    }

                    bllCambio.RegistrarCambio(usuarioModificado, "Modificacion", modificadoPor);

                    if (BLL_GestorDeSesion.Instancia.EstaLogeado)
                    {
                        BLLBitacora.RegistrarBitacora(BLL_GestorDeSesion.Instancia.UsuarioActual.ID_Usuario, BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre, "Modificar", $"Modificó al usuario '{nuevoNombre}'", DateTime.Now);
                    }

                    // Refresh
                    CargarUsuarios();
                    EnlazarBitacora();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        private void buttonRecomponerEstadoAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewControldecambios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una versión en la tabla de control de cambios para recomponer.");
                    return;
                }

                var cambio = dataGridViewControldecambios.SelectedRows[0].DataBoundItem as BE_UsuarioCambio;
                if (cambio == null)
                {
                    MessageBox.Show("No se pudo obtener el cambio seleccionado.");
                    return;
                }

                var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
                string modificadoPor = usuarioSesion != null ? usuarioSesion.Nombre : "admin";

                BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                bool exito = bllCambio.RecomponerEstadoAnterior(cambio, modificadoPor);

                if (exito)
                {
                    MessageBox.Show("El estado del usuario ha sido recompuesto a la versión " + cambio.Version + " con éxito.");
                    if (usuarioSesion != null)
                    {
                        BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Recomponer", $"Recompuso al usuario '{cambio.Nombre}' a versión {cambio.Version}", DateTime.Now);
                    }
                    CargarUsuarios();
                    EnlazarBitacora();
                }
                else
                {
                    MessageBox.Show("No se pudo recomponer el estado del usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recomponer el estado: " + ex.Message);
            }
        }

        private void CargarIdiomas()
        {
            try
            {
                comboBoxIdioma.SelectedIndexChanged -= comboBoxIdioma_SelectedIndexChanged;
                
                var idiomas = BLL_Multilenguaje.Instancia.ObtenerIdiomas();
                comboBoxIdioma.DataSource = null;
                comboBoxIdioma.DataSource = idiomas;
                comboBoxIdioma.DisplayMember = "Nombre";

                // Filtrar por idiomas agregados (activos) para la visualización
                List<BE_Idioma> idiomasActivos = new List<BE_Idioma>();
                foreach (var idm in idiomas)
                {
                    if (idm.Agregado)
                    {
                        idiomasActivos.Add(idm);
                    }
                }

                comboBoxIdiomaMostrar.DataSource = null;
                comboBoxIdiomaMostrar.DataSource = idiomasActivos;
                comboBoxIdiomaMostrar.DisplayMember = "Nombre";

                comboBoxIdioma.SelectedIndexChanged += comboBoxIdioma_SelectedIndexChanged;

                // Select current language en ambos
                var actual = BLL_Multilenguaje.Instancia.IdiomaActual;
                if (actual != null)
                {
                    foreach (var idm in listToArrayHack(idiomas))
                    {
                        if (idm.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdioma.SelectedItem = idm;
                            break;
                        }
                    }

                    foreach (var idm in listToArrayHack(idiomasActivos))
                    {
                        if (idm.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdiomaMostrar.SelectedItem = idm;
                            break;
                        }
                    }
                }
                else if (idiomas.Count > 0)
                {
                    comboBoxIdioma.SelectedIndex = 0;
                    BLL_Multilenguaje.Instancia.IdiomaActual = idiomas[0];
                }
                
                CargarTraducciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar idiomas: " + ex.Message);
            }
        }

        private void buttonActualizarIdiomaMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdiomaMostrar.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    BLL_Multilenguaje.Instancia.IdiomaActual = selectedIdioma;
                    MessageBox.Show("Idioma de visualización actualizado con éxito.");
                }
                else
                {
                    MessageBox.Show("Seleccione un idioma válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el idioma de visualización: " + ex.Message);
            }
        }

        private BE_Idioma[] listToArrayHack(List<BE_Idioma> list)
        {
            BE_Idioma[] arr = new BE_Idioma[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }

        private void CargarTraducciones()
        {
            try
            {
                var selectedIdioma = comboBoxIdioma.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    dataGridViewTraducirControl.DataSource = null;
                    dataGridViewTraducirControl.DataSource = BLL_Multilenguaje.Instancia.ObtenerTablaTraducciones(selectedIdioma.ID_Idioma);

                    if (dataGridViewTraducirControl.Columns.Count > 0)
                    {
                        dataGridViewTraducirControl.Columns["id_Control"].ReadOnly = true;
                        dataGridViewTraducirControl.Columns["nombre_control"].ReadOnly = true;
                        dataGridViewTraducirControl.Columns["form"].ReadOnly = true;
                        dataGridViewTraducirControl.Columns["texto"].ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar traducciones: " + ex.Message);
            }
        }

        private void comboBoxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIdioma = comboBoxIdioma.SelectedItem as BE_Idioma;
            if (selectedIdioma != null)
            {
                BLL_Multilenguaje.Instancia.IdiomaActual = selectedIdioma;
                CargarTraducciones();
            }
        }

        private void buttonActivarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdioma.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    selectedIdioma.Agregado = true;
                    BLL_Multilenguaje.Instancia.GuardarIdioma(selectedIdioma);
                    MessageBox.Show("Idioma activado con éxito.");
                    CargarIdiomas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al activar idioma: " + ex.Message);
            }
        }

        private void buttonDesactivarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdioma.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    selectedIdioma.Agregado = false;
                    BLL_Multilenguaje.Instancia.GuardarIdioma(selectedIdioma);
                    MessageBox.Show("Idioma desactivado con éxito.");
                    CargarIdiomas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desactivar idioma: " + ex.Message);
            }
        }

        private void buttonAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBoxAgregarNombreIdioma.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del idioma no puede estar vacío.");
                    return;
                }

                BE_Idioma nuevo = new BE_Idioma();
                nuevo.Nombre = nombre;
                nuevo.Agregado = false; // Deactivated by default

                BLL_Multilenguaje.Instancia.GuardarIdioma(nuevo);
                textBoxAgregarNombreIdioma.Text = "";
                MessageBox.Show("Idioma agregado con éxito. Active el idioma y traduzca sus controles.");
                CargarIdiomas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar idioma: " + ex.Message);
            }
        }

        private void buttonAplicarCambiosIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdioma.SelectedItem as BE_Idioma;
                if (selectedIdioma == null) return;

                DataTable dt = dataGridViewTraducirControl.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int idControl = Convert.ToInt32(row["id_Control"]);
                        string texto = row["texto"].ToString();
                        BLL_Multilenguaje.Instancia.GuardarTraduccion(selectedIdioma.ID_Idioma, idControl, texto);
                    }
                    MessageBox.Show("Traducciones aplicadas con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cambios: " + ex.Message);
            }
        }

        public void ActualizarLenguaje()
        {
            labelBienvenido.Text = BLL_Multilenguaje.Instancia.Traducir("labelBienvenido", "PanelAdmin");
            labelUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelUsuario", "PanelAdmin");
            labelContraseña.Text = BLL_Multilenguaje.Instancia.Traducir("labelContrasena", "PanelAdmin");
            buttonRegistrarUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("buttonRegistrarUsuario", "PanelAdmin");
            buttonCerrarSesion.Text = BLL_Multilenguaje.Instancia.Traducir("buttonCerrarSesion", "PanelAdmin");
            labelBitacora.Text = BLL_Multilenguaje.Instancia.Traducir("labelBitacora", "PanelAdmin");
            btn_LimpiarBitacora.Text = BLL_Multilenguaje.Instancia.Traducir("btn_LimpiarBitacora", "PanelAdmin");
            buttonBuscar.Text = BLL_Multilenguaje.Instancia.Traducir("buttonBuscar", "PanelAdmin");
            labelFechaInicio.Text = BLL_Multilenguaje.Instancia.Traducir("labelFechaInicio", "PanelAdmin");
            labelFechaFinal.Text = BLL_Multilenguaje.Instancia.Traducir("labelFechaFinal", "PanelAdmin");
            labelNombredeusuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelNombredeusuario", "PanelAdmin");
            labelSelectUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelSelectUsuario", "PanelAdmin");
            labelTreePermisos.Text = BLL_Multilenguaje.Instancia.Traducir("labelTreePermisos", "PanelAdmin");
            btnAsignar.Text = BLL_Multilenguaje.Instancia.Traducir("btnAsignar", "PanelAdmin");
            btnQuitar.Text = BLL_Multilenguaje.Instancia.Traducir("btnQuitar", "PanelAdmin");
            labelPermisosUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelPermisosUsuario", "PanelAdmin");
            labelControldecambios.Text = BLL_Multilenguaje.Instancia.Traducir("labelControldecambios", "PanelAdmin");
            buttonRecomponerEstadoAnterior.Text = BLL_Multilenguaje.Instancia.Traducir("buttonRecomponerEstadoAnterior", "PanelAdmin");
            buttonModificarUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("buttonModificarUsuario", "PanelAdmin");
            labelManejodeidiomas.Text = BLL_Multilenguaje.Instancia.Traducir("labelManejodeidiomas", "PanelAdmin");
            labelIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("labelIdioma", "PanelAdmin");
            buttonActivarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonActivarIdioma", "PanelAdmin");
            buttonDesactivarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonDesactivarIdioma", "PanelAdmin");
            labelNombredelidioma.Text = BLL_Multilenguaje.Instancia.Traducir("labelNombredelidioma", "PanelAdmin");
            buttonAgregarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonAgregarIdioma", "PanelAdmin");
            buttonAplicarCambiosIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonAplicarCambiosIdioma", "PanelAdmin");
            this.Text = BLL_Multilenguaje.Instancia.Traducir("PanelAdmin", "PanelAdmin");

            string tBtnActualizar = BLL_Multilenguaje.Instancia.Traducir("buttonActualizarIdiomaMostrar", "PanelAdmin");
            buttonActualizarIdiomaMostrar.Text = tBtnActualizar.StartsWith("[Default:") ? "Actualizar" : tBtnActualizar;

            // Traducir TabPages con fallback a español si no están en base de datos de traducciones
            string tUsuarios = BLL_Multilenguaje.Instancia.Traducir("tabPageUsuarios", "PanelAdmin");
            tabPageUsuarios.Text = tUsuarios.StartsWith("[Default:") ? "Usuarios y Permisos" : tUsuarios;

            string tBitacora = BLL_Multilenguaje.Instancia.Traducir("tabPageBitacora", "PanelAdmin");
            tabPageBitacora.Text = tBitacora.StartsWith("[Default:") ? "Bitácora" : tBitacora;

            string tControlCambios = BLL_Multilenguaje.Instancia.Traducir("tabPageControlCambios", "PanelAdmin");
            tabPageControlCambios.Text = tControlCambios.StartsWith("[Default:") ? "Control de Cambios" : tControlCambios;

            string tIdiomas = BLL_Multilenguaje.Instancia.Traducir("tabPageIdiomas", "PanelAdmin");
            tabPageIdiomas.Text = tIdiomas.StartsWith("[Default:") ? "Idiomas" : tIdiomas;

            // Traducir nuevos controles de control de cambios
            if (labelSelectUsuarioCambio != null)
            {
                string tLblUsuarioCambio = BLL_Multilenguaje.Instancia.Traducir("labelSelectUsuarioCambio", "PanelAdmin");
                labelSelectUsuarioCambio.Text = tLblUsuarioCambio.StartsWith("[Default:") ? "Usuario:" : tLblUsuarioCambio;

                string tLblFechaInicio = BLL_Multilenguaje.Instancia.Traducir("labelFechaInicioCambio", "PanelAdmin");
                labelFechaInicioCambio.Text = tLblFechaInicio.StartsWith("[Default:") ? "Desde:" : tLblFechaInicio;

                string tLblFechaFin = BLL_Multilenguaje.Instancia.Traducir("labelFechaFinCambio", "PanelAdmin");
                labelFechaFinCambio.Text = tLblFechaFin.StartsWith("[Default:") ? "Hasta:" : tLblFechaFin;

                string tLblTipoCambio = BLL_Multilenguaje.Instancia.Traducir("labelTipoCambio", "PanelAdmin");
                labelTipoCambio.Text = tLblTipoCambio.StartsWith("[Default:") ? "Tipo:" : tLblTipoCambio;

                string tBtnFiltrar = BLL_Multilenguaje.Instancia.Traducir("btnFiltrarCambio", "PanelAdmin");
                btnFiltrarCambio.Text = tBtnFiltrar.StartsWith("[Default:") ? "Filtrar" : tBtnFiltrar;

                string tBtnLimpiar = BLL_Multilenguaje.Instancia.Traducir("btnLimpiarFiltrosCambio", "PanelAdmin");
                btnLimpiarFiltrosCambio.Text = tBtnLimpiar.StartsWith("[Default:") ? "Limpiar" : tBtnLimpiar;
                
                CargarUsuariosCambios();
            }
        }
        // --- Role Management Controls ---
        private System.Windows.Forms.Label labelNuevoRol;
        private System.Windows.Forms.TextBox textBoxNuevoRol;
        private System.Windows.Forms.Button buttonCrearRol;
        private System.Windows.Forms.Label labelSelectRol;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button btnAsignarARol;
        private System.Windows.Forms.Button btnQuitarDeRol;
        private System.Windows.Forms.ListBox listBoxPermisosRol;
        private System.Windows.Forms.ComboBox comboBoxPermisosTodos;

        // --- Control de Cambios Filter Controls ---
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

        private void InicializarControlesRol()
        {
            labelNuevoRol = new System.Windows.Forms.Label { Text = "Nuevo Rol:", Location = new System.Drawing.Point(325, 200), AutoSize = true };
            textBoxNuevoRol = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(325, 220), Size = new System.Drawing.Size(100, 20) };
            buttonCrearRol = new System.Windows.Forms.Button { Text = "Crear", Location = new System.Drawing.Point(430, 218), Size = new System.Drawing.Size(70, 23) };
            buttonCrearRol.Click += buttonCrearRol_Click;

            labelSelectRol = new System.Windows.Forms.Label { Text = "Editar Rol:", Location = new System.Drawing.Point(585, 200), AutoSize = true };
            comboBoxRoles = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Location = new System.Drawing.Point(585, 220), Size = new System.Drawing.Size(127, 21) };
            comboBoxRoles.SelectedIndexChanged += comboBoxRoles_SelectedIndexChanged;

            listBoxPermisosRol = new System.Windows.Forms.ListBox { Location = new System.Drawing.Point(585, 250), Size = new System.Drawing.Size(127, 80), DisplayMember = "Nombre" };

            comboBoxPermisosTodos = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Location = new System.Drawing.Point(450, 250), Size = new System.Drawing.Size(125, 21) };

            btnAsignarARol = new System.Windows.Forms.Button { Text = "Asig. Rol", Location = new System.Drawing.Point(510, 275), Size = new System.Drawing.Size(65, 23) };
            btnAsignarARol.Click += btnAsignarARol_Click;

            btnQuitarDeRol = new System.Windows.Forms.Button { Text = "Quit. Rol", Location = new System.Drawing.Point(510, 305), Size = new System.Drawing.Size(65, 23) };
            btnQuitarDeRol.Click += btnQuitarDeRol_Click;

            tabPageUsuarios.Controls.Add(labelNuevoRol);
            tabPageUsuarios.Controls.Add(textBoxNuevoRol);
            tabPageUsuarios.Controls.Add(buttonCrearRol);
            tabPageUsuarios.Controls.Add(labelSelectRol);
            tabPageUsuarios.Controls.Add(comboBoxRoles);
            tabPageUsuarios.Controls.Add(listBoxPermisosRol);
            tabPageUsuarios.Controls.Add(comboBoxPermisosTodos);
            tabPageUsuarios.Controls.Add(btnAsignarARol);
            tabPageUsuarios.Controls.Add(btnQuitarDeRol);

            CargarRoles();
        }

        private void CargarRoles()
        {
            var todos = bllPermiso.ObtenerTodos();
            var roles = new System.Collections.Generic.List<BE_Componente>();
            var permisosComunes = new System.Collections.Generic.List<BE_Componente>();

            foreach(var c in todos)
            {
                if(c.Tipo == "Composite") roles.Add(c);
                permisosComunes.Add(c);
            }

            comboBoxRoles.SelectedIndexChanged -= comboBoxRoles_SelectedIndexChanged;
            comboBoxRoles.DataSource = null;
            comboBoxRoles.DataSource = roles;
            comboBoxRoles.DisplayMember = "Nombre";
            comboBoxRoles.SelectedIndexChanged += comboBoxRoles_SelectedIndexChanged;

            comboBoxPermisosTodos.DataSource = null;
            comboBoxPermisosTodos.DataSource = permisosComunes;
            comboBoxPermisosTodos.DisplayMember = "Nombre";

            if (roles.Count > 0)
            {
                comboBoxRoles.SelectedIndex = 0;
            }
            CargarPermisosRol();
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermisosRol();
        }

        private void CargarPermisosRol()
        {
            listBoxPermisosRol.Items.Clear();
            var rol = comboBoxRoles.SelectedItem as BE_Componente;
            if (rol != null)
            {
                var todos = bllPermiso.ObtenerTodos();
                BE_Componente rolActualizado = null;
                foreach(var c in todos)
                {
                    if (c.ID_Componente == rol.ID_Componente)
                    {
                        rolActualizado = c;
                        break;
                    }
                }
                if (rolActualizado != null)
                {
                    foreach (var h in rolActualizado.Hijos)
                    {
                        listBoxPermisosRol.Items.Add(h);
                    }
                }
            }
        }

        private void buttonCrearRol_Click(object sender, EventArgs e)
        {
            string nombreRol = textBoxNuevoRol.Text.Trim();
            if (string.IsNullOrEmpty(nombreRol)) return;

            var comp = new BE_Componente { Nombre = nombreRol, Tipo = "Composite" };
            bllPermiso.GuardarComponente(comp);
            MessageBox.Show("Rol creado con éxito.");
            textBoxNuevoRol.Text = "";
            CargarArbolPermisos();
            CargarRoles();
        }

        private void btnAsignarARol_Click(object sender, EventArgs e)
        {
            var rol = comboBoxRoles.SelectedItem as BE_Componente;
            var permiso = comboBoxPermisosTodos.SelectedItem as BE_Componente;
            if (rol == null || permiso == null) return;

            if (permiso.ID_Componente == rol.ID_Componente)
            {
                MessageBox.Show("No puede asignarse un rol a sí mismo.");
                return;
            }

            var todos = bllPermiso.ObtenerTodos();
            BE_Componente rolActual = null;
            BE_Componente permisoCompleto = null;
            foreach(var c in todos) 
            { 
                if (c.ID_Componente == rol.ID_Componente) rolActual = c; 
                if (c.ID_Componente == permiso.ID_Componente) permisoCompleto = c;
            }
            if (rolActual == null || permisoCompleto == null) return;

            foreach(var h in rolActual.Hijos)
            {
                if (h.ID_Componente == permiso.ID_Componente)
                {
                    MessageBox.Show("El rol ya tiene este permiso.");
                    return;
                }
            }

            // Verificar circularidad: el rolActual no puede estar dentro del permiso (si es que el permiso es un Composite)
            bool EsHijo(BE_Componente padre, int idBuscado)
            {
                if (padre.ID_Componente == idBuscado) return true;
                foreach(var h in padre.Hijos)
                {
                    if (EsHijo(h, idBuscado)) return true;
                }
                return false;
            }

            if (EsHijo(permisoCompleto, rolActual.ID_Componente))
            {
                MessageBox.Show("No se puede asignar porque generaría una referencia circular.");
                return;
            }

            rolActual.Hijos.Add(permiso);
            bllPermiso.GuardarComponente(rolActual);
            CargarArbolPermisos();
            CargarPermisosRol();
            
            var u = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (u != null) BLLBitacora.RegistrarBitacora(u.ID_Usuario, u.Nombre, "Roles", $"Asignó permiso '{permiso.Nombre}' al rol '{rolActual.Nombre}'", DateTime.Now);
            EnlazarBitacora();
            ConfigurarPermisos();
        }

        private void btnQuitarDeRol_Click(object sender, EventArgs e)
        {
            var rol = comboBoxRoles.SelectedItem as BE_Componente;
            var permiso = listBoxPermisosRol.SelectedItem as BE_Componente;
            if (rol == null || permiso == null) return;

            var todos = bllPermiso.ObtenerTodos();
            BE_Componente rolActual = null;
            foreach(var c in todos) { if (c.ID_Componente == rol.ID_Componente) rolActual = c; }
            if (rolActual == null) return;

            BE_Componente aRemover = null;
            foreach(var h in rolActual.Hijos)
            {
                if (h.ID_Componente == permiso.ID_Componente) aRemover = h;
            }

            if (aRemover != null)
            {
                rolActual.Hijos.Remove(aRemover);
                bllPermiso.GuardarComponente(rolActual);
                CargarArbolPermisos();
                CargarPermisosRol();

                var u = BLL_GestorDeSesion.Instancia.UsuarioActual;
                if (u != null) BLLBitacora.RegistrarBitacora(u.ID_Usuario, u.Nombre, "Roles", $"Quitó permiso '{permiso.Nombre}' al rol '{rolActual.Nombre}'", DateTime.Now);
                EnlazarBitacora();
                ConfigurarPermisos();
            }
        }

        private void InicializarControlesControlCambios()
        {
            // Shifting dataGridViewControldecambios down and adjusting height
            dataGridViewControldecambios.Location = new System.Drawing.Point(21, 80);
            dataGridViewControldecambios.Size = new System.Drawing.Size(850, 170);

            // Shifting title label slightly up
            labelControldecambios.Location = new System.Drawing.Point(18, 10);

            // User Select
            labelSelectUsuarioCambio = new System.Windows.Forms.Label { Text = "Usuario:", Location = new System.Drawing.Point(18, 48), AutoSize = true };
            comboBoxUsuarioCambio = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Location = new System.Drawing.Point(75, 45), Size = new System.Drawing.Size(120, 21) };
            comboBoxUsuarioCambio.SelectedIndexChanged += comboBoxUsuarioCambio_SelectedIndexChanged;

            // Date Range
            labelFechaInicioCambio = new System.Windows.Forms.Label { Text = "Desde:", Location = new System.Drawing.Point(210, 48), AutoSize = true };
            dateTimePickerInicioCambio = new System.Windows.Forms.DateTimePicker { Format = System.Windows.Forms.DateTimePickerFormat.Short, Location = new System.Drawing.Point(260, 45), Size = new System.Drawing.Size(110, 20), Value = DateTime.Now.AddDays(-30) };

            labelFechaFinCambio = new System.Windows.Forms.Label { Text = "Hasta:", Location = new System.Drawing.Point(385, 48), AutoSize = true };
            dateTimePickerFinCambio = new System.Windows.Forms.DateTimePicker { Format = System.Windows.Forms.DateTimePickerFormat.Short, Location = new System.Drawing.Point(435, 45), Size = new System.Drawing.Size(110, 20), Value = DateTime.Now };

            // Change Type
            labelTipoCambio = new System.Windows.Forms.Label { Text = "Tipo:", Location = new System.Drawing.Point(560, 48), AutoSize = true };
            comboBoxTipoCambio = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Location = new System.Drawing.Point(600, 45), Size = new System.Drawing.Size(110, 21) };
            comboBoxTipoCambio.Items.AddRange(new string[] { "Todos", "Registro", "Modificacion", "Recomposicion" });
            comboBoxTipoCambio.SelectedIndex = 0;
            comboBoxTipoCambio.SelectedIndexChanged += (s, e) => FiltrarControlCambios();

            // Buttons
            btnFiltrarCambio = new System.Windows.Forms.Button { Text = "Filtrar", Location = new System.Drawing.Point(720, 43), Size = new System.Drawing.Size(70, 25) };
            btnFiltrarCambio.Click += btnFiltrarCambio_Click;

            btnLimpiarFiltrosCambio = new System.Windows.Forms.Button { Text = "Limpiar", Location = new System.Drawing.Point(800, 43), Size = new System.Drawing.Size(70, 25) };
            btnLimpiarFiltrosCambio.Click += btnLimpiarFiltrosCambio_Click;

            // Add controls to TabPage
            tabPageControlCambios.Controls.Add(labelSelectUsuarioCambio);
            tabPageControlCambios.Controls.Add(comboBoxUsuarioCambio);
            tabPageControlCambios.Controls.Add(labelFechaInicioCambio);
            tabPageControlCambios.Controls.Add(dateTimePickerInicioCambio);
            tabPageControlCambios.Controls.Add(labelFechaFinCambio);
            tabPageControlCambios.Controls.Add(dateTimePickerFinCambio);
            tabPageControlCambios.Controls.Add(labelTipoCambio);
            tabPageControlCambios.Controls.Add(comboBoxTipoCambio);
            tabPageControlCambios.Controls.Add(btnFiltrarCambio);
            tabPageControlCambios.Controls.Add(btnLimpiarFiltrosCambio);

            CargarUsuariosCambios();
        }

        private void CargarUsuariosCambios()
        {
            try
            {
                comboBoxUsuarioCambio.SelectedIndexChanged -= comboBoxUsuarioCambio_SelectedIndexChanged;

                int idSeleccionado = 0;
                if (comboBoxUsuarioCambio.SelectedItem is BE_Usuario prevSelected)
                {
                    idSeleccionado = prevSelected.ID_Usuario;
                }

                var usuarios = BLLusuario.ObtenerUsuarios();
                List<BE_Usuario> listaUsuarios = new List<BE_Usuario>();

                BE_Usuario todos = new BE_Usuario();
                todos.ID_Usuario = 0;
                string txtTodos = BLL_Multilenguaje.Instancia.Traducir("Todos", "PanelAdmin");
                todos.Nombre = txtTodos.StartsWith("[Default:") ? "Todos" : txtTodos;

                listaUsuarios.Add(todos);
                listaUsuarios.AddRange(usuarios);

                comboBoxUsuarioCambio.DataSource = null;
                comboBoxUsuarioCambio.DataSource = listaUsuarios;
                comboBoxUsuarioCambio.DisplayMember = "Nombre";

                if (idSeleccionado > 0)
                {
                    var found = listaUsuarios.FirstOrDefault(u => u.ID_Usuario == idSeleccionado);
                    if (found != null)
                    {
                        comboBoxUsuarioCambio.SelectedItem = found;
                    }
                    else
                    {
                        comboBoxUsuarioCambio.SelectedIndex = 0;
                    }
                }
                else
                {
                    comboBoxUsuarioCambio.SelectedIndex = 0;
                }

                comboBoxUsuarioCambio.SelectedIndexChanged += comboBoxUsuarioCambio_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios en control de cambios: " + ex.Message);
            }
        }

        private void FiltrarControlCambios()
        {
            try
            {
                dataGridViewControldecambios.DataSource = null;
                if (comboBoxUsuarioCambio.SelectedItem == null) return;

                var usuarioSelected = comboBoxUsuarioCambio.SelectedItem as BE_Usuario;
                if (usuarioSelected != null)
                {
                    BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                    var listaCambios = bllCambio.ObtenerCambiosUsuario(usuarioSelected.ID_Usuario);

                    DateTime fechaInicio = dateTimePickerInicioCambio.Value.Date;
                    DateTime fechaFin = dateTimePickerFinCambio.Value.Date.AddDays(1).AddTicks(-1);
                    string tipoSeleccionado = comboBoxTipoCambio.SelectedItem?.ToString() ?? "Todos";

                    var consulta = listaCambios.AsEnumerable();

                    // Filter by Date range
                    consulta = consulta.Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin);

                    // Filter by Tipo de Cambio
                    if (tipoSeleccionado != "Todos")
                    {
                        if (tipoSeleccionado == "Recomposicion")
                        {
                            consulta = consulta.Where(c => c.Tipo_Cambio != null && c.Tipo_Cambio.Contains("Recomposicion"));
                        }
                        else
                        {
                            consulta = consulta.Where(c => c.Tipo_Cambio != null && c.Tipo_Cambio.Equals(tipoSeleccionado, StringComparison.OrdinalIgnoreCase));
                        }
                    }

                    dataGridViewControldecambios.DataSource = consulta.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar el control de cambios: " + ex.Message);
            }
        }

        private void comboBoxUsuarioCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarControlCambios();
        }

        private void btnFiltrarCambio_Click(object sender, EventArgs e)
        {
            FiltrarControlCambios();
        }

        private void btnLimpiarFiltrosCambio_Click(object sender, EventArgs e)
        {
            dateTimePickerInicioCambio.Value = DateTime.Now.AddDays(-30);
            dateTimePickerFinCambio.Value = DateTime.Now;
            comboBoxTipoCambio.SelectedIndex = 0;
            comboBoxUsuarioCambio.SelectedIndex = 0;
            FiltrarControlCambios();
        }
    }
}
