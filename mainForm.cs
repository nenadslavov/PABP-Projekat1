using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PABP_PrviProjekat
{
    public partial class mainForm : Form
    {
        Form1 f1;
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        DataView dv;
        
        

        public mainForm(Form1 frm)
        {   
            this.f1 = frm;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            dv = new System.Data.DataView();
            InitializeComponent();
            
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                int kategorija = (int)f1.cmbCtg.SelectedValue;
                productsBindingSource.Filter = "CategoryID =" + kategorija;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex);
            }
            // TODO: This line of code loads data into the 'northwindDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
            // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
            // TODO: This line of code loads data into the 'northwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);

        }

        private void btnPretDob_Click(object sender, EventArgs e)
        {
            try
            {
                int kategorija = (int)f1.cmbCtg.SelectedValue;
                int dobavljac = (int)(suppliersComboBox.SelectedValue);
                if (dobavljac.ToString() =="")
                {
                    productsBindingSource.Filter = "CategoryID =" + kategorija;
                }
                else
                {
                    productsBindingSource.Filter = "CategoryID =" + kategorija + " AND SupplierID=" + dobavljac;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex);
            }

        }

        private void btnPretCen_Click(object sender, EventArgs e)
        {
            try
            {
                string cena = textBox1.Text;
                Convert.ToDouble(cena);
                int kategorija = (int)f1.cmbCtg.SelectedValue;
                int dobavljac = (int)(suppliersComboBox.SelectedValue);
                if (cena == "")
                {
                    productsBindingSource.Filter = "CategoryID =" + kategorija;
                }
                else
                {
                    productsBindingSource.Filter = "CategoryID =" + kategorija + " AND UnitPrice+UnitsInStock > '" + cena + "'";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* dataGridView2.DataSource = null;
            try
            {
                int selRowId =
                MessageBox.Show("" + selRowId);
                da = new SqlDataAdapter("SELECT * FROM [Order Details] Where ProductID=" + selRowId, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex);
            }*/
        }

        private void btnIzmena_Click(object sender, EventArgs e)
        {

            izmenaForm ifrm = new izmenaForm();
            ifrm.ShowDialog();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            unosForm frm = new unosForm();
            frm.ShowDialog();
        }

        private void productsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                string prodId = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                string prodName = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                string supId = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                string catId = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                string quantPu = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                string unitPr = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                string unitStoc = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                string unitOrd = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                string recLvl = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                string disc = dataGridView1.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();

                
            }*/
            
        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            productsBindingSource.Remove(dataGridView1.SelectedRows);
        }
    }
}
