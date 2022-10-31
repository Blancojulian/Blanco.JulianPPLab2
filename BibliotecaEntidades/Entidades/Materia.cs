using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{

    public class Materia
    {
        private int _codigoMateria;
        private string _nombre;
        private string _cuatrimestre;
        private List<Profesor> _profesores;
        private Dictionary<Alumno, EstadoAlumno> _alumnos;
        private List<Examen> _examenes;
        private int _materiaCorrelativa;

        public Materia(int codigoMateria, string nombre, string cuatrimestre, int materiaCorrelativa)
        {
            if(codigoMateria < 0)
            {
                codigoMateria = 1;
            }
            this._codigoMateria = codigoMateria;
            this._nombre = nombre.ToLower();
            this._cuatrimestre = cuatrimestre.ToLower();
            this._materiaCorrelativa = materiaCorrelativa;
            this._profesores = new List<Profesor>();
            this._alumnos = new Dictionary<Alumno, EstadoAlumno>();
            this._examenes = new List<Examen>();
        }

        public Materia(int codigoMateria, string nombre, string cuatrimestre) : this(codigoMateria, nombre, cuatrimestre, 0)
        {
        }
        
        public static bool operator ==(Materia m1, Materia m2)
        {
            bool retorno = false;

            if(m1.CodigoMateria == m2.CodigoMateria)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Materia m1, Materia m2)
        {
            return !(m1 == m2);
        }


        public static bool operator ==(Materia m, Alumno a)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m == a);
        }

        public static bool operator +(Materia m, Alumno a)
        {
            bool retorno = false;

            if (m != a)
            {
                
                    if (m.MateriaCorrelativa == 0 || a == m.MateriaCorrelativa)
                    {
                        m._alumnos.Add(a, new EstadoAlumno());
                        retorno = true;
                    }
                
            }

            return retorno;
        }

        public static bool operator ==(Materia m, Profesor p)
        {
            bool retorno = false;

            foreach( Profesor profesor in m._profesores)
            {
                if(profesor == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Materia m, Profesor p)
        {
            return !(m == p);
        }

        public static bool operator +(Materia m, Profesor p)
        {
            bool retorno = false;

            if (m != p && p + m)
            {
                m._profesores.Add(p);
                retorno = true;
            }

            return retorno;
        }

        public static bool operator ==(Materia m, Examen e)
        {
            bool retorno = false;

            foreach (Examen examen in m._examenes)
            {
                if (examen == e)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Materia m, Examen e)
        {
            return !(m == e);
        }

        public static bool operator +(Materia m, Examen e)
        {
            bool retorno = false;

            if (m != e)
            {
                m._examenes.Add(e);
                retorno = true;
            }

            return retorno;
        }
        public static bool DarNota(Materia m, Profesor p, Alumno a, Examen e, int nota)
        {
            bool retorno = false;

            if (m == p)
            {
                foreach (Examen examen in m._examenes)
                {
                    if (examen == e)
                    {
                        retorno = Examen.DarNota(e, a, nota);
                        break;
                    }
                }
            }
            

            return retorno;
        }
        public static bool DarAsistencia(Materia m, Alumno a)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    alumno.Value.Asistencia = true;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static EstadoAlumno? GetEstado(Materia m, Alumno a)
        {
            
            EstadoAlumno? estado = null;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    estado = alumno.Value;
                    break;
                }
            }

            return estado;
        }
        public static EEstadoMateria GetEstadoMateriaAlumno(Materia m, Alumno a)
        {
            EEstadoMateria estado = EEstadoMateria.Cursando;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    estado = alumno.Value.EstadoMateria;
                    break;
                }
            }

            return estado;
        }

        public static bool SetEstadoMateriaAlumno(Materia m, Alumno a, EEstadoMateria estado)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    alumno.Value.EstadoMateria = estado;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static EEstadoAlumno GetEstadoAlumno(Materia m, Alumno a)
        {
            //ver
            EEstadoAlumno estado = EEstadoAlumno.Regular;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if(alumno.Key == a)
                {
                    estado = alumno.Value.Estado;
                    break;
                }
            }
        
            return estado;
        }

        public static bool SetEstadoAlumno(Materia m, Alumno a, EEstadoAlumno estado)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
            {
                if (alumno.Key == a)
                {
                    alumno.Value.Estado = estado;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public int CodigoMateria { get { return this._codigoMateria; } }

        public int MateriaCorrelativa { get { return this._materiaCorrelativa; } }

        public string Nombre { get { return this._nombre; } }

        public string Cuatrimestre { get { return this._cuatrimestre; } }


    }
}
