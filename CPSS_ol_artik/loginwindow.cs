using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace CPSS_ol_artik
{
    public partial class loginwindow : Form
    {
        private string connectionString = "Data Source=CPSS.db;";
        public loginwindow()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginwindow_Load(object sender, EventArgs e)
        {

        }

        private void loginbttn_Click(object sender, EventArgs e)
        {
            string usernametxt = usernamebox.Text;
            string passwordtxt = passwordbox.Text;
            if (string.IsNullOrEmpty(usernametxt) || string.IsNullOrEmpty(passwordtxt)) 
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş olamaz");
                return;
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                    using(SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username",usernametxt);
                        cmd.Parameters.AddWithValue ("@password", passwordtxt);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            mainmenu mainmenu = new mainmenu();
                            mainmenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu {ex.Message}");
            }
        }

        private void registerbttn_Click(object sender, EventArgs e)
        {
            registerwindow registerwindow = new registerwindow();
            registerwindow.Show();
        }
    }
}
