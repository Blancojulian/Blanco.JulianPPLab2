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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void login_lbl_1_Click(object sender, EventArgs e)
        {

        }

        private void login_btn_aceptar_Click(object sender, EventArgs e)
        {
            int dni;
            
            if(int.TryParse(this.tbx_dni.Text, out dni))
            {
                Usuario usuario = (Alumno)ListaUsuarios.ComprobarLogin(this.tbx_nombre.Text, this.tbx_contrasenia.Text, dni);
            
                if(usuario is not null)
                {
                    if(usuario.NivelUsuario == NivelUsuario.Alumno)
                    {
                        this.tbx_nombre.Text = $"funciona {usuario.Apellido} {usuario.MostrarInformacion()}";
                        new FormAlumno((Alumno)usuario);
                    }
                }
            
            }
            else
            {
                MessageBox.Show("DNI invalido");
            }

        }

        private void login_btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
