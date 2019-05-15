using Ccovar.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccovar
{
    public partial class Principal : Form
    {
        private Usuario usuario;
        Form fh;

        public Principal(Usuario usu)
        {
            usuario = usu;
            InitializeComponent();
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\fa-solid-900.ttf");
            this.toolTipMensaje.SetToolTip(this.btnUser, "Lista de usuarios");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void AbrirFormInPanel(object FormHijo)
        {
            fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelParent.Controls.Add(fh);
            this.panelParent.Tag = fh;
            fh.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.NoMove2D;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Rentas());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new UsuariosPanel());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Clientes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Autos());
        }

        private void btnES_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Rentas());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Mantenimientos());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Incidencias());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            fh.Close();
            AbrirFormInPanel(new Marcas());
        }
    }
}
