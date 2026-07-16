using BE;
using Servicio;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Permiso
    {
        private MP_Permiso mpPermiso = new MP_Permiso();

        public List<S_Componente> ObtenerTodos()
        {
            return mpPermiso.ObtenerTodos();
        }

        public int GuardarComponente(S_Componente componente)
        {
            return mpPermiso.GuardarComponente(componente);
        }

        public List<S_Componente> ObtenerPermisosUsuario(BE_Usuario usuario)
        {
            List<S_Componente> todos = mpPermiso.ObtenerTodos();
            return mpPermiso.ObtenerPermisosUsuario(usuario.ID_Usuario, todos);
        }

        public void GuardarPermisosUsuario(BE_Usuario usuario, List<S_Componente> permisos)
        {
            mpPermiso.GuardarPermisosUsuario(usuario.ID_Usuario, permisos);
        }

        public bool TienePermiso(BE_Usuario usuario, string nombrePermiso)
        {
            if (usuario == null || usuario.Permisos == null) return false;
            return usuario.Permisos.Any(comp => comp.TienePermiso(nombrePermiso));
        }
    }
}
