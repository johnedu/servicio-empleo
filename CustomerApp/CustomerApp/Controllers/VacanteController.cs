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

        public IEnumerable<Vacante> obtenerVacantes(string palabra, string ciudadDepartamento)
        {
            return repository.GetAllVacants(palabra, ciudadDepartamento);
        }

        public IEnumerable<Vacante> obtenerVacantesXEmpleador(string vacanteID)
        {
            return repository.GetAllByEmployer(vacanteID);
        }
        

        public Vacante obtenerVacante(string vacanteID)
        {
            Vacante vacante = repository.Get(vacanteID);
            if (vacante == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return vacante;
        }

        public HttpResponseMessage agregarVante(Vacante vacante)
        {
            vacante = repository.Add(vacante);
            var response = Request.CreateResponse<Vacante>(HttpStatusCode.Created, vacante);

            string uri = Url.Link("DefaultApi", new { vacanteID = vacante.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void modificarVacante(Vacante vacante)
        {
            if (!repository.Update(vacante))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void eliminarVacante(string vacanteID)
        {
            Vacante vacante = repository.Get(vacanteID);
            if (vacante == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(vacanteID);
        }
    }
}