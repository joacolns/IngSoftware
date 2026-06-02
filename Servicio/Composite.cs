using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Composite : Componente
    {
        private List<Componente> hijos = new List<Componente>();

        public override void Agregar(Componente permiso)
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

        public override void Quitar(Componente permiso)
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

        public override List<Componente> ObtenerHijos()
        {
            return hijos;
        }
    }
}