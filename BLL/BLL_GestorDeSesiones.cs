using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
        public sealed class BLL_GestorDeSesiones
        {
            //variable estática privada
            private static BLL_GestorDeSesiones _instancia = null;
            private static  object _padlock = new object();
            private BLL_GestorDeSesiones() { }

            //puerta de acceso global
            public static BLL_GestorDeSesiones Instancia
            {
                get
                {
                    lock (_padlock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new BLL_GestorDeSesiones();
                        }
                        return _instancia;
                    }
                }
            }
            //Atributos de la Sesión

            public BE.Usuario UsuarioActual { get; private set; }

            public bool EstaLogeado { get { return UsuarioActual != null; } }

            public void IniciarSesion(BE.Usuario usuario)
            {
                UsuarioActual = usuario;
            }

            public void CerrarSesion()
            {
                UsuarioActual = null;
            }
        }
    }



    
