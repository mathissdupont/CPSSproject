using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPSS_ol_artik
{
    public partial class mainmenu : Form
    {
        public mainmenu()
        {
            InitializeComponent();
            databaseclass dbclass = new databaseclass();
            dbclass.loaddatatocombobox("products", "products", stockproductname);
            dbclass.loaddatatocombobox("products", "products", delstockproductname);
            dbclass.loaddatatocombobox("products", "products", updatestockproductname);
            dbclass.loaddatatocombobox("products", "products", orderaddproname);
            dbclass.LoadStocksToDataGridView(stockgoruntulegrid);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void mainmenu_Load(object sender, EventArgs e)
        {

        }

        private void addnewproductbttn_Click(object sender, EventArgs e)
        {
            addproduct addproduct = new addproduct();
            addproduct.ShowDialog();
        }

        private void stockproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void delstockproductname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addstockbttn_Click(object sender, EventArgs e)
        {
            string secilenurun = stockproductname.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenurun))
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }
            if (int.TryParse(stockaddvalue.Text, out int productvalue) && productvalue > 0)
            {
                databaseclass dbclass = new databaseclass();
                dbclass.addProductStock(secilenurun, productvalue);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
            }
        }

        private void updatestockbttn_Click(object sender, EventArgs e)
        {
            string secilenurun = updatestockproductname.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenurun))
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }
            if(int.TryParse(updateproductvalue.Text,out int productvalue) && productvalue > 0)
            {
                databaseclass dbclass = new databaseclass();
                dbclass.UpdateProductStock(secilenurun, productvalue);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
            }
        }

        private void delstock_Click(object sender, EventArgs e)
        {
            string secilenurun= delstockproductname.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenurun))
            {
                MessageBox.Show("Lütfen bir ürün seçiniz");
                return;
            }
            if (int.TryParse(delstockvalue.Text, out int productvalue) && productvalue > 0)
            {
                databaseclass databaseclass = new databaseclass();
                databaseclass.delProductStock(secilenurun,productvalue);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz");
            }
        }

        private void saveandquitbttn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockgoruntulegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
