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
    }
}
