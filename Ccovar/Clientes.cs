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
    public partial class Clientes : Form
    {
        static ManagerSQL MNG_Ccovar = new ManagerSQL();
        private int idRow = 0;
        public Clientes()
        {
            InitializeComponent();
        }

        internal void Registrar_ClientesAsync()
        {
            dataGridClientes.Rows.Clear();
            DataModel.Clientes clientes = MNG_Ccovar.ObtenerClientes();
            for (var i = 0; i < clientes.clientes.Length; i++)
            {
                dataGridClientes.Rows.Add(clientes.clientes[i].id, clientes.clientes[i].nombre, clientes.clientes[i].apellido_paterno, clientes.clientes[i].apellido_materno, clientes.clientes[i].calle, clientes.clientes[i].numero, clientes.clientes[i].colonia, clientes.clientes[i].codigo_postal, clientes.clientes[i].ciudad, clientes.clientes[i].estado, clientes.clientes[i].pais, clientes.clientes[i].numero_liciencia, clientes.clientes[i].nacionalidad, clientes.clientes[i].telefono);
            }
            dataGridClientes.Update();
            dataGridClientes.Refresh();
        }

        private void enabledAll()
        {
            txtNombre.Enabled = true;
            txtPaterno.Enabled = true;
            txtMaterno.Enabled = true;
            txtCalle.Enabled = true;
            txtNumero.Enabled = true;
            txtColonia.Enabled = true;
            txtPostal.Enabled = true;
            txtCiudad.Enabled = true;
            txtEstado.Enabled = true;
            txtPais.Enabled = true;
            txtLiciencia.Enabled = true;
            txtNacionalidad.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void disableAll()
        {
            txtNombre.Enabled = false;
            txtPaterno.Enabled = false;
            txtMaterno.Enabled = false;
            txtCalle.Enabled = false;
            txtNumero.Enabled = false;
            txtColonia.Enabled = false;
            txtPostal.Enabled = false;
            txtCiudad.Enabled = false;
            txtEstado.Enabled = false;
            txtPais.Enabled = false;
            txtLiciencia.Enabled = false;
            txtNacionalidad.Enabled = false;
            txtTelefono.Enabled = false;
        }

        private void clearAll()
        {
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtColonia.Text = "";
            txtPostal.Text = "";
            txtCiudad.Text = "";
            txtEstado.Text = "";
            txtPais.Text = "";
            txtLiciencia.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Registrar_ClientesAsync();
        }

        private bool checkCampos()
        {
            int lNombre = txtNombre.Text.Length;
            int lPaterno = txtPaterno.Text.Length;
            int lMaterno = txtMaterno.Text.Length;
            int lCalle = txtCalle.Text.Length;
            int lNumero = txtNumero.Text.Length;
            int lColonia = txtColonia.Text.Length;
            int lPostal = txtPostal.Text.Length;
            int lCiudad = txtCiudad.Text.Length;
            int lEstado = txtEstado.Text.Length;
            int lPais = txtPais.Text.Length;
            int lLiciencia = txtLiciencia.Text.Length;
            int lNacionalidad = txtNacionalidad.Text.Length;
            int lTelefono = txtTelefono.Text.Length;

            if (lNombre == 0 || lPaterno == 0 || lMaterno == 0 || lCalle == 0 || lNumero == 0 || lColonia == 0 || lPostal == 0 || lCiudad == 0 || lEstado == 0 || lPais == 0 || lLiciencia == 0 || lNacionalidad == 0 || lTelefono == 0)
            {
                MessageBox.Show("Necesita llenar todos los campos");
                return false;
            }
            return true;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            bool check = checkCampos();
            if (check == true)
            {
                if (idRow == 0)
                {
                    MNG_Ccovar.InsertarCliente(txtNombre.Text, txtPaterno.Text,txtMaterno.Text,txtCalle.Text,txtNumero.Text,txtColonia.Text,txtPostal.Text,txtCiudad.Text,txtEstado.Text,txtPais.Text,txtLiciencia.Text,txtNacionalidad.Text,txtTelefono.Text);
                }
                else
                {
                    MNG_Ccovar.UpdateCliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtCalle.Text, txtNumero.Text, txtColonia.Text, txtPostal.Text, txtCiudad.Text, txtEstado.Text, txtPais.Text, txtLiciencia.Text, txtNacionalidad.Text, txtTelefono.Text, idRow);
                    Registrar_ClientesAsync();
                }
                clearAll();
            }
        }
    }
}
