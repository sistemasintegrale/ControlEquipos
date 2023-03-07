using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGE.ControlEquipos.DataAcces;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;

namespace SGE.ControlEquipos
{
    public partial class FrmMateVersiones : MetroFramework.Forms.MetroForm
    {
        ControlVersiones obj = new ControlVersiones();
        public FrmMateVersiones()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            obj.cvr_vversion = txtVersion.Text;
            obj.cvr_vurl = txtUrl.Text;

            Task<bool> taskGuardarVersiones = new Task<bool>(Guardar);
            taskGuardarVersiones.Start();
            await taskGuardarVersiones;
            MsgShow mensaje = new MsgShow(3, "Registro Exitoso");
            mensaje.ShowDialog();
            DialogResult = DialogResult.OK;
        }
        private bool Guardar() {
            new GeneralData().Version_Guardar(obj);
            return true;               
        }

    }
}
