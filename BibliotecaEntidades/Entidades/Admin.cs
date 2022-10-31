using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Admin : Usuario
    {
        public Admin(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {            
            this._nivelUsuario = NivelUsuario.Admin;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            return ListaUsuarios.AgregarUsuario(usuario);
        }
        public bool CrearAlumno(string nombre, string apellido, string contrasenia, int dni)
        {
            return ListaUsuarios.AgregarUsuario( new Alumno(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearProfesor(string nombre, string apellido, string contrasenia, int dni)
        {
            return ListaUsuarios.AgregarUsuario( new Profesor(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearAdmin(string nombre, string apellido, string contrasenia, int dni)
        {
            return ListaUsuarios.AgregarUsuario( new Admin(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearMateria(int codigoMateria, string nombre, string cuatrimestre)
        {
            return ListaMaterias.AgregarMateria(new Materia(codigoMateria, nombre, cuatrimestre));
        }

        public bool CrearMateria(Materia materia)
        {
            return ListaMaterias.AgregarMateria(materia);
        }

        public bool CrearMateria(int codigoMateria, string nombre, string cuatrimestre, int materiaCorrelativa)
        {
            return ListaMaterias.AgregarMateria( new Materia(codigoMateria, nombre, cuatrimestre, materiaCorrelativa) );
        }

        public bool AgregarProfesorAMateria(Materia materia, Profesor profesor)
        {
            return materia + profesor;
        }

        public bool CambiarEstadoAlumno(Materia materia, Alumno alumno, EEstadoAlumno estado)
        {
            return Materia.SetEstadoAlumno(materia, alumno, estado);
        }
        //ver si se puedo usar, este tema no lo dio
        public T CrearUsuario <T>(string nombre, string apellido, string contrasenia, int dni) where T : new()
        {
            T usuario = new T();
            return usuario;
            //return new T(nombre, apellido, contrasenia, dni);
        }

    }
}
