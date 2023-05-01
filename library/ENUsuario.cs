using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        private string nick_interno, nombre_interno, apell_interno, email_interno, passw_interno, telef_interno, rol_interno;
        private DateTime fecha_interno;

        public string nick
        {
            get { return nick_interno; }
            set { nick_interno = value; }
        }
        public string nombre
        {
            get { return nombre_interno; }
            set { nombre_interno = value; }
        }
        public string apellidos
        {
            get { return apell_interno; }
            set { apell_interno = value; }
        }
        public string email
        {
            get { return email_interno; }
            set { email_interno = value; }
        }
        public string password
        {
            get { return passw_interno; }
            set { passw_interno = value; }
        }
        public DateTime fecha_nac
        {
            get { return fecha_interno; }
            set { fecha_interno = value; }
        }
        public string telef
        {
            get { return telef_interno; }
            set { telef_interno = value; }
        }
        public string rol
        {
            get { return rol_interno; }
            set { rol_interno = value; }
        }
        public ENUsuario()
        {
            nick = "blank";
            nombre = "blank";
            apellidos = "blank";
            email = "blank";
            password = "blank";
            fecha_nac = DateTime.Now;
            telef = "blank";
            rol = "blank";
        }
        public ENUsuario(string nick, string nom, string apell, string email, string pass, DateTime fecha, string tel, string rol)
        {
            this.nick = nick;
            this.nombre = nom;
            this.apellidos = apell;
            this.email = email;
            this.password = pass;
            this.fecha_nac = fecha;
            this.telef = tel;
            this.rol = rol;
        }

        public bool createUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.createUsuario(this);
            return result;
        }

        public bool readUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.readUsuario(this);
            return result;
        }

        public bool readFirstUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.readFirstUsuario(this);
            return result;
        }

        public bool readNextUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.readNextUsuario(this);
            return result;
        }

        public bool readPrevUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.readPrevUsuario(this);
            return result;
        }

        public bool updateUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.updateUsuario(this);
            return result;
        }

        public bool deleteUsuario()
        {
            bool result = true;
            CADUsuario c = new CADUsuario();
            result = c.deleteUsuario(this);
            return result;
        }
    }
}
