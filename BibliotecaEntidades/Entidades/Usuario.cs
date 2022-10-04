using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public enum NivelUsuario
    {
        Admin,
        Profesor,
        Alumno
    }
    public abstract class Usuario
    {
        protected int _id;
        protected string _nombre;
        protected string _apellido;
        protected string _contrasenia;
        protected int _dni;
        protected NivelUsuario _nivelUsuario;

        public Usuario(string nombre, string apellido, string contrasenia, int dni)
        {
            this._id = ListaUsuarios.GetId();
            this._nombre = nombre.ToLower();
            this._apellido = apellido.ToLower();
            this._contrasenia = contrasenia;
            this._dni = dni;
        }

        public string Nombre {
            get { return this._nombre; }
            set { this._nombre = value.ToLower(); }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value.ToLower(); }
        }
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = value; }
        }
        public int Id
        {
            get { return this._id; }
        }
        public NivelUsuario NivelUsuario
        {
            get { return this._nivelUsuario; }
        }

        public bool ComprobarContrasenia(string contrasenia)
        {
            bool retorno = false;

            if(contrasenia == this._contrasenia)
            {
                retorno = true;
            }

            return retorno;
        }

        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {this._id}");
            sb.AppendLine($"DNI: {this._dni}");
            sb.AppendLine($"Apellido: {this._apellido}");
            sb.AppendLine($"Nombre: {this._nombre}");

            return sb.ToString();
        }
    }
}
