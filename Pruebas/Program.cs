using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Pruebas
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChangeString ChangeString = new ChangeString();
            OrderRange OrderRange = new OrderRange();
            MoneyParts MoneyParts = new Clases.MoneyParts();

            string cadena = "";             
            int nroEjercicio;
            int[] coleccion = null;

            Console.WriteLine("Escriba el nro de Ejercicio a probar 1, 2 o 3");
            nroEjercicio = Convert.ToInt32(Console.ReadLine());

            while (nroEjercicio == 1 || nroEjercicio == 2 || nroEjercicio == 3)
            {
                switch (nroEjercicio)
                {
                    case 1:
                        Console.WriteLine("Cadena de Entrada: ");
                        cadena = Console.ReadLine();
                        Console.Write("");
                        Console.WriteLine("Cadena de Salida : " + ChangeString.build(cadena));
                        Console.WriteLine("Escriba el nro de Ejercicio a probar 1, 2 o 3");
                        nroEjercicio = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 2:
                        Console.WriteLine("Ingrese la coleccion de enteros separado por comas:");
                        cadena = Console.ReadLine();
                        var listaNumeros = cadena.Split(',');
                        coleccion = new int[listaNumeros.Count()];

                        for (int i = 0; i < listaNumeros.Length; i++)
                        {
                            coleccion[i] = Convert.ToInt32((listaNumeros[i].ToString()));
                        }
                        var resultList = OrderRange.build(coleccion);                        
                        Console.WriteLine(string.Join(",", resultList[0]));
                        Console.WriteLine(string.Join(",", resultList[1]));
                        Console.WriteLine("");
                        Console.WriteLine("Escriba el nro de Ejercicio a probar 1, 2 o 3");
                        nroEjercicio = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 3:
                        Console.WriteLine("Ingrese el monto en soles:");
                        cadena = Console.ReadLine();
                        var res = MoneyParts.build(cadena);

                        foreach (var item in res.Values)
                        {
                            Console.WriteLine(string.Join(",", item));
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Escriba el nro de Ejercicio a probar 1, 2 o 3");
                        nroEjercicio = Convert.ToInt32(Console.ReadLine());

                        break;
                    default:
                        break;
                }

            }
        }

    }
}
