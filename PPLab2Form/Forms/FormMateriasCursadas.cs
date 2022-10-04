using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPLab2Form.Forms
{
    public partial class FormMateriasCursadas : Form
    {
        private Alumno _alumno;
        private List<Materia> _listaMaterias;
        public FormMateriasCursadas(Alumno alumno)
        {
            this._alumno = alumno;
            this._listaMaterias = new List<Materia>();
            this.LoadDataDataGridView();
            this.lbl_alumno.Text = $"Materias - {this._alumno.Apellido} {this._alumno.Nombre}";
            InitializeComponent();
        }

        private void LoadDataDataGridView()
        {
            this._listaMaterias = Alumno.MostrarMateriasCursadas(this._alumno);
            string estado = "";

            foreach(Materia materia in _listaMaterias)
            {
                estado = Materia.GetEstadoAlumno(materia, this._alumno);
                this.dataGridView1.Rows.Add(materia.CodigoMateria, materia.Nombre, estado);

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormMateriasCursadas_Load(object sender, EventArgs e)
        {

        }
    }
}
