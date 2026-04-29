using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
        public sealed class BLL_GestorDeSesion
        {
            //variable estática privada
            private static BLL_GestorDeSesion _instancia = null;
            private static  object _padlock = new object();
            private BLL_GestorDeSesion() { }

            //puerta de acceso global
            public static BLL_GestorDeSesion Instancia
            {
                get
                {
                    lock (_padlock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new BLL_GestorDeSesion();
                        }
                        return _instancia;
                    }
                }
            }
            //Atributos de la Sesión

            public BE.BE_Usuario UsuarioActual { get; private set; }

            public bool EstaLogeado { get { return UsuarioActual != null; } }

            public void IniciarSesion(BE.BE_Usuario usuario)
            {
                UsuarioActual = usuario;
            }

            public void CerrarSesion()
            {
                UsuarioActual = null;
            }
        }
    }



    
