using System;

namespace Servicio
{
    public interface ISujeto
    {
        void Registrar(IObserver observer);
        void Desregistrar(IObserver observer);
        void Notificar();
    }
}
