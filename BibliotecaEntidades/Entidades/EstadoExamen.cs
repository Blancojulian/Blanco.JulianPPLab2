﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class EstadoExamen
    {
        private Examen? _examen;
        private int _nota;
        private bool _rendido;

        public EstadoExamen(Examen examen, int nota, bool rendido)
        {
            _examen = examen;
            _nota = nota;
            _rendido = rendido;
        }
        public EstadoExamen(Examen examen) : this(examen, 0, false)
        {
            _examen = examen;
        }


        public int Nota
        {
            get { return this._nota; }
            set
            {
                if (value < 1 || value > 10)
                {
                    value = 0;
                }
                this._nota = value;
            }
        }

        public bool Rendido
        {
            get { return this._rendido; }
            set
            {
                if (this._rendido == true && value == false)
                {
                    value = true;
                }
                this._rendido = value;
            }
        }

        public Examen? Examen { get => _examen; set => _examen ??= value; }
    }
}
