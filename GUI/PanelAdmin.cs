using BE;
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
    public partial class PanelAdmin : Form
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

            // Initialize permissions UI
            listBoxPermisosUsuario.DisplayMember = "Nombre";
            SeedPermissionsAndAdmin();
            CargarUsuarios();
            CargarArbolPermisos();
            ConfigurarPermisos();

            // Bind control de cambios events and config
            dataGridViewControldecambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewControldecambios.MultiSelect = false;
            buttonRecomponerEstadoAnterior.Click += buttonRecomponerEstadoAnterior_Click;

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
            string nuevoNombre = txtNuevoUsuario.Text;
            string nuevaClave = txtNuevaPassword.Text; 
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();

            bool registrado = gestorUsuario.RegistrarUsuario(nuevoNombre, nuevaClave, comboBox1.SelectedItem.ToString());

            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (registrado)
            {
                MessageBox.Show("Usuario creado y encriptado con éxito");
                
                if (usuarioSesion != null)
                {
                    BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Registro", "El administrador ha creado un nuevo usuario", DateTime.Now);
                }
                
                EnlazarBitacora();
                CargarUsuarios();
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

        private void SeedPermissionsAndAdmin()
        {
            try
            {
                var todos = bllPermiso.ObtenerTodos();

                if (todos.Count == 0)
                {
                    // Create leaves
                    BE_Hoja h1 = new BE_Hoja { Nombre = "Ver Bitacora" };
                    BE_Hoja h2 = new BE_Hoja { Nombre = "Limpiar Bitacora" };
                    BE_Hoja h3 = new BE_Hoja { Nombre = "Registrar Usuario" };
                    BE_Hoja h4 = new BE_Hoja { Nombre = "Gestionar Permisos" };

                    bllPermiso.GuardarComponente(h1);
                    bllPermiso.GuardarComponente(h2);
                    bllPermiso.GuardarComponente(h3);
                    bllPermiso.GuardarComponente(h4);

                    // Create composites
                    BE_Composite rAdmin = new BE_Composite { Nombre = "Rol Admin" };
                    BE_Composite rUser = new BE_Composite { Nombre = "Rol Usuario" };

                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);

                    // Add children
                    rAdmin.Agregar(h1);
                    rAdmin.Agregar(h2);
                    rAdmin.Agregar(h3);
                    rAdmin.Agregar(h4);

                    rUser.Agregar(h1);

                    // Save relationships
                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Seed Admin User if not exists
                var usuarios = BLLusuario.ObtenerUsuarios();
                if (!usuarios.Any(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase)))
                {
                    BLLusuario.RegistrarUsuario("admin", "1234567", "admin");
                    
                    usuarios = BLLusuario.ObtenerUsuarios();
                    var adminUser = usuarios.FirstOrDefault(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase));
                    
                    if (adminUser != null)
                    {
                        var allPerms = bllPermiso.ObtenerTodos();
                        var rolAdmin = allPerms.FirstOrDefault(p => p.Nombre == "Rol Admin");
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
                    foreach (var h in c.ObtenerHijos())
                    {
                        hijosIds.Add(h.ID_Componente);
                    }
                }

                var raices = todos.Where(c => !hijosIds.Contains(c.ID_Componente)).ToList();

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

            foreach (var hijo in comp.ObtenerHijos())
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
                comboBox1.SelectedItem = usuarioSelected.Role;
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
                button1.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevoUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                txtNuevaPassword.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");
                comboBox1.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Registrar Usuario");

                // 3. Gestionar Permisos
                comboBoxUsuarios.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                treePermisos.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                listBoxPermisosUsuario.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                btnAsignar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");
                btnQuitar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar Permisos");

                // 4. Ver Bitacora
                dataGridViewBitacora.Visible = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                buttonBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                textBoxUsuarioBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaInicio.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaFinal.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CargarControlCambiosUsuario()
        {
            try
            {
                dataGridViewControldecambios.DataSource = null;
                var usuarioSelected = comboBoxUsuarios.SelectedItem as BE_Usuario;
                if (usuarioSelected != null)
                {
                    BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                    dataGridViewControldecambios.DataSource = bllCambio.ObtenerCambiosUsuario(usuarioSelected.ID_Usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el control de cambios: " + ex.Message);
            }
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
                string nuevoRol = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : usuarioSelected.Role;

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
                int filas = bllCambio.ActualizarUsuario(usuarioSelected.ID_Usuario, nuevoNombre, passwordHasheada, nuevoRol);

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
                    usuarioModificado.Role = nuevoRol;

                    string modificadoPor = "admin";
                    if (BLL_GestorDeSesion.Instancia.EstaLogeado)
                    {
                        modificadoPor = BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
                    }

                    bllCambio.RegistrarCambio(usuarioModificado, "Modificacion", modificadoPor);

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
    }
}
