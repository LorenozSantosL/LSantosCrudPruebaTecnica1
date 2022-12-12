using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    { 
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
           
            Console.Write("Ingrese Nombre del Libro: ");
            libro.Nombre = Console.ReadLine();

            Console.Write("Ingrese Id de Autor: ");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.Write("Ingres número de páginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Fecha de Publicación(DD-MM-YYYY: ");
            libro.FechaPublicacion = Console.ReadLine();

            Console.Write("Ingrese Id de Editorial: ");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Edición: ");
            libro.Edicion = Console.ReadLine();

            Console.Write("Ingrese el id del Género: ");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(result.Message);
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Error al Agregar el libro");
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }

        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.Write("Ingrese el Id de Libro a actualizar: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Nombre del Libro: ");
            libro.Nombre = Console.ReadLine();

            Console.Write("Ingrese Id de Autor: ");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.Write("Ingres número de páginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Fecha de Publicación(DD-MM-YYYY):  ");
            libro.FechaPublicacion = Console.ReadLine();

            Console.Write("Ingrese Id de Editorial: ");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Edición: ");
            libro.Edicion = Console.ReadLine();

            Console.Write("Ingrese el id del Género: ");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(result.Message);
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Error al actualizar el libro");
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            Console.Write("Ingrese el Id de Libro a eliminar: ");
            int IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(IdLibro);
            if (result.Correct)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(result.Message);
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Error al eliminar el libro");
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach(ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("Id de Libro: " + libro.IdLibro);
                    Console.WriteLine("Nombre Libro: " + libro.Nombre);
                    Console.WriteLine("Id Autor: " + libro.Autor.IdAutor);
                    Console.WriteLine("Nombre Autor: " + libro.Autor.Nombre);
                    Console.WriteLine("Número de páginas: " + libro.NumeroPaginas);
                    Console.WriteLine("Fecha de publicación: " + libro.FechaPublicacion);
                    Console.WriteLine("Id de Editorial: " + libro.Editorial.IdEditorial);
                    Console.WriteLine("Nombre de Editorial: " + libro.Editorial.Nombre);
                    Console.WriteLine("Edición: " + libro.Edicion);
                    Console.WriteLine("id de Género: " + libro.Genero.IdGenero);
                    Console.WriteLine("Nombre del Género: " + libro.Genero.Nombre);


                    Console.WriteLine("--------------------------------------------------------------");

                }
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Error al obtener los libros");
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
        }

        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();
            Console.Write("Ingrese el Id de Libro a consultal: ");
            int IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(IdLibro);

            if (result.Correct)
            {
                libro = (ML.Libro)result.Object;

                Console.WriteLine("Id de Libro: " + libro.IdLibro);
                Console.WriteLine("Nombre Libro: " + libro.Nombre);
                Console.WriteLine("Id Autor: " + libro.Autor.IdAutor);
                Console.WriteLine("Nombre Autor: " + libro.Autor.Nombre);
                Console.WriteLine("Número de páginas: " + libro.NumeroPaginas);
                Console.WriteLine("Fecha de publicación: " + libro.FechaPublicacion);
                Console.WriteLine("Id de Editorial: " + libro.Editorial.IdEditorial);
                Console.WriteLine("Nombre de Editorial: " + libro.Editorial.Nombre);
                Console.WriteLine("Edición: " + libro.Edicion);
                Console.WriteLine("id de Género: " + libro.Genero.IdGenero);
                Console.WriteLine("Nombre del Género: " + libro.Genero.Nombre);


                Console.WriteLine("--------------------------------------------------------------");

                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Error al obtener el libro");
                Console.WriteLine("Presione una tecla para terminar el programa");
                Console.ReadKey();
            }
        }
    }
}
