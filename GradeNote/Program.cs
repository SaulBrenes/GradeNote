using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeNote
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ConexionDB c = new ConexionDB();
            //MessageBox.Show(c.loadData());
            Colegio c = new Colegio();
            ColegioDB cbd = new ColegioDB();
            c.nombre = "a";
            c.profesor = "b";
            c.municipio = "c";
            c.departamento = "d";
            c.director = "e";
            c.nucleoEducativo = "f";
            cbd.ActualizarColegio(c);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
        }
    }
}
