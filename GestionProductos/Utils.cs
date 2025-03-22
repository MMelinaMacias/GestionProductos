using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos
{
    public class Utils
    {
        public static string ValidateString(string str)
        {
            while (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("El valor ingresado no puede estar vacío. Inténtelo de nuevo.");
                str = Console.ReadLine();
            }
            return str;
        }


        public static int ValidateInt(string str)
        {
            int resultado;
            while (!int.TryParse(str, out resultado ) || resultado <= 0)
            {
                Console.WriteLine("El valor ingresado no es un número entero válido. Inténtelo de nuevo.");
                str = Console.ReadLine();
            }
            return resultado;
        }

        public static decimal ValidateDecimal(string str)
        {
            decimal resultado;
            while (!decimal.TryParse(str, out resultado) || resultado <= 0)
            {
                Console.WriteLine("El valor ingresado no es un número decimal válido. Inténtelo de nuevo.");
                str = Console.ReadLine();
            }
            return resultado;
        }
    }
}
