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
        private ECuatrimestre _cuatrimestre;
        private List<Profesor> _profesores;
        private Dictionary<Alumno, EstadoAlumno> _alumnos;
        private List<Examen> _examenes;
        private Examen? _primerExamen;
        private Examen? _segundoExamen;
        private int _materiaCorrelativa;

        public Materia(int codigoMateria, string nombre, ECuatrimestre cuatrimestre, int materiaCorrelativa)
        {
            if(codigoMateria < 0)
            {
                codigoMateria = 1;
            }
            this._codigoMateria = codigoMateria;
            this._nombre = nombre.ToLower();
            this._cuatrimestre = cuatrimestre;
            this._materiaCorrelativa = materiaCorrelativa;
            this._profesores = new List<Profesor>();
            this._alumnos = new Dictionary<Alumno, EstadoAlumno>();
            this._examenes = new List<Examen>();
        }

        public Materia(int codigoMateria, string nombre, ECuatrimestre cuatrimestre) : this(codigoMateria, nombre, cuatrimestre, 0)
        {
        }

        #region SOBRECARGA OPERADORES
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

        public static bool operator ==(Materia m, int codigoMateria)
        {
            bool retorno = false;

            if (m.CodigoMateria == codigoMateria)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Materia m, int codigoMateria)
        {
            return !(m == codigoMateria);
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
                        m._alumnos.Add(a, new EstadoAlumno(m.PrimerExamen, m.SegundoExamen));
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
        #endregion

        public void AgregarExamenAAlumnos(Examen examen, EExanen eExamen)
        {
            foreach (var alumno in _alumnos)
            {
                if (eExamen == EExanen.Primer)
                {
                    alumno.Value.PrimerExamen.Examen = examen;
                }
                else if (eExamen == EExanen.Segundo)
                {
                    alumno.Value.SegundoExamen.Examen = examen;
                }
            }
        }
        public static bool DarNota(Materia m, Profesor p, Alumno a, EExanen examen, int nota)
        {
            bool retorno = false;

            if (m == p)
            {
                foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in m._alumnos)
                {
                    if (alumno.Key == a )
                    {
                        retorno = m.CambiarNota(alumno.Key, alumno.Value, examen, nota);
                        break;
                    }
                }
            }
            

            return retorno;
        }

        private bool CambiarNota(Alumno alumno, EstadoAlumno estado, EExanen tipoExamen, int nota)
        {
            bool retorno = false;
            bool notaValida = nota > 0 && nota <= 10;

            if (notaValida && tipoExamen == EExanen.Primer &&
                estado.PrimerExamen.Examen is not null)
            {
                estado.PrimerExamen.Nota = nota;
                estado.PrimerExamen.Rendido = true;
                retorno = true;

            }
            else if (notaValida && tipoExamen == EExanen.Segundo &&
                estado.PrimerExamen.Rendido &&
                estado.SegundoExamen.Examen is not null)
            {
                estado.SegundoExamen.Nota = nota;
                estado.SegundoExamen.Rendido = true;
                CalcularNotaMateria(alumno, estado);
                retorno = true;

            }
            return retorno;
        }

        private void CalcularNotaMateria(Alumno alumno, EstadoAlumno estado)
        {
            bool boolean = estado.Estado == EEstadoAlumno.Regular;
            if (boolean && estado.PrimerExamen.Nota > 6 &&
                estado.SegundoExamen.Nota > 6)

            {
                estado.EstadoMateria = EEstadoMateria.Aprobado;
                alumno.RestarCantidadMateriaCursada();

            }
            else if(boolean && (estado.PrimerExamen.Nota <= 6 ||
                estado.SegundoExamen.Nota <= 6) )
            {
                estado.EstadoMateria = EEstadoMateria.Desaprobado;
                alumno.RestarCantidadMateriaCursada();

            }


        }
        public static float CalcularNotaPromedio(Materia m, Alumno a)
        {
            EstadoAlumno? estado = Materia.GetEstado(m, a);
            float promedio = 0;

            if(estado is not null)
            {
                if (estado.PrimerExamen.Rendido && estado.SegundoExamen.Rendido)
                {
                    promedio = (estado.PrimerExamen.Nota + estado.SegundoExamen.Nota) / 2;

                }
                else if(estado.PrimerExamen.Rendido)
                {
                    promedio = estado.PrimerExamen.Nota;
                }
            }

            return promedio;
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

        public int MateriaCorrelativa {get { return this._materiaCorrelativa; } }

        public string Nombre { get { return this._nombre; } set => _nombre = value; }

        public ECuatrimestre Cuatrimestre { get { return this._cuatrimestre; } }
        public string MostrarMateriaCorrelativa { 
            get
            {
                string retorno = "No tiene materia correlativa";
                Materia? m;

                if (MateriaCorrelativa > 0 && (m = Sistema.Materias.Get(MateriaCorrelativa)) is not null)
                {
                    retorno = m.Nombre;
                }

                return retorno;
            }
        }
        public string Alumnos {
            get
            {
                StringBuilder sb = new StringBuilder();

                
                for (int i = 0; i < _alumnos.Count; i++)
                {
                    if (_alumnos.Count - 1 == i)
                    {
                        sb.Append($"{_alumnos.ElementAt(i).Key.ToString()}.");
                    }
                    else
                    {
                        sb.Append($"{_alumnos.ElementAt(i).Key.ToString()}, ");
                    }
                }
                
                if ( string.IsNullOrEmpty( sb.ToString() ) )
                {
                    sb.Append("No tiene alumnos inscriptos");
                }

                return sb.ToString();
            }
        }

        public string Profesores
        {
            get
            {
                StringBuilder sb = new StringBuilder();


                for (int i = 0; i < _profesores.Count; i++)
                {
                    if (_profesores.Count - 1 == i)
                    {
                        sb.Append($"{_profesores.ElementAt(i).ToString()}.");
                    }
                    else
                    {
                        sb.Append($"{_profesores.ElementAt(i).ToString()}, ");
                    }
                }

                if (string.IsNullOrEmpty(sb.ToString()))
                {
                    sb.Append("No tiene profesores asigandos");
                }

                return sb.ToString();
            }
        }

        public Dictionary<Alumno, EstadoAlumno> ListaAlumnos { get => new Dictionary<Alumno, EstadoAlumno>(_alumnos); }
        public Examen? PrimerExamen { get => _primerExamen; set => _primerExamen = value; }
        public Examen? SegundoExamen { get => _segundoExamen; set => _segundoExamen = value; }
    }
}
