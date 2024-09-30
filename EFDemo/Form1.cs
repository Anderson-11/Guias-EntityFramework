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
            dgvCustomers.DataSource = lista1;
            txtObtenerID.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se Ingreso {resultado}");
            Limpiar();
        }
    }
}
