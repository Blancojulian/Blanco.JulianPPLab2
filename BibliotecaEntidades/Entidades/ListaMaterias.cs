using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class ListaMaterias : Lista<Materia>
    {
        public ListaMaterias() : base()
        {

        }

        public override bool Existe(Materia m)
        {
            bool retorno = false;

            foreach (Materia materia in _lista)
            {
                if (materia == m)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /*
        public override bool Existe(int codigoMateria)
        {
            bool retorno = false;

            foreach (Materia materia in _lista)
            {
                if (materia.CodigoMateria == codigoMateria)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }*/

        public override Materia? Get(int codigoMateria)
        {
            Materia? retorno = null;

            foreach (Materia materia in _lista)
            {
                if (materia == codigoMateria)
                {
                    retorno = materia;
                    break;
                }
            }

            return retorno;
        }

        public override bool Agregar(Materia materia)
        {
            bool retorno = false;

            if (!Existe(materia))
            {
                _lista.Add(materia);
                retorno = true;
            }

            return retorno;
        }

        public override bool Eliminar(Materia materia)
        {
            bool retorno = false;

            if (Existe(materia))
            {
                _lista.Remove(materia);
                retorno = true;
            }

            return retorno;
        }

        public override bool Eliminar(int codigoMateria)
        {
            bool retorno = false;

            Materia? materia = Get(codigoMateria);

            if (materia is not null)
            {
                _lista.Remove(materia);
                retorno = true;
            }

            return retorno;
        }

        //public override List<Materia> Lista { get => new List<Materia>(_lista); }
    }
}
