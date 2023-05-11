using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace library
{
    //Codigo Omar

    public class ENReview
    {
        public ENUsuario usuario { get; set; }
        public ENVideojuego videoJuego { get; set; }
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
        public int puntuacion { get; set; }
        private CADReview review { get; set; }

        public ENReview()
        {
            this.usuario = new ENUsuario();
            this.videoJuego = new ENVideojuego();
            this.fecha = DateTime.Now;
            this.puntuacion = 0;
            this.comentario = "";
            this.review = new CADReview();
        }

        public ENReview(DateTime fecha , int puntuacion , string comentario , ENVideojuego videojuego , ENUsuario usuario)
        {
            this.usuario = usuario;
            this.videoJuego = videojuego;
            this.fecha = fecha;
            this.puntuacion = puntuacion;
            this.comentario = comentario;
            this.review = new CADReview();
        }

        public bool createReview()
        {
            return this.review.createReview(this, usuario , videoJuego);
        }
        public bool deleteReview()
        {
            return this.review.deleteReview(this);
        }
        public bool updateReview()
        {
            return this.review.updateReview(this);
        }
        public bool readReview()
        {
            return this.review.readReview(this);
        }

        public DataSet listarReviews()
        {
            DataSet result = new DataSet();
            CADReview c = new CADReview();
            result = c.listarReviews();
            return result;
        }
    }

}
