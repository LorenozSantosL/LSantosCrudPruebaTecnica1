using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione una opcíon");
            Console.WriteLine("Add: 1");
            Console.WriteLine("Update: 2");
            Console.WriteLine("Delete: 3");
            Console.WriteLine("GetAll: 4");
            Console.WriteLine("GetById: 5");
            Console.Write("Opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("-------------------------------------------");
                    Libro.Add();
                    break;
                case 2:
                    Console.WriteLine("-------------------------------------------");
                    Libro.Update();
                    break;
                case 3:
                    Console.WriteLine("-------------------------------------------");
                    Libro.Delete();
                    break;
                case 4:
                    Console.WriteLine("-------------------------------------------");
                    Libro.GetAll();
                    break;
                case 5:
                    Console.WriteLine("--------------------------------------------");
                    Libro.GetById();
                    break;
                default:
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Opción incorrecta, presione cualquier tecla para terminar el programa");
                    Console.ReadKey();
                    break;

            }


        }
    }
}
