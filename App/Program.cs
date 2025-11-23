using CajeroLite.Controladores;
using CajeroLite.App;
using CajeroLite.Data;
using CajeroLite.IO;
using CajeroLite.Modelos;
using CajeroLite.Operaciones;
using CajeroLite.Utilidades;


namespace CajeroLite.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Cajero cajero = new Cajero();
            cajero.Iniciar();
        }
    }
}
