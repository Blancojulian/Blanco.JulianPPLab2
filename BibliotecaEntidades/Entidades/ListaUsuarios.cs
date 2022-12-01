using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class ListaUsuarios : Lista<Usuario>
    {
        public ListaUsuarios() : base()
        {
        }

        public override bool Existe(Usuario usuario)
        {
            bool retorno = false;

            foreach (Usuario u in _lista)
            {
                if (usuario == u)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public override bool Agregar(Usuario usuario)
        {
            bool retorno = false;

            if (!Existe(usuario))
            {
                _lista.Add(usuario);
                retorno = true;
            }

            return retorno;
        }

        public override bool Eliminar(Usuario usuario)
        {
            bool retorno = false;

            if (Existe(usuario))
            {
                _lista.Remove(usuario);
                retorno = true;
            }

            return retorno;
        }

        public override bool Eliminar(int dni)
        {
            bool retorno = false;

            Usuario? usuario = Get(dni);

            if(usuario is not null)
            {
                _lista.Remove(usuario);
            }

            return retorno;
        }

        public override Usuario? Get(int dni)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _lista)
            {
                if (u == dni)
                {
                    usuario = u;
                    break;
                }
            }

            return usuario;
        }

        public Usuario? ComprobarLogin(string nombre, string contrasenia, int dni)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _lista)
            {
                if (u.Nombre == nombre && u.Dni == dni &&
                    Usuario.ComprobarContrasenia(u, contrasenia))
                {
                    usuario = u;
                }
            }

            return usuario;
        }

        public List<Profesor> ListaProfesores
        {
            get
            {
                List<Profesor> listaProfesores = new List<Profesor>();

                foreach (Usuario usuario in _lista)
                {
                    if (usuario.NivelUsuario == NivelUsuario.Profesor)
                    {
                        listaProfesores.Add((Profesor)usuario);

                    }
                }

                return listaProfesores;
            }
        }
    }
}
