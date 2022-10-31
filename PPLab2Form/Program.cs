using BibliotecaEntidades.Entidades;
using PPLab2Form.Forms;
using System.Diagnostics.CodeAnalysis;

namespace PPLab2Form
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Profesor profesor1 = new Profesor("pablo", "luis", "123", 123);
            Admin admin1 = new Admin("Jose", "Admin", "1111", 1111);
            admin1.CrearUsuario(admin1);

            //Materia
            Materia materia1 = new Materia(10, "Programacion", "primer");
            admin1.CrearMateria(materia1);
            

            //Alumno
            Alumno alumno1 = new Alumno("elsa", "murai", "123", 123);
            alumno1.InscribirseAMateria(materia1);

           
            admin1.CrearUsuario(profesor1);



            
            Application.Run(new FrmElegirProfesor());
            
        }
    }
}