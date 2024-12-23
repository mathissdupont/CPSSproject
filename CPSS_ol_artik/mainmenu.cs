﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
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
            dbclass.loaddatatocombobox("products","products",orderdellproname);
            databaseclass.LoadTablesToComboBox(datatablecombox);
            dbclass.LoadStocksToDataGridView(stockgoruntulegrid);
            dbclass.LoadOrdersToDataGridView(orderdetailsgrid);

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
            
            string selectedProduct = orderaddproname.SelectedItem?.ToString();
            
            if (string.IsNullOrEmpty(selectedProduct))
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }
            if (orderaddmiktar.Value > 0)
            {
                decimal totalPrice = databaseclass.totalprice();
                totalpricelabel.Text = $"{totalPrice}";
                int quantity = (int)orderaddmiktar.Value;
                databaseclass dbclass = new databaseclass();
                dbclass.AddOrder(selectedProduct, quantity,stockgoruntulegrid);
                MessageBox.Show("Sipariş Eklendi");
                dbclass.LoadOrdersToDataGridView(orderdetailsgrid);
                dbclass.loaddatatocombobox("products", "products", orderdellproname);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz."); 
            }
        }

        private void mainmenu_Load(object sender, EventArgs e)
        {

        }

        private void addnewproductbttn_Click(object sender, EventArgs e)
        {
            addproduct addproduct = new addproduct();
            addproduct.ShowDialog();
        }

        public void stockproductname_SelectedIndexChanged(object sender, EventArgs e)
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
                dbclass.addProductStock(secilenurun, productvalue,stockgoruntulegrid);
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
                dbclass.UpdateProductStock(secilenurun, productvalue,stockgoruntulegrid);
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
                databaseclass.delProductStock(secilenurun,productvalue,stockgoruntulegrid);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            databaseclass dbclass = new databaseclass();
            int totalPrice = databaseclass.totalprice();
            
            dbclass.MoveOrdersToConfirmed(totalPrice); 
            dbclass.LoadOrdersToDataGridView(orderdetailsgrid); 
            dbclass.LoadConfirmedOrdersToDataGridView(confirmedordersgrid); 
            MessageBox.Show("Siparişler onaylandı ve Kaydedildi.!");
        }

        private void orderdell_Click(object sender, EventArgs e)
        {
            string selectedProduct = orderdellproname.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedProduct))
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }
            if (orderdellmiktar.Value > 0)
            {
                int totalPrice = databaseclass.totalprice();
                totalpricelabel.Text = $"{totalPrice}";
                int quantity = (int)orderdellmiktar.Value;
                databaseclass dbclass = new databaseclass();
                dbclass.DelOrder(selectedProduct, quantity, stockgoruntulegrid);
                MessageBox.Show("Sipariş Silindi");
                dbclass.LoadOrdersToDataGridView(orderdetailsgrid);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
            }
        }

        private void orderaddproname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void orderaddmiktar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void confirmedordersgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ordercancelID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ordercancelbttn_Click(object sender, EventArgs e)
        {
            databaseclass db = new databaseclass();
            string selectedID = ordercancelID.Text;
            db.delorderfinite(selectedID,confirmedordersgrid);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += printDocument1_PrintPage;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDocument
                };

                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazdırma işlemi başlatılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            databaseclass.PrintDataGridView(printgridview, e);
        }

        private void selecttablebttn_Click(object sender, EventArgs e)
        {
            string datatablecombo = datatablecombox.SelectedItem?.ToString();
            databaseclass.LoadTableData(datatablecombo,printgridview);
        }

        private void datatablecombox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void orderdetailsgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
