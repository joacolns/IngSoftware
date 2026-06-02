using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Hoja : BE_Componente
    {
        public override void Agregar(BE_Componente permiso)
        {
            throw new InvalidOperationException("No se pueden agregar permisos a una hoja.");
        }

        public override void Quitar(BE_Componente permiso)
        {
            throw new InvalidOperationException("No se pueden quitar permisos de una hoja.");
        }

        public override List<BE_Componente> ObtenerHijos()
        {
            return new List<BE_Componente>();
        }
    }
}