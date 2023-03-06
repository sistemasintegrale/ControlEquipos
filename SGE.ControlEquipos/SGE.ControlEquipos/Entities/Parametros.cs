using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.ControlEquipos.Entities
{
    public class Parametros : Auditoria
    {
        public int pm_icod_parametro { get; set; }
        public decimal? pm_nigv_parametro { get; set; }
        public decimal? pm_ntope_parametro { get; set; }
        public decimal? pm_nuit_parametro { get; set; }
        public decimal? pm_ncategoria_parametro { get; set; }
        public decimal? pm_nivap_parametro { get; set; }
        public decimal? pm_nisc_parametro { get; set; }
        public string pm_nombre_empresa { get; set; } = string.Empty;
        public string pm_direccion_empresa { get; set; } = string.Empty;
        public string pm_vruc { get; set; } = string.Empty;
        public long? pm_correlativo_OR { get; set; }
        public decimal? pm_ntipo_cambio { get; set; }
        public string pm_vtokec_consulta_ruc { get; set; } = string.Empty;
    }
}
