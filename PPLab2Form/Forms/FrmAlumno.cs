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
        private EEstadoFrmAlumno _estado;
       
        private enum EEstadoFrmAlumno
        {
            Inscripcion,
            Materias
        }
        public FrmAlumno(Alumno alumno)
        {
            this._alumno = alumno;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void FormAlumno_Load(object sender, EventArgs e)
        {
            this.lbl_bienvenida.Text = $"Bienvenido {this._alumno.Apellido} {this._alumno.Nombre}";
            ConfiguarForm();
            ConfigurarDataGrid();
            ConfigurarParaVerMateriasCursadas();
            dtgv_datos.ClearSelection();
            
        }

        private void alumno_lbl_inicio_Click(object sender, EventArgs e)
        {

        }

       

        private void ConfigurarParaInscribirse()
        {
            _estado = EEstadoFrmAlumno.Inscripcion;

            btn_inscribirse.Enabled = true;
            btn_inscribirse.Visible = true;

            List<Materia> materias = Sistema.Materias.GetLista;
            List<Materia> materiasSinCursar = new List<Materia>();

            foreach (var m in materias)
            {
                if(m != _alumno)
                {
                    materiasSinCursar.Add(m);
                }
            }

            dtgv_datos.DataSource = materiasSinCursar;


            dtgv_datos.Columns["CodigoMateria"].HeaderText = "Codigo Materia";
            dtgv_datos.Columns["Nombre"].HeaderText = "Nombre Materia";
            dtgv_datos.Columns["MostrarMateriaCorrelativa"].HeaderText = "Materia Correlativa";


            dtgv_datos.Columns["MateriaCorrelativa"].Visible = false;
            dtgv_datos.Columns["Alumnos"].Visible = false;
            dtgv_datos.Columns["ListaAlumnos"].Visible = false;
            dtgv_datos.Columns["PrimerExamen"].Visible = false;
            dtgv_datos.Columns["SegundoExamen"].Visible = false;



            dtgv_datos.Update();
            dtgv_datos.Refresh();
            dtgv_datos.ClearSelection();

            
        }

        private void ConfigurarParaVerMateriasCursadas()
        {
            _estado = EEstadoFrmAlumno.Materias;

            btn_inscribirse.Enabled = false;
            btn_inscribirse.Visible = false;

            List<Materia> materias = _alumno.Materias;
            EstadoAlumno? estadoAlumno;

            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cuatrimestre");
            dt.Columns.Add("Estado Alumno");
            dt.Columns.Add("Estado Cursada");
            dt.Columns.Add("Primer Parcial");
            dt.Columns.Add("Nota 1");
            dt.Columns.Add("Segundo Parcial");
            dt.Columns.Add("Nota 2");

            

            foreach (Materia m in materias)
            {
                if (m is not null)
                {
                    estadoAlumno = Materia.GetEstado(m, _alumno);

                    string nombrePrimerParcial = estadoAlumno.PrimerExamen.Examen is not null ? estadoAlumno.PrimerExamen.Examen.Nombre : "Parcial no asignado";
                    string notaPrimerParcial = estadoAlumno?.PrimerExamen is not null ? (estadoAlumno.PrimerExamen.Nota > 0 ? $"{estadoAlumno.PrimerExamen.Nota}" : "No corregido") : "No corregido";

                    string nombreSegundoParcial = estadoAlumno.SegundoExamen.Examen is not null ? estadoAlumno.SegundoExamen.Examen.Nombre : "Parcial no asignado";
                    string notaSegundoParcial = estadoAlumno.SegundoExamen is not null ? (estadoAlumno.SegundoExamen.Nota > 0 ? $"{estadoAlumno.SegundoExamen.Nota}" : "No corregido") : "No corregido";

                    
                    dt.Rows.Add(m.CodigoMateria, m.Nombre, m.Cuatrimestre, estadoAlumno.Estado,
                        estadoAlumno.EstadoMateria, nombrePrimerParcial, notaPrimerParcial,
                        nombreSegundoParcial, notaSegundoParcial);
                }

            }

            

            dtgv_datos.DataSource = dt;

            dtgv_datos.Columns["Nota 1"].HeaderText = "Nota";
            dtgv_datos.Columns["Nota 2"].HeaderText = "Nota";


            dtgv_datos.Update();
            dtgv_datos.Refresh();
            dtgv_datos.ClearSelection();

            

        }

        
        private void ConfigurarDataGrid()
        {
            //selecciona toda la fila
            this.dtgv_datos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //selecciona de a uno
            this.dtgv_datos.MultiSelect = false;
            //cambia a solamente lectura
            this.dtgv_datos.ReadOnly = true;
            //le saca la flechita que tiene al costado la fila
            this.dtgv_datos.RowHeadersVisible = false;
            //ajusta el tamaño de las columnas para ocupar todo el data griw view
            this.dtgv_datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dtgv_datos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.dtgv_datos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //el usuario podra agregar filas o no
            this.dtgv_datos.AllowUserToAddRows = false;


            dtgv_datos.ClearSelection();


        }

        private void btn_materiasCursadas_Click(object sender, EventArgs e)
        {
            ConfigurarParaVerMateriasCursadas();
        }

        private void btn_inscribirse_Click(object sender, EventArgs e)
        {
            if(dtgv_datos.SelectedRows.Count > 0 && _estado == EEstadoFrmAlumno.Inscripcion)
            {
                Materia materia = (Materia)dtgv_datos.CurrentRow.DataBoundItem;
                MessageBox.Show($"El alumno se encuentra cursando {_alumno.CantidadMateriasCursando} materias");

                if (_alumno.InscribirseAMateria(materia))
                {
                    MessageBox.Show($"Se inscribio a la materia {materia.Nombre}");
                }
                else if (materia.MateriaCorrelativa > 0 && _alumno != materia.MateriaCorrelativa)
                {
                    MessageBox.Show($"No aprobo la materia correlativa {materia.MostrarMateriaCorrelativa}");

                }
                else if ( _alumno.CantidadMateriasCursando >= 2 )
                {
                    MessageBox.Show($"El alumno se encuentra cursando {_alumno.CantidadMateriasCursando} materias");

                }
                else
                {
                    MessageBox.Show("Fallo la inscripcion");
                }

                ConfigurarParaInscribirse();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una materia");
            }
        }

        private void btn_inscribirseAMaterias_Click(object sender, EventArgs e)
        {
            ConfigurarParaInscribirse();
        }


        private void msi_materiasCursadas_Click(object sender, EventArgs e)
        {
            ConfigurarParaVerMateriasCursadas();
        }

        private void msi_inscribirseAMaterias_Click(object sender, EventArgs e)
        {
            ConfigurarParaInscribirse();
        }
        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(222, 122, 34);
        }

        private void msi_cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
