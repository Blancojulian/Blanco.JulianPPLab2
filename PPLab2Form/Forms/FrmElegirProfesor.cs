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
    public partial class FrmElegirProfesor : Form
    {
        private List<Profesor> _profesores;
        public FrmElegirProfesor()
        {
            InitializeComponent();
        }

        private void FrmElegirProfesor_Load(object sender, EventArgs e)
        {
            var source = new BindingSource();
            this._profesores = ListaUsuarios.ListaProfesores;
            //this.cbx_profesores.DataSource = _profesores;
            //source.DataSource = this._profesores;
            this.dgvw_profesores.DataSource = this._profesores;
        }

        private void dgvw_profesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgvw_profesores.SelectedRows;
        }
    }
}
