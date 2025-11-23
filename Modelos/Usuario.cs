using System;
using CajeroLite.Modelos;
using CajeroLite.App;


namespace CajeroLite.Modelos
{
    public class Usuario
    {
        
        public string IdUsuario { get; private set; }
        public string Nombre { get; private set; }
        public string Pin { get; private set; }
        public Cuenta Cuenta { get; private set; }


        public Usuario(string idUsuario, string pin, decimal saldoInicial)
        {
            IdUsuario = idUsuario;
            Pin = pin;
            Cuenta = new Cuenta(saldoInicial);
        }

        // Validar si el PIN ingresado coincide
        public bool ValidarPin(string pinIngresado)
        {
            return Pin == pinIngresado;
        }

        // Cambiar PIN de manera segura
        public bool CambiarPin(string pinActual, string nuevoPin)
        {
            if (pinActual != Pin)
                return false;

            if (string.IsNullOrWhiteSpace(nuevoPin) || nuevoPin.Length < 4)
                return false;

            Pin = nuevoPin;
            return true;
        }
    }
}
