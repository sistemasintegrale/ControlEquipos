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
    public partial class MsgShow : Form
    {
        private int typeAlert = 0 ;
        private string Menssage = string.Empty;
        public MsgShow(int typeAlert, string menssage)
        {
            InitializeComponent();
            this.typeAlert = typeAlert;
            Menssage = menssage;

            lblMensaje.Text = Menssage;
            switch (typeAlert)
            {
                case 1: //ALTERT
                    picImage.IconChar = FontAwesome.Sharp.IconChar.Exclamation;
                    picImage.IconColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.DodgerBlue;
                    picImage.BackColor = System.Drawing.Color.DodgerBlue;
                    lblMensaje.BackColor = System.Drawing.Color.DodgerBlue;
                    break;
                case 2: //ERROR
                    picImage.IconChar = FontAwesome.Sharp.IconChar.TriangleExclamation;
                    picImage.IconColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.IndianRed;
                    picImage.BackColor = System.Drawing.Color.IndianRed;
                    lblMensaje.BackColor = System.Drawing.Color.IndianRed;
                    break;
                case 3: //SUCCES
                    picImage.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    picImage.IconColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.LimeGreen;
                    picImage.BackColor = System.Drawing.Color.LimeGreen;
                    lblMensaje.BackColor = System.Drawing.Color.LimeGreen;
                    break;
                default:
                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
        }

        private void MsgShow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
