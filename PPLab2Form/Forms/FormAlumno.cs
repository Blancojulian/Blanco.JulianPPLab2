using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;

namespace PPLab2Form.Forms
{
    public partial class FormAlumno : Form
    {
        private Alumno _alumno;
        public FormAlumno(Alumno alumno)
        {
            this._alumno = alumno;
            this.lbl_bienvenida.Text = $"Bienvenido {this._alumno.Apellido} {this._alumno.Nombre}";
            InitializeComponent();
        }

        private void FormAlumno_Load(object sender, EventArgs e)
        {
            
        }

        private void alumno_lbl_inicio_Click(object sender, EventArgs e)
        {

        }
    }
}
