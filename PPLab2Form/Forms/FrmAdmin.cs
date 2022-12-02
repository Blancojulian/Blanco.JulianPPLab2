﻿using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPLab2Form.Forms
{
    public partial class FrmAdmin : Form
    {
        private Admin _admin;

        public FrmAdmin(Admin admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            ConfiguarForm();
            ConfigurarDataGrid();
            CargarDataGrid();
            
        }

        private void Refrescar()
        {
            //CargarDataGrid();
            this.dtgv_materias.DataSource = Sistema.Materias.GetLista;
            dtgv_materias.Update();
            dtgv_materias.Refresh();

            dtgv_materias.ClearSelection();
            

        }
        private void ConfigurarDataGrid()
        {
            //selecciona toda la fila
            this.dtgv_materias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //selecciona de a uno
            this.dtgv_materias.MultiSelect = false;
            //cambia a solamente lectura
            this.dtgv_materias.ReadOnly = true;
            //le saca la flechita que tiene al costado la fila
            this.dtgv_materias.RowHeadersVisible = false;
            //ajusta el tamaño de las columnas para ocupar todo el data griw view
            this.dtgv_materias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dtgv_materias.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.dtgv_materias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            

        }

        private void CargarDataGrid()
        {
            this.dtgv_materias.DataSource = Sistema.Materias.GetLista;


            this.dtgv_materias.Columns["CodigoMateria"].HeaderText = "Codigo Materia";
            this.dtgv_materias.Columns["Nombre"].HeaderText = "Nombre Materia";
            this.dtgv_materias.Columns["MostrarMateriaCorrelativa"].HeaderText = "Materia Correlativa";


            this.dtgv_materias.Columns["MateriaCorrelativa"].Visible = false;
            this.dtgv_materias.Columns["ListaAlumnos"].Visible = false;
            this.dtgv_materias.Columns["PrimerExamen"].Visible = false;
            this.dtgv_materias.Columns["SegundoExamen"].Visible = false;




            dtgv_materias.ClearSelection();
        }

        private void msi_crearUsuario_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frm = new FrmCrearUsuario();
            DialogResult respuesta = frm.ShowDialog();

            if (respuesta == DialogResult.OK && _admin.CrearUsuario(frm.Usuario))
            {
                MessageBox.Show($"Se creo el {frm.Usuario.NivelUsuario} {frm.Usuario.Apellido} {frm.Usuario.Nombre} con exito");
                Refrescar();
            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show($"Se cancelo la operación");

            }
        }

        private void msi_crearMateria_Click(object sender, EventArgs e)
        {
            FrmCrearMateria frm = new FrmCrearMateria();
            DialogResult respuesta = frm.ShowDialog();

            if (respuesta == DialogResult.OK && _admin.CrearMateria(frm.Materia))
            {
                MessageBox.Show($"Se creo la {frm.Materia.Nombre} con exito");
                Refrescar();
            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show($"Se cancelo la operación");

            }
        }

        private void msi_cambiarEstado_Click(object sender, EventArgs e)
        {
            if(dtgv_materias.SelectedRows.Count > 0)
            {
                Materia materia = (Materia)dtgv_materias.CurrentRow.DataBoundItem;
                FrmEstadoAlumno frm = new FrmEstadoAlumno(_admin, materia);
                DialogResult respuesta = frm.ShowDialog();

                if (respuesta == DialogResult.OK)
                {
                    string texto = frm.Cambios ? "Se modificaron con exito" : "No se realizaron cambios";
                    MessageBox.Show(texto);
                    Refrescar();
                }
                else if (respuesta == DialogResult.Cancel)
                {
                    MessageBox.Show("Se cancelo la operación");
                }

            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una materia");

            }
        }

        private void msi_asignarProfesorAMateria_Click(object sender, EventArgs e)
        {
            if (dtgv_materias.SelectedRows.Count > 0)
            {
                Materia materia = (Materia)dtgv_materias.CurrentRow.DataBoundItem;
                FrmElegirProfesor frm = new FrmElegirProfesor(materia.Nombre);
                DialogResult respuesta = frm.ShowDialog();

                if (respuesta == DialogResult.OK)
                {
                    
                    if (frm.Profesor is not null && _admin.AgregarProfesorAMateria(materia, frm.Profesor))
                    {
                        MessageBox.Show($"Se agrego el profesor {frm.Profesor.Apellido} {frm.Profesor.Nombre} a la materia {materia.Nombre}");
                        Refrescar();
                    }
                }
                else if (respuesta == DialogResult.Cancel)
                {
                    MessageBox.Show("Se cancelo la operación");
                }

            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una materia");

            }
        }

       

        private void ConfiguarForm()
        {
            this.Dock = DockStyle.Fill;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(55, 94, 151);
        }

        private void msi_calcularCantidadDeAlumnos_Click(object sender, EventArgs e)
        {
            FrmCantidadAlumnos frm = new FrmCantidadAlumnos();
            DialogResult respuesta = frm.ShowDialog();

            if (respuesta == DialogResult.OK)
            {

            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo la operación");
            }
        }

        private void msi_calcularLaNotaPromedio_Click(object sender, EventArgs e)
        {
            FrmPromedioNotas frm = new FrmPromedioNotas();
            DialogResult respuesta = frm.ShowDialog();

            if (respuesta == DialogResult.OK)
            {

            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo la operación");
            }
        }

        private void msi_asignarAlumno_Click(object sender, EventArgs e)
        {
            if (dtgv_materias.SelectedRows.Count > 0)
            {
                Materia materia = (Materia)dtgv_materias.CurrentRow.DataBoundItem;
                FrmElegirAlumno frm = new FrmElegirAlumno(materia.Nombre);
                DialogResult respuesta = frm.ShowDialog();

                if (respuesta == DialogResult.OK)
                {

                    if (frm.Alumno is not null && frm.Alumno.InscribirseAMateria(materia))
                    {
                        MessageBox.Show($"Se agrego el profesor {frm.Alumno.Apellido} {frm.Alumno.Nombre} a la materia {materia.Nombre}");
                        Refrescar();
                    }
                }
                else if (respuesta == DialogResult.Cancel)
                {
                    MessageBox.Show("Se cancelo la operación");
                }

            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una materia");

            }
        }
    }
}
