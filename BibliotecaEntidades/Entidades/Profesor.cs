using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Profesor : Usuario
    {
        private List<Materia> _materias;
        public Profesor(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {
            this._nivelUsuario = NivelUsuario.Profesor;
            this._materias = new List<Materia>();
        }

        public bool AgregarExamen(Materia materia, string nombre, DateTime fecha, EExanen examen)
        {
            bool retorno = false;

            if(materia == this)
            {
                if (examen == EExanen.Primer && materia.PrimerExamen is null)
                {
                    Examen ex = new Examen(nombre, fecha);
                    materia.PrimerExamen ??= ex;
                    materia.AgregarExamenAAlumnos(ex, examen);
                    retorno = true;
                }
                else if (examen == EExanen.Segundo && materia.SegundoExamen is null)
                {
                    Examen ex = new Examen(nombre, fecha);
                    materia.SegundoExamen ??= ex;
                    materia.AgregarExamenAAlumnos(ex, examen);
                    retorno = true;
                }
            }

            
            return retorno;
        }
        public bool AgregarExamen(Materia materia, Examen examen, EExanen eExamen)
        {
            bool retorno = false;

            if (materia == this)
            {
                if (eExamen == EExanen.Primer && materia.PrimerExamen is null)
                {
                    materia.PrimerExamen ??= examen;
                    materia.AgregarExamenAAlumnos(examen, eExamen);
                    retorno = true;
                }
                else if (eExamen == EExanen.Segundo && materia.SegundoExamen is null)
                {
                    materia.SegundoExamen ??= examen;
                    materia.AgregarExamenAAlumnos(examen, eExamen);
                    retorno = true;
                }
            }


            return retorno;
        }
        public bool AgregarNota(Materia materia, Alumno alumno, EExanen tipoExamen, int nota)
        {
            return Materia.DarNota(materia, this, alumno, tipoExamen, nota);
        }

        public override string ToString()
        {
            return $"{Apellido} {Nombre}";
        }

        public static bool operator +(Profesor p, Materia m)
        {
            bool retorno = true;

            foreach (Materia materia in p._materias)
            {
                if (materia == m)
                {
                    retorno = false;
                    break;
                }
            }

            if (retorno)
            {
                p._materias.Add(m);
            }

            return retorno;
        }

        public List<Materia> Materias { get { return new List<Materia>(this._materias); } }
    }
}
