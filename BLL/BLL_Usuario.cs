using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        public bool Login(string nombreUsuario, string passwordIngresada)
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            BE.BE_Usuario usuarioBD = mp_usuario.BuscarUsuarioPorNombre(nombreUsuario);

            if (usuarioBD != null)
            {
               
                bool passwordCorrecta = BLL_Seguridad.VerificarPassword(passwordIngresada, usuarioBD.Password);

                if (passwordCorrecta)
                {
                    BLL_Permiso bllPermiso = new BLL_Permiso();
                    usuarioBD.Permisos = bllPermiso.ObtenerPermisosUsuario(usuarioBD);

                    BLL_GestorDeSesion.Instancia.IniciarSesion(usuarioBD);
                    return true;
                }
            }

            return false;
        }

      
        public bool RegistrarUsuario(string nombre, string passwordPlana, string role)
        {
          
            string passwordHasheada = BLL_Seguridad.HashearPassword(passwordPlana);

            BE.BE_Usuario nuevoUsuario = new BE.BE_Usuario();
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Password = passwordHasheada;
            nuevoUsuario.Role = role;
            nuevoUsuario.Logeado = 0;

            // Calcular DVH antes de insertar (usamos id=0 temporalmente, se recalcula después)
            nuevoUsuario.DigVerH = "";

            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            int filas = mp_usuario.Insertar(nuevoUsuario);

            if (filas > 0)
            {
                // Recalcular todos los DVH y DVV para mantener integridad
                BLL_DigitoVerificador bllDigVer = new BLL_DigitoVerificador();
                bllDigVer.RecalcularTodo();
            }

            return filas > 0;
        }

        public void Logout()
        {
            BLL_GestorDeSesion.Instancia.CerrarSesion();
        }

        public List<BE.BE_Usuario> ObtenerUsuarios()
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            return mp_usuario.ObtenerUsuarios();
        }
    }
}
    

