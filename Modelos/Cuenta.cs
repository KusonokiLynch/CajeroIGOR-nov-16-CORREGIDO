using System;

namespace CajeroLite.Modelos
{
    public class Cuenta
    {
        // Saldo: lectura pública, escritura privada
        public decimal Saldo { get; private set; }

        public Cuenta(decimal saldoInicial)
        {
            if (saldoInicial < 0)
                saldoInicial = 0;

            Saldo = saldoInicial;
        }

        // Depositar
        public bool Depositar(decimal monto)
        {
            if (monto <= 0) return false;

            Saldo += monto;
            return true;
        }

        // Retirar
        public bool Retirar(decimal monto)
        {
            if (monto <= 0) return false;
            if (monto > Saldo) return false;

            Saldo -= monto;
            return true;
        }

        // Consultar saldo
        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
    }
}
