using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace CPSS_ol_artik
{
    public partial class addproduct : Form
    {
        private string connectionString = "Data Source=CPSS.db;";
        public addproduct()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addproduct_Load(object sender, EventArgs e)
        {

        }

        private void addproductbttn_Click(object sender, EventArgs e)
        {
            string productname = addproductname.Text;
            string productID = addproductID.Text;
            string productvalue = addproductvalue.Text;
            if (string.IsNullOrEmpty(productvalue) || string.IsNullOrEmpty(productname) || string.IsNullOrEmpty(productvalue)) 
            {
                MessageBox.Show("Kutucuklar boş bırakılamaz.!");
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO products (products,productID,stock) VALUES (@products,@productID,@stock)";
                    using(SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@products", productname);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        cmd.Parameters.AddWithValue("stock", productvalue);
                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            MessageBox.Show("Ürün başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Ürün Eklerken Hata ile Karşılaşıldı","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata meydana geldi: {ex.Message}");
            }
        }
    }
}
