using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPLab2Form.Forms
{
    public partial class FrmCrearMateria : Form
    {
        private Materia _materia;
        public FrmCrearMateria()
        {
            InitializeComponent();
            this.loadComboBox();
        }

        private void chbx_materiaCorrelativa_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_materiaCorrelativa.Checked)
            {
                this.cbx_materiaCorrelativa.Enabled = true;
            }
            else
            {
                this.cbx_materiaCorrelativa.Enabled = false;
            }
        }

        private void FrmCrearMateria_Load(object sender, EventArgs e)
        {
            List<Materia> materias = ListaMaterias.Lista;

            if (materias.Count > 0)
            {
                this.cbx_materiaCorrelativa.Enabled = false;
            }
        }

        private void loadComboBox()
        {
            List<Materia> materias = ListaMaterias.Lista;
            List<int> codigosMaterias = new List<int>();

            foreach (Materia materia in materias)
            {
                codigosMaterias.Add(materia.CodigoMateria);
            }
            
            this.cbx_materiaCorrelativa.DataSource = codigosMaterias;
            this.cbx_materiaCorrelativa.SelectedIndex = 0;
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            int codigo;
            int materiaCorrelativa;

            if (!string.IsNullOrWhiteSpace(tbx_nombre.Text) &&
                !string.IsNullOrWhiteSpace(tbx_cuatrimestre.Text) &&
                !string.IsNullOrWhiteSpace(tbx_codigo.Text))
            {
                if (int.TryParse(this.tbx_codigo.Text, out codigo))
                {
                    if (this.chbx_materiaCorrelativa.Checked && int.TryParse(this.tbx_codigo.Text, out materiaCorrelativa))
                    {
                        this._materia = new Materia(codigo, tbx_nombre.Text, tbx_cuatrimestre.Text, materiaCorrelativa);

                    }
                    else
                    {
                        this._materia = new Materia(codigo, tbx_nombre.Text, tbx_cuatrimestre.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Codigo invalido");
                }

            }
            else
            {
                MessageBox.Show("Debe completar todos campos");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Materia Materia { get { return this._materia; } }
    }
}
