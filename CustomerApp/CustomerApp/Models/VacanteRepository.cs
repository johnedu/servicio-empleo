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
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador] " +
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
                            vacante.Descripcion = reader.GetString(2);
                            vacante.Experiencia = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Fecha_publicacion = reader.GetDateTime(6);
                            vacante.Fecha_vencimiento = reader.GetDateTime(7);
                            vacante.Nivel_estudios = reader.GetString(8);
                            vacante.Profesion = reader.GetString(9);
                            vacante.Salario = reader.GetString(10);
                            vacante.Municipio = reader.GetString(11);
                            vacante.Departamento = reader.GetString(12);
                            vacante.Sector = reader.GetString(13);
                            vacante.Latitud = reader.GetString(14);
                            vacante.Longitud = reader.GetString(15);
                            vacante.Empleador = reader.GetString(16);

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

        public IEnumerable<Vacante> GetAllJobs(string palabra, string ciudad, string departamento)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("EXEC [stp_Vacantes_FullTextSearch] '" + palabra + "', '" + ciudad + "', '" + departamento + "', 'N' WITH RECOMPILE");
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
                            vacante.Descripcion = reader.GetString(2);
                            vacante.Experiencia = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Fecha_publicacion = reader.GetDateTime(6);
                            vacante.Fecha_vencimiento = reader.GetDateTime(7);
                            vacante.Nivel_estudios = reader.GetString(8);
                            vacante.Profesion = reader.GetString(9);
                            vacante.Salario = reader.GetString(10);
                            vacante.Municipio = reader.GetString(11);
                            vacante.Departamento = reader.GetString(12);
                            vacante.Sector = reader.GetString(13);
                            vacante.Latitud = reader.GetString(14);
                            vacante.Longitud = reader.GetString(15);
                            vacante.Empleador = reader.GetString(16);

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

        public IEnumerable<Vacante> GetAllJobsMap(string palabra, string ciudad, string departamento)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try {
                string query = string.Format("EXEC [stp_Vacantes_FullTextSearch] '" + palabra + "', '" + ciudad + "', '" + departamento + "', 'M' WITH RECOMPILE");
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
                            vacante.Descripcion = reader.GetString(2);
                            vacante.Experiencia = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Fecha_publicacion = reader.GetDateTime(6);
                            vacante.Fecha_vencimiento = reader.GetDateTime(7);
                            vacante.Nivel_estudios = reader.GetString(8);
                            vacante.Profesion = reader.GetString(9);
                            vacante.Salario = reader.GetString(10);
                            vacante.Municipio = reader.GetString(11);
                            vacante.Departamento = reader.GetString(12);
                            vacante.Sector = reader.GetString(13);
                            vacante.Latitud = reader.GetString(14);
                            vacante.Longitud = reader.GetString(15);
                            vacante.Empleador = reader.GetString(16);

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
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador], " +
                                                    "[dbo].[Vacante].[Estado] " +
                                            "FROM    [dbo].[Vacante] " +
                                            "WHERE   [dbo].[Vacante].[Empleador] = '" + employerUserName + "'");

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
                            vacante.Descripcion = reader.GetString(2);
                            vacante.Experiencia = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Fecha_publicacion = reader.GetDateTime(6);
                            vacante.Fecha_vencimiento = reader.GetDateTime(7);
                            vacante.Nivel_estudios = reader.GetString(8);
                            vacante.Profesion = reader.GetString(9);
                            vacante.Salario = reader.GetString(10);
                            vacante.Municipio = reader.GetString(11);
                            vacante.Departamento = reader.GetString(12);
                            vacante.Sector = reader.GetString(13);
                            vacante.Latitud = reader.GetString(14);
                            vacante.Longitud = reader.GetString(15);
                            vacante.Empleador = reader.GetString(16);
                            vacante.Estado = reader.GetString(17);

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
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Experiencia], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Nivel_estudios], " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Salario], " +
                                                    "[dbo].[Vacante].[Municipio], " +
                                                    "[dbo].[Vacante].[Departamento], " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador] " +
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
                            vacante.Descripcion = reader.GetString(2);
                            vacante.Experiencia = reader.GetString(3);
                            vacante.Num_vacantes = reader.GetInt32(4);
                            vacante.Cargo = reader.GetString(5);
                            vacante.Fecha_publicacion = reader.GetDateTime(6);
                            vacante.Fecha_vencimiento = reader.GetDateTime(7);
                            vacante.Nivel_estudios = reader.GetString(8);
                            vacante.Profesion = reader.GetString(9);
                            vacante.Salario = reader.GetString(10);
                            vacante.Municipio = reader.GetString(11);
                            vacante.Departamento = reader.GetString(12);
                            vacante.Sector = reader.GetString(13);
                            vacante.Latitud = reader.GetString(14);
                            vacante.Longitud = reader.GetString(15);
                            vacante.Empleador = reader.GetString(16);                
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
            item.Num_denuncias = 0;
            item.Estado = "A";
            try {
                string query = string.Format("INSERT INTO [dbo].[Vacante] " +
                                                "([Titulo], " +
                                                "[Descripcion], " +
                                                "[Experiencia], " +
                                                "[Num_vacantes], " +
                                                "[Cargo], " +
                                                "[Fecha_publicacion], " +
                                                "[Fecha_vencimiento], " +
                                                "[Nivel_estudios], " +
                                                "[Profesion], " +
                                                "[Salario], " +
                                                "[Municipio], " +
                                                "[Departamento], " +
                                                "[Sector], " +
                                                "[Latitud], " +
                                                "[Longitud], " +
                                                "[Empleador], " +
                                                "[Busqueda], " +
                                                "[Num_denuncias], " +
                                                "[Estado]) " +
                                            "VALUES " +
                                                "('{0}', " +
                                                "'{1}', " +
                                                "'{2}', " +
                                                "{3}, " +
                                                "'{4}', " +
                                                "'{5}', " +
                                                "'{6}', " +
                                                "'{7}', " +
                                                "'{8}', " +
                                                "'{9}', " +
                                                "'{10}', " +
                                                "'{11}', " +
                                                "'{12}', " +
                                                "'{13}', " +
                                                "'{14}', " +
                                                "'{15}', " +
                                                "'{16}', " +
                                                "'{17}', " +
                                                "'{18}')",
                                             item.Titulo, 
                                             item.Descripcion, 
                                             item.Experiencia, 
                                             item.Num_vacantes, 
                                             item.Cargo,
                                             String.Format("{0:u}", item.Fecha_publicacion),
                                             String.Format("{0:u}", item.Fecha_vencimiento), 
                                             item.Nivel_estudios, 
                                             item.Profesion, 
                                             item.Salario, 
                                             item.Municipio.ToUpper(),
                                             item.Departamento.ToUpper(), 
                                             item.Sector, 
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

        public string RemoveJob(string vacanteID, string empleador)
        {
            try {
                string query = string.Format("DELETE FROM [dbo].[Vacante] WHERE [dbo].[Vacante].[ID] = {0} AND [dbo].[Vacante].[Empleador] = '{1}'", vacanteID, empleador);
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if(n > 0)
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
            try {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Titulo] = '{0}', " +
                                                "[dbo].[Vacante].[Descripcion] = '{1}', " +
                                                "[dbo].[Vacante].[Experiencia] = '{2}', " +
                                                "[dbo].[Vacante].[Num_vacantes] = {3}, " +
                                                "[dbo].[Vacante].[Cargo] = '{4}', " +
                                                "[dbo].[Vacante].[Fecha_publicacion] = '{5}', " +
                                                "[dbo].[Vacante].[Fecha_vencimiento] = '{6}', " +
                                                "[dbo].[Vacante].[Nivel_estudios] = '{7}', " +
                                                "[dbo].[Vacante].[Profesion] = '{8}', " +
                                                "[dbo].[Vacante].[Salario] = '{9}', " +
                                                "[dbo].[Vacante].[Municipio] = '{10}', " +
                                                "[dbo].[Vacante].[Departamento] = '{11}', " +
                                                "[dbo].[Vacante].[Sector] = '{12}', " +
                                                "[dbo].[Vacante].[Latitud] = '{13}', " +
                                                "[dbo].[Vacante].[Longitud] = '{14}', " +
                                                "[dbo].[Vacante].[Empleador] = '{15}' " +
                                            "WHERE [dbo].[Vacante].[ID] = {16}", 
                                            item.Titulo, 
                                            item.Descripcion, 
                                            item.Experiencia, 
                                            item.Num_vacantes, 
                                            item.Cargo,
                                            String.Format("{0:u}", item.Fecha_publicacion),
                                            String.Format("{0:u}", item.Fecha_vencimiento),
                                            item.Nivel_estudios,
                                            item.Profesion,
                                            item.Salario,
                                            item.Municipio.ToUpper(),
                                            item.Departamento.ToUpper(), 
                                            item.Sector, 
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
                            return "Denuncia creada correctamente";
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