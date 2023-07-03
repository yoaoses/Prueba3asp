using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoachimOsesPrueba3
{
    public class Asignatura
    {
        public Asignatura(int id, string codigo, string nombre, int horas, int semestre)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Horas = horas;
            Semestre = semestre;
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }
        public int Semestre { get; set; }
    }

}