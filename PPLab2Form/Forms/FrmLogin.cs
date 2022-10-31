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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
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
                Alumno usuario = (Alumno)ListaUsuarios.ComprobarLogin(this.tbx_nombre.Text, this.tbx_contrasenia.Text, dni);
                Alumno usuario2 = (Alumno)ListaUsuarios._lista[0];
                if (usuario is not null)
                {
                    if(usuario.NivelUsuario == NivelUsuario.Alumno)
                    {
                        this.tbx_nombre.Text = $"funciona {usuario.Apellido} {usuario.MostrarInformacion()}";
                        var f = new FrmAlumno(usuario);
                        f.Show();
                        this.Hide();
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
