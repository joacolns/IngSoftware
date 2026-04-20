using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
        public sealed class GestorDeSesiones
        {
            // 2. La variable estática privada
            private static GestorDeSesiones _instancia = null;

            // 3. El candado (recomendable ponerle 'readonly')
            private static readonly object _padlock = new object();

            // 4. El constructor privado (nadie puede hacer 'new' desde afuera)
            private GestorDeSesiones() { }

            // 5. La puerta de acceso global
            public static GestorDeSesiones Instancia
            {
                get
                {
                    lock (_padlock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new GestorDeSesiones();
                        }
                        return _instancia;
                    }
                }
            }

            // --- Atributos de la Sesión ---

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



    
