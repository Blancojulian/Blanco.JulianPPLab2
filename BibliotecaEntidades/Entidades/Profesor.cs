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

        public bool AgregarExamen(Materia materia, string nombre, DateTime fecha)
        {
            bool retorno = false;

            if(materia == this)
            {
                retorno = materia + new Examen(nombre, fecha);
            }
            return retorno;
        }

        public bool AgregarNota(Materia materia, Alumno alumno, Examen examen, int nota)
        {
            return Materia.DarNota(materia, this, alumno, examen, nota);
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
