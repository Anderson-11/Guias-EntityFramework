using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Customers crearCliente()
        {
            var cliente = new Customers
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text,
            };
            return cliente;
        }

        private void Limpiar()
        {
            txbCustomerID.Text = "";
            txbCompanyName.Text = "";
            txbContactName.Text = "";
            txbContactTitle.Text = "";
            txbAddress.Text = "";
        }

        private void llenarCampos(Customers customers)
        {
            txbCustomerID.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            txbAddress.Text = customers.Address;
        }

        private CustomerRepository cr = new CustomerRepository();
        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtenerID_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(txtObtenerID.Text);
            List<Customers> lista1 = new List<Customers> { cliente };
            txtObtenerID.Text = "";
            if(cliente != null)
            {
                llenarCampos(cliente);
                txbCustomerID.Enabled = false;
            }
            dgvCustomers.DataSource = lista1;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se Ingreso {resultado}");
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            cr.UpdateCliente(cliente);
            var resultado = cr.ObtenerPorID(cliente.CustomerID);
            List<Customers> lista1 = new List<Customers> { resultado };
            dgvCustomers.DataSource = lista1;
            MessageBox.Show("Actualizacion Exitosa");
            txbCustomerID.Enabled = true;
            Limpiar();
        }
    }
}
