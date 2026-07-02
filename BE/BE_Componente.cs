using System;
using System.Collections.Generic;

namespace BE
{
    public abstract class BE_Componente
    {
        public int ID_Componente { get; set; }
        public string Nombre { get; set; }
        public abstract string Tipo { get; }
        public abstract List<BE_Componente> Hijos { get; }
        public abstract void Agregar(BE_Componente componente);
        public abstract void Quitar(BE_Componente componente);
        public abstract bool TienePermiso(string nombrePermiso);
        public abstract bool Contiene(int idComponente);

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class BE_Permiso : BE_Componente
    {
        public override string Tipo => "Hoja";

        public override List<BE_Componente> Hijos => new List<BE_Componente>();

        public override void Agregar(BE_Componente componente)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a un permiso simple.");
        }

        public override void Quitar(BE_Componente componente)
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

    public class BE_Rol : BE_Componente
    {
        private List<BE_Componente> _hijos = new List<BE_Componente>();

        public override string Tipo => "Composite";

        public override List<BE_Componente> Hijos => _hijos;

        public override void Agregar(BE_Componente componente)
        {
            if (componente != null && !_hijos.Exists(h => h.ID_Componente == componente.ID_Componente))
            {
                _hijos.Add(componente);
            }
        }

        public override void Quitar(BE_Componente componente)
        {
            if (componente != null)
            {
                BE_Componente aEliminar = _hijos.Find(h => h.ID_Componente == componente.ID_Componente);
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