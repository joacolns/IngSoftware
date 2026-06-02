using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Hoja : Componente
    {
        public override void Agregar(Componente permiso)
        {
            throw new InvalidOperationException("No se pueden agregar permisos a una hoja.");
        }

        public override void Quitar(Componente permiso)
        {
            throw new InvalidOperationException("No se pueden quitar permisos de una hoja.");
        }

        public override List<Componente> ObtenerHijos()
        {
            return new List<Componente>();
        }
    }
}