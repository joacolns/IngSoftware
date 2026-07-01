using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
        public sealed class S_GestorDeSesion
        {
            //variable estática privada
            private static S_GestorDeSesion _instancia = null;
            private static  object _padlock = new object();
            private S_GestorDeSesion() { }

            //puerta de acceso global
            public static S_GestorDeSesion Instancia
            {
                get
                {
                    lock (_padlock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new S_GestorDeSesion();
                        }
                        return _instancia;
                    }
                }
            }
            //Atributos de la Sesión

            public object UsuarioActual { get; set; }

            public bool EstaLogeado { get { return UsuarioActual != null; } }

            public void IniciarSesion(object usuario)
            {
                UsuarioActual = usuario;
            }

            public void CerrarSesion()
            {
                UsuarioActual = null;
            }
        }
    }



    
