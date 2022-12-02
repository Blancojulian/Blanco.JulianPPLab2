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
            return Sistema.Usuarios.Agregar(usuario);
        }
        public bool CrearAlumno(string nombre, string apellido, string contrasenia, int dni)
        {
            return Sistema.Usuarios.Agregar( new Alumno(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearProfesor(string nombre, string apellido, string contrasenia, int dni)
        {
            return Sistema.Usuarios.Agregar( new Profesor(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearAdmin(string nombre, string apellido, string contrasenia, int dni)
        {
            return Sistema.Usuarios.Agregar( new Admin(nombre, apellido, contrasenia, dni) );
        }

        public bool CrearMateria(int codigoMateria, string nombre, ECuatrimestre cuatrimestre)
        {
            return Sistema.Materias.Agregar(new Materia(codigoMateria, nombre, cuatrimestre));
        }

        public bool CrearMateria(Materia materia)
        {
            return Sistema.Materias.Agregar(materia);
        }

        public bool CrearMateria(int codigoMateria, string nombre, ECuatrimestre cuatrimestre, int materiaCorrelativa)
        {
            return Sistema.Materias.Agregar( new Materia(codigoMateria, nombre, cuatrimestre, materiaCorrelativa) );
        }

        public bool AgregarProfesorAMateria(Materia materia, Profesor profesor)
        {
            return materia + profesor;
        }

        public bool CambiarEstadoAlumno(Materia materia, Alumno alumno, EEstadoAlumno estado)
        {
            return Materia.SetEstadoAlumno(materia, alumno, estado);
        }
        
        public T CrearUsuario <T>(string nombre, string apellido, string contrasenia, int dni) where T : new()
        {
            T usuario = new T();
            return usuario;
            //return new T(nombre, apellido, contrasenia, dni);
        }

        public bool InscribirseAMateria(Materia materia, Alumno alumno)
        {
            return Alumno.InscribirAlumnoAMateria(materia, alumno);
        }

    }
}
