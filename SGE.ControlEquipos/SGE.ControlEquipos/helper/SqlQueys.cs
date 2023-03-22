using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.ControlEquipos.helper
{
    public class SqlQueys
    {
        public static string LISTAR_EQUIPOS = "SELECT" +
                                              " A.ceq_icod_equipo" +
                                              ",A.ceq_vnombre_equipo" +
                                              ",A.cvr_icod_version" +
                                              ",A.ceq_sfecha_actualizacion" +
                                              ",B.cvr_vversion" +
                                              ",B.cvr_sfecha_version" +
                                              ",cep_vid_cpu" +
                                              ",cep_bflag_acceso" +
                                              ",cep_vubicacion_actualizador" +
                                              ",ceq_vnombre_usuario" +
                                              " FROM SGE_CONTROL_EQUIPOS AS A LEFT JOIN SGE_CONTROL_VERSIONES AS B ON A.cvr_icod_version=B.cvr_icod_version";

        public static string MODIFICAR_EQUIPOS(Entities.ControlEquipos objEquipo)
        {
            int acceso = objEquipo.cep_bflag_acceso ? 1 : 0;
            return $" UPDATE SGE_CONTROL_EQUIPOS" +
                   $" SET" +
                   $" ceq_vnombre_usuario='{objEquipo.ceq_vnombre_usuario}'" +
                   $" ,cep_bflag_acceso={acceso}" +
                   $" WHERE" +
                   $" ceq_icod_equipo = {objEquipo.ceq_icod_equipo}";
        }
    }
}
