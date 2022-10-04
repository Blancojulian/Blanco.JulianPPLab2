using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public static class ListaUsuarios
    {
        private static List<Usuario>_lista;
        private static int _id;

        static ListaUsuarios()
        {
            _id = 0;
            _lista = new List<Usuario>();
            AgregarUsuario(new Alumno("Juan", "Doe", "asd123", 1234));
            AgregarUsuario(new Alumno("Juan", "esteban", "AAA111", 2222));

        }

        public static int GetId()
        {
            _id++;
            return _id;
        }

        private static bool UsuarioExiste(Usuario u)
        {
            bool retorno = false;

            foreach (Usuario usuario in _lista)
            {
                if(usuario.Dni == u.Dni)
                {
                    retorno = true;
                    break;
                }
            }
            
            return retorno;
        }
        
        public static bool AgregarUsuario(Usuario u)
        {
            bool retorno = false;

            if (!UsuarioExiste(u))
            {
                _lista.Add(u);
                retorno = true;
            }

            return retorno;
        }

        public static bool EliminarUsuario(Usuario u)
        {
            bool retorno = false;

            if (UsuarioExiste(u))
            {
                _lista.Remove(u);
                retorno = true;
            }

            return retorno;
        }

        public static Usuario ComprobarLogin(string nombre, string contrasenia, int dni)
        {
            
            foreach(Usuario usuario in _lista)
            {
                if(usuario.Nombre == nombre && usuario.Dni == dni && usuario.ComprobarContrasenia(contrasenia))
                {
                    return usuario;
                }
            }
            

            return null;
        }

    }
}
