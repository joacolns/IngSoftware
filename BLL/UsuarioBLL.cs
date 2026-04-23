using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        public bool Login(string nombreUsuario, string passwordIngresada)
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            BE.Usuario usuarioBD = mp_usuario.BuscarUsuarioPorNombre(nombreUsuario);

            if (usuarioBD != null)
            {
               
                bool passwordCorrecta = Seguridad.VerificarPassword(passwordIngresada, usuarioBD.Password);

                if (passwordCorrecta)
                {
                   
                    GestorDeSesiones.Instancia.IniciarSesion(usuarioBD);
                    return true;
                }
            }

            return false;
        }

      
        public bool RegistrarUsuario(string nombre, string passwordPlana)
        {
          
            string passwordHasheada = Seguridad.HashearPassword(passwordPlana);

            BE.Usuario nuevoUsuario = new BE.Usuario();
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Password = passwordHasheada;
            nuevoUsuario.Logeado = 0;
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            int filas = mp_usuario.Insertar(nuevoUsuario);

            return filas > 0;
        }

        public void Logout()
        {
            GestorDeSesiones.Instancia.CerrarSesion();
        }
    }
}
    

