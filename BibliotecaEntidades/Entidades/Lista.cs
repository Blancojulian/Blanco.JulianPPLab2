using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public abstract class Lista<T>
    {
        protected List<T> _lista;


        public Lista()
        {
            _lista = new List<T>();
        }

        public virtual List<T> GetLista { get => new List<T>(_lista); }

        public abstract bool Existe(T elemento);

        public abstract bool Agregar(T elemento);

        public abstract bool Eliminar(T elemento);
        public abstract bool Eliminar(int numero);
        public abstract T? Get(int numero);
        

    }
}
