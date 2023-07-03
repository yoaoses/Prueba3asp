using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoachimOsesPrueba3
{
    
    public class Inscripcion
    {
        public int Id { get; set; }
        public int semestre { get; set; }
        public string Rut { get; set; }
        public string Codigo { get; set; }
        public string studentName { get; set; }
        public string subjectName { get; set; }
        public DateTime Fecha { get; set; }

        // Constructor
        public Inscripcion() { }
        public Inscripcion(int id, string rut, string codigo, DateTime fecha)
        {
            Id = id;
            Rut = rut;
            Codigo = codigo;
            Fecha = fecha;
        }        
    }

}