using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library
namespace web
{
    public partial class Noticia : System.Web.UI.Page
    {
        private string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Noticia> MostrarNoticias()
        {
            List<Noticia> noticias = new List<Noticia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Titulo, Contenido, FechaPublicacion, Productora FROM Noticias ORDER BY FechaPublicacion DESC";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Noticia noticia = new Noticia();

                    noticia.id = (int)reader["Id"];
                    noticia.Titulo = (string)reader["Titulo"];
                    noticia.Contenido = (string)reader["Contenido"];
                    noticia.FechaPublicacion = (DateTime)reader["FechaPublicacion"];
                    noticia.Productora = (string)reader["Productora"];

                    noticias.Add(noticia);
                }

                reader.Close();
            }

            return noticias;

        }
    }
}