using Guna.UI2.WinForms;
using SGE.ControlEquipos.DataAcces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGE.ControlEquipos
{
    public partial class frmManteEquipos : MetroFramework.Forms.MetroForm
    {
        public Entities.ControlEquipos Obe = new Entities.ControlEquipos();
        public frmManteEquipos()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button2.Text = "Guardando...";
            Obe.ceq_vnombre_usuario = txtUsuario.Text;
            Obe.cep_bflag_acceso = Convert.ToBoolean(checkAcceso.Checked);
            Task taskModificarEquipo = new Task(()=> new GeneralData().Equipo_Modificar(Obe));
            taskModificarEquipo.Start();
            await taskModificarEquipo;
            this.DialogResult= DialogResult.OK;
        }
        public void setValues () {
            txtUsuario.Text = Obe.ceq_vnombre_usuario;
            txtCpuID.Text = Obe.cep_vid_cpu;
            txtEquipo.Text = Obe.ceq_vnombre_equipo;
            checkAcceso.Checked = Obe.cep_bflag_acceso;
        }
    }
}
