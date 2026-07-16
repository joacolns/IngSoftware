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

                    // Registrar usuario como observador
                    BLL_Multilenguaje.Instancia.Registrar(usuarioBD);

                    // Cargar el idioma preferido del usuario si está configurado
                    if (usuarioBD.Idioma != null && usuarioBD.Idioma.ID_Idioma > 0) //> 0 - si no es español
                    {
                        var list = BLL_Multilenguaje.Instancia.ObtenerIdiomas();
                        var userLang = list.FirstOrDefault(i => i.ID_Idioma == usuarioBD.Idioma.ID_Idioma && i.Agregado);
                        if (userLang != null)
                        {
                            BLL_Multilenguaje.Instancia.IdiomaActual = userLang;
                        }
                    }
                    else
                    {
                        // Usar el idioma actual por defecto si no tiene ninguno guardado
                        usuarioBD.Idioma = BLL_Multilenguaje.Instancia.IdiomaActual;
                    }

                    return true;
                }
            }

            return false;
        }

      
        public bool RegistrarUsuario(string nombre, string passwordPlana)
        {
          
            string passwordHasheada = BLL_Seguridad.HashearPassword(passwordPlana);

            BE.BE_Usuario nuevoUsuario = new BE.BE_Usuario();
            nuevoUsuario.Nombre = nombre;
            nuevoUsuario.Password = passwordHasheada;
            nuevoUsuario.Logeado = 0;

            // Calcular DVH antes de insertar (usamos id=0 temporalmente, se recalcula después)
            nuevoUsuario.DigVerH = "";

            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            int filas = mp_usuario.Insertar(nuevoUsuario);

            if (filas > 0)
            {
                // Buscar el usuario recién creado
                BE.BE_Usuario usuarioCreado = mp_usuario.BuscarUsuarioPorNombre(nombre);
                if (usuarioCreado != null)
                {
                    // Asignar idioma Español por defecto
                    var idiomas = BLL_Multilenguaje.Instancia.ObtenerIdiomas();
                    BE.BE_Idioma espanol = null;
                    foreach (var i in idiomas)
                    {
                        if (i.Nombre.Equals("Espanol", StringComparison.OrdinalIgnoreCase))
                        {
                            espanol = i;
                            break;
                        }
                    }
                    if (espanol != null)
                    {
                        mp_usuario.ActualizarUsuarioIdioma(usuarioCreado.ID_Usuario, espanol.ID_Idioma);
                    }

                    // Recalcular todos los DVH y DVV para mantener integridad
                    // (se hace DESPUÉS de asignar el idioma para que el hash incluya el idIdioma correcto)
                    BLL_DigitoVerificador bllDigVer = new BLL_DigitoVerificador();
                    bllDigVer.RecalcularTodo();

                    // Registrar en control de cambios
                    BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                    string modificadoPor = "admin";
                    if (BLL_GestorDeSesion.Instancia.EstaLogeado)
                    {
                        modificadoPor = BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
                    }
                    bllCambio.RegistrarCambio(usuarioCreado, "Registro", modificadoPor);
                }
            }

            return filas > 0;
        }

        public void Logout()
        {
            var user = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (user != null)
            {
                BLL_Multilenguaje.Instancia.Desregistrar(user);
            }
            BLL_GestorDeSesion.Instancia.CerrarSesion();
        }

        public List<BE.BE_Usuario> ObtenerUsuarios()
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            return mp_usuario.ObtenerUsuarios();
        }

        public void ActualizarUsuarioIdioma(int idUsuario, int idIdioma)
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            mp_usuario.ActualizarUsuarioIdioma(idUsuario, idIdioma);
        }
    }
}
    

