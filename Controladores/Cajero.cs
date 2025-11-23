using System;
using CajeroLite.Data;
using CajeroLite.IO;
using CajeroLite.Modelos;
using CajeroLite.Operaciones;
using CajeroLite.Utilidades;

namespace CajeroLite.Controladores
{
    public class Cajero
    {
        private Usuario usuarioActivo;

        public void Iniciar()
        {
            IO.IO.MostrarEncabezado("CAJERO AUTOMÁTICO IGOR");

            // LOGIN
            usuarioActivo = Login();

            if (usuarioActivo == null)
            {
                IO.IO.MostrarMensaje("Demasiados intentos fallidos. Saliendo...", true);
                return;
            }

            // MENÚ PRINCIPAL
            MenuPrincipal();
        }

        private Usuario Login()
        {
            int intentos = 0;

            while (intentos < 3)
            {
                string id = IO.IO.LeerEntrada("Ingrese su ID:");
                string pin = IO.IO.LeerPin("Ingrese su PIN:");

                if (Datos.VerificarPin(id, pin))
                {
                    IO.IO.MostrarMensaje("Inicio de sesión exitoso.");
                    return Datos.BuscarUsuario(id);
                }

                intentos++;
                IO.IO.MostrarMensaje($"Credenciales incorrectas. Intentos restantes: {3 - intentos}", true);
                Utilidades.Utilidades.PausaAux();
            }

            return null;
        }

        private void MenuPrincipal()
        {
            int opcion = 0;

            do
            {
                IO.IO.MostrarEncabezado("MENÚ PRINCIPAL");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Salir");

                string entrada = IO.IO.LeerEntrada("Seleccione una opción:");

                if (!Utilidades.Utilidades.OpcionValida(entrada, 1, 4))
                {
                    IO.IO.MostrarMensaje("Opción no válida.", true);
                    Utilidades.Utilidades.PausaAux();
                    continue;
                }

                opcion = int.Parse(entrada);

                switch (opcion)
                {
                    case 1:
                        ConsultarSaldo();
                        break;
                    case 2:
                        Depositar();
                        break;
                    case 3:
                        Retirar();
                        break;
                }

            } while (opcion != 4);

            IO.IO.MostrarMensaje("Gracias por usar el cajero. ¡Hasta luego!");
        }

        private void ConsultarSaldo()
        {
            decimal saldo = usuarioActivo.Cuenta.Saldo;
            IO.IO.MostrarMensaje($"Saldo actual: {saldo:C}");
            Utilidades.Utilidades.PausaAux();
        }

        private void Depositar()
        {
            string montoStr = IO.IO.LeerEntrada("Ingrese el monto a depositar:");
            if (decimal.TryParse(montoStr, out decimal monto) && monto > 0)
            {
                usuarioActivo.Cuenta.Depositar(monto);
                IO.IO.MostrarMensaje($"Depósito exitoso. Nuevo saldo: {usuarioActivo.Cuenta.Saldo:C}");
            }
            else
            {
                IO.IO.MostrarMensaje("Monto inválido.", true);
            }
            Utilidades.Utilidades.PausaAux();
        }

        private void Retirar()
        {
            string montoStr = IO.IO.LeerEntrada("Ingrese el monto a retirar:");
            if (decimal.TryParse(montoStr, out decimal monto) && monto > 0)
            {
                if (usuarioActivo.Cuenta.Retirar(monto))
                    IO.IO.MostrarMensaje($"Retiro exitoso. Nuevo saldo: {usuarioActivo.Cuenta.Saldo:C}");
                else
                    IO.IO.MostrarMensaje("Fondos insuficientes.", true);
            }
            else
            {
                IO.IO.MostrarMensaje("Monto inválido.", true);
            }
            Utilidades.Utilidades.PausaAux();
        }
    }
}