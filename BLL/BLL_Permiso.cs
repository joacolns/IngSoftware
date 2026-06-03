using BE;
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

        public List<BE_Componente> ObtenerTodos()
        {
            return mpPermiso.ObtenerTodos();
        }

        public int GuardarComponente(BE_Componente componente)
        {
            return mpPermiso.GuardarComponente(componente);
        }

        public List<BE_Componente> ObtenerPermisosUsuario(BE_Usuario usuario)
        {
            List<BE_Componente> todos = mpPermiso.ObtenerTodos();
            return mpPermiso.ObtenerPermisosUsuario(usuario.ID_Usuario, todos);
        }

        public void GuardarPermisosUsuario(BE_Usuario usuario, List<BE_Componente> permisos)
        {
            mpPermiso.GuardarPermisosUsuario(usuario.ID_Usuario, permisos);
        }

        public bool TienePermiso(BE_Usuario usuario, string nombrePermiso)
        {
            if (usuario == null || usuario.Permisos == null) {

                return false;
            } 

            foreach (var comp in usuario.Permisos)
            {
                if (EvaluarTienePermiso(comp, nombrePermiso))
                {
                    return true;
                }
            }
            return false;
        }

        private bool EvaluarTienePermiso(BE_Componente comp, string nombrePermiso)
        {
            if (comp.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            foreach (var hijo in comp.ObtenerHijos())
            {
                if (EvaluarTienePermiso(hijo, nombrePermiso))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
