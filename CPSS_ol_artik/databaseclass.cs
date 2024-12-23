﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
namespace CPSS_ol_artik
{
    public class databaseclass
    {
        public static int totalprice()
        {
            int totalPrice = 0;

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query = "SELECT Quantity, Price FROM orderstemp";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int quantity = Convert.ToInt32(reader["Quantity"]);
                        int price = Convert.ToInt32(reader["Price"]);
                        totalPrice += quantity * price;
                    }
                }
            }

            return totalPrice;
        }
        public static void LoadTableData(string tableName,DataGridView dataGrid)
        {
            string connectionString = "Data Source=CPSS.db;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Seçilen tablodaki verileri al
                    string query = $"SELECT * FROM {tableName}";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Verileri DataGridView'e yükle
                    dataGrid.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tablodaki verileri yüklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void LoadTablesToComboBox(ComboBox comboBoxTables)
        {
            string connectionString = "Data Source=CPSS.db;"; 
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string query = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    
                    while (reader.Read())
                    {
                        comboBoxTables.Items.Add(reader["name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tablo adlarını yüklerken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void PrintDataGridView(DataGridView dataGridView, PrintPageEventArgs e)
        {
            try
            {
                int yPosition = 0; 
                int rowHeight = 30; 

                Font font = new Font("Arial", 10); 
                Brush brush = Brushes.Black; 

                
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    string headerText = dataGridView.Columns[col].HeaderText;
                    e.Graphics.DrawString(headerText, font, brush, new PointF(100 + col * 100, yPosition));
                }

                yPosition += rowHeight;

                
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        string cellText = dataGridView.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                        e.Graphics.DrawString(cellText, font, brush, new PointF(100 + col * 100, yPosition));
                    }
                    yPosition += rowHeight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazdırma sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void delorderfinite(string UrunID,DataGridView dgv)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query = "DELETE FROM orders WHERE OrderGroupID = @UrunID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UrunID", UrunID);

                    int rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected > 0)
                    {
                        MessageBox.Show("Sipariş Başarıyla Silindi");
                        LoadConfirmedOrdersToDataGridView(dgv);
                    }
                    else
                    {
                        MessageBox.Show("Sipariş silinirken bir hata ile karşılaşıldı");
                    }
                }
            }
        }
        public void register(string username,string password,string email,string adminpass)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO user (username, password, email) VALUES (@username, @password, @email)";
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email)||string.IsNullOrEmpty(adminpass))
                {
                    MessageBox.Show("Lütfen hiçbir alanı boş bırakmayınız");
                    return;
                }
                else
                {
                    try
                    {
                        if (adminpass == "fos35")
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@email", email);
                                int rowsaffected = cmd.ExecuteNonQuery();
                                if (rowsaffected > 0)
                                {
                                    MessageBox.Show("Kayıt Başarıyla Eklendi.");
                                }
                                else
                                {
                                    MessageBox.Show("Kayıt Eklerken Hata ile Karşılaşıldı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Admin Şifresi Hatalı");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata Oluştu:{ex.Message}");
                    }
                }
            }
        }

        string randomID = Guid.NewGuid().ToString();


        public void MoveOrdersToConfirmed(int totalPrice)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();

                
                string orderGroupID = Guid.NewGuid().ToString();

                string insertQuery = @"
                INSERT INTO orders (ProductName, Quantity, OrderGroupID, Price)
                SELECT ProductName, Quantity, @orderGroupID, @TotalPrice FROM orderstemp";

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
                            insertCmd.Parameters.AddWithValue("@ProductName", productName);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@orderGroupID", orderGroupID);
                            insertCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
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
        public void LoadConfirmedOrdersToDataGridView(DataGridView gridView)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();


                string query = @"
                SELECT 
                DISTINCT OrderGroupID,
                GROUP_CONCAT(ProductName || ' (' || Quantity || ')', ', ') AS Products,
                Price AS Price
                FROM orders
                GROUP BY OrderGroupID";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridView.DataSource = dt;
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

        public void AddOrder(string productName, int quantity,DataGridView dataGridView)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query1 = "UPDATE products SET stock = stock - @quantity WHERE products = @productName";
                string query = @"
                    INSERT INTO orderstemp (ProductName, Quantity, Price) 
                    SELECT @ProductName, @Quantity, Price 
                    FROM products 
                    WHERE products = @ProductName";



                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
                using(SQLiteCommand cmd = new SQLiteCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                    LoadStocksToDataGridView(dataGridView);
                    mainmenu mm = new mainmenu();
                    loaddatatocombobox("products", "products", mm.orderdellproname);
                }
            }
        }
        public void DelOrder(string productName, int quantity, DataGridView dataGridView)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=CPSS.db;"))
            {
                conn.Open();
                string query1 = "UPDATE products SET stock = stock + @quantity WHERE products = @productName";
                string query = "DELETE FROM orderstemp WHERE ProductName = @ProductName AND Quantity = @Quantity";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                    LoadStocksToDataGridView(dataGridView);
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

        public void delProductStock(string productname, int productvalue,DataGridView dataGridView)
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
                    LoadStocksToDataGridView(dataGridView);
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
        public void UpdateProductStock(string productname, int productvalue,DataGridView dataGridView)
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
                    LoadStocksToDataGridView(dataGridView);
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
        public void addProductStock(string productname, int productvalue,DataGridView dataGridView)
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
                    LoadStocksToDataGridView(dataGridView);
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
