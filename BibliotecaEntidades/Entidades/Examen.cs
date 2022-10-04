using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    internal class Examen
    {
        private string _nombre;
        private DateTime _fecha;
        private Dictionary<int, int> _notasAlumnos;// nota en -1 poque no rindieron el examen

        public Examen(string nombre, DateTime fecha, Dictionary<Alumno, EstadoAlumno> listaAlumnos)
        {
            this._nombre = nombre;
            this._fecha = fecha;
            this._notasAlumnos = new Dictionary<int, int>();
            this.LoadDictionary(listaAlumnos);
        }
        private void LoadDictionary(Dictionary<Alumno, EstadoAlumno> listaAlumnos)
        {

            foreach (KeyValuePair<Alumno, EstadoAlumno> alumno in listaAlumnos)
            {
                if(alumno.Value != EstadoAlumno.Aprobado)
                {
                    this._notasAlumnos.Add(alumno.Key.Id, -1);
                }
            }
        }
    }
}
