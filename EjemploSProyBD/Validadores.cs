using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EjemploSProyBD
{
    public class ValidadorTexto : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                MensajeError = "El campo de texto no puede estar vacío.";
                return false;
            }
            return true;
        }
    }

    // 2. Validador para Decimales (ej. Precio)
    public class ValidadorDecimal : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                !decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultado) ||
                resultado < 0)
            {
                MensajeError = "Debe ingresar un número decimal válido mayor o igual a 0 (ej. 4.50).";
                return false;
            }
            return true;
        }
    }

    // 3. Validador para Enteros (ej. Cantidad o Folio)
    public class ValidadorEntero : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                !int.TryParse(valor, out int resultado) ||
                resultado < 0)
            {
                MensajeError = "Debe ingresar un número entero válido mayor o igual a 0.";
                return false;
            }
            return true;
        }
    }
}
