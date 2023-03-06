using Guna.UI2.WinForms;
using SGE.ControlEquipos.DataAcces;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;
using System.Runtime.CompilerServices;

namespace SGE.ControlEquipos
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<Entities.ControlEquipos> lista = new List<Entities.ControlEquipos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = btnGP.Text;
            this.Refresh();
            Constantes.Connection = 1;
        }

        private void btnGP_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnGrenPeru;
            this.Text = btnGP.Text;
            this.Refresh();
            cargar();
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnGalyCompany;
            this.Text = btnGC.Text;
            this.Refresh();
            cargar();
        }

        private void btnMT_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnMotoTorque;
            this.Text = btnMT.Text;
            this.Refresh();
            cargar();
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnNovaGlass;
            this.Text = btnNG.Text;
            this.Refresh();
            cargar();
        }

        private void btnNF_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnNovaFlat;
            this.Text = btnNF.Text;
            this.Refresh();
            cargar();
        }

        private void btnNM_Click(object sender, EventArgs e)
        {
            Constantes.Connection = Constantes.ConnNovaMotos;
            this.Text = btnNM.Text;
            this.Refresh();
            cargar();
        }

        void cargar() {
            
            lista = new GeneralData().Listar_Equipos();
            grdLista.DataSource = lista;
        }
    }
}