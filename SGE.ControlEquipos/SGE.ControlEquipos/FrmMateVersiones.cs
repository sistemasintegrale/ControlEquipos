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
using System.Windows.Interop;
using Guna.UI2.WinForms;
using SGE.ControlEquipos.DataAcces;
using SGE.ControlEquipos.Entities;
using SGE.ControlEquipos.helper;

namespace SGE.ControlEquipos
{
    public partial class FrmMateVersiones : MetroFramework.Forms.MetroForm
    {
        public ControlVersiones obj = new ControlVersiones();
        Guna2MessageDialog msg = new Guna2MessageDialog();
        public FrmMateVersiones()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            txtVersion.Text = obj.cvr_vversion;
            txtUrl.Text = obj.cvr_vurl;

        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            obj.cvr_vversion = txtVersion.Text;
            obj.cvr_vurl = txtUrl.Text;
            if (obj.cvr_icod_version == 0)
            {
                msg = new Guna2MessageDialog();
                Task<bool> taskGuardarVersiones = new Task<bool>(Guardar);
                taskGuardarVersiones.Start();
                await taskGuardarVersiones;
                msg.Caption = "Información del Sistema";
                msg.Text = "Registro Exitoso";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent = this;
                msg.Show();

            }
            else
            {
                msg = new Guna2MessageDialog();
                await new GeneralData().Version_Modificar(obj);
                msg.Caption = "Información del Sistema";
                msg.Text = "Actualización Exitosa";
                msg.Buttons = MessageDialogButtons.OK;
                msg.Style = MessageDialogStyle.Light;
                msg.Icon = MessageDialogIcon.Information;
                msg.Parent= this;
                msg.Show();
            }  
            
            DialogResult = DialogResult.OK;
        }
        private bool Guardar()
        {
            new GeneralData().Version_Guardar(obj);
            return true;
        }

    }
}
