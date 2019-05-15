using Ccovar.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccovar
{
    public partial class Marcas : Form
    {
        static ManagerSQL MNG_Ccovar = new ManagerSQL();
        private int idRow = 0;
        public Marcas()
        {
            InitializeComponent();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            idRow = 0;
            txtMarca.Enabled = true;
            txtNacionalidad.Enabled = true;
        }

        private void disableAll()
        {
            txtMarca.Enabled = false;
            txtNacionalidad.Enabled = false;
        }

        private void enabledAll()
        {
            txtMarca.Enabled = true;
            txtNacionalidad.Enabled = true;
        }

        private void clearAll()
        {
            txtMarca.Text = "";
            txtNacionalidad.Text = "";
        }

        private bool checkCampos()
        {
            int lMarca = txtMarca.Text.Length;
            int lNacionalidad = txtNacionalidad.Text.Length;
            if (lMarca == 0 || lNacionalidad == 0)
            {
                MessageBox.Show("Necesita llenar todos los campos");
                return false;
            }
            return true;
        }

        internal void Registrar_MarcasAsync()
        {
            dataGridMarcas.Rows.Clear();
            DataModel.Marcas marcas = MNG_Ccovar.ObtenerMarcas();
            for (var i = 0; i < marcas.marcas.Length; i++)
            {
                dataGridMarcas.Rows.Add(marcas.marcas[i].id, marcas.marcas[i].marca, marcas.marcas[i].nacionalidad);
            }
            dataGridMarcas.Update();
            dataGridMarcas.Refresh();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            bool check = checkCampos();
            if(check == true)
            {
                if (idRow == 0)
                {
                    MNG_Ccovar.InsertarMarca(txtMarca.Text, txtNacionalidad.Text);
                }
                else
                {
                    MNG_Ccovar.UpdateMarca(txtMarca.Text, txtNacionalidad.Text, idRow);
                    Registrar_MarcasAsync();
                }
                clearAll();
            }
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            Registrar_MarcasAsync();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            idRow = Int32.Parse(dataGridMarcas.SelectedRows[0].Cells[0].Value.ToString());
            txtMarca.Text = dataGridMarcas.SelectedRows[0].Cells[1].Value.ToString();
            txtNacionalidad.Text = dataGridMarcas.SelectedRows[0].Cells[2].Value.ToString();
            enabledAll();
        }
    }
}