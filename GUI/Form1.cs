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
    public partial class Form1 : Form
    {

        BLL.Usuario BLLusuario;
        BE.Usuario BEUsuario;


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            BEUsuario.Nombre = txtBox_usuario.Text;
            BEUsuario.Password = txtBox_password.Text;

            BLLusuario.Login(BEUsuario);

            if (BEUsuario.Logeado == 1)
            {
                MessageBox.Show("Logeado");
            }
        }
    }
}
