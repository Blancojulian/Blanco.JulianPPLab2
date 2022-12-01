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
        private int _nota;
        private bool _rendido;

        public Examen(string nombre, DateTime fecha)
        {
            _nombre = nombre.ToLower();
            _fecha = fecha;
        }/*
        public Examen(string nombre, DateTime fecha) : this(0, nombre, fecha)
        {

        }*/

                
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

        public string Nombre { get => _nombre; set => _nombre = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
    }
}
