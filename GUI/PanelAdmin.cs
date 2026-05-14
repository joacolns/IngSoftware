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
    }
}
