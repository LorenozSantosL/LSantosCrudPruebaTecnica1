using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroAdd";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Se ha agregado el libro";
                        }
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

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroUpdate";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;

                        collection[3] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Se ha actualizado el libro";
                        }
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

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroDelete";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Se ha elimiado el libro";
                        }

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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroGetAll";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(tableLibro);


                        if (tableLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach(DataRow row in tableLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.Nombre = row[3].ToString();

                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = row[5].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.Nombre = row[7].ToString();

                                libro.Edicion = row[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.Nombre = row[10].ToString();

                                result.Objects.Add(libro);
                            }
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }

            return result;
        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    var query = "LibroGetById";

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(tableLibro);

                        if(tableLibro.Rows.Count > 0)
                        {
                            DataRow row = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.Autor.Nombre = row[3].ToString();

                            libro.NumeroPaginas = int.Parse(row[4].ToString());
                            libro.FechaPublicacion = row[5].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.Nombre = row[7].ToString();

                            libro.Edicion = row[8].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.Nombre = row[10].ToString();

                            result.Object = libro;
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }
            return result;
        }

        //CRUD para Entity Framework 

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities conext = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    var libros = conext.LibroGetAll().ToList();

                    result.Objects = new List<object>();

                    if(libros != null)
                    {
                        foreach(var obj in libros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Nombre;

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = obj.IdAutor.Value;
                            libro.Autor.Nombre = obj.NombreAutor;

                            libro.NumeroPaginas = obj.NumeroPaginas.Value;
                            libro.FechaPublicacion = obj.FechaPublicacion.Value.ToString("dd-MM-yyyy");

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = obj.IdEditorial.Value;
                            libro.Editorial.Nombre = obj.NombreEditorial;

                            libro.Edicion = obj.Edicion;

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = obj.IdGenero.Value;
                            libro.Genero.Nombre = obj.NombreGenero;

                            result.Objects.Add(libro);
                        }
                    }
                }

                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    var Objlibro = context.LibroGetById(IdLibro).SingleOrDefault();

                    if(Objlibro != null)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = Objlibro.IdLibro;
                        libro.Nombre = Objlibro.Nombre;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = Objlibro.IdAutor.Value;
                        libro.Autor.Nombre = Objlibro.NombreAutor;

                        libro.NumeroPaginas = Objlibro.NumeroPaginas.Value;
                        libro.FechaPublicacion = Objlibro.FechaPublicacion.Value.ToString("dd-MM-yyyy");

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = Objlibro.IdEditorial.Value;
                        libro.Editorial.Nombre = Objlibro.NombreEditorial;

                        libro.Edicion = Objlibro.Edicion;

                        libro.Genero = new ML.Genero();

                        libro.Genero.IdGenero = Objlibro.IdGenero.Value;
                        libro.Genero.Nombre = Objlibro.NombreGenero;

                        result.Object = libro;

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
        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    int query = context.LibroAdd(libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);

                    if(query > 0)
                    {
                        result.Message = "Se ha agreado el libro correctamente";
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

        public static ML.Result UpdtadeEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    int query = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);

                    if(query > 0)
                    {
                        result.Message = "Se ha actualizado el libro";
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex){
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error: " + result.EX;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosPruebaTecnica1Entities context = new DL_EF.LSantosPruebaTecnica1Entities())
                {
                    int query = context.LibroDelete(IdLibro);

                    if(query > 0)
                    {
                        result.Message = "Se ha eliminado el libro";
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
