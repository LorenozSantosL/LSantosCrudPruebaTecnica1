using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    var editoriales =context.EditorialGetAll().ToList();

                    result.Objects = new List<object>();

                    if(editoriales != null)
                    {
                        foreach(var obj in editoriales)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.Nombre = obj.Nombre;

                            result.Objects.Add(editorial);

                        }
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }
            return result;
        }
    }
}
