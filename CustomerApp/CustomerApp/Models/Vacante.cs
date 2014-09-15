using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicioEmpleo.Models
{
    public class Vacante
    {
        public Int64 ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Experiencia { get; set; }
        public int Num_vacantes { get; set; }
        public string Cargo { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public string Nivel_estudios { get; set; }
        public string Profesion { get; set; }
        public string Salario { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Sector { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Empleador { get; set; }
        public string Busqueda { get; set; }
        public int Num_denuncias { get; set; }
    }

    public class FAQ
    {
        public Int32 ID { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }
}