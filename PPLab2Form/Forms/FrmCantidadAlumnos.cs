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
    public partial class FrmCantidadAlumnos : Form
    {
        public FrmCantidadAlumnos()
        {
            InitializeComponent();
        }

        private void FrmCantidadAlumnos_Load(object sender, EventArgs e)
        {
            ConfiguarForm();
            ConfigurarDataGrid();
            Refrescar();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Refrescar()
        {
            CargarDataGridView();
            dtgv_profesores.Update();
            dtgv_profesores.Refresh();
            dtgv_profesores.ClearSelection();
        }
        private void CargarDataGridView()
        {
            Dictionary<Profesor, int> lista = CalcularCantidadDeAlumnos();
            DataTable dt = new DataTable();

            dt.Columns.Add("Profesor");
            dt.Columns.Add("Cantidad Alumnos");

            foreach (KeyValuePair<Profesor, int> item in lista)
            {
                string strCantidad = item.Value <= 0 ? "No tiene alumnos" : $"{item.Value}";
                dt.Rows.Add($"{item.Key.Apellido} {item.Key.Nombre}", strCantidad);
            }

            dtgv_profesores.DataSource = dt;
        }

        private Dictionary<Profesor, int> CalcularCantidadDeAlumnos()
        {
            List<Profesor> listaProfesores = Sistema.Usuarios.ListaProfesores;
            List<Materia> listaMateria = Sistema.Materias.GetLista;
            Dictionary<Profesor, int> cantidadAlumnos = new Dictionary<Profesor, int>();
            foreach (var profesor in listaProfesores)
            {
                int cantidad = 0;
                foreach (var materia in listaMateria)
                {
                    if (materia == profesor)
                    {
                        cantidad += materia.ListaAlumnos.Count;
                    }
                }
                cantidadAlumnos.Add(profesor, cantidad);
            }

            return cantidadAlumnos;
        }

        private void ConfigurarDataGrid()
        {
            //selecciona toda la fila
            this.dtgv_profesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //selecciona de a uno
            this.dtgv_profesores.MultiSelect = false;
            //cambia a solamente lectura
            this.dtgv_profesores.ReadOnly = true;
            //le saca la flechita que tiene al costado la fila
            this.dtgv_profesores.RowHeadersVisible = false;
            //ajusta el tamaño de las columnas para ocupar todo el data griw view
            this.dtgv_profesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dtgv_profesores.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.dtgv_profesores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //el usuario podra agregar filas o no
            this.dtgv_profesores.AllowUserToAddRows = false;


            dtgv_profesores.ClearSelection();


        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(55, 94, 151);
        }
    }
}
