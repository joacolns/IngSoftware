using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BLL_UsuarioCambio
    {
        private MP_UsuarioCambio mpCambio = new MP_UsuarioCambio();

        public void RegistrarCambio(BE_Usuario usuario, string tipoCambio, string modificadoPor)
        {
            int ultimaVersion = mpCambio.ObtenerUltimaVersionUsuario(usuario.ID_Usuario);
            int nuevaVersion = ultimaVersion + 1;

            BE_UsuarioCambio cambio = new BE_UsuarioCambio();
            cambio.ID_Usuario = usuario.ID_Usuario;
            cambio.Version = nuevaVersion;
            cambio.Nombre = usuario.Nombre;
            cambio.Password = usuario.Password;
            cambio.Fecha = DateTime.Now;
            cambio.Modificado_Por = modificadoPor;
            cambio.Tipo_Cambio = tipoCambio;

            mpCambio.Insertar(cambio);
        }

        public List<BE_UsuarioCambio> ObtenerCambiosUsuario(int idUsuario)
        {
            return mpCambio.ObtenerCambiosUsuario(idUsuario);
        }

        public int ActualizarUsuario(int idUsuario, string nombre, string password)
        {
            return mpCambio.ActualizarUsuario(idUsuario, nombre, password);
        }

        public bool RecomponerEstadoAnterior(BE_UsuarioCambio cambio, string modificadoPor)
        {
            int filas = mpCambio.ActualizarUsuario(cambio.ID_Usuario, cambio.Nombre, cambio.Password);
            if (filas > 0)
            {
                // Recalcular dígitos verificadores
                BLL_DigitoVerificador bllDigVer = new BLL_DigitoVerificador();
                bllDigVer.RecalcularTodo();

                // Registrar el cambio de recomposición
                BE_Usuario usuarioRecompuesto = new BE_Usuario();
                usuarioRecompuesto.ID_Usuario = cambio.ID_Usuario;
                usuarioRecompuesto.Nombre = cambio.Nombre;
                usuarioRecompuesto.Password = cambio.Password;

                RegistrarCambio(usuarioRecompuesto, "Recomposicion (v" + cambio.Version + ")", modificadoPor);
                return true;
            }
            return false;
        }
    }
}
