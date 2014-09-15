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
                        Vacante customer = new Vacante();
                        customer.ID = reader.GetInt64(0);
                        customer.Titulo = reader.GetString(1);
                        customer.Descripcion = reader.GetString(2);
                        customer.Experiencia = reader.GetString(3);
                        customer.Num_vacantes = reader.GetInt32(4);
                        customer.Cargo = reader.GetString(5);
                        customer.Fecha_publicacion = reader.GetDateTime(6);
                        customer.Fecha_vencimiento = reader.GetDateTime(7);
                        customer.Nivel_estudios = reader.GetString(8);
                        customer.Profesion = reader.GetString(9);
                        customer.Salario = reader.GetString(10);
                        customer.Municipio = reader.GetString(11);
                        customer.Departamento = reader.GetString(12);
                        customer.Sector = reader.GetString(13);
                        customer.Latitud = reader.GetString(14);
                        customer.Longitud = reader.GetString(15);
                        customer.Empleador = reader.GetString(16);

                        vacantes.Add(customer);
                    }
                    con.Close(); 
                }
            }
            return vacantes.ToArray();
        }

        public IEnumerable<Vacante> GetAllVacants(string palabra, string ciudadDepartamento)
        {
            List<Vacante> vacantes = new List<Vacante>();
            string query = string.Format("EXEC [stp_Vacantes_FullTextSearch] '" + palabra + "', '" + ciudadDepartamento + "' WITH RECOMPILE");
            using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Vacante customer = new Vacante();
                        customer.ID = reader.GetInt64(0);
                        customer.Titulo = reader.GetString(1);
                        customer.Descripcion = reader.GetString(2);
                        customer.Experiencia = reader.GetString(3);
                        customer.Num_vacantes = reader.GetInt32(4);
                        customer.Cargo = reader.GetString(5);
                        customer.Fecha_publicacion = reader.GetDateTime(6);
                        customer.Fecha_vencimiento = reader.GetDateTime(7);
                        customer.Nivel_estudios = reader.GetString(8);
                        customer.Profesion = reader.GetString(9);
                        customer.Salario = reader.GetString(10);
                        customer.Municipio = reader.GetString(11);
                        customer.Departamento = reader.GetString(12);
                        customer.Sector = reader.GetString(13);
                        customer.Latitud = reader.GetString(14);
                        customer.Longitud = reader.GetString(15);
                        customer.Empleador = reader.GetString(16);

                        vacantes.Add(customer);
                    }
                    con.Close();
                }
            }
            return vacantes.ToArray();
        }

        public IEnumerable<Vacante> GetAllByEmployer(string employerUserName)
        {
            List<Vacante> vacantes = new List<Vacante>();
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
                        Vacante customer = new Vacante();
                        customer.ID = reader.GetInt64(0);
                        customer.Titulo = reader.GetString(1);
                        customer.Descripcion = reader.GetString(2);
                        customer.Experiencia = reader.GetString(3);
                        customer.Num_vacantes = reader.GetInt32(4);
                        customer.Cargo = reader.GetString(5);
                        customer.Fecha_publicacion = reader.GetDateTime(6);
                        customer.Fecha_vencimiento = reader.GetDateTime(7);
                        customer.Nivel_estudios = reader.GetString(8);
                        customer.Profesion = reader.GetString(9);
                        customer.Salario = reader.GetString(10);
                        customer.Municipio = reader.GetString(11);
                        customer.Departamento = reader.GetString(12);
                        customer.Sector = reader.GetString(13);
                        customer.Latitud = reader.GetString(14);
                        customer.Longitud = reader.GetString(15);
                        customer.Empleador = reader.GetString(16);

                        vacantes.Add(customer);
                    }
                    con.Close();
                }
            }
            return vacantes.ToArray();
        }

        public Vacante Get(string vacanteID)
        {
            Vacante customer = new Vacante();
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
                        customer.ID = reader.GetInt64(0);
                        customer.Titulo = reader.GetString(1);
                        customer.Descripcion = reader.GetString(2);
                        customer.Experiencia = reader.GetString(3);
                        customer.Num_vacantes = reader.GetInt32(4);
                        customer.Cargo = reader.GetString(5);
                        customer.Fecha_publicacion = reader.GetDateTime(6);
                        customer.Fecha_vencimiento = reader.GetDateTime(7);
                        customer.Nivel_estudios = reader.GetString(8);
                        customer.Profesion = reader.GetString(9);
                        customer.Salario = reader.GetString(10);
                        customer.Municipio = reader.GetString(11);
                        customer.Departamento = reader.GetString(12);
                        customer.Sector = reader.GetString(13);
                        customer.Latitud = reader.GetString(14);
                        customer.Longitud = reader.GetString(15);
                        customer.Empleador = reader.GetString(16);                
                    }
                    con.Close(); 
                }
            }
            return customer;
        }

        public Vacante Add(Vacante item)
        {
            item.Busqueda = item.Titulo + " " + item.Descripcion + " " + item.Cargo + " " + item.Profesion;
            item.Num_denuncias = 0;
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
                                            "[Num_denuncias]) " +
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
                                            "'{17}')",
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
                                         item.Num_denuncias);
            using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return item;
        }

        public bool Remove(string vacanteID)
        {
            string query = string.Format("DELETE FROM [dbo].[Vacante] WHERE [dbo].[Vacante].[ID] = {0}", vacanteID); 

            using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return true;
        }

        public bool Update(Vacante item)
        {
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
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return true;
        }

        public IEnumerable<FAQ> GetFAQs()
        {
            List<FAQ> FAQs = new List<FAQ>();
            string query = string.Format("SELECT [dbo].[Preguntas_frecuentes].[ID], " +
                                                "[dbo].[Preguntas_frecuentes].[Titulo], " +
                                                "[dbo].[Preguntas_frecuentes].[Descripcion]" +
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
            return FAQs.ToArray();
        }
    }
}