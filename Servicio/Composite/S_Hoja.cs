using System;
using System.Collections.Generic;

namespace Servicio
{
    /// <summary>
    /// Leaf del patron Composite: un permiso simple, sin hijos.
    /// </summary>
    public class S_Hoja : S_Componente
    {
        public override string Tipo => "Hoja";

        public override List<S_Componente> Hijos => new List<S_Componente>();

        public override void Agregar(S_Componente componente)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a un permiso simple.");
        }

        public override void Quitar(S_Componente componente)
        {
            throw new InvalidOperationException("No se pueden quitar hijos de un permiso simple.");
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            return Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Contiene(int idComponente)
        {
            return ID_Componente == idComponente;
        }
    }
}
