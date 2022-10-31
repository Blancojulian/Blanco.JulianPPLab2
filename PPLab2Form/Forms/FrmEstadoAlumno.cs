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
    public partial class FrmEstadoAlumno : Form
    {
        private Alumno _alumno;
        private Admin _admin;
        private Materia _materia;
        private EstadoAlumno? _estadoAlumno;

        public FrmEstadoAlumno(Admin admin, Alumno alumno, Materia materia)
        {
            InitializeComponent();
            this._admin = admin;
            this._alumno = alumno;
            this._materia = materia;
            this._estadoAlumno = Materia.GetEstado(this._materia, this._alumno);
        }

        private void FrmEstadoAlumno_Load(object sender, EventArgs e)
        {
            this.lbl_datos.Text = DatosAlumno();

            this.cbx_estado.DataSource = Enum.GetValues( typeof(EEstadoAlumno) );
            this.cbx_estado.SelectedItem = _estadoAlumno.Estado;
        }

        private string DatosAlumno()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this._alumno.MostrarInformacion());
            sb.AppendLine($"Materia: {_materia.Nombre}");
            sb.AppendLine($"Estado actual: {_estadoAlumno.Estado.ToString()}");

            return sb.ToString();
        }

        private void btn_confimar_Click(object sender, EventArgs e)
        {
            EEstadoAlumno estado = (EEstadoAlumno)cbx_estado.SelectedValue;
            
            if (this._admin.CambiarEstadoAlumno(this._materia, this._alumno, estado))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
