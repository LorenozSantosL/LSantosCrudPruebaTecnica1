using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    var autores = context.AutorGetAll().ToList();

                    result.Objects = new List<object>();

                    if(autores != null)
                    {
                        foreach(var obj in autores)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = obj.IdAutor;
                            autor.Nombre = obj.Nombre;

                            result.Objects.Add(autor);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }
            return result;
        }
    }
}
