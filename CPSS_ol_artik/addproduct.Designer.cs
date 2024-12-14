namespace CPSS_ol_artik
{
    partial class addproduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addproductname = new System.Windows.Forms.TextBox();
            this.addproductID = new System.Windows.Forms.TextBox();
            this.addproductvalue = new System.Windows.Forms.TextBox();
            this.addproductbttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yeni Ürün Ekle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(27, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ürün ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(27, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ürün Miktar";
            // 
            // addproductname
            // 
            this.addproductname.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addproductname.Location = new System.Drawing.Point(186, 77);
            this.addproductname.Name = "addproductname";
            this.addproductname.Size = new System.Drawing.Size(284, 39);
            this.addproductname.TabIndex = 4;
            this.addproductname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // addproductID
            // 
            this.addproductID.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addproductID.Location = new System.Drawing.Point(186, 144);
            this.addproductID.Name = "addproductID";
            this.addproductID.Size = new System.Drawing.Size(284, 39);
            this.addproductID.TabIndex = 5;
            // 
            // addproductvalue
            // 
            this.addproductvalue.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addproductvalue.Location = new System.Drawing.Point(186, 208);
            this.addproductvalue.Name = "addproductvalue";
            this.addproductvalue.Size = new System.Drawing.Size(284, 39);
            this.addproductvalue.TabIndex = 6;
            // 
            // addproductbttn
            // 
            this.addproductbttn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addproductbttn.Location = new System.Drawing.Point(186, 269);
            this.addproductbttn.Name = "addproductbttn";
            this.addproductbttn.Size = new System.Drawing.Size(283, 45);
            this.addproductbttn.TabIndex = 7;
            this.addproductbttn.Text = "Ürün Ekle";
            this.addproductbttn.UseVisualStyleBackColor = true;
            // 
            // addproduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 334);
            this.Controls.Add(this.addproductbttn);
            this.Controls.Add(this.addproductvalue);
            this.Controls.Add(this.addproductID);
            this.Controls.Add(this.addproductname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addproduct";
            this.Text = "addproduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addproductname;
        private System.Windows.Forms.TextBox addproductID;
        private System.Windows.Forms.TextBox addproductvalue;
        private System.Windows.Forms.Button addproductbttn;
    }
}