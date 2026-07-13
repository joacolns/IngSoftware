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
    public partial class FormIdiomas : Form
    {
        // Evento para notificar al PanelAdmin que hubo cambios
        public event EventHandler DatosModificados;

        public FormIdiomas()
        {
            InitializeComponent();
        }

        private void FormIdiomas_Load(object sender, EventArgs e)
        {
            comboBoxIdioma.SelectedIndexChanged += comboBoxIdioma_SelectedIndexChanged;
            buttonActivarIdioma.Click += buttonActivarIdioma_Click;
            buttonDesactivarIdioma.Click += buttonDesactivarIdioma_Click;
            buttonAgregarIdioma.Click += buttonAgregarIdioma_Click;
            buttonAplicarCambiosIdioma.Click += buttonAplicarCambiosIdioma_Click;

            CargarIdiomas();
            ConfigurarPermisos();
            ActualizarLenguaje();

            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado += UsuarioActual_IdiomaCambiado;
            }
        }

        private void FormIdiomas_FormClosing(object sender, FormClosingEventArgs e)
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

        // --- Cargar idiomas ---
        private void CargarIdiomas()
        {
            try
            {
                comboBoxIdioma.SelectedIndexChanged -= comboBoxIdioma_SelectedIndexChanged;

                var idiomas = BLL_Multilenguaje.Instancia.ObtenerIdiomas();
                comboBoxIdioma.DataSource = null;
                comboBoxIdioma.DataSource = idiomas;
                comboBoxIdioma.DisplayMember = "Nombre";

                comboBoxIdioma.SelectedIndexChanged += comboBoxIdioma_SelectedIndexChanged;

                // Seleccionar el idioma actual
                var actual = BLL_Multilenguaje.Instancia.IdiomaActual;
                if (actual != null)
                {
                    foreach (var idm in ConvertirListaAArray(idiomas))
                    {
                        if (idm.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdioma.SelectedItem = idm;
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

        private BE_Idioma[] ConvertirListaAArray(List<BE_Idioma> list)
        {
            return list?.ToArray() ?? new BE_Idioma[0];
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
                    NotificarCambios();
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
                    NotificarCambios();
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
                nuevo.Agregado = false; // Desactivado por defecto

                BLL_Multilenguaje.Instancia.GuardarIdioma(nuevo);
                textBoxAgregarNombreIdioma.Text = "";
                MessageBox.Show("Idioma agregado con éxito. Active el idioma y traduzca sus controles.");
                CargarIdiomas();
                NotificarCambios();
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
                    NotificarCambios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cambios: " + ex.Message);
            }
        }

        // --- Configurar permisos ---
        public void ConfigurarPermisos()
        {
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (usuarioSesion != null)
            {
                BLL_Permiso bllPermisoEval = new BLL_Permiso();
                bool tienePermiso = bllPermisoEval.TienePermiso(usuarioSesion, "Gestionar idiomas");
                foreach (Control c in this.Controls)
                {
                    c.Enabled = tienePermiso;
                }
            }
        }

        // --- Traducción ---
        public void ActualizarLenguaje()
        {
            string tIdiomas = BLL_Multilenguaje.Instancia.Traducir("tabPageIdiomas", "PanelAdmin");
            this.Text = tIdiomas.StartsWith("[Default:") ? "Idiomas" : tIdiomas;

            labelManejodeidiomas.Text = BLL_Multilenguaje.Instancia.Traducir("labelManejodeidiomas", "PanelAdmin");
            labelIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("labelIdioma", "PanelAdmin");
            buttonActivarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonActivarIdioma", "PanelAdmin");
            buttonDesactivarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonDesactivarIdioma", "PanelAdmin");
            labelNombredelidioma.Text = BLL_Multilenguaje.Instancia.Traducir("labelNombredelidioma", "PanelAdmin");
            buttonAgregarIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonAgregarIdioma", "PanelAdmin");
            buttonAplicarCambiosIdioma.Text = BLL_Multilenguaje.Instancia.Traducir("buttonAplicarCambiosIdioma", "PanelAdmin");
        }
    }
}
