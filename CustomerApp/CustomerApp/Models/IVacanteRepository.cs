using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicioEmpleo.Models
{
    public interface IVacanteRepository
    {
        IEnumerable<Vacante> GetAll();
        IEnumerable<Vacante> GetAllJobs(string palabra, string ciudad, string departamento);
        IEnumerable<Vacante> GetAllJobsMap(string palabra, string ciudad, string departamento);
        IEnumerable<Vacante> GetAllJobsByEmployer(string employerUserName);
        Vacante GetJob(string vacanteID);
        string AddJob(Vacante item);
        string RemoveJob(string vacanteID, string empleador);
        string UpdateJob(Vacante item);
        IEnumerable<FAQ> GetAllFAQs();
        string AddComplaint(Denuncia item);
        IEnumerable<Denuncia> GetAllComplaintsByJob(Int64 IdJob);
    }
}
