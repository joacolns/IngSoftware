using System;
using System.Collections.Generic;

namespace Servicio
{
    /// <summary>
    /// Composite del patron: un rol, que agrupa hojas y/o otros roles.
    /// Sus operaciones delegan recursivamente en los hijos.
    /// </summary>
    public class S_Composite : S_Componente
    {
        private List<S_Componente> _hijos = new List<S_Componente>();

        public override string Tipo => "Composite";

        public override List<S_Componente> Hijos => _hijos;

        public override void Agregar(S_Componente componente)
        {
            if (componente != null && !_hijos.Exists(h => h.ID_Componente == componente.ID_Componente))
            {
                _hijos.Add(componente);
            }
        }

        public override void Quitar(S_Componente componente)
        {
            if (componente != null)
            {
                S_Componente aEliminar = _hijos.Find(h => h.ID_Componente == componente.ID_Componente);
                if (aEliminar != null)
                {
                    _hijos.Remove(aEliminar);
                }
            }
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            if (Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return _hijos.Exists(h => h.TienePermiso(nombrePermiso));
        }

        public override bool Contiene(int idComponente)
        {
            if (ID_Componente == idComponente)
            {
                return true;
            }
            return _hijos.Exists(h => h.Contiene(idComponente));
        }
    }
}
