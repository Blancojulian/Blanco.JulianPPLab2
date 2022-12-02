﻿using BibliotecaEntidades.Entidades;
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
    public partial class FrmElegirAlumno : Form
    {
        private string _materia;
        private Alumno _alumno;

        public Alumno Alumno { get => _alumno; }

        public FrmElegirAlumno(string materia)
        {
            _materia = materia;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmElegirAlumno_Load(object sender, EventArgs e)
        {
            ConfiguarForm();
            ConfigurarDataGrid();
            this.lbl_materia.Text = $"Asignar un profesores a la {_materia}";
            this.dtgv_profesores.DataSource = Sistema.Usuarios.ListaProfesores;
            this.dtgv_profesores.Columns["NivelUsuario"].HeaderText = "Tipo de usuario";
            this.dtgv_profesores.ClearSelection();
        }

        private void Refrescar()
        {
            dtgv_profesores.DataSource = Sistema.Usuarios.ListaAlumnos;
            dtgv_profesores.Columns["NivelUsuario"].HeaderText = "Tipo de usuario";
            dtgv_profesores.Update();
            dtgv_profesores.Refresh();
            dtgv_profesores.ClearSelection();
        }


        private void btn_asignar_Click(object sender, EventArgs e)
        {
            if (dtgv_profesores.SelectedRows.Count > 0)
            {
                Alumno alumno = (Alumno)dtgv_profesores.SelectedRows[0].DataBoundItem;

                DialogResult respuesta = MessageBox.Show($"Esta seguro de asignar el alumno {alumno.Nombre} {alumno.Apellido} la materia {_materia}", "Confirmar", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    _alumno = alumno;
                    this.DialogResult = DialogResult.OK;


                }
                else if (respuesta == DialogResult.No)
                {
                    MessageBox.Show("Se cancelo la carga");

                }
                Refrescar();
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar un profesor");

            }
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


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfiguarForm()
        {
            this.BackColor = Color.FromArgb(55, 94, 151);
        }
    }
}
