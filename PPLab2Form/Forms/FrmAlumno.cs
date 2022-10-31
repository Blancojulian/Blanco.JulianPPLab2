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
    public partial class FrmAlumno : Form
    {
        private Alumno _alumno;
        public FrmAlumno(Alumno alumno)
        {
            this._alumno = alumno;
            InitializeComponent();
        }

        private void FormAlumno_Load(object sender, EventArgs e)
        {
            this.lbl_bienvenida.Text = $"Bienvenido {this._alumno.Apellido} {this._alumno.Nombre}";
        }

        private void alumno_lbl_inicio_Click(object sender, EventArgs e)
        {

        }

        private void btn_mostrarMaterias_Click(object sender, EventArgs e)
        {
            FrmMateriasCursadas frmMaterias = new FrmMateriasCursadas(this._alumno);
            frmMaterias.ShowDialog();
        }

        private void FormAlumno_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
