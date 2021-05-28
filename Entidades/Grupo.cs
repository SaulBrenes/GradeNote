using System.Collections.Generic;

namespace Entidades
{
    public class Grupo
    {
        private int id;
        private int anioElectivo;
        private string nombre;
        private string turno;
        private List<Materia> materias;
        private List<Estudiante> estudiantes;


        //Constructor
        public Grupo(string nombre, string turno, int anio)
        {
            this.nombre = nombre;
            this.turno = turno;
            this.anioElectivo = anio;
        }

        public Grupo(){}

        //propiedades
        public int Id { get => id; set => id = value; }
        public int AnioElectivo { get => anioElectivo; set => anioElectivo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Turno { get => turno; set => turno = value; }
        public List<Materia> Materias { get => materias; set => materias = value; }
        public List<Estudiante> Estudiantes { get => estudiantes; set => estudiantes = value; }
    }
}
