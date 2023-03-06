using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SGE.ControlEquipos.Entities
{
    public class Usuario
    {
        public int usua_icod_usuario { get; set; }
        public string usua_codigo_usuario { get; set; } = string.Empty;
        public string usua_nombre_usuario { get; set; } = string.Empty;
        public string usua_password_usuario { get; set; } = string.Empty;
        public bool usua_iactivo { get; set; }
        public string strEstado { get; set; } = string.Empty;

        public int connection { get; set; }
    }
}
