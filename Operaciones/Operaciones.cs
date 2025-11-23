using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroLite.Data;
using CajeroLite.Utilidades;

namespace CajeroLite.Operaciones
{
    public static class Operaciones
    {
        public static (bool, string) Depositar(string id, decimal monto)
        {
            try
            {
                if (!Utilidades.Utilidades.ValidarMonto(monto))
                    return (false, "Monto inválido. Debe ser mayor que cero.");

                decimal saldoActual = Datos.ObtenerSaldo(id);
                decimal nuevo = saldoActual + monto;
                Datos.ActualizarSaldo(id, nuevo);
                return (true, $"Depósito exitoso. Nuevo saldo: {nuevo:C}");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar el depósito: " + ex.Message);
            }
        }

        public static (bool, string) Retirar(string id, decimal monto)
        {
            try
            {
                if (!Utilidades.Utilidades.ValidarMonto(monto))
                    return (false, "Monto inválido. Debe ser mayor que cero.");

                decimal saldoActual = Datos.ObtenerSaldo(id);

                if (monto > saldoActual)
                    return (false, "Fondos insuficientes para realizar el retiro.");

                decimal nuevo = saldoActual - monto;
                Datos.ActualizarSaldo(id, nuevo);
                return (true, $"Retiro exitoso. Nuevo saldo: {nuevo:C}");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar el retiro: " + ex.Message);
            }
        }

        public static decimal ConsultarSaldo(string id)
        {
            return Datos.ObtenerSaldo(id);
        }
    }
}