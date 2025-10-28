using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.ControlEquipos.helper
{
    public class HelperConnection
    {
        public static string conexion()
        {
            string strConexion = string.Empty;
            int number = (Int32)Constantes.Connection;
            switch (number)
            {
                case 1: //GREEN PERU
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=ges-pro_com_db;Persist Security Info=True;User ID=ges-pro_com_ges;Password=EY4hI006Z_b;MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False";
                    break;
                case 2: //GALY COMPANY
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=telaslima_com_GC;Persist Security Info=True;User ID=sistemasintegrales_com_de;Password=rogola2012;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 3: // MOTO TORQUE
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=sistemasintegrales_com_MT;Persist Security Info=True;User ID=sistemasintegrales_com_de;Password=rogola2012;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 4: //NOVA GLASS
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=novaglass_pe_NG;Persist Security Info=True;User ID=novaglass_pe_de;Password=rogola2012;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 5: //NOVA FLAT
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=novaflatsac_com_NF;Persist Security Info=True;User ID=novaflatsac_com_NF;Password=rogola2012;MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False";
                    break;
                case 6: // NOVA MOTOS
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=novamotos_com_NM;Persist Security Info=True;User ID=novamotos_com_de;Password=_9]4z#rWW;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 7: //CALZADOS JAGUAR
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=jaguar_com_pe_CJ;Persist Security Info=True;User ID=jaguar_com_pe_CJ;Password=eY-68j#0D;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 8: //PRADOS VERDES
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=parquesdelparaiso_pe_PV;Persist Security Info=True;User ID=parquesdelparaiso_pe_de;Password=rogola2012;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 9: //TELAS LIMA
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=telaslima_com_TL;Persist Security Info=True;User ID=telaslima_com_de;Password=X3V!~OB@za;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";

                    break;
                case 10: //ULIKE
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=telaslima_com_UL;Persist Security Info=True;User ID=telaslimacom_de;Password=X3V!~OB@za;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 11: //MULTISISTEMA
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=real_invest_mmm_com_me;Persist Security Info=True;User ID=telaslima_com_de;Password=X3V!~OB@za;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 12: //JABSA
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=jabsa_pe_jb;Persist Security Info=True;User ID=jabsa_pe_jb;Password=zgWPRSePOHb9;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 13: //JUTIDH LAB
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=judithdermocosmeticaprofesional_com_jl;Persist Security Info=True;User ID=judithdermocosmeticaprofesional_com_jl;Password=0*3G]c9*jrK;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 14: //mjsgroup
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=mjcgroupsac_com_mjc;Persist Security Info=True;User ID=mjcgroupsac_com_mjc;Password=4PeI=%,a;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
                case 15: //iglesia sjl
                    strConexion = "Data Source=tcp:95.217.194.247,1433;Initial Catalog=alianzasjl_org_alianzasjl;Persist Security Info=True;User ID=alianzasjl_org_alianzasjl;Password=(6FY~wgi;MultipleActiveResultSets = True; TrustServerCertificate = False; Encrypt = False";
                    break;
            }
            return strConexion;
        }

        public static string GeneratePath(int number)
        {
            string strConexion = string.Empty;
            switch (number)
            {
                case 1: //GREEN PERU
                    strConexion = "Green-Peru";
                    break;
                case 2: //GALY COMPANY
                    strConexion = "Galy-Company";
                    break;
                case 3: // MOTO TORQUE
                    strConexion = "Moto-Torque";
                    break;
                case 4: //NOVA GLASS
                    strConexion = "Nova-Glass";
                    break;
                case 5: //NOVA FLAT
                    strConexion = "Nova-Flat";
                    break;
                case 6: // NOVA MOTOS
                    strConexion = "Nova-Motos";
                    break;
                case 7: // CALZADOS JAGUAR
                    strConexion = "Calzados-Jaguar";
                    break;
                case 8: // PRADOS VERDES
                    strConexion = "Prados-Verdes";
                    break;
                case 9: // PRADOS VERDES
                    strConexion = "Telas-Lima";
                    break;
                case 10: // PRADOS VERDES
                    strConexion = "Ulike";
                    break;
                case 11: // Multisistema
                    strConexion = "Multi-Empresa";
                    break;
                case 12:// JABSA
                    strConexion = "Jabsa";
                    break;
                case 13:// IGLESIA
                    strConexion = "Iglesia-Sjl";
                    break;
            }
            return strConexion;
        }


    }
}
