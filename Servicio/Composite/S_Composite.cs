using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class S_Composite : S_Componente
    {
        private List<S_Componente> hijos = new List<S_Componente>();

        public override void Agregar(S_Componente permiso)
        {
            if (permiso != null)
            {
                foreach (var h in hijos)
                {
                    if (h.ID_Componente == permiso.ID_Componente)
                        return; // Si ya existe, salimos
                }
                hijos.Add(permiso);
            }
        }

        public override void Quitar(S_Componente permiso)
        {
            if (permiso != null)
            {
                foreach (var h in hijos)
                {
                    if (h.ID_Componente == permiso.ID_Componente)
                    {
                        hijos.Remove(h);
                        return; // Se encontró y se eliminó, salimos del ciclo
                    }
                }
            }
        }

        public override List<S_Componente> ObtenerHijos()
        {
            return hijos;
        }
    }
}