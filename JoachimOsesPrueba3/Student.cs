using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoachimOsesPrueba3
{
    public class Student
    {
        public Student(int id, string rut, string nombre)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
        }

        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
    }
}