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
        IEnumerable<Vacante> GetAllJobs(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio);
        IEnumerable<Vacante> GetAllJobsMap(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio);
        IEnumerable<Vacante> GetAllJobsByEmployer(string employerUserName);
        Vacante GetJob(string vacanteID);
        string AddJob(Vacante item);
        string RemoveJob(string vacanteID, string empleador);
        string ChangeStateJob(string vacanteID, string empleador, string estado);
        string UpdateJob(Vacante item);
        IEnumerable<FAQ> GetAllFAQs();
        string AddComplaint(Denuncia item);
        string RemoveJobComplaints(Int64 vacanteID, string Email, string tituloEmail, string textoEmail);
        IEnumerable<Denuncia> GetAllComplaintsByJob(Int64 IdJob);
    }
}
