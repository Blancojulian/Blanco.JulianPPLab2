using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPLab2Form.Forms
{
    public partial class FrmAsignarNota : Form
    {
        private Materia _materia;
        private Profesor _profesor;
        private bool _cambios;

        public bool Cambios { get => _cambios; }

        public FrmAsignarNota(Materia materia, Profesor profesor)
        {
            _materia = materia;
            _profesor = profesor;
            _cambios = false;
            InitializeComponent();

        }

        private void FrmAsignarNota_Load(object sender, EventArgs e)
        {
            btn_asignarNota.Enabled = false;

            ConfiguarForm();
            ConfigurarComboBox();
            ConfigurarDataGrid();
            CargarDatagrid();
        }

        private void Refrescar()
        {
            dtgv_alumnos.Update();
            dtgv_alumnos.Refresh();
            dtgv_alumnos.ClearSelection();
        }
        private void CargarDatagrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Estado Alumno");
            dt.Columns.Add("Estado Cursada");
            dt.Columns.Add("Primer Parcial");
            dt.Columns.Add("Nota 1");
            dt.Columns.Add("Segundo Parcial");
            dt.Columns.Add("Nota 2");




            foreach (KeyValuePair<Alumno, EstadoAlumno> a in _materia.ListaAlumnos)
            {


                string nombrePrimerParcial = a.Value.PrimerExamen.Examen is not null ? a.Value.PrimerExamen.Examen.Nombre : "Parcial no asignado";
                string notaPrimerParcial = a.Value?.PrimerExamen is not null ? (a.Value.PrimerExamen.Nota > 0 ? $"{a.Value.PrimerExamen.Nota}" : "No corregido") : "No corregido";

                string nombreSegundoParcial = a.Value.SegundoExamen.Examen is not null ? a.Value.SegundoExamen.Examen.Nombre : "Parcial no asignado";
                string notaSegundoParcial = a.Value.SegundoExamen is not null ? (a.Value.SegundoExamen.Nota > 0 ? $"{a.Value.SegundoExamen.Nota}" : "No corregido") : "No corregido";

                string nombre = $"{a.Key.Apellido} {a.Key.Nombre}";

                dt.Rows.Add(nombre, a.Key.Dni, a.Value.Estado,
                     a.Value.EstadoMateria, nombrePrimerParcial, notaPrimerParcial,
                    nombreSegundoParcial, notaSegundoParcial);


            }


            dtgv_alumnos.DataSource = dt;

            dtgv_alumnos.Columns["Nota 1"].HeaderText = "Nota";
            dtgv_alumnos.Columns["Nota 2"].HeaderText = "Nota";


            Refrescar();
        }

        private void ConfigurarDataGrid()
        {
            //selecciona toda la fila
            this.dtgv_alumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //selecciona de a uno
            this.dtgv_alumnos.MultiSelect = false;
            //cambia a solamente lectura
            this.dtgv_alumnos.ReadOnly = true;
            //le saca la flechita que tiene al costado la fila
            this.dtgv_alumnos.RowHeadersVisible = false;
            //ajusta el tamaño de las columnas para ocupar todo el data griw view
            this.dtgv_alumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dtgv_alumnos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //ver bien que hacer si pasa la cantidad que entra
            this.dtgv_alumnos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //el usuario podra agregar filas o no
            this.dtgv_alumnos.AllowUserToAddRows = false;


            dtgv_alumnos.ClearSelection();


        }

        private void ConfigurarComboBox()
        {
            cbx_examen.DataSource = Enum.GetValues(typeof(EExanen));
            cbx_examen.SelectedIndex = 0;
        }

        private void btn_asignarNota_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (dtgv_alumnos.SelectedRows.Count > 0)
                {
                    
                    string? nombre = dtgv_alumnos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    int dni = int.Parse(dtgv_alumnos.SelectedRows[0].Cells["DNI"].Value.ToString());
                    int nota = int.Parse(tbx_nota.Text);
                    EExanen examen = (EExanen)cbx_examen.SelectedItem;
                    Alumno? alumno = (Alumno?)Sistema.Usuarios.Get(dni);

                    LanzarExcepcionParcial();

                    if( nota >= 1 && nota <= 10 && alumno is not null)
                    {
                        DialogResult respuesta = MessageBox.Show($"Esta seguro de asignar nota {tbx_nota.Text} al alumno {nombre}", "Confirmar", MessageBoxButtons.YesNo);

                        if (respuesta == DialogResult.Yes)
                        {
                            if (_profesor.AgregarNota(_materia, alumno, examen, nota))
                            {
                                MessageBox.Show("Se cargo la nota");
                                _cambios = true;
                            }
                            else
                            {
                                MessageBox.Show("FALLO al cargar la nota");

                            }
                            CargarDatagrid();
                            

                        }
                        else if (respuesta == DialogResult.No)
                        {
                            MessageBox.Show("Se cancelo la carga");

                        }
                        
                    }
                    

                }
                else
                {
                    MessageBox.Show("Tiene que seleccionar una persona");

                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Es null exception: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ingrese un numero valido");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LanzarExcepcionParcial()
        {
            string strParcial = "Parcial no asignado";
            string strNota = "No corregido";

            string? parcial1 = dtgv_alumnos.SelectedRows[0].Cells["Primer Parcial"].Value.ToString();
            string? parcial2 = dtgv_alumnos.SelectedRows[0].Cells["Segundo Parcial"].Value.ToString();
            string? strNota1 = dtgv_alumnos.SelectedRows[0].Cells["Nota 1"].Value.ToString();
            string? strNota2 = dtgv_alumnos.SelectedRows[0].Cells["Nota 2"].Value.ToString();

            int nota1;
            int nota2;

            int nota = int.Parse(tbx_nota.Text);

            EExanen examen = (EExanen)cbx_examen.SelectedItem;

            if (!(nota > 1 && nota <= 10))
            {
                throw new Exception("La tiene que ser entre 1 y 10");

            }
            switch (examen)
            {
                case EExanen.Primer:
                    if (parcial1 == strParcial)
                    {
                        throw new Exception(strParcial);
                    }
                    else if(strNota1 != strNota && int.TryParse(strNota1, out nota1) && nota1 > 0)
                    {
                        throw new Exception("Parcial ya corregido");
                    }
                    break;
                case EExanen.Segundo:
                    if (parcial2 == strParcial)
                    {
                        throw new Exception(strParcial);
                    }
                    else if (strNota2 != strNota &&int.TryParse(strNota2, out nota2) && nota2 > 0)
                    {
                        throw new Exception("Parcial ya corregido");
                    }
                    break;
                default:
                    break;
            }
        }


        private void tbx_nota_TextChanged(object sender, EventArgs e)
        {
            btn_asignarNota.Enabled = true;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ConfiguarForm()
        {
            this.BackColor = Color.FromArgb(134, 44, 132);
        }
    }
}
