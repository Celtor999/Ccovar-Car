using Ccovar.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccovar
{
    public partial class Login : Form
    {
        static ManagerSQL MNG_Ccovar = new ManagerSQL();

        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle myRectangle = button1.ClientRectangle;
            myRectangle.Inflate(0, 30);
            buttonPath.AddEllipse(myRectangle);
            button1.Region = new Region(buttonPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var usuarios = MNG_Ccovar.Login(txtUser.Text, txtPassword.Text);
            if(usuarios.usuarios.Length != 0)
            {
                this.Hide();
                var Principal = new Principal(usuarios.usuarios[0]);
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario denegado.");
            }
        }
    }
}
