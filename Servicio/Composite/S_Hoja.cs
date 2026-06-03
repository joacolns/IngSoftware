using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class S_Hoja : S_Componente
    {
        public override void Agregar(S_Componente permiso)
        {
            throw new InvalidOperationException("No se pueden agregar permisos a una hoja.");
        }

        public override void Quitar(S_Componente permiso)
        {
            throw new InvalidOperationException("No se pueden quitar permisos de una hoja.");
        }

        public override List<S_Componente> ObtenerHijos()
        {
            return new List<S_Componente>();
        }
    }
}