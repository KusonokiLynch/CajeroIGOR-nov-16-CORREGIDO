using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroLite.Utilidades
{
    public static class Utilidades
    {
        public static bool ValidarMonto(decimal monto)
        {
            return monto > 0m;
        }

        public static bool OpcionValida(string opcion, int min, int max)
        {
            if (!int.TryParse(opcion, out int val)) return false;
            return val >= min && val <= max;
        }

        // Método auxiliar para pausar con nombre consistente
        public static void PausaAux()
        {
            IO.IO.Pausar();
        }
    }
}
