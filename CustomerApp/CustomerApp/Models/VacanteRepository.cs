using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace servicioEmpleo.Models
{
    public class VacanteRepository : IVacanteRepository
    {
        public IEnumerable<Vacante> GetAll()
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("SELECT [dbo].[Vacante].[ID], " +
                                                    "[dbo].[Vacante].[Titulo], " +
                                                    "[dbo].[Vacante].[Tipo], " +
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador], " +
                                                    "[dbo].[Vacante].[Ultima_Actualizacion] " +
                                            "FROM    [dbo].[Vacante]");

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Vacante vacante = new Vacante();
                            vacante.ID = reader.GetInt64(0);
                            vacante.Titulo = reader.GetString(1);
                            vacante.TipoID = reader.GetInt32(2);
                            vacante.Descripcion = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.SalarioID = reader.GetInt32(6);
                            vacante.Sector = reader.GetString(7);
                            vacante.ExperienciaID = reader.GetInt32(8);
                            vacante.Nivel_estudiosID = reader.GetInt32(9);
                            vacante.Profesion = reader.GetString(10);
                            vacante.Municipio = reader.GetInt32(11);
                            vacante.Departamento = reader.GetInt32(12);
                            vacante.Fecha_publicacion = reader.GetDateTime(13);
                            vacante.Fecha_vencimiento = reader.GetDateTime(14);
                            vacante.Latitud = reader.GetString(15);
                            vacante.Longitud = reader.GetString(16);
                            vacante.Empleador = reader.GetString(17);
                            vacante.Ultima_Actualizacion = reader.GetDateTime(18);

                            vacantes.Add(vacante);
                        }
                        con.Close(); 
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return vacantes.ToArray();
        }

        public IEnumerable<Vacante> GetAllJobs(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("EXEC [stp_Vacantes_FullTextSearch] '" + palabra + "', " + tipo + ", " + salario + ", " + experiencia + ", " + nivel + ", " + municipio + ", 'N' WITH RECOMPILE");
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Vacante vacante = new Vacante();
                            vacante.ID = reader.GetInt64(0);
                            vacante.Titulo = reader.GetString(1);
                            vacante.Tipo = reader.GetString(2);
                            vacante.Descripcion = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Salario = reader.GetString(6);
                            vacante.Sector = reader.GetString(7);
                            vacante.Experiencia = reader.GetString(8);
                            vacante.Nivel_estudios = reader.GetString(9);
                            vacante.Profesion = reader.GetString(10);
                            vacante.Municipio = reader.GetInt32(11);
                            vacante.Departamento = reader.GetInt32(12);
                            vacante.Fecha_publicacion = reader.GetDateTime(13);
                            vacante.Fecha_vencimiento = reader.GetDateTime(14);
                            vacante.Latitud = reader.GetString(15);
                            vacante.Longitud = reader.GetString(16);
                            vacante.Empleador = reader.GetString(17);
                            vacante.Ultima_Actualizacion = reader.GetDateTime(18);
                            vacante.DiasVence = reader.GetInt32(19);
                            vacantes.Add(vacante);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return vacantes.ToArray();
        }

        public IEnumerable<Vacante> GetAllJobsMap(string palabra, string tipo, string salario, string experiencia, string nivel, string municipio)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("EXEC [stp_Vacantes_FullTextSearch] '" + palabra + "', " + tipo + ", " + salario + ", " + experiencia + ", " + nivel + ", " + municipio + ", 'M' WITH RECOMPILE");
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Vacante vacante = new Vacante();
                            vacante.ID = reader.GetInt64(0);
                            vacante.Titulo = reader.GetString(1);
                            vacante.Latitud = reader.GetString(2);
                            vacante.Longitud = reader.GetString(3);

                            vacantes.Add(vacante);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return vacantes.ToArray();
        }

        public IEnumerable<Vacante> GetAllJobsByEmployer(string employerUserName)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("SELECT [dbo].[Vacante].[ID], " +
                                                    "[dbo].[Vacante].[Titulo], " +
                                                    "[dbo].[Vacante].[Tipo], " +
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador], " +
                                                    "[dbo].[Vacante].[Ultima_Actualizacion] " +
                                            "FROM    [dbo].[Vacante] " +
                                            "WHERE   [dbo].[Vacante].[Empleador] = '" + employerUserName + "'" +
                                            "AND     ([dbo].[Vacante].[Estado] = 'A' OR [dbo].[Vacante].[Estado] = 'I')");

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Vacante vacante = new Vacante();
                            vacante.ID = reader.GetInt64(0);
                            vacante.Titulo = reader.GetString(1);
                            vacante.TipoID = reader.GetInt32(2);
                            vacante.Descripcion = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.SalarioID = reader.GetInt32(6);
                            vacante.Sector = reader.GetString(7);
                            vacante.ExperienciaID = reader.GetInt32(8);
                            vacante.Nivel_estudiosID = reader.GetInt32(9);
                            vacante.Profesion = reader.GetString(10);
                            vacante.Municipio = reader.GetInt32(11);
                            vacante.Departamento = reader.GetInt32(12);
                            vacante.Fecha_publicacion = reader.GetDateTime(13);
                            vacante.Fecha_vencimiento = reader.GetDateTime(14);
                            vacante.Latitud = reader.GetString(15);
                            vacante.Longitud = reader.GetString(16);
                            vacante.Empleador = reader.GetString(17);
                            vacante.Ultima_Actualizacion = reader.GetDateTime(18);

                            vacantes.Add(vacante);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return vacantes.ToArray();
        }

        public Vacante GetJob(string vacanteID)
        {
            Vacante vacante = new Vacante();
            try {
                string query = string.Format("SELECT [dbo].[Vacante].[ID], " +
                                                    "[dbo].[Vacante].[Titulo], " +
                                                    "[dbo].[Vacante].[Tipo], " +
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador], " +
                                                    "[dbo].[Vacante].[Ultima_Actualizacion] " +
                                            "FROM    [dbo].[Vacante]" +
                                            "WHERE   [dbo].[Vacante].[ID] = " + vacanteID);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            vacante.ID = reader.GetInt64(0);
                            vacante.Titulo = reader.GetString(1);
                            vacante.TipoID = reader.GetInt32(2);
                            vacante.Descripcion = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.SalarioID = reader.GetInt32(6);
                            vacante.Sector = reader.GetString(7);
                            vacante.ExperienciaID = reader.GetInt32(8);
                            vacante.Nivel_estudiosID = reader.GetInt32(9);
                            vacante.Profesion = reader.GetString(10);
                            vacante.Municipio = reader.GetInt32(11);
                            vacante.Departamento = reader.GetInt32(12);
                            vacante.Fecha_publicacion = reader.GetDateTime(13);
                            vacante.Fecha_vencimiento = reader.GetDateTime(14);
                            vacante.Latitud = reader.GetString(15);
                            vacante.Longitud = reader.GetString(16);
                            vacante.Empleador = reader.GetString(17);
                            vacante.Ultima_Actualizacion = reader.GetDateTime(18);           
                        }
                        con.Close(); 
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return vacante;
        }

        public string AddJob(Vacante item)
        {
            item.Busqueda = item.Titulo + " " + item.Descripcion + " " + item.Cargo + " " + item.Profesion;
            item.Busqueda = item.Busqueda.ToLower();
            item.Num_denuncias = 0;
            item.Estado = "A";
            try {
                string query = string.Format("INSERT INTO [dbo].[Vacante] " +
                                                "([Titulo], " +
                                                "[Tipo], " +
                                                "[Descripcion], " +
                                                "[Num_vacantes], " +
                                                "[Cargo], " +
                                                "[Salario], " +
                                                "[Sector], " +
                                                "[Experiencia], " +
                                                "[Nivel_estudios], " +
                                                "[Profesion], " +
                                                "[Municipio], " +
                                                "[Departamento], " +
                                                "[Fecha_publicacion], " +
                                                "[Fecha_vencimiento], " +
                                                "[Latitud], " +
                                                "[Longitud], " +
                                                "[Empleador], " +
                                                "[Busqueda], " +
                                                "[Num_denuncias], " +
                                                "[Estado], " +
                                                "[Ultima_Actualizacion]) " +
                                            "VALUES " +
                                                "('{0}', " +
                                                "{1}, " +
                                                "'{2}', " +
                                                "{3}, " +
                                                "'{4}', " +
                                                "{5}, " +
                                                "'{6}', " +
                                                "{7}, " +
                                                "{8}, " +
                                                "'{9}', " +
                                                "{10}, " +
                                                "{11}, " +
                                                "'{12}', " +
                                                "'{13}', " +
                                                "'{14}', " +
                                                "'{15}', " +
                                                "'{16}', " +
                                                "'{17}', " +
                                                "'{18}', " +
                                                "'{19}', " +
                                                "GETDATE())",
                                             item.Titulo, 
                                             item.TipoID, 
                                             item.Descripcion, 
                                             item.Num_vacantes, 
                                             item.Cargo,
                                             item.SalarioID,
                                             item.Sector, 
                                             item.ExperienciaID,
                                             item.Nivel_estudiosID,
                                             item.Profesion,
                                             item.Municipio,
                                             item.Departamento, 
                                             item.Fecha_publicacion.ToString("yyyy-MM-dd HH:mm:ss"),
                                             item.Fecha_vencimiento.ToString("yyyy-MM-dd HH:mm:ss"),
                                             item.Latitud, 
                                             item.Longitud, 
                                             item.Empleador,
                                             item.Busqueda,
                                             item.Num_denuncias,
                                             item.Estado);
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                            return "Vacante creada correctamente";
                        else
                            return "Ocurrió un error al crear la vacante";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al crear la vacante";
                //return e.Message;
            }
        }

        //public string RemoveJob(string vacanteID, string empleador)
        //{
        //    try {
        //        string query = string.Format("DELETE FROM [dbo].[Vacante] WHERE [dbo].[Vacante].[ID] = {0} AND [dbo].[Vacante].[Empleador] = '{1}'", vacanteID, empleador);
        //        using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(query, con))
        //            {
        //                con.Open();
        //                int n = cmd.ExecuteNonQuery();
        //                con.Close();
        //                if(n > 0)
        //                    return "Vacante eliminada correctamente";
        //                else
        //                    return "La vacante no pertenece al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "Ocurrió un error al eliminar la vacante";
        //        //return e.Message;
        //    }
        //}

        public string InactivateJob(string vacanteID, string empleador)
        {
            try
            {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Estado] = 'I', " +
                                            "[dbo].[Vacante].[Ultima_Actualizacion] = GETDATE() " +
                                            "WHERE [dbo].[Vacante].[ID] = {0} " +
                                            "AND [dbo].[Vacante].[Empleador] = '{1}' ",
                                            vacanteID,
                                            empleador);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                            return "Vacante inactivada correctamente";
                        else
                            return "La vacante no pertenece al usuario";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al inactivar la vacante";
                //return e.Message;
            }
        }

        public string RemoveJob(string vacanteID, string empleador)
        {
            try
            {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Estado] = 'R', " +
                                            "[dbo].[Vacante].[Ultima_Actualizacion] = GETDATE() " +
                                            "WHERE [dbo].[Vacante].[ID] = {0} " +
                                            "AND [dbo].[Vacante].[Empleador] = '{1}' ",
                                            vacanteID,
                                            empleador);
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                            return "Vacante eliminada correctamente";
                        else
                            return "La vacante no pertenece al usuario";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al eliminar la vacante";
                //return e.Message;
            }
        }

        public string UpdateJob(Vacante item)
        {
            try
            {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Titulo] = '{0}', " +
                                                "[dbo].[Vacante].[Tipo] = {1}, " +
                                                "[dbo].[Vacante].[Descripcion] = '{2}', " +
                                                "[dbo].[Vacante].[Num_vacantes] = {3}, " +
                                                "[dbo].[Vacante].[Cargo] = '{4}', " +
                                                "[dbo].[Vacante].[Salario] = {5}, " +
                                                "[dbo].[Vacante].[Sector] = '{6}', " +
                                                "[dbo].[Vacante].[Experiencia] = {7}, " +
                                                "[dbo].[Vacante].[Nivel_estudios] = {8}, " +
                                                "[dbo].[Vacante].[Profesion] = '{9}', " +
                                                "[dbo].[Vacante].[Municipio] = {10}, " +
                                                "[dbo].[Vacante].[Departamento] = {11}, " +
                                                "[dbo].[Vacante].[Fecha_publicacion] = '{12}', " +
                                                "[dbo].[Vacante].[Fecha_vencimiento] = '{13}', " +
                                                "[dbo].[Vacante].[Latitud] = '{14}', " +
                                                "[dbo].[Vacante].[Longitud] = '{15}', " +
                                                "[dbo].[Vacante].[Empleador] = '{16}', " +
                                                "[dbo].[Vacante].[Ultima_Actualizacion] = GETDATE() " +
                                            "WHERE [dbo].[Vacante].[ID] = {17}",
                                            item.Titulo,
                                            item.TipoID,
                                            item.Descripcion,
                                            item.Num_vacantes,
                                            item.Cargo,
                                            item.SalarioID,
                                            item.Sector,
                                            item.ExperienciaID,
                                            item.Nivel_estudiosID,
                                            item.Profesion,
                                            item.Municipio,
                                            item.Departamento,
                                            item.Fecha_publicacion.ToString("yyyy-MM-dd HH:mm:ss"),
                                            item.Fecha_vencimiento.ToString("yyyy-MM-dd HH:mm:ss"),
                                            item.Latitud,
                                            item.Longitud,
                                            item.Empleador,
                                            item.ID);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                            return "Vacante modificada correctamente";
                        else
                            return "La vacante no existe";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al modificar la vacante";
                //return e.Message;
            }
        }

        public IEnumerable<FAQ> GetAllFAQs()
        {
            List<FAQ> FAQs = new List<FAQ>();
            try {
                string query = string.Format("SELECT [dbo].[Preguntas_frecuentes].[ID], " +
                                                    "[dbo].[Preguntas_frecuentes].[Pregunta], " +
                                                    "[dbo].[Preguntas_frecuentes].[Respuesta]" +
                                            "FROM    [dbo].[Preguntas_frecuentes]");

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            FAQ faq = new FAQ();
                            faq.ID = reader.GetInt32(0);
                            faq.Pregunta = reader.GetString(1);
                            faq.Respuesta = reader.GetString(2);

                            FAQs.Add(faq);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return FAQs.ToArray();
        }

        public string AddComplaint(Denuncia item)
        {
            try {
                string query = string.Format("INSERT INTO [dbo].[Denuncias] " +
                                                "([Fecha], " +
                                                "[Tipo], " +
                                                "[ID_vacante]) " +
                                            "VALUES " +
                                                "(GETDATE(), " +
                                                "'{0}', " +
                                                "'{1}')",
                                             item.Tipo,
                                             item.vacanteID);
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                        {
                            string query2 = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Num_denuncias] = [dbo].[Vacante].[Num_denuncias] + 1 " +
                                            "WHERE [dbo].[Vacante].[ID] = {0} ",
                                            item.vacanteID);
                            using (SqlConnection con2 = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                            {
                                using (SqlCommand cmd2 = new SqlCommand(query2, con2))
                                {
                                    con2.Open();
                                    cmd2.ExecuteNonQuery();
                                    con2.Close();
                                }
                            }

                            RemoveJobComplaints(item.vacanteID.ToString());

                            return "Denuncia creada correctamente";
                        }
                        else
                            return "Ocurrió un error al crear la denuncia";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al crear la denuncia";
                //return e.Message;
            }
        }

        public string RemoveJobComplaints(string vacanteID)
        {
            try
            {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Estado] = 'R', " +
                                            "[dbo].[Vacante].[Ultima_Actualizacion] = GETDATE() " +
                                            "WHERE [dbo].[Vacante].[ID] = {0} " +
                                            "AND [dbo].[Vacante].[Num_denuncias] > 2 ",
                                            vacanteID);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                            return "Vacante eliminada correctamente";
                        else
                            return "La vacante no pertenece al usuario";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al eliminar la vacante";
                //return e.Message;
            }
        }

        public IEnumerable<Denuncia> GetAllComplaintsByJob(Int64 IdJob)
        {
            List<Denuncia> denuncias = new List<Denuncia>();
            try {
                string query = string.Format("SELECT [dbo].[Denuncias].[ID], " +
                                                    "[dbo].[Denuncias].[Fecha], " +
                                                    "[dbo].[Denuncias].[Tipo], " +
                                                    "[dbo].[Denuncias].[ID_vacante] " +
                                            "FROM    [dbo].[Denuncias] " +
                                            "WHERE   [dbo].[Denuncias].[ID_vacante] = " + IdJob);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Denuncia denuncia = new Denuncia();
                            denuncia.ID = reader.GetInt64(0);
                            denuncia.Fecha = reader.GetDateTime(1);
                            denuncia.Tipo = reader.GetString(2);
                            denuncia.vacanteID = reader.GetInt64(3);

                            denuncias.Add(denuncia);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return denuncias.ToArray();
        }
    }
}