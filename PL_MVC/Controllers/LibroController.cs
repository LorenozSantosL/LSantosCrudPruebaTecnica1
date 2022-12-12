using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = BL.Libro.GetAllEF();

            if (result.Correct)
            {
                libro.Libros = result.Objects;   
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();
            ML.Result resultGenero = BL.Genero.GeAll();

            if(IdLibro == null)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;

                    libro.Autor.Autores = resultAutor.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                    libro.Genero.Generos = resultGenero.Objects;
                    return View(libro);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al traer los datos del libro";
                    return PartialView("Modal");
                }

                
            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            if (libro.IdLibro == 0)
            {
                ML.Result result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: "+result.Message;
                }
            }
            else
            {
                ML.Result result = BL.Libro.UpdtadeEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {
            if(IdLibro > 0)
            {
                ML.Result result = BL.Libro.DeleteEF(IdLibro);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: "+result.Message;
                }
            }
            return PartialView("Modal");
        }

    }
}