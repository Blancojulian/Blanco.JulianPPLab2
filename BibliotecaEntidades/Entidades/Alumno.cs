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
        

        public Alumno(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {
            this._cantidadMaterias = 0;
            this._nivelUsuario = NivelUsuario.Alumno;
        }


        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Alumno");
            sb.AppendLine($"{base.MostrarInformacion()}");

            return sb.ToString();
        }

        public static List<Materia> MostrarMateriasCursadas(Alumno a)
        {
            List<Materia> listaMaterias = ListaMaterias.Lista;
            List<Materia> listaMateriasCursadas = new List<Materia>();

            foreach (Materia materia in listaMaterias)
            {
                if(materia == a)
                {
                    listaMateriasCursadas.Add(materia);
                }
            }

            return listaMateriasCursadas;
        }
    }
}
