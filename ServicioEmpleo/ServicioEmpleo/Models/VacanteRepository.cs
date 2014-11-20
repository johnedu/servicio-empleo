using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                            vacante.Telefono = reader.GetString(20);
                            vacante.Indicativo = reader.GetString(21);
                            vacante.Celular = reader.GetString(22);
                            vacante.Direccion = reader.GetString(23);
                            vacante.Email = reader.GetString(24);
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
                                                    "[dbo].[Vacante].[Ultima_Actualizacion]," +
                                                    "CASE WHEN GETDATE() BETWEEN [dbo].[Vacante].[Fecha_publicacion] AND [dbo].[Vacante].[Fecha_vencimiento] " +
                                                        "THEN [dbo].[Vacante].[Estado] " +
                                                        "ELSE 'I' END AS Estado, " +
                                                    "ISNULL([dbo].[Vacante].[Telefono],'') AS Telefono, " +
                                                    "ISNULL([dbo].[Vacante].[Indicativo],'') AS Indicativo, " +
                                                    "ISNULL([dbo].[Vacante].[Celular],'') AS Celular, " +
                                                    "ISNULL([dbo].[Vacante].[Direccion],'') AS Direccion, " +
                                                    "ISNULL([dbo].[Vacante].[Email],'') AS Email, " +
                                                    "DATEDIFF(DAY, GETDATE(), [dbo].[Vacante].[Fecha_vencimiento]) AS DiasVence, " +
                                                    "CASE " +
                                                    "    WHEN [dbo].[Vacante].[Tipo] = 1 " +
                                                    "        THEN 'Empleo' " +
                                                    "    WHEN [dbo].[Vacante].[Tipo] = 2 " +
                                                    "        THEN 'Pasantía' " +
                                                    "    WHEN [dbo].[Vacante].[Tipo] = 3 " +
                                                    "        THEN 'Práctica laboral' " +
                                                    "    WHEN [dbo].[Vacante].[Tipo] = 4 " +
                                                    "        THEN 'Contrato de aprendizaje' " +
                                                    "END AS Tipo, " +
                                                    "CASE " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 0 " +
                                                    "        THEN 'Menos de 1 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 1 " +
                                                    "        THEN '1 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 2 " +
                                                    "        THEN 'Más de 1 SMMLV hasta 2 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 3 " +
                                                    "        THEN 'Más de 2 SMMLV hasta 3 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 4 " +
                                                    "        THEN 'Más de 3 SMMLV hasta 5 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 5 " +
                                                    "        THEN '[5] Más de 5 SMMLV hasta 7 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 6 " +
                                                    "        THEN 'Más de 7 SMMLV' " +
                                                    "    WHEN [dbo].[Vacante].[Salario] = 7 " +
                                                    "        THEN 'A convenir' " +
                                                    "END AS Salario, " +
                                                    "CASE " +
                                                    "    WHEN [dbo].[Vacante].[Experiencia] = 0 " +
                                                    "        THEN 'Ninguna' " +
                                                    "    WHEN [dbo].[Vacante].[Experiencia] = 1 " +
                                                    "        THEN 'De 0 a  6 meses' " +
                                                    "    WHEN [dbo].[Vacante].[Experiencia] = 2 " +
                                                    "        THEN 'De 7 a 12 meses' " +
                                                    "    WHEN [dbo].[Vacante].[Experiencia] = 3 " +
                                                    "        THEN 'De 13 a 24 meses' " +
                                                    "    WHEN [dbo].[Vacante].[Experiencia] = 4 " +
                                                    "        THEN 'Más de 24 meses' " +
                                                    "END AS Experiencia, " +
                                                    "CASE " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 1 " +
                                                    "        THEN 'NINGUNO' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 2 " +
                                                    "        THEN 'PREESCOLAR' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 3 " +
                                                    "        THEN 'BÁSICA PRIMARIA (1 - 5)' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 4 " +
                                                    "        THEN 'BÁSICA SECUNDARIA (6 - 9)' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 5 " +
                                                    "        THEN 'MEDIA (10 - 13)' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 6 " +
                                                    "        THEN 'POSTGRADO' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 7 " +
                                                    "        THEN 'TÉCNICA LABORAL' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 8 " +
                                                    "        THEN 'TÉCNICA PROFESIONAL' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 9 " +
                                                    "        THEN 'TECNOLÓGICA' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 10 " +
                                                    "        THEN 'UNIVERSITARIA' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 11 " +
                                                    "        THEN 'ESPECIALIZACIÓN' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 12 " +
                                                    "        THEN 'MAESTRÍA' " +
                                                    "    WHEN [dbo].[Vacante].[Nivel_estudios] = 13 " +
                                                    "        THEN 'DOCTORADO' " +
                                                    "END AS Nivel_estudios, " +
                                                    "[dbo].[Municipio].[Nombre] AS Munipicio, " +
                                                    "[dbo].[Departamento].[Nombre] AS Departamento " +
                                            "FROM    [dbo].[Vacante] INNER JOIN [dbo].[Municipio] ON " +
                                            "        [dbo].[Vacante].[Municipio] = [dbo].[Municipio].[Id] " +
                                            "        INNER JOIN [dbo].[Departamento] ON " +
                                            "        [dbo].[Vacante].[Departamento] = [dbo].[Departamento].[Id] " +
                                            "WHERE   [dbo].[Vacante].[Empleador] = '" + employerUserName + "'" +
                                            "AND     ([dbo].[Vacante].[Estado] = 'A' OR [dbo].[Vacante].[Estado] = 'I') " +
                                            "ORDER BY	Estado ASC, " +
                                            "           [dbo].[Vacante].[Fecha_vencimiento] ASC");

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
                            vacante.Estado = reader.GetString(19);
                            vacante.Telefono = reader.GetString(20);
                            vacante.Indicativo = reader.GetString(21);
                            vacante.Celular = reader.GetString(22);
                            vacante.Direccion = reader.GetString(23);
                            vacante.Email = reader.GetString(24);
                            vacante.DiasVence = reader.GetInt32(25);
                            vacante.Tipo = reader.GetString(26);
                            vacante.Salario = reader.GetString(27);
                            vacante.Experiencia = reader.GetString(28);
                            vacante.Nivel_estudios = reader.GetString(29);
                            vacante.MunicipioNombre = reader.GetString(30);
                            vacante.DepartamentoNombre = reader.GetString(31);
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
                                                    "[dbo].[Vacante].[Tipo] AS TipoId, " +
                                                    "[dbo].[Vacante].[Descripcion], " +
                                                    "[dbo].[Vacante].[Num_vacantes], " +
                                                    "[dbo].[Vacante].[Cargo], " +
                                                    "[dbo].[Vacante].[Salario] AS SalarioId, " +
                                                    "[dbo].[Vacante].[Sector], " +
                                                    "[dbo].[Vacante].[Experiencia] AS ExperienciaId, " +
                                                    "[dbo].[Vacante].[Nivel_estudios] AS NivelId, " +
                                                    "[dbo].[Vacante].[Profesion], " +
                                                    "[dbo].[Vacante].[Municipio] AS MunicipioId, " +
                                                    "[dbo].[Vacante].[Departamento] AS DepartamentoId, " +
                                                    "[dbo].[Vacante].[Fecha_publicacion], " +
                                                    "[dbo].[Vacante].[Fecha_vencimiento], " +
                                                    "[dbo].[Vacante].[Latitud], " +
                                                    "[dbo].[Vacante].[Longitud], " +
                                                    "[dbo].[Vacante].[Empleador], " +
                                                    "[dbo].[Vacante].[Ultima_Actualizacion], " +
                                                    "CASE WHEN GETDATE() BETWEEN [dbo].[Vacante].[Fecha_publicacion] AND [dbo].[Vacante].[Fecha_vencimiento] " +
                                                        "THEN [dbo].[Vacante].[Estado] " +
                                                        "ELSE 'I' " +
                                                    "END AS Estado, " +
                                                    "ISNULL([dbo].[Vacante].[Telefono],'') AS Telefono, " +
                                                    "ISNULL([dbo].[Vacante].[Indicativo],'') AS Indicativo, " +
                                                    "ISNULL([dbo].[Vacante].[Celular],'') AS Celular, " +
                                                    "ISNULL([dbo].[Vacante].[Direccion],'') AS Direccion, " +
                                                    "ISNULL([dbo].[Vacante].[Email],'') AS Email, " +
                                                    "DATEDIFF(DAY, GETDATE(), [dbo].[Vacante].[Fecha_vencimiento]) AS DiasVence, " +
                                                    "CASE " +
						                            "    WHEN [dbo].[Vacante].[Tipo] = 1 " +
							                        "        THEN 'Empleo' " +
						                            "    WHEN [dbo].[Vacante].[Tipo] = 2 " +
							                        "        THEN 'Pasantía' " +
						                            "    WHEN [dbo].[Vacante].[Tipo] = 3 " +
							                        "        THEN 'Práctica laboral' " +
						                            "    WHEN [dbo].[Vacante].[Tipo] = 4 " +
							                        "        THEN 'Contrato de aprendizaje' " +
                                                    "END AS Tipo, " +
                                                    "CASE " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 0 " +
							                        "        THEN 'Menos de 1 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 1 " +
							                        "        THEN '1 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 2 " +
							                        "        THEN 'Más de 1 SMMLV hasta 2 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 3 " +
							                        "        THEN 'Más de 2 SMMLV hasta 3 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 4 " +
							                        "        THEN 'Más de 3 SMMLV hasta 5 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 5 " +
							                        "        THEN '[5] Más de 5 SMMLV hasta 7 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 6 " +
							                        "        THEN 'Más de 7 SMMLV' " +
						                            "    WHEN [dbo].[Vacante].[Salario] = 7 " +
							                        "        THEN 'A convenir' " +
                                                    "END AS Salario, " +
                                                    "CASE " +
						                            "    WHEN [dbo].[Vacante].[Experiencia] = 0 " +
							                        "        THEN 'Ninguna' " +
						                            "    WHEN [dbo].[Vacante].[Experiencia] = 1 " +
							                        "        THEN 'De 0 a  6 meses' " +
						                            "    WHEN [dbo].[Vacante].[Experiencia] = 2 " +
							                        "        THEN 'De 7 a 12 meses' " +
						                            "    WHEN [dbo].[Vacante].[Experiencia] = 3 " +
							                        "        THEN 'De 13 a 24 meses' " +
						                            "    WHEN [dbo].[Vacante].[Experiencia] = 4 " +
							                        "        THEN 'Más de 24 meses' " +
                                                    "END AS Experiencia, " +
                                                    "CASE " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 1 " +
							                        "        THEN 'NINGUNO' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 2 " +
							                        "        THEN 'PREESCOLAR' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 3 " +
							                        "        THEN 'BÁSICA PRIMARIA (1 - 5)' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 4 " +
							                        "        THEN 'BÁSICA SECUNDARIA (6 - 9)' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 5 " +
							                        "        THEN 'MEDIA (10 - 13)' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 6 " +
							                        "        THEN 'POSTGRADO' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 7 " +
							                        "        THEN 'TÉCNICA LABORAL' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 8 " +
							                        "        THEN 'TÉCNICA PROFESIONAL' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 9 " +
							                        "        THEN 'TECNOLÓGICA' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 10 " +
							                        "        THEN 'UNIVERSITARIA' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 11 " +
							                        "        THEN 'ESPECIALIZACIÓN' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 12 " +
							                        "        THEN 'MAESTRÍA' " +
						                            "    WHEN [dbo].[Vacante].[Nivel_estudios] = 13 " +
							                        "        THEN 'DOCTORADO' " +
                                                    "END AS Nivel_estudios, " +
                                                    "[dbo].[Municipio].[Nombre] AS Munipicio, " +
                                                    "[dbo].[Departamento].[Nombre] AS Departamento " +
                                            "FROM    [dbo].[Vacante] INNER JOIN [dbo].[Municipio] ON " +
                                            "        [dbo].[Vacante].[Municipio] = [dbo].[Municipio].[Id] " +
                                            "        INNER JOIN [dbo].[Departamento] ON " +
                                            "        [dbo].[Vacante].[Departamento] = [dbo].[Departamento].[Id] " +
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
                            vacante.Estado = reader.GetString(19);
                            vacante.Telefono = reader.GetString(20);
                            vacante.Indicativo = reader.GetString(21);
                            vacante.Celular = reader.GetString(22);
                            vacante.Direccion = reader.GetString(23);
                            vacante.Email = reader.GetString(24);
                            vacante.DiasVence = reader.GetInt32(25);
                            vacante.Tipo = reader.GetString(26);
                            vacante.Salario = reader.GetString(27);
                            vacante.Experiencia = reader.GetString(28);
                            vacante.Nivel_estudios = reader.GetString(29);
                            vacante.MunicipioNombre = reader.GetString(30);
                            vacante.DepartamentoNombre = reader.GetString(31);
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
                                                "[Ultima_Actualizacion], " +
                                                "[Telefono], " +
                                                "[Indicativo], " +
                                                "[Celular], " +
                                                "[Direccion], " +
                                                "[Email]) " +
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
                                                "GETDATE()," +
                                                "'{20}', " +
                                                "'{21}', " +
                                                "'{22}', " +
                                                "'{23}', " +
                                                "'{24}')",
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
                                             //item.Fecha_publicacion.ToString("yyyy-MM-dd HH:mm:ss"),
                                             "GETDATE()",
                                             item.Fecha_vencimiento.ToString("yyyy-MM-dd HH:mm:ss"),
                                             item.Latitud, 
                                             item.Longitud, 
                                             item.Empleador,
                                             item.Busqueda,
                                             item.Num_denuncias,
                                             item.Estado,
                                             item.Telefono,
                                             item.Indicativo,
                                             item.Celular,
                                             item.Direccion,
                                             item.Email);
                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        if (n > 0)
                        {
                            string titulo = "Se ha publicado exitosamente la vacante '" + item.Titulo + "' a través del Servicio de Empleo Móvil";
                            string mensaje_enviar = "Señor/a " + item.Empleador + "<br/><br/>" +
                                  "Acaba de publicar una vacante en el Servicio de Empleo Móvil.<br/><br/>" +
                                  "RESUMEN DE LA VACANTE:<br/><br/>" +
                                  "Título de la vacante: " + item.Titulo + "<br/>" +
                                  "Tipo de oportunidad”: " + item.Tipo + "<br/>" +
                                  "Descripción de la vacante: " + item.Descripcion + "<br/>" +
                                  "Cargo: " + item.Cargo + "<br/>" +
                                  "Salario ofrecido: " + item.Salario + "<br/>" +
                                  "Experiencia mínima requerida: " + item.Experiencia + "<br/>" +
                                  "Nivel de estudio mínimo requerido”: " + item.Nivel_estudios + "<br/>" +
                                  "Profesión: " + item.Profesion + "<br/>" +
                                  "Ubicación: " + item.Departamento + "/" + item.Municipio + "<br/>" +
                                  "Dirección de referencia: " + item.Direccion + "<br/>" +
                                  "Correo Electrónico de Contacto: " + item.Email + "<br/>" +
                                  "Teléfono de Contacto: " + item.Telefono + "<br/><br/>" +
                                  "Servicio de Empleo Móvil - Este es un correo electrónico automático, por favor no lo responda";
                            item.Email = "johnedu06@gmail.com";
                            SendMail("servicioempleomovil@gmail.com", "asdf1234QWER", item.Email, titulo, mensaje_enviar, "", "Servicio de Empleo Móvil", "0");
                            return "Vacante creada correctamente";
                        }
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

        public string ChangeStateJob(string vacanteID, string empleador, string estado)
        {
            try
            {
                string query = string.Format("UPDATE [dbo].[Vacante] " +
                                            "SET [dbo].[Vacante].[Estado] = '" + estado + "', " +
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
                            if (estado.Equals("I"))
                                return "Vacante inactivada correctamente";
                            else
                                return "Vacante activada correctamente";
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
                                                "[dbo].[Vacante].[Ultima_Actualizacion] = GETDATE(), " +
                                                "[dbo].[Vacante].[Telefono] = '{17}', " +
                                                "[dbo].[Vacante].[Indicativo] = '{18}', " +
                                                "[dbo].[Vacante].[Celular] = '{19}', " +
                                                "[dbo].[Vacante].[Direccion] = '{20}', " +
                                                "[dbo].[Vacante].[Email] = '{21}'" +
                                            "WHERE [dbo].[Vacante].[ID] = {22}",
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
                                            //item.Fecha_publicacion.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "GETDATE()",
                                            item.Fecha_vencimiento.ToString("yyyy-MM-dd HH:mm:ss"),
                                            item.Latitud,
                                            item.Longitud,
                                            item.Empleador,
                                            item.Telefono,
                                            item.Indicativo,
                                            item.Celular,
                                            item.Direccion,
                                            item.Email,
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

                            RemoveJobComplaints(item.vacanteID, item.Email, item.tituloEmail, item.textoEmail);

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

        public string RemoveJobComplaints(Int64 vacanteID, string email, string tituloEmail, string textoEmail)
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
                        if (n > 0) {
                            email = "sdanglejan@gmail.com";
                            SendMail("servicioempleomovil@gmail.com", "asdf1234QWER", email, tituloEmail, textoEmail, "", "Servicio de Empleo Móvil", "0");
                            return "Vacante eliminada correctamente";
                        }   
                        else
                            return "Vacante aún activa";
                    }
                }
            }
            catch (Exception e)
            {
                return "Ocurrió un error al eliminar la vacante";
                //return e.Message;
            }
        }

        public IEnumerable<Denuncia> GetAllComplaintsByJob(Int64 idJob)
        {
            List<Denuncia> denuncias = new List<Denuncia>();
            try {
                string query = string.Format("SELECT [dbo].[Denuncias].[ID], " +
                                                    "[dbo].[Denuncias].[Fecha], " +
                                                    "[dbo].[Denuncias].[Tipo], " +
                                                    "[dbo].[Denuncias].[ID_vacante] " +
                                            "FROM    [dbo].[Denuncias] " +
                                            "WHERE   [dbo].[Denuncias].[ID_vacante] = " + idJob);

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
                            denuncia.vacanteID = idJob;
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

        public IEnumerable<Departamento> GetAllDepartments()
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                string query = string.Format("SELECT [dbo].[Departamento].[Id], " +
                                                    "[dbo].[Departamento].[Nombre] " +
                                            "FROM    [dbo].[Departamento]");

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Departamento departamento = new Departamento();
                            departamento.ID = reader.GetInt32(0);
                            departamento.Nombre = reader.GetString(1);
                            departamentos.Add(departamento);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return departamentos.ToArray();
        }

        public IEnumerable<Municipio> GetAllMunicipalities(int department)
        {
            List<Municipio> municipios = new List<Municipio>();
            try
            {
                string query = string.Format("SELECT [dbo].[Municipio].[Id], " +
                                                    "[dbo].[Municipio].[Nombre] " +
                                            "FROM    [dbo].[Municipio] " +
                                            "WHERE   [dbo].[Municipio].[Departamento] = " + department);

                using (SqlConnection con = new SqlConnection("Server=966aafe3-077b-4d00-b57c-a3a00010872a.sqlserver.sequelizer.com;Database=db966aafe3077b4d00b57ca3a00010872a;User ID=ciatmhpgrdfmfmes;Password=eBpvohJoCGFdGGmuXt8Gjf8ngtPRUfJa7R5M67Z7SUq6SEQh62N2DLG7Bbo4AZBw;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Municipio municipio = new Municipio();
                            municipio.ID = reader.GetInt32(0);
                            municipio.Nombre = reader.GetString(1);
                            municipios.Add(municipio);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Write(e.Message);
            }
            return municipios.ToArray();
        }

        public IEnumerable<Vacante> UpdateFavorites(string listaFavoritas)
        {
            List<Vacante> vacantes = new List<Vacante>();
            try
            {
                string query = string.Format("EXEC [stp_Vacantes_BuscarFavoritas] '" + listaFavoritas + "' WITH RECOMPILE");
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
                            vacante.MunicipioNombre = reader.GetString(11);
                            vacante.DepartamentoNombre = reader.GetString(12);
                            vacante.Fecha_publicacion = reader.GetDateTime(13);
                            vacante.Fecha_vencimiento = reader.GetDateTime(14);
                            vacante.Latitud = reader.GetString(15);
                            vacante.Longitud = reader.GetString(16);
                            vacante.Empleador = reader.GetString(17);
                            vacante.Ultima_Actualizacion = reader.GetDateTime(18);
                            vacante.DiasVence = reader.GetInt32(19);
                            vacante.Telefono = reader.GetString(20);
                            vacante.Indicativo = reader.GetString(21);
                            vacante.Celular = reader.GetString(22);
                            vacante.Direccion = reader.GetString(23);
                            vacante.Email = reader.GetString(24);
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

        public static bool SendMail(string gMailAccount, string password, string to, string subject, string message, string bcc, string DisplayName, string pAttachmentPath)
        {
            try
            {
                NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(gMailAccount, DisplayName);
                string[] tos = to.Split(',');
                for (int i = 0; i < tos.Length; i++)
                {
                    msg.To.Add(new MailAddress(tos[i]));
                }
                if (bcc != "")
                    msg.Bcc.Add(new MailAddress(bcc));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;

                if (pAttachmentPath.Trim() != "0")
                {
                    msg.Attachments.Add(new Attachment(pAttachmentPath));
                }

                msg.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);

                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }
    }
}