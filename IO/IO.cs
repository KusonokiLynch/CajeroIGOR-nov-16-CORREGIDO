using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroLite.IO
{
    public static class IO
    {
        public static void MostrarMensaje(string mensaje, bool esError = false)
        {
            if (esError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mensaje);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mensaje);
                Console.ResetColor();   
            }
        }

        public static string LeerEntrada(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        public static string LeerPin(string prompt)
        {
            Console.Write(prompt + " ");
            string pin = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin = pin.Substring(0, pin.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    pin += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pin.Trim();
        }

        public static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(titulo);
            Console.WriteLine("=====================================");
        }

        public static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
