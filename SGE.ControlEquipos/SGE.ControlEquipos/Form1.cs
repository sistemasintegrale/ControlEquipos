using Guna.UI2.WinForms;
using SGE.ControlEquipos.DataAcces;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace SGE.ControlEquipos
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<Entities.ControlEquipos> lista = new List<Entities.ControlEquipos>();
        List<ControlVersiones> listVersiones = new List<ControlVersiones>();
        List<ControlVersionesPvt> listaPvt = new List<ControlVersionesPvt>();
        private bool Pvt = false;
        public Form1()
        {
            InitializeComponent();
        }

        void Reload(int conneccion, Guna2Button button)
        {

            limpiarGrds();
            this.Text = button.Text;
            this.Refresh();
            Constantes.Connection = conneccion;
            cargar();
        }



        private void Form1_Load(object sender, EventArgs e) => Reload(1, btnGP);
        private void btnGP_Click(object sender, EventArgs e) => Reload(Constantes.ConnGrenPeru, btnGP);
        private void btnGC_Click(object sender, EventArgs e) => Reload(Constantes.ConnGalyCompany, btnGC);
        private void btnMT_Click(object sender, EventArgs e) => Reload(Constantes.ConnMotoTorque, btnMT);
        private void btnNG_Click(object sender, EventArgs e) => Reload(Constantes.ConnNovaGlass, btnNG);
        private void btnNF_Click(object sender, EventArgs e) => Reload(Constantes.ConnNovaFlat, btnNF);
        private void btnNM_Click(object sender, EventArgs e) => Reload(Constantes.ConnNovaMotos, btnNM);
        private void guna2Button1_Click(object sender, EventArgs e) => Reload(Constantes.ConnCalzadosJaguar, btnCJ);
        private void btnPV_Click(object sender, EventArgs e) => Reload(Constantes.ConnPradosVerdes, btnPV);
        private void btnTL_Click(object sender, EventArgs e) => Reload(Constantes.ConnTelasLima, btnTL);
        private void btnUl_Click(object sender, EventArgs e) => Reload(Constantes.ConnUlike, btnUl);
        private void btnMS_Click(object sender, EventArgs e) => Reload(Constantes.ConnMultiEmpresa, btnMS);
        private void btnJabsa_Click(object sender, EventArgs e) => Reload(Constantes.ConnJabsa, btnJabsa); 
        private void btnjudithlab_Click(object sender, EventArgs e) => Reload(Constantes.ConnJudithLab, btnjudithlab);
         

        async void cargar()
        {
            spiner1.Visible = true;
            spiner2.Visible = true;
            spiner3.Visible = true;

            lista = await Task.Run(() => new GeneralData().Listar_Equipos());
            listVersiones = await Task.Run(() => new GeneralData().Listar_Versiones());
            listaPvt = await Task.Run(() => new GeneralData().Listar_Versiones_pvt());

            spiner1.Visible = false;
            grdPublicaciones.DataSource = listVersiones;
            spiner2.Visible = false;
            grdLista.DataSource = lista;
            spiner3.Visible = false;
            grdPvt.DataSource = listaPvt;

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

                Guna2MessageDialog msg = new Guna2MessageDialog();
                msg.Caption = "Información del Sistema";
                msg.Text = "Actualización Exitosa";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent = this;
                msg.Show();
                cargar();
            }

        }

        void limpiarGrds()
        {
            grdLista.DataSource = new List<Entities.ControlEquipos>();
            grdPublicaciones.DataSource = new List<ControlVersiones>();
            grdPvt.DataSource = new List<ControlVersionesPvt>();
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

        private async void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdLista.SelectedCells.Count == 0)
                return;
            int index = grdPublicaciones.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = grdPublicaciones.Rows[index];

            ControlVersiones Obe = new ControlVersiones();

            var data = selectedRow.Cells;

            Obe.cvr_icod_version = Convert.ToInt32(selectedRow.Cells["icod_version"].Value);
            Task<List<ControlVersiones>> taskVersiones = new Task<List<ControlVersiones>>(new GeneralData().Listar_Versiones);
            taskVersiones.Start();
            var lista = await taskVersiones;
            Obe = lista.Where(x => x.cvr_icod_version == Obe.cvr_icod_version).FirstOrDefault()!;
            FrmMateVersiones frm = new FrmMateVersiones();
            frm.obj = Obe;
            frm.SetValues();
            frm.ShowDialog();
            DialogResult result = frm.DialogResult;
            if (result == DialogResult.OK)
            {
                cargar();
            }
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (grdLista.SelectedCells.Count == 0)
                return;

            Entities.ControlEquipos Obe = new Entities.ControlEquipos();

            int index = grdLista.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = grdLista.Rows[index];

            Obe = lista.Where(x => x.ceq_icod_equipo == Convert.ToInt32(selectedRow.Cells["ceq_icod_equipo"].Value)).FirstOrDefault()!;

            frmManteEquipos frm = new frmManteEquipos();
            frm.Obe = Obe;
            frm.setValues();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Guna2MessageDialog msg = new Guna2MessageDialog();
                msg.Caption = "Información del Sistema";
                msg.Text = "Actualización Exitosa";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent = this;
                msg.Show();
                cargar();
            }

        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMatePvt frm = new FrmMatePvt();


            if (frm.ShowDialog() == DialogResult.OK)
            {
                Guna2MessageDialog msg = new Guna2MessageDialog();
                msg.Caption = "Información del Sistema";
                msg.Text = "Actualización Exitosa";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent = this;
                msg.Show();
                cargar();
            }
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = grdPvt.SelectedRows[0];
            ControlVersionesPvt controlVersionesPvt = new ControlVersionesPvt
            {
                Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                Link = selectedRow.Cells["Link"].Value.ToString()!,
                Nombre = selectedRow.Cells["Nombre"].Value.ToString()!,
                Fecha = Convert.ToDateTime(selectedRow.Cells["Fecha"].Value)
            };

            FrmMatePvt frm = new FrmMatePvt();
            frm.obj = controlVersionesPvt;
            frm.SetValues();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Guna2MessageDialog msg = new Guna2MessageDialog();
                msg.Caption = "Información del Sistema";
                msg.Text = "Actualización Exitosa";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent = this;
                msg.Show();
                cargar();
            }
        }

      
    }
}