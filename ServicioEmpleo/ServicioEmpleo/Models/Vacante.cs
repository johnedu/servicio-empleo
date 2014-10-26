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
        public int TipoID { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Num_vacantes { get; set; }
        public string Cargo { get; set; }
        public int SalarioID { get; set; }
        public string Salario { get; set; }
        public string Sector { get; set; }
        public int ExperienciaID { get; set; }
        public string Experiencia { get; set; }
        public int Nivel_estudiosID { get; set; }
        public string Nivel_estudios { get; set; }
        public string Profesion { get; set; }
        public int Municipio { get; set; }
        public int Departamento { get; set; }
        public string MunicipioNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Empleador { get; set; }
        public string Busqueda { get; set; }
        public int Num_denuncias { get; set; }
        public string Estado { get; set; }
        public DateTime Ultima_Actualizacion { get; set; }
        public int DiasVence { get; set; }
        public string Telefono { get; set; }
        public string Indicativo { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }

    public class FAQ
    {
        public int ID { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }

    public class Denuncia
    {
        public Int64 ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public Int64 vacanteID { get; set; }
        public string Email { get; set; }
        public string textoEmail { get; set; }
        public string tituloEmail { get; set; }
    }

    public class Municipio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }

    public class Departamento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}