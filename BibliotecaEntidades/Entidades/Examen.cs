using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Examen
    {
        private string _nombre;
        private DateTime _fecha;
        private Dictionary<Alumno, Nota> _notasAlumnos;

        public Examen(string nombre, DateTime fecha)
        {
            this._nombre = nombre.ToLower();
            this._fecha = fecha;
            this._notasAlumnos = new Dictionary<Alumno, Nota>();
        }
        

        public static bool DarNota(Examen e, Alumno a, int nota)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, Nota> alumno in e._notasAlumnos)
            {
                if (alumno.Key == a)
                {
                    alumno.Value.Rendido = true;
                    alumno.Value.NotaParcial = nota;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator ==(Examen e1, Examen e2)
        {
            bool retorno = false;

            if (e1._nombre == e2._nombre)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Examen e1, Examen e2)
        {
            return !(e1 == e2);
        }

        public static bool operator ==(Examen e, Alumno a)
        {
            bool retorno = false;

            foreach (KeyValuePair<Alumno, Nota> alumno in e._notasAlumnos)
            {
                if (alumno.Key == a)
                {
                    retorno = true;
                    break;
                }
            }
            
            return retorno;
        }

        public static bool operator !=(Examen e, Alumno a)
        {
            return !(e == a);
        }


        public static bool operator +(Examen e, Alumno a)
        {
            bool retorno = false;

            if (e != a)
            {
                e._notasAlumnos.Add(a, new Nota());
                retorno = true;
            }

            return retorno;
        }
    }
}
