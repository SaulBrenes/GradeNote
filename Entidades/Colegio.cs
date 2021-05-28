using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Colegio
    {
        public string nombre { get; set; }
        public string director { get; set; }
        public string municipio { get; set; }
        public string departamento { get; set; }
        public string nucleoEducativo { get; set; }
        public string profesor { get; set; }
        public List<Grupo> grupos { get; set; }

        public Colegio(string nombre, string director, string municipio, string departamento, string nucleoEducativo, string profesor)
        {
            this.nombre = nombre;
            this.director = director;
            this.municipio = municipio;
            this.departamento = departamento;
            this.nucleoEducativo = nucleoEducativo;
            this.profesor = profesor;
        } 

        public Colegio() { }
    }
}
