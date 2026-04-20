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
            // 1. Instanciamos la DAL (Capa de Acceso a Datos)
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();

            // 2. Le pedimos a la DAL que intente el login. 
            // Como refactorizamos la DAL antes, ahora nos devuelve el objeto BE completo o null.
            BE.Usuario usuarioValidado = mp_usuario.Login(nombre, password);

            // 3. Lógica de Decisión
            if (usuarioValidado != null)
            {
                // ¡Punto clave! Si el usuario existe, lo guardamos en nuestro Singleton.
                // A partir de este milisegundo, el usuario está "logeado" para todo el sistema.
                GestorDeSesiones.Instancia.IniciarSesion(usuarioValidado);

                return true; // Éxito
            }

            // Si llegamos acá, es porque la DAL devolvió null (usuario/clave mal)
            return false;
        }

        public void Logout()
        {
            // Simplemente le pedimos al Singleton que borre los datos del usuario actual
            GestorDeSesiones.Instancia.CerrarSesion();
        }
    }
}
    

