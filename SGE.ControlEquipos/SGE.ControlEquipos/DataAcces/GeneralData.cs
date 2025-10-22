using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;
using System.Data;
using Microsoft.EntityFrameworkCore;
using static Guna.UI2.Native.WinApi;

namespace SGE.ControlEquipos.DataAcces
{
    public class GeneralData
    {

        internal List<ControlVersiones> Listar_Versiones() {

            List<ControlVersiones> lista = new();
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_ACTUALIZACIONES_LISTAR", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new ControlVersiones()
                            {
                                cvr_icod_version = Convert.ToInt32(reader["cvr_icod_version"]),
                                cvr_vversion = reader["cvr_vversion"].ToString()!,
                                cvr_sfecha_version = Convert.ToDateTime(reader["cvr_sfecha_version"]).AddHours(-5),
                                cvr_vurl = reader["cvr_vurl"].ToString()!,
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return lista;
        }

        internal void Equipo_Dar_Acceso(Entities.ControlEquipos obe)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_EQUIPO_DAR_ACCESO", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        cmd.Parameters.AddWithValue("@ceq_icod_equipo", obe.ceq_icod_equipo);
                        cmd.Parameters.AddWithValue("@cep_bflag_acceso", obe.cep_bflag_acceso);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        internal async void Equipo_Modificar(Entities.ControlEquipos objEquipo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlQueys.MODIFICAR_EQUIPOS(objEquipo), cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = int.MaxValue;
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal Entities.ControlEquipos Equipo_Obtner_Datos(string nombre, string idCpu)
        {
            Entities.ControlEquipos obj = new Entities.ControlEquipos();
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_EQUIPO_DATOS_OBTENER", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@cep_vid_cpu", idCpu);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            obj.ceq_icod_equipo = Convert.ToInt32(reader["ceq_icod_equipo"]);
                            obj.ceq_vnombre_equipo = reader["ceq_vnombre_equipo"].ToString()!;
                            obj.cvr_icod_version = Convert.ToInt32(reader["cvr_icod_version"]);
                            var data = reader["ceq_sfecha_actualizacion"];
                            obj.ceq_sfecha_actualizacion = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["ceq_sfecha_actualizacion"]);
                            obj.cvr_vversion = reader["cvr_vversion"].ToString()!;
                            data = reader["cvr_sfecha_version"];
                            obj.cvr_sfecha_version = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["cvr_sfecha_version"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
                            obj.cep_vid_cpu = reader["cep_vid_cpu"].ToString()!;
                            obj.cep_bflag_acceso = Convert.ToBoolean(reader["cep_bflag_acceso"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return obj;
        }

        internal List<Entities.ControlEquipos> Listar_Equipos()
        {
            List<Entities.ControlEquipos> lista = new List<Entities.ControlEquipos>();
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();

                    
                    using (SqlCommand cmd = new SqlCommand(SqlQueys.LISTAR_EQUIPOS, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = int.MaxValue;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Entities.ControlEquipos obj = new Entities.ControlEquipos();
                            obj.ceq_icod_equipo = Convert.ToInt32(reader["ceq_icod_equipo"]);
                            obj.ceq_vnombre_equipo = reader["ceq_vnombre_equipo"].ToString()!;
                            var data = reader["cvr_icod_version"];
                            obj.cvr_icod_version = string.IsNullOrEmpty(data.ToString()) ? 0 : Convert.ToInt32(data);
                            data = reader["ceq_sfecha_actualizacion"];
                            obj.ceq_sfecha_actualizacion = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["ceq_sfecha_actualizacion"]);
                            obj.cvr_vversion = reader["cvr_vversion"].ToString()!;
                            data = reader["cvr_sfecha_version"];
                            obj.cvr_sfecha_version = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["cvr_sfecha_version"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
                            obj.cep_vid_cpu = reader["cep_vid_cpu"].ToString()!;
                            obj.cep_bflag_acceso = Convert.ToBoolean(reader["cep_bflag_acceso"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
                            obj.ceq_vnombre_usuario = reader["ceq_vnombre_usuario"].ToString()!;
                            lista.Add(obj);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return lista;
        }

        internal void Version_Guardar(ControlVersiones obj)
        {
            try
            {
               
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    string query = "INSERT INTO SGE_CONTROL_VERSIONES (cvr_vversion, cvr_vurl) VALUES (@version, @url)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@version", obj.cvr_vversion);
                    cmd.Parameters.AddWithValue("@url", obj.cvr_vurl);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal async Task Version_Modificar(ControlVersiones obj)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    string query = $"update SGE_CONTROL_VERSIONES set cvr_vversion = '{obj.cvr_vversion}', cvr_vurl = '{obj.cvr_vurl}' where cvr_icod_version = {obj.cvr_icod_version}";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public List<ControlVersionesPvt> Listar_Versiones_pvt()
        {
            List<ControlVersionesPvt> lista = new List<ControlVersionesPvt>();
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_CONTROL_PUNTO_VENTA_LISTAR", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            lista.Add(new ControlVersionesPvt()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()!,
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Link = reader["Link"].ToString()!,


                            }); ;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return lista;
        }

        internal void Version_Guardar_pvt(ControlVersionesPvt obj)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    string query = $"INSERT INTO SGE_CONTROL_PUNTO_VENTA (Nombre,Link) VALUES ('{obj.Nombre}','{obj.Link}')";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal async Task Version_Modificar_pvt(ControlVersionesPvt obj)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    string query = $"update SGE_CONTROL_PUNTO_VENTA set Nombre = '{obj.Nombre}', Link = '{obj.Link}' where Id = {obj.Id}";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
