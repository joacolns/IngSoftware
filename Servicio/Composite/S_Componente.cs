using System;
using System.Collections.Generic;

namespace Servicio
{
    /// <summary>
    /// Component del patron Composite.
    /// Define la interfaz comun para hojas (S_Hoja) y compuestos (S_Composite),
    /// de modo que el cliente pueda tratarlos de forma uniforme.
    /// </summary>
    public abstract class S_Componente
    {
        public int ID_Componente { get; set; }
        public string Nombre { get; set; }

        /// Discriminador que se persiste en la columna "tipo": "Hoja" o "Composite".
        public abstract string Tipo { get; }

        public abstract List<S_Componente> Hijos { get; }

        public abstract void Agregar(S_Componente componente);
        public abstract void Quitar(S_Componente componente);

        /// Resuelve el permiso recorriendo el arbol hacia abajo.
        public abstract bool TienePermiso(string nombrePermiso);

        /// Indica si el componente dado ya cuelga de este (evita ciclos al anidar).
        public abstract bool Contiene(int idComponente);

        public override string ToString()
        {
            return Nombre;
        }
    }
}
