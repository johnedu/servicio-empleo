using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using servicioEmpleo.Models;

namespace servicioEmpleo.Controllers
{
    public class VacanteController : ApiController
    {
        static readonly IVacanteRepository repository = new VacanteRepository();

        public IEnumerable<Vacante> obtenerVacantes(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio)
        {
            return repository.GetAllJobs(palabra, tipo, salario, experiencia, nivel, municipio);
        }

        public IEnumerable<Vacante> obtenerVacantesMapa(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio)
        {
            return repository.GetAllJobsMap(palabra, tipo, salario, experiencia, nivel, municipio);
        }

        public IEnumerable<Vacante> obtenerVacantesXEmpleador(string empleador)
        {
            return repository.GetAllJobsByEmployer(empleador);
        }

        public Vacante obtenerVacante(string vacanteID)
        {
            Vacante vacante = repository.GetJob(vacanteID);
            if (vacante == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return vacante;
        }

        public string agregarVacante(Vacante vacante)
        {
            return repository.AddJob(vacante);
        }

        public string modificarVacante(Vacante vacante)
        {
            return repository.UpdateJob(vacante);
        }

        public string eliminarVacante(string ID, string empleador)
        {
            Vacante vacante = repository.GetJob(ID);
            if (vacante == null)
            {
                return "Elemento no encontrado";
            }
            return repository.RemoveJob(ID, empleador);
        }

        public string cambiarEstadoVacante(string ID, string empleador, string estado)
        {
            Vacante vacante = repository.GetJob(ID);
            if (vacante == null)
            {
                return "Elemento no encontrado";
            }
            return repository.ChangeStateJob(ID, empleador, estado);
        }

        public IEnumerable<FAQ> obtenerFAQs()
        {
            return repository.GetAllFAQs();
        }

        public string agregarDenuncia(Denuncia denuncia)
        {
            return repository.AddComplaint(denuncia);
        }

        public IEnumerable<Denuncia> obtenerDenunciasXVacante(Int16 vacanteID)
        {
            return repository.GetAllComplaintsByJob(vacanteID);
        }
    }
}