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

        public IEnumerable<Vacante> obtenerVacantes(string pal, string ciu, string dep)
        {
            return repository.GetAllJobs(pal, ciu, dep);
        }

        public IEnumerable<Vacante> obtenerVacantesMapa(string pal, string ciu, string dep)
        {
            return repository.GetAllJobsMap(pal, ciu, dep);
        }

        public IEnumerable<Vacante> obtenerVacantesXEmpleador(string vacanteID)
        {
            return repository.GetAllJobsByEmployer(vacanteID);
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

        public string eliminarVacante(string ID, string emp)
        {
            Vacante vacante = repository.GetJob(ID);
            if (vacante == null)
            {
                return "Elemento no encontrado";
            }
            return repository.RemoveJob(ID, emp);
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