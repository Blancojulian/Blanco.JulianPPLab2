using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Alumno : Usuario
    {
        private int _cantidadMaterias;
        private List<Materia> _materias;
        

        public Alumno(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {
            this._cantidadMaterias = 0;
            this._nivelUsuario = NivelUsuario.Alumno;
            this._materias = new List<Materia>();
        }

        

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Información alumno");
            sb.AppendLine($"{base.MostrarInformacion()}");

            return sb.ToString();
        }

        public bool InscribirseAMateria(Materia materia)
        {
            bool retorno = materia + this;

            if (retorno)
            {
                this._materias.Add(materia);
            }

            return retorno;
        }

        public bool DarAsistenciaAMateria(Materia materia)
        {
            return Materia.DarAsistencia(materia, this);
        }



        public static bool operator ==(Alumno a, int codigoMateria)
        {
            bool retorno = false;

            foreach (Materia materia in a._materias)
            {
                if (materia.CodigoMateria == codigoMateria)
                {

                    if (EEstadoMateria.Aprobado == Materia.GetEstadoMateriaAlumno(materia, a))
                    {
                        retorno = true;
                        break;
                    }
                    
                }
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, int codigoMateria)
        {
            return !(a == codigoMateria);
        }

        public List<Materia> Materias { get { return new List<Materia>(this._materias); } }
        /*
        public static implicit operator Alumno(string nombre, string apellido, string contrasenia, int dni)
        {
            return new Alumno(nombre, apellido, contrasenia, dni);
        }*/
    }
}
