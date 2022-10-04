using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public enum EstadoAlumno
    {
        Regular,
        Libre,
        Aprobado
    }
    public class Materia
    {
        private int _codigoMateria;
        private string _nombre;
        private string _cuatrimestre;
        private List<Profesor> _profesores;
        private Dictionary<Alumno, EstadoAlumno> _alumnos;
        private int _materiaCorrelativa;

        public Materia(string nombre, string cuatrimestre, int materiaCorrelativa)
        {
            this._nombre = nombre.ToLower();
            this._cuatrimestre = cuatrimestre.ToLower();
            this._materiaCorrelativa = materiaCorrelativa;
            this._profesores = new List<Profesor>();
            this._alumnos = new Dictionary<Alumno, EstadoAlumno>();
        }

        public Materia(string nombre, string cuatrimestre) : this(nombre, cuatrimestre, 0)
        {
        }

        public Materia(string nombre, string cuatrimestre, Profesor profesor) : this(nombre, cuatrimestre)
        {
            this._profesores.Add(profesor);
        }


        public static bool operator ==(Materia m, Alumno a)
        {
            return m._alumnos.ContainsKey(a);
        }

        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m == a);
        }

        public static bool operator +(Materia m, Alumno a)
        {
            if (m != a)
            {
                //cambiar 1 a EstadoAlumno.Regular
                m._alumnos.Add(a, EstadoAlumno.Regular);
                return true;
            }

            return false;
        }
        public static string GetEstadoAlumno(Materia m, Alumno a)
        {
            string estado = "";
            EstadoAlumno nivelUsuario;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if(alumno.Key.Id == a.Id)
                {
                    nivelUsuario = alumno.Value;

                    if (nivelUsuario == EstadoAlumno.Regular)
                    {
                        estado = "regular";
                    } else if (nivelUsuario == EstadoAlumno.Libre)
                    {
                        estado = "libre";
                    } else if (nivelUsuario == EstadoAlumno.Aprobado)
                    {
                        estado = "aprobado";
                    }

                    break;
                }
            }

            return estado;
        }

        public int CodigoMateria { get { return this._codigoMateria; } }

        public int MateriaCorrelativa { get { return this._materiaCorrelativa; } }

        public string Nombre { get { return this._nombre; } }

        public string Cuatrimestre { get { return this._cuatrimestre; } }


    }
}
