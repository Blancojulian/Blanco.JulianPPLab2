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
        private int _cantidadMateriasCursando;
        private List<Materia> _materias;
        

        public Alumno(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {
            this._cantidadMateriasCursando = 0;
            this._nivelUsuario = NivelUsuario.Alumno;
            this._materias = new List<Materia>();
        }

        

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Información alumno");
            sb.Append($"{base.MostrarInformacion()}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{Apellido} {Nombre}";
        }

        public bool InscribirseAMateria(Materia materia)
        {

            bool retorno = false;
            bool boolean = AgregarCantidadMateriaCursada();

            if (boolean && materia + this)
            {
                this._materias.Add(materia);
                retorno = true;
            }
            else if (boolean)
            {
                RestarCantidadMateriaCursada();
            }

            return retorno;
        }
        private bool AgregarCantidadMateriaCursada()
        {
            bool retorno = false;

            if (_cantidadMateriasCursando >= 0 && _cantidadMateriasCursando + 1 <= 2)
            {
                _cantidadMateriasCursando++;
                retorno = true;
            }
            return retorno;
        }

        public bool RestarCantidadMateriaCursada()
        {
            bool retorno = false;

            if (_cantidadMateriasCursando - 1 >= 0 && _cantidadMateriasCursando <= 2)
            {
                _cantidadMateriasCursando--;
                retorno = true;
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

        public int CantidadMateriasCursando { get => _cantidadMateriasCursando; }
        /*
public static implicit operator Alumno(string nombre, string apellido, string contrasenia, int dni)
{
return new Alumno(nombre, apellido, contrasenia, dni);
}*/
    }
}
