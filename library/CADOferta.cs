using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace library
{
    public class CADOferta
    {
        private String constring;

        public CADOferta()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        //Crear oferta
        public bool addOferta(ENOferta en)
        {
            bool creado = false;
            SqlConnection connection = null;
            String sentence = "INSERT INTO [Oferta] " +
                "(descuento, fecha_inicio, fecha_fin, productoraID, videojuegoID) " +
                "VALUES (@descuento, @fecha_inicio, @fecha_fin, @plataforma, @productoraID, @videojuegoID);";


            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                com.Parameters.AddWithValue("@descuento", en.Descuento);
                com.Parameters.AddWithValue("@fecha_inicio", en.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@fecha_fin", en.FechaFin.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@videojuegoID", en.Videojuego.Id);

                com.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("Creating oferta operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("Creating oferta operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return creado;

        }

        //Leer oferta
        public bool readOferta(ENOferta en)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();
                string sentence = "SELECT * FROM [Oferta] WHERE nombre = @nombre";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@nombre", en.Nombre);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Id = Int32.Parse(dr["id"].ToString());
                    en.FechaInicio = DateTime.Parse(dr["fecha_inicio"].ToString());
                    en.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());

                    //Lectura de la productora
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(dr["productoraID"].ToString());

                    sentence = "SELECT * FROM [Productora] WHERE id = " + productora.Id + ";";
                    com = new SqlCommand(sentence, connection);
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        productora.Nombre = dr["nombre"].ToString(); ;
                        productora.Descripcion = dr["descripcion"].ToString();
                        productora.Imagen = dr["Imagen"].ToString();
                        productora.Web = dr["Web"].ToString();
                    }

                    en.Productora = productora;

                    //Lectura del videojuego
                    ENVideojuego videojuego = new ENVideojuego();
                    videojuego.Id = Int32.Parse(dr["videojuegoID"].ToString());

                    //Se lee la videojuego a partir de su ID
                    sentence = "SELECT * FROM [Videojuego] WHERE id = " + videojuego.Id + ";";
                    //Se obtiene Id de la productora
                    com = new SqlCommand(sentence, connection);
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        videojuego.Titulo = dr["titulo"].ToString();
                        videojuego.Descripcion = dr["descripcion"].ToString();
                        videojuego.FechaLanzamiento = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                        videojuego.Plataforma = dr["plataforma"].ToString();
                        videojuego.Precio = Double.Parse(dr["precio"].ToString());
                        videojuego.Imagen = dr["imagen"].ToString();
                        videojuego.Productora = productora;

                        //Lectura de la categoria
                        ENCategoria cat = new ENCategoria();
                        cat.Id = Int32.Parse(dr["categoriaID"].ToString());

                        //Se lee la categoria a partir de su ID
                        sentence = "SELECT * FROM [Categoria] WHERE id = " + cat.Id + ";";
                        //Se obtiene Id de la productora
                        com = new SqlCommand(sentence, connection);
                        dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            cat.Nombre = dr["nombre"].ToString(); ;
                            cat.Descripcion = dr["descripcion"].ToString();
                        }

                        videojuego.Categoria = cat;

                    }

                    en.Videojuego = videojuego;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }

    }
}
