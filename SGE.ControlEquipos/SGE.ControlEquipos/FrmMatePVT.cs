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
    public partial class FrmMatePvt : MetroFramework.Forms.MetroForm
    {
        public ControlVersionesPvt obj = new ControlVersionesPvt();
        Guna2MessageDialog msg = new Guna2MessageDialog();
        public FrmMatePvt()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            txtVersion.Text = obj.Nombre;
            txtUrl.Text = obj.Link;

        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            obj.Nombre = txtVersion.Text;
            obj.Link = txtUrl.Text;
            if (obj.Id == 0)
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
                await new GeneralData().Version_Modificar_pvt(obj);
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
            new GeneralData().Version_Guardar_pvt(obj);
            return true;
        }

    }
}
