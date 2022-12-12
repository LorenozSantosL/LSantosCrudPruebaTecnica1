using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GeAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    var generos = context.GeneroGetAll().ToList();

                    result.Objects = new List<object>();

                    if(generos != null)
                    {
                        foreach(var obj in generos)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = obj.IdGenero;
                            genero.Nombre = obj.Nombre;

                            result.Objects.Add(genero);
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
