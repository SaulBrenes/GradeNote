using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Grupo
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string turno { get; set; }
        public Int64 anio { get; set; }
        public List<Materia> materias { get; set; }
        public List<Estudiante> estudiantes { get; set; }


        //Constructor
        public Grupo(string nombre, string turno, Int64 anio)
        {
            this.nombre = nombre;
            this.turno = turno;
            this.anio = anio;
        }

        public Grupo(Int64 id, string nombre, string turno, Int64 anio)
        {
            this.id = id;
            this.nombre = nombre;
            this.turno = turno;
            this.anio = anio;
        }

        public Grupo(){}

    }
}
