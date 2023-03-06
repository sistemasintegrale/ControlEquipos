using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.ControlEquipos.Entities
{
    public class ControlEquipos : ControlVersiones
    {
        public int ceq_icod_equipo { get; set; }
        public string ceq_vnombre_equipo { get; set; } = null!;
        public int? cvr_icod_version { get; set; } = null!;
        public DateTime? ceq_sfecha_actualizacion { get; set; }
        public string cep_vid_cpu { get; set; } = null!;
        public bool cep_bflag_acceso { get; set; }
        public string cep_vubicacion_actualizador { get; set; } = null!;
    }
}
