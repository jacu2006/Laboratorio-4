using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploSProyBD
{
    public interface IValidadorCampo
    {
        bool EsValido(string? valor);
        string MensajeError { get; }
    }
}
