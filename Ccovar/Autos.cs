using Ccovar.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccovar
{
    public partial class Autos : Form
    {
        static ManagerSQL MNG = new ManagerSQL();
        private int idRow = 0;

        public Autos()
        {
            InitializeComponent();
        }

        internal void Registrar_AutosAsync()
        {
            dataGridAutos.Rows.Clear();
            DataModel.Autos autos = MNG.ObtenerAutos();
            for(var i = 0;i < autos.autos.Length;i++)
            {
                dataGridAutos.Rows.Add(autos.autos[i].id, autos.autos[i].marca, autos.autos[i].año, autos.autos[i].color, autos.autos[i].tipo, autos.autos[i].capacidad, autos.autos[i].disponibilidad, autos.autos[i].razon_disponibilidad, autos.autos[i].fecha_disponibilidad, autos.autos[i].kilometraje, autos.autos[i].folio_segro, autos.autos[i].observaciones, autos.autos[i].renta_fija, autos.autos[i].renta_dia);
            }
            dataGridAutos.Update();
            dataGridAutos.Refresh();
        }

        private void Autos_Load(object sender, EventArgs e)
        {
            Registrar_AutosAsync();
        }

        private void enabledAll()
        {
            txtModelo.Enabled = true;
            txtAño.Enabled = true;
            txtColor.Enabled = true;
            txtTipo.Enabled = true;
            txtCapacidad.Enabled = true;
            txtDisponibilidad.Enabled = true;
            txtRazondisp.Enabled = true;
            txtFechadisp.Enabled = true;
            txtKilometraje.Enabled = true;
            txtFolio.Enabled = true;
            txtObservacion.Enabled = true;
            txtRentafija.Enabled = true;
            txtRentadia.Enabled = true;
        }

        private void disabledAll()
        {
            txtModelo.Enabled = false;
            txtAño.Enabled = false;
            txtColor.Enabled = false;
            txtTipo.Enabled = false;
            txtCapacidad.Enabled = false;
            txtDisponibilidad.Enabled = false;
            txtRazondisp.Enabled = false;
            txtFechadisp.Enabled = false;
            txtKilometraje.Enabled = false;
            txtFolio.Enabled = false;
            txtObservacion.Enabled = false;
            txtRentafija.Enabled = false;
            txtRentadia.Enabled = false;
        }

        private void clearAll()
        {
            txtModelo.Text = "";
            txtAño.Text = "";
            txtColor.Text = "";
            txtTipo.Text = "";
            txtCapacidad.Text = "";
            txtDisponibilidad.Text = "";
            txtRazondisp.Text = "";
            txtFechadisp.Text = "";
            txtKilometraje.Text = "";
            txtFolio.Text = "";
            txtObservacion.Text = "";
            txtRentafija.Text = "";
            txtRentadia.Text = "";
        }

        private bool checkCampos()
        {
            int lMarca = txtMarca.Text.Length;
            int lModelo = txtModelo.Text.Length;
            int lAño = txtAño.Text.Length;
            int lColor = txtColor.Text.Length;
            int lTipo = txtTipo.Text.Length;
            int lCapacidad = txtCapacidad.Text.Length;
            int lDisponibilidad = txtDisponibilidad.Text.Length;
            int lRazondisp = txtRazondisp.Text.Length;
            int lFechadisp = txtFechadisp.Text.Length;
            int lKilometraje = txtKilometraje.Text.Length;
            int lFolioseguro = txtFolio.Text.Length;
            int lObservaciones = txtObservacion.Text.Length;
            int lRentafija = txtRentafija.Text.Length;
            int lRentadia = txtRentadia.Text.Length;
            if (lMarca == 0 || lModelo == 0 || lAño == 0 || lColor == 0 || lTipo == 0 || lCapacidad == 0 || lDisponibilidad == 0 || lRazondisp == 0 || lFechadisp == 0 || lKilometraje == 0 || lFolioseguro == 0 || lObservaciones == 0 || lRentafija == 0 || lRentadia == 0)
            {
                MessageBox.Show("Necesita llenar todos los campos");
                return false;
            }
            return true;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            idRow = 0;
            enabledAll();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            bool check = checkCampos();
            if (check == true)
            {
                //if (idRow == 0)
                //{
                //    MNG.InsertarMarca(txtMarca.Text, txtNacionalidad.Text);
                //}
                //else
                //{
                //    MNG.UpdateMarca(txtMarca.Text, txtNacionalidad.Text, idRow);
                //}
                Registrar_AutosAsync();
                clearAll();
            }
        }
    }
}
