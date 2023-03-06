using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;
using System.Data;

namespace SGE.ControlEquipos.DataAcces
{
    public class GeneralData
    {
 

        internal void Equipo_Modificar(Entities.ControlEquipos objEquipo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_EQUIPO_MODIFICAR", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        cmd.Parameters.AddWithValue("@ceq_icod_equipo", objEquipo.ceq_icod_equipo);
                        cmd.Parameters.AddWithValue("@ceq_vnombre_equipo", objEquipo.ceq_vnombre_equipo);
                        cmd.Parameters.AddWithValue("@cvr_icod_version", objEquipo.cvr_icod_version);
                        cmd.Parameters.AddWithValue("@ceq_sfecha_actualizacion", objEquipo.ceq_sfecha_actualizacion);
                        cmd.Parameters.AddWithValue("@cep_vubicacion_actualizador", objEquipo.cep_vubicacion_actualizador);
                        cmd.ExecuteNonQuery();
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
                            obj.ceq_sfecha_actualizacion = string.IsNullOrEmpty(data.ToString())? (DateTime?)null : Convert.ToDateTime(reader["ceq_sfecha_actualizacion"]);
                            obj.cvr_vversion = reader["cvr_vversion"].ToString()!;
                            data = reader["cvr_sfecha_version"];
                            obj.cvr_sfecha_version = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null: Convert.ToDateTime(reader["cvr_sfecha_version"]);
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
                    using (SqlCommand cmd = new SqlCommand("ACT_EQUIPO_LISTAR", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Entities.ControlEquipos obj = new Entities.ControlEquipos();
                            obj.ceq_icod_equipo = Convert.ToInt32(reader["ceq_icod_equipo"]);
                            obj.ceq_vnombre_equipo = reader["ceq_vnombre_equipo"].ToString()!;
                            var data = reader["cvr_icod_version"];
                            obj.cvr_icod_version = string.IsNullOrEmpty(data.ToString())? 0: Convert.ToInt32(data);
                            data = reader["ceq_sfecha_actualizacion"];
                            obj.ceq_sfecha_actualizacion = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["ceq_sfecha_actualizacion"]);
                            obj.cvr_vversion = reader["cvr_vversion"].ToString()!;
                            data = reader["cvr_sfecha_version"];
                            obj.cvr_sfecha_version = string.IsNullOrEmpty(data.ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["cvr_sfecha_version"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
                            obj.cep_vid_cpu = reader["cep_vid_cpu"].ToString()!;
                            obj.cep_bflag_acceso = Convert.ToBoolean(reader["cep_bflag_acceso"]);
                            obj.cep_vubicacion_actualizador = reader["cep_vubicacion_actualizador"].ToString()!;
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

        internal List<ControlVersiones> Listar_Versiones()
        {
            List<ControlVersiones> lista = new List<ControlVersiones>();
            try
            {
                using (SqlConnection cn = new SqlConnection(HelperConnection.conexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ACT_ACTUALIZACIONES_LISTAR", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.MaxValue;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            lista.Add(new ControlVersiones()
                            {
                                cvr_icod_version = Convert.ToInt32(reader["cvr_icod_version"]),
                                cvr_vversion = reader["cvr_vversion"].ToString()!,
                                cvr_sfecha_version = Convert.ToDateTime(reader["cvr_sfecha_version"]),
                                cvr_vurl = reader["cvr_vurl"].ToString()!,
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

    }
}
