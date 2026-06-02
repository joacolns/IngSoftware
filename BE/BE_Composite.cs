using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Composite : BE_Componente
    {
        private List<BE_Componente> _hijos = new List<BE_Componente>();

        public override void Agregar(BE_Componente permiso)
        {
            if (permiso != null && !_hijos.Any(h => h.ID_Componente == permiso.ID_Componente))
            {
                _hijos.Add(permiso);
            }
        }

        public override void Quitar(BE_Componente permiso)
        {
            if (permiso != null)
            {
                var aEliminar = _hijos.FirstOrDefault(h => h.ID_Componente == permiso.ID_Componente);
                if (aEliminar != null)
                {
                    _hijos.Remove(aEliminar);
                }
            }
        }

        public override List<BE_Componente> ObtenerHijos()
        {
            return _hijos;
        }
    }
}