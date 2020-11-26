using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PABP_PrviProjekat
{
    public partial class izmenaForm : Form
    {
        public izmenaForm()
        {
            InitializeComponent();

        }
        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void izmenaForm_Load(object sender, EventArgs e)
        {
           // string prodId = Value;
            productsBindingSource.Filter = "ProductID=2";
            //
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);



        }

        private void btnIzmenaBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        class Product
        {
            public string ProdName;
            public string untPrice;

            public Product(string ProdName, string UntPrice)
            {
                this.ProdName = ProdName;
                this.untPrice = untPrice;
            }
            public string Prodname
            {
                set { ProdName = value; }
                get { return  ProdName; }
            }
            public string UntPrice
            {
                set { untPrice = value; }
                get { return untPrice; }
            }
        }
        private void btnIzmenaOk_Click(object sender, EventArgs e)
        {
            /*productsBindingSource.Add(Product(productNameTextBox.Text, unitPriceTextBox.Text);*/
        }

    }
}
