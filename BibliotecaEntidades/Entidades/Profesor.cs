using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Profesor : Usuario
    {
        private NivelUsuario _nivelUsuario;
        public Profesor(string nombre, string apellido, string contrasenia, int dni) : base(nombre, apellido, contrasenia, dni)
        {
            this._nivelUsuario = NivelUsuario.Profesor;
        }

        public NivelUsuario NivelUsuario
        {
            get { return this._nivelUsuario; }
        }
    }
}
