using BE;
using Servicio;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormUsuarios : Form
    {
        private BLL.BLL_Bitacora BLLBitacora;
        private BLL.BLL_Usuario BLLusuario;
        private BLL.BLL_Permiso bllPermiso;

        // Evento para notificar al PanelAdmin que hubo cambios
        public event EventHandler DatosModificados;

        public FormUsuarios(BLL.BLL_Bitacora bllBitacora, BLL.BLL_Usuario bllUsuario, BLL.BLL_Permiso bllPermisoParam)
        {
            InitializeComponent();
            this.BLLBitacora = bllBitacora;
            this.BLLusuario = bllUsuario;
            this.bllPermiso = bllPermisoParam;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            listBoxPermisosUsuario.DisplayMember = "Nombre";
            CargarRoles();
            CargarUsuarios();
            CargarArbolPermisos();
            ConfigurarPermisos();
            ActualizarLenguaje();

            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado += UsuarioActual_IdiomaCambiado;
            }
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado -= UsuarioActual_IdiomaCambiado;
            }
        }

        private void UsuarioActual_IdiomaCambiado(object sender, EventArgs e)
        {
            ActualizarLenguaje();
        }

        private void NotificarCambios()
        {
            DatosModificados?.Invoke(this, EventArgs.Empty);
        }

        // --- Registro de usuario ---
        private void buttonRegistrarUsuario_Click(object sender, EventArgs e)
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
                NotificarCambios();
            }
            else
            {
                MessageBox.Show("Error al registrar");

                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Registro", "El administrador ha intentado crear un nuevo usuario", DateTime.Now);
                }

                NotificarCambios();
            }
        }

        // --- Modificar usuario ---
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
                    NotificarCambios();
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

        // --- Cargar usuarios ---
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        // --- Árbol de permisos ---
        private void CargarArbolPermisos()
        {
            try
            {
                treePermisos.Nodes.Clear();
                var todos = bllPermiso.ObtenerTodos();

                // Buscar raíces (componentes sin padres)
                HashSet<int> hijosIds = new HashSet<int>();
                foreach (var c in todos)
                {
                    foreach (var h in c.Hijos)
                    {
                        hijosIds.Add(h.ID_Componente);
                    }
                }

                List<S_Componente> raices = new List<S_Componente>();
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

        private void LlenarNodo(TreeNodeCollection nodos, S_Componente comp)
        {
            TreeNode nuevoNodo = new TreeNode(comp.Nombre);
            nuevoNodo.Tag = comp;
            nodos.Add(nuevoNodo);

            foreach (var hijo in comp.Hijos)
            {
                LlenarNodo(nuevoNodo.Nodes, hijo);
            }
        }

        // --- Permisos del usuario ---
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

            var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
            if (usuarioSelected != null)
            {
                txtNuevoUsuario.Text = usuarioSelected.Nombre;
                txtNuevaPassword.Text = "";
            }
        }

        // --- Asignar permiso ---
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

                var permiso = selectedNode.Tag as S_Componente;
                if (permiso == null) return;

                if (usuarioSelected.Permisos.Any(p => p.ID_Componente == permiso.ID_Componente)) //verifica si ya tiene el permiso
                {
                    MessageBox.Show("El usuario ya cuenta con este permiso asignado directamente.");
                    return;
                }

                usuarioSelected.Permisos.Add(permiso);
                bllPermiso.GuardarPermisosUsuario(usuarioSelected, usuarioSelected.Permisos);


                var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Permisos",
                        $"El administrador asignó el permiso '{permiso.Nombre}' al usuario '{usuarioSelected.Nombre}'", DateTime.Now);
                }

                MessageBox.Show("Permiso asignado correctamente.");
                CargarPermisosUsuario();
                NotificarCambios();

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

        // --- Quitar permiso ---
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

                var permiso = listBoxPermisosUsuario.SelectedItem as S_Componente;
                if (permiso == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso de la lista de permisos directos.");
                    return;
                }

                // Evitar quitar el permiso de admin al propio usuario admin (verificación de seguridad)
                if (usuarioSelected.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase) && permiso.Nombre.Equals("Rol Admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No se puede quitar el rol de administrador al usuario principal admin.");
                    return;
                }

                // Quitar
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
                    NotificarCambios();

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

        // --- Roles ---
        private void CargarRoles()
        {
            var todos = bllPermiso.ObtenerTodos();
            var roles = new System.Collections.Generic.List<S_Componente>();
            var permisosComunes = new System.Collections.Generic.List<S_Componente>();

            foreach (var c in todos)
            {
                if (c is S_Composite) roles.Add(c);
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
            var rol = comboBoxRoles.SelectedItem as S_Componente;
            if (rol != null)
            {
                var todos = bllPermiso.ObtenerTodos();
                S_Componente rolActualizado = null;
                foreach (var c in todos)
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

            var comp = new S_Composite { Nombre = nombreRol };
            bllPermiso.GuardarComponente(comp);
            MessageBox.Show("Rol creado con éxito.");
            textBoxNuevoRol.Text = "";
            CargarArbolPermisos();
            CargarRoles();
            NotificarCambios();
        }

        private void btnAsignarARol_Click(object sender, EventArgs e)
        {
            var rol = comboBoxRoles.SelectedItem as S_Componente;
            var permiso = comboBoxPermisosTodos.SelectedItem as S_Componente;
            if (rol == null || permiso == null) return;

            if (permiso.ID_Componente == rol.ID_Componente)
            {
                MessageBox.Show("No puede asignarse un rol a sí mismo.");
                return;
            }

            var todos = bllPermiso.ObtenerTodos();
            S_Componente rolActual = null;
            S_Componente permisoCompleto = null;
            foreach (var c in todos)
            {
                if (c.ID_Componente == rol.ID_Componente) rolActual = c;
                if (c.ID_Componente == permiso.ID_Componente) permisoCompleto = c;
            }
            if (rolActual == null || permisoCompleto == null) return;

            foreach (var h in rolActual.Hijos)
            {
                if (h.ID_Componente == permiso.ID_Componente)
                {
                    MessageBox.Show("El rol ya tiene este permiso.");
                    return;
                }
            }

            // Verificar circularidad: el rolActual no puede estar dentro del permiso (si es que el permiso es un Composite)
            if (permisoCompleto.Contiene(rolActual.ID_Componente))
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
            NotificarCambios();
            ConfigurarPermisos();
        }

        private void btnQuitarDeRol_Click(object sender, EventArgs e)
        {
            var rol = comboBoxRoles.SelectedItem as S_Componente;
            var permiso = listBoxPermisosRol.SelectedItem as S_Componente;
            if (rol == null || permiso == null) return;

            var todos = bllPermiso.ObtenerTodos();
            S_Componente rolActual = null;
            foreach (var c in todos) { if (c.ID_Componente == rol.ID_Componente) rolActual = c; }
            if (rolActual == null) return;

            S_Componente aRemover = null;
            foreach (var h in rolActual.Hijos)
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
                NotificarCambios();
                ConfigurarPermisos();
            }
        }

        // --- Configurar permisos ---
        public void ConfigurarPermisos()
        {
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (usuarioSesion != null)
            {
                BLL_Permiso bllPermisoEval = new BLL_Permiso();

                // Registrar Usuario
                buttonRegistrarUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevoUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevaPassword.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");

                // Gestionar Permisos
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
            }
        }

        // --- Traducción ---
        public void ActualizarLenguaje()
        {
            this.Text = BLL_Multilenguaje.Instancia.Traducir("tabPageUsuarios", "PanelAdmin");
            if (this.Text.StartsWith("[Default:")) this.Text = "Usuarios y Permisos";

            labelUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelUsuario", "PanelAdmin");
            labelContraseña.Text = BLL_Multilenguaje.Instancia.Traducir("labelContrasena", "PanelAdmin");
            buttonRegistrarUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("buttonRegistrarUsuario", "PanelAdmin");
            labelSelectUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelSelectUsuario", "PanelAdmin");
            labelTreePermisos.Text = BLL_Multilenguaje.Instancia.Traducir("labelTreePermisos", "PanelAdmin");
            btnAsignar.Text = BLL_Multilenguaje.Instancia.Traducir("btnAsignar", "PanelAdmin");
            btnQuitar.Text = BLL_Multilenguaje.Instancia.Traducir("btnQuitar", "PanelAdmin");
            labelPermisosUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelPermisosUsuario", "PanelAdmin");
            buttonModificarUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("buttonModificarUsuario", "PanelAdmin");

            if (labelNuevoRol != null)
            {
                string tLblNuevoRol = BLL_Multilenguaje.Instancia.Traducir("labelNuevoRol", "PanelAdmin");
                labelNuevoRol.Text = tLblNuevoRol.StartsWith("[Default:") ? "Nuevo Rol:" : tLblNuevoRol;

                string tBtnCrearRol = BLL_Multilenguaje.Instancia.Traducir("buttonCrearRol", "PanelAdmin");
                buttonCrearRol.Text = tBtnCrearRol.StartsWith("[Default:") ? "Crear" : tBtnCrearRol;

                string tLblSelectRol = BLL_Multilenguaje.Instancia.Traducir("labelSelectRol", "PanelAdmin");
                labelSelectRol.Text = tLblSelectRol.StartsWith("[Default:") ? "Editar Rol:" : tLblSelectRol;

                string tBtnAsignarARol = BLL_Multilenguaje.Instancia.Traducir("btnAsignarARol", "PanelAdmin");
                btnAsignarARol.Text = tBtnAsignarARol.StartsWith("[Default:") ? "Asig. Rol" : tBtnAsignarARol;

                string tBtnQuitarDeRol = BLL_Multilenguaje.Instancia.Traducir("btnQuitarDeRol", "PanelAdmin");
                btnQuitarDeRol.Text = tBtnQuitarDeRol.StartsWith("[Default:") ? "Quit. Rol" : tBtnQuitarDeRol;
            }
        }
    }
}
