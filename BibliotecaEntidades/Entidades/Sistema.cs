using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.Entidades
{
    public class Sistema
    {
        private static ListaMaterias _listaMaterias;
        private static ListaUsuarios _listaUsuarios;


        static Sistema()
        {
            _listaMaterias = new ListaMaterias();
            _listaUsuarios = new ListaUsuarios();
            CargarDatosHardcodeados();
        }

        private static void CargarDatosHardcodeados()
        {
            
            Admin admin1 = new Admin("Jose", "Admin", "123", 1000);

            Usuarios.Agregar(admin1);

            admin1.CrearUsuario(admin1);

            
            Materia materia1 = new Materia(1, "Programacion 1", ECuatrimestre.Primer);
            Materia materia2 = new Materia(2, "Matematica 1", ECuatrimestre.Primer);

            List<Materia> listaMaterias = new List<Materia>()
            {
                materia1,
                materia2,
                new Materia(3, "SPD", ECuatrimestre.Primer),
                new Materia(4, "Matematica 2", ECuatrimestre.Segundo, 2),
                new Materia(5, "Arq sistemas", ECuatrimestre.Segundo, 3),
                new Materia(6, "Programacion 2", ECuatrimestre.Segundo, 1)
            };

            List<Alumno> listaAlumnos = new List<Alumno>()
            {
                new Alumno("juan", "esteban", "123", 1111),
                new Alumno("aquiles", "bailo", "123", 2222),
                new Alumno("laura", "alumno", "123", 3333),
                new Alumno("jorge", "esteban", "123", 4444),
                new Alumno("juan", "doe", "123", 5555),
                new Alumno("elsa", "rubio", "123", 1234)
            };



            Profesor profesor1 = new Profesor("pablo", "esteban", "123", 6666);
            Profesor profesor2 = new Profesor("carlos", "bello", "123", 7777);
            Profesor profesor3 = new Profesor("lucas", "gaston", "123", 8888);
            Profesor profesor4 = new Profesor("mirian", "esteban", "123", 9999);
                
            

            foreach(Materia m in listaMaterias)
            {
                admin1.CrearMateria(m);
            }

            foreach (Alumno a in listaAlumnos)
            {
                admin1.CrearUsuario(a);
                a.InscribirseAMateria(materia1);
            }

            admin1.CrearUsuario(profesor1);
            admin1.CrearUsuario(profesor2);
            admin1.CrearUsuario(profesor3);
            admin1.CrearUsuario(profesor4);

            admin1.AgregarProfesorAMateria(materia1, profesor1);
            admin1.AgregarProfesorAMateria(materia1, profesor2);
            admin1.AgregarProfesorAMateria(materia2, profesor3);
            admin1.AgregarProfesorAMateria(materia2, profesor4);

            DateTime fecha = DateTime.Now;
            profesor1.AgregarExamen(materia1, "PP Prog 1", fecha, EExanen.Primer);
            profesor3.AgregarExamen(materia2, "PP Matematica 1", fecha, EExanen.Primer);
            profesor3.AgregarExamen(materia2, "SP Matematica 1", fecha, EExanen.Segundo);

            admin1.CambiarEstadoAlumno(materia1, listaAlumnos[3], EEstadoAlumno.Libre);
            admin1.CambiarEstadoAlumno(materia1, listaAlumnos[5], EEstadoAlumno.Libre);

        }
        public static ListaMaterias Materias { get => _listaMaterias; }
        public static ListaUsuarios Usuarios { get => _listaUsuarios; }
    }
}
