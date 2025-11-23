using System;
using System.Collections.Generic;
using System.Linq;
using CajeroLite.Modelos;

namespace CajeroLite.Data
{
    public static class Datos
    {
      
        public static List<Usuario> Usuarios = new List<Usuario>()
        {
            new Usuario("1001", "1234", 500000m),
            new Usuario("2002", "5678", 1200000m)
        };

        public static Usuario BuscarUsuario(string id)
        {
            return Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public static bool UsuarioExiste(string id)
        {
            return BuscarUsuario(id) != null;
        }

        public static bool VerificarPin(string id, string pin)
        {
            var user = BuscarUsuario(id);
            return user != null && user.Pin == pin;
        }

        public static decimal ObtenerSaldo(string id)
        {

            var user = BuscarUsuario(id);
            return user?.Cuenta.Saldo ?? 0;
        }

        public static void ActualizarSaldo(string id, decimal nuevoSaldo)
        {
            var user = BuscarUsuario(id);
            if (user != null)
            {
               
                decimal diferencia = nuevoSaldo - user.Cuenta.Saldo;
                if (diferencia > 0)
                {
                    user.Cuenta.Depositar(diferencia);
                }
                else if (diferencia < 0)
                {
                    user.Cuenta.Retirar(Math.Abs(diferencia));
                }
            }
        }
    }
}