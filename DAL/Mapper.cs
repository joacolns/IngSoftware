using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    abstract public class Mapper<T>
    {
        internal Acceso acceso;

        public abstract int Insertar(T objeto);
        public abstract int Login(T objeto);
    }
}