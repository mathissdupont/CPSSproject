using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
namespace CPSS_ol_artik
{
    public class databaseclass
    {
        public void LoadStocksToDataGridView(DataGridView dataGridView)
        {
            string connectionString = "Data Source=CPSS.db;"; 
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM products";  

                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);
                    DataTable dataTable = new DataTable(); 
                    dataAdapter.Fill(dataTable); 

                    dataGridView.DataSource = dataTable; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        public void delProductStock(string productname, int productvalue)
        {
            string connectionString = "Data Source=CPSS.db;";
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(connectionString);
                con.Open();
                string query = "UPDATE products SET stock = stock - @productvalue WHERE products = @productname";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@productvalue", productvalue);
                cmd.Parameters.AddWithValue("@productname", productname);
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    MessageBox.Show("Stok Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu: {ex.Message}");
            }
        }
        public void UpdateProductStock(string productname, int productvalue)
        {
            string connectionString = "Data Source=CPSS.db;";
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(connectionString);
                con.Open();
                string query = "UPDATE products SET stock = @productvalue WHERE products = @productname";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@productvalue", productvalue);
                cmd.Parameters.AddWithValue("@productname", productname);
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    MessageBox.Show("Stok Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu: {ex.Message}");
            }
        }
        public void addProductStock(string productname, int productvalue)
        {
            string connectionString = "Data Source=CPSS.db;";
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(connectionString);
                con.Open();
                string query = "UPDATE products SET stock = stock + @productvalue WHERE products = @productname";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@productvalue", productvalue);
                cmd.Parameters.AddWithValue("@productname", productname);
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    MessageBox.Show("Stok Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu: { ex.Message}");
            }
        }
        public void loaddatatocombobox(string table,string column,ComboBox comboboxname)
        {
            string connectionString = "Data Source=CPSS.db;";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                string query = $"SELECT {table} FROM {column}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    comboboxname.Items.Add(reader[table].ToString());
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
