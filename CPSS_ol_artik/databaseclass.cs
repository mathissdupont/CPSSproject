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

        string randomID = Guid.NewGuid().ToString();
        public void LoadConfirmedOrdersToDataGridView(DataGridView gridView)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query = "SELECT * FROM orders";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridView.DataSource = dt;
                }
            }
        }

        public void MoveOrdersToConfirmed()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();

                
                string insertQuery = @"
                INSERT INTO orders (ID, ProductName, Quantity)
                SELECT @ID, ProductName, Quantity FROM orderstemp";

                
                string selectOrdersQuery = "SELECT ProductName, Quantity FROM orderstemp";
                using (SQLiteCommand selectCmd = new SQLiteCommand(selectOrdersQuery, conn))
                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        int quantity = Convert.ToInt32(reader["Quantity"]);

                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                        {
                            string randomID = Guid.NewGuid().ToString(); 
                            insertCmd.Parameters.AddWithValue("@ID", randomID);
                            insertCmd.Parameters.AddWithValue("@ProductName", productName);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                
                string deleteQuery = "DELETE FROM orderstemp";
                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    deleteCmd.ExecuteNonQuery();
                }
            }
        }


        public void LoadOrdersToDataGridView(DataGridView gridView)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query = "SELECT * FROM orderstemp";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridView.DataSource = dt;
                }
            }
        }

        public void AddOrder(string productName, int quantity)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query = "INSERT INTO orderstemp (ProductName, Quantity) VALUES (@ProductName, @Quantity)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

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
