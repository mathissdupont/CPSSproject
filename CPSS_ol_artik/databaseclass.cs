using System;
using System.Collections.Generic;
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
