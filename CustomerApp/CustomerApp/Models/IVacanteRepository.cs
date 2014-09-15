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
        IEnumerable<Vacante> GetAllVacants(string palabra, string ciudadDepartamento);
        IEnumerable<Vacante> GetAllByEmployer(string employerUserName);
        Vacante Get(string vacanteID);
        Vacante Add(Vacante item);
        bool Remove(string vacanteID);
        bool Update(Vacante item);
    }
}
