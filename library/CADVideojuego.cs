using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    public class CADVideojuego
    {
        private String constring;

        public CADVideojuego()
        {
            constring = ConfigurationManager.ConnectionStrings["UAGames"].ToString();
        }

        //Crear videojuego
        public bool addVideojuego(ENVideojuego en)
        {
            bool creado = false;
            SqlConnection connection = null;
            String sentence = "INSERT INTO [Videojuego] " +
                "(titulo, descripcion, fecha_lanzamiento, plataforma, precio, imagen, productoraID, categoriaID) " +
                "VALUES (@titulo, @descripcion, @fecha_lanzamiento, @plataforma, @precio, @imagen, @productoraID, @categoriaID);";


            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                com.Parameters.AddWithValue("@titulo", en.Titulo);
                com.Parameters.AddWithValue("@descripcion", en.Descripcion);
                com.Parameters.AddWithValue("@fecha_lanzamiento", en.FechaLanzamiento.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@plataforma", en.Plataforma);
                com.Parameters.AddWithValue("@precio", en.Precio);
                com.Parameters.AddWithValue("@imagen", en.Imagen);
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@categoriaID", en.Categoria.id);

                com.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
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

        //Leer videojuego
        public bool readVideojuego(ENVideojuego en)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlConnection conProductora = null;
            SqlConnection conCategoria = null;
            SqlDataReader dr = null;
            try
            {
                connection = new SqlConnection(constring);
                conProductora = new SqlConnection(constring);
                conCategoria = new SqlConnection(constring);
                connection.Open();
                conProductora.Open();
                conCategoria.Open();
                string sentence = "SELECT * FROM [Videojuego] WHERE titulo = @titulo";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@titulo", en.Titulo);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Id = Int32.Parse(dr["id"].ToString());
                    en.Descripcion = dr["descripcion"].ToString();
                    en.FechaLanzamiento = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                    en.Plataforma = dr["plataforma"].ToString();
                    en.Imagen = dr["imagen"].ToString();
                    en.Precio = Double.Parse(dr["precio"].ToString());

                    //Lectura de la productora
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(dr["productoraID"].ToString());
                    string sentenceProductora = "SELECT * FROM [Productora] WHERE Id = @Id";
                    SqlCommand comProductora = new SqlCommand(sentenceProductora, conProductora);
                    comProductora.Parameters.AddWithValue("@Id", productora.Id);

                    SqlDataReader drProductora = comProductora.ExecuteReader();

                    if (drProductora.Read())
                    {
                        productora.Nombre = drProductora["nombre"].ToString(); ;
                        productora.Descripcion = drProductora["descripcion"].ToString();
                        productora.Imagen = drProductora["imagen"].ToString();
                        productora.Web = drProductora["web"].ToString();
                    }

                    en.Productora = productora;

                    //Lectura de la categoria
                    ENCategoria cat = new ENCategoria();
                    cat.id = Int32.Parse(dr["categoriaID"].ToString());

                    string sentenceCat = "SELECT * FROM [Categoria] WHERE Id = @Id";
                    SqlCommand comCategoria = new SqlCommand(sentenceCat, conCategoria);
                    comCategoria.Parameters.AddWithValue("@Id", cat.id);

                    SqlDataReader drCategoria = comCategoria.ExecuteReader();

                    if (drCategoria.Read())
                    {
                        cat.nombre = drCategoria["nombre"].ToString(); ;
                        cat.descripcion = drCategoria["descripcion"].ToString();
                    }

                    en.Categoria = cat;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }


        public bool readVideojuegoId(ENVideojuego en)
        {
            bool leido = false;
            SqlConnection connection = null;
            //SqlConnection conProductora = null;
            //SqlConnection conCategoria = null;
            SqlDataReader dr = null;
            try
            {
                connection = new SqlConnection(constring);
                //conProductora = new SqlConnection(constring);
                //conCategoria = new SqlConnection(constring);
                connection.Open();
                //conProductora.Open();
                //conCategoria.Open();
                string sentence = "SELECT * FROM [Videojuego] WHERE Id = @Id";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@Id", en.Id);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Titulo = dr["titulo"].ToString();
                    en.Descripcion = dr["descripcion"].ToString();
                    en.FechaLanzamiento = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                    en.Plataforma = dr["plataforma"].ToString();
                    en.Imagen = dr["imagen"].ToString();
                    en.Precio = Double.Parse(dr["precio"].ToString());

                    //Lectura de la productora
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(dr["productoraID"].ToString());
                    /*
                    string sentenceProductora = "SELECT * FROM [Productora] WHERE Id = @Id";
                    SqlCommand comProductora = new SqlCommand(sentenceProductora, conProductora);
                    comProductora.Parameters.AddWithValue("@Id", productora.Id);

                    SqlDataReader drProductora = comProductora.ExecuteReader();

                    if (drProductora.Read())
                    {
                        productora.Nombre = drProductora["nombre"].ToString(); ;
                        productora.Descripcion = drProductora["descripcion"].ToString();
                        productora.Imagen = drProductora["imagen"].ToString();
                        productora.Web = drProductora["web"].ToString();
                    }*/

                    CADProductora prod = new CADProductora();
                    prod.readProductora(productora);

                    en.Productora = productora;

                    //Lectura de la categoria
                    ENCategoria cat = new ENCategoria();
                    cat.id = Int32.Parse(dr["categoriaID"].ToString());

                    /*string sentenceCat = "SELECT * FROM [Categoria] WHERE Id = @Id";
                    SqlCommand comCategoria = new SqlCommand(sentenceCat, conCategoria);
                    comCategoria.Parameters.AddWithValue("@Id", cat.id);

                    SqlDataReader drCategoria = comCategoria.ExecuteReader();

                    if (drCategoria.Read())
                    {
                        cat.nombre = drCategoria["nombre"].ToString(); ;
                        cat.descripcion = drCategoria["descripcion"].ToString();
                    }*/
                    CADCategoria categoria = new CADCategoria();
                    categoria.readCategoria(cat);

                    en.Categoria = cat;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }

        //Leer todos los videojuegos
        public DataSet readVideojuegos()
        {
            SqlConnection connection = null;
            DataSet videojuegos = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT v.titulo, v.descripcion, v.fecha_lanzamiento, v.plataforma, v.precio, v.imagen, " +
                    "p.nombre AS productora, c.nombre AS categoria FROM [Videojuego] v " +
                    "JOIN [Productora] p ON v.productoraID = p.id " +
                    "JOIN [Categoria] c ON v.categoriaID = c.id;";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(videojuegos, "videojuego");
               
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Reading videojuegos operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading videojuegos operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return videojuegos;
        }

        //Leer videojuegos especificos de una productora
        public DataSet readVideojuegosProductora(string prod)
        {
            SqlConnection connection = null;
            DataSet videojuegos = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT v.titulo, v.descripcion, v.fecha_lanzamiento, v.plataforma, v.precio, v.imagen, " +
                    "p.nombre AS productora, c.nombre AS categoria FROM [Videojuego] v " +
                    "JOIN [Productora] p ON v.productoraID = p.id " +
                    "JOIN [Categoria] c ON v.categoriaID = c.id" +
                    "WHERE p.nombre = '" + prod +
                    "';";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(videojuegos, "videojuego");

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Reading videojuegos and productora operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading videojuegos and productora operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return videojuegos;
        }

        //Leer videojuegos especificos de una categoria
        public DataSet readVideojuegosCategoria(string cat)
        {
            SqlConnection connection = null;
            SqlDataReader dr = null;
            DataSet videojuegos = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT v.titulo, v.descripcion, v.fecha_lanzamiento, v.plataforma, v.precio, v.imagen, " +
                    "p.nombre AS productora, c.nombre AS categoria FROM [Videojuego] v " +
                    "JOIN [Productora] p ON v.productoraID = p.id " +
                    "JOIN [Categoria] c ON v.categoriaID = c.id" +
                    "WHERE c.nombre = '" + cat +
                    "';";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(videojuegos, "videojuego");

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Reading videojuegos and categoria operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading videojuegos and categoria operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return videojuegos;
        }



        //Actualizar videojuego
        public bool updateVideojuego(ENVideojuego en)
        {
            bool actualizado = false;
            SqlConnection connection = null;
            String sentence = "UPDATE [Videojuego] SET " +
                "titulo = @titulo, descripcion = @descripcion, fecha_lanzamiento = @fecha_lanzamiento," +
                "plataforma = @plataforma, precio = @precio, imagen = @imagen, productoraID = @productoraID, categoriaID = @categoriaID) " +
                "WHERE id = @id;";

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                com.Parameters.AddWithValue("@titulo", en.Titulo);
                com.Parameters.AddWithValue("@descripcion", en.Descripcion);
                com.Parameters.AddWithValue("@fecha_lanzamiento", en.FechaLanzamiento.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@plataforma", en.Plataforma);
                com.Parameters.AddWithValue("@precio", en.Precio);
                com.Parameters.AddWithValue("@imagen", en.Imagen);
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@categoriaID", en.Categoria);
                com.Parameters.AddWithValue("@id", en.Id);

                com.ExecuteNonQuery();

                actualizado = true;
            }
            catch (SqlException e)
            {
                actualizado = false;
                Console.WriteLine("Updating videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                actualizado = false;
                Console.WriteLine("Updating videogame operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return actualizado;

        }

        //Eliminar videojuego
        public bool deleteVideojuego(ENVideojuego en)
        {
            bool eliminado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "DELETE FROM [Videojuego] " +
                    "where id = @id;";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@id", en.Id);
                com.ExecuteNonQuery();

                eliminado = true;
            }
            catch (SqlException e)
            {
                eliminado = false;
                Console.WriteLine("Deleting videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                eliminado = false;
                Console.WriteLine("Deleting videogame operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return eliminado;
        }


    }

}
