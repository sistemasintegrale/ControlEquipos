using Guna.UI2.WinForms;
using SGE.ControlEquipos.DataAcces;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

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
            cargar();
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

        async void cargar() {
            Task<List<Entities.ControlEquipos>> task = new Task<List<Entities.ControlEquipos>>(new GeneralData().Listar_Equipos);
            task.Start();
            lista =await task;
            grdLista.DataSource = lista;
        }

        private void grdLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void darAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (grdLista.SelectedCells.Count > 0)
            {
                Entities.ControlEquipos Obe = new Entities.ControlEquipos();

                int index = grdLista.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdLista.Rows[index];

                Obe.ceq_vnombre_equipo = selectedRow.Cells["Nombre"].Value.ToString()!;
                Obe.cep_vid_cpu = selectedRow.Cells["CPU"].Value.ToString()!;

                Obe = new GeneralData().Equipo_Obtner_Datos(Obe.ceq_vnombre_equipo, Obe.cep_vid_cpu);

                Obe.cep_bflag_acceso = true;
                new GeneralData().Equipo_Dar_Acceso(Obe);
                cargar();
            }

        }
    }
}