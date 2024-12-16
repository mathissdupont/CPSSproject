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
    public partial class registerwindow : Form
    {
        public registerwindow()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerwindow_Load(object sender, EventArgs e)
        {

        }

        private void registerusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerbttn_Click(object sender, EventArgs e)
        {
            databaseclass db = new databaseclass();
            string username = registerusername.Text; 
            string password = registerpass.Text;
            string email = registermail.Text;
            string oppass = registeroppass.Text;
            db.register(username,password,email,oppass);
            this.Close();
        }
    }
}
