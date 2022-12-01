using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    
    public class EstadoAlumno
    {
        private EEstadoMateria _estadoMateria;
        private bool _asistencia;
        private EEstadoAlumno _estadoAlumno;
        private EstadoExamen _primerExamen;
        private EstadoExamen _segundoExamen;

        private EstadoAlumno(EEstadoMateria estadoMateria, bool asistencia, EEstadoAlumno estadoAlumno)
        {
            this._estadoMateria = estadoMateria;
            this._asistencia = asistencia;
            this._estadoAlumno = estadoAlumno;
        }

        public EstadoAlumno() : this(EEstadoMateria.Cursando, false, EEstadoAlumno.Regular)
        {

        }

        public EstadoAlumno(Examen primerExamen, Examen segundoExamen) : this(EEstadoMateria.Cursando, false, EEstadoAlumno.Regular)
        {
            _primerExamen = new EstadoExamen(primerExamen);
            _segundoExamen = new EstadoExamen(segundoExamen);

        }

        public EEstadoAlumno Estado
        {
            get { return this._estadoAlumno; }
            set { this._estadoAlumno = value; }
        }

        public EEstadoMateria EstadoMateria
        {
            get { return this._estadoMateria; }
            set
            {
                if (this._estadoMateria == EEstadoMateria.Aprobado && value != EEstadoMateria.Aprobado)
                {
                    value = EEstadoMateria.Aprobado;
                }
                this._estadoMateria = value;
            }
        }

        public bool Asistencia
        {
            get { return this._asistencia; }
            set { this._asistencia = value; }
        }

        public EstadoExamen PrimerExamen { get => _primerExamen; set => _primerExamen ??= value; }
        public EstadoExamen SegundoExamen { get => _segundoExamen; set => _segundoExamen ??= value; }
    }
}
