using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        public bool Login(string nombre, string password)
        {
           
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            BE.Usuario usuarioValidado = mp_usuario.Login(nombre, password);

            if (usuarioValidado != null)
            {
               
                GestorDeSesiones.Instancia.IniciarSesion(usuarioValidado);

                return true; 
            }

            return false;
        }
        public void Logout()
        {
            GestorDeSesiones.Instancia.CerrarSesion();
        }
    }
}
    

