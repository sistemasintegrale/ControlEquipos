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
        List<ControlVersiones> listVersiones = new List<ControlVersiones>();
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
            limpiarGrds();
            Constantes.Connection = Constantes.ConnGrenPeru;
            this.Text = btnGP.Text;
            this.Refresh();
            cargar();
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            limpiarGrds();
            Constantes.Connection = Constantes.ConnGalyCompany;
            this.Text = btnGC.Text;
            this.Refresh();
            cargar();
        }

        private void btnMT_Click(object sender, EventArgs e)
        {
            limpiarGrds();
            Constantes.Connection = Constantes.ConnMotoTorque;
            this.Text = btnMT.Text;
            this.Refresh();
            cargar();
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            limpiarGrds();
            Constantes.Connection = Constantes.ConnNovaGlass;
            this.Text = btnNG.Text;
            this.Refresh();
            cargar();
        }

        private void btnNF_Click(object sender, EventArgs e)
        {
            limpiarGrds();
            Constantes.Connection = Constantes.ConnNovaFlat;
            this.Text = btnNF.Text;
            this.Refresh();
            cargar();
        }

        private void btnNM_Click(object sender, EventArgs e)
        {
            limpiarGrds();
            Constantes.Connection = Constantes.ConnNovaMotos;
            this.Text = btnNM.Text;
            this.Refresh();
            cargar();
        }

        async void cargar()
        {
            spiner1.Visible = true;
            spiner2.Visible = true;
            Task<List<Entities.ControlEquipos>> taskEquipos = new Task<List<Entities.ControlEquipos>>(new GeneralData().Listar_Equipos);
            Task<List<ControlVersiones>> taskVersiones = new Task<List<ControlVersiones>>(new GeneralData().Listar_Versiones);
            taskVersiones.Start();
            taskEquipos.Start();
            lista = await taskEquipos;
            listVersiones = await taskVersiones;

            spiner1.Visible = false;
            grdPublicaciones.DataSource = listVersiones;
            spiner2.Visible = false;
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

        void limpiarGrds()
        {
            grdLista.DataSource = new List<Entities.ControlEquipos>();
            grdPublicaciones.DataSource = new List<ControlVersiones>();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMateVersiones frm = new FrmMateVersiones();
            frm.ShowDialog();
            DialogResult result = frm.DialogResult;
            if (result == DialogResult.OK)
            {
                cargar();
            }
        }
    }
}