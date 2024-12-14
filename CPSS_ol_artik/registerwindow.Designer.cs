namespace CPSS_ol_artik
{
    partial class registerwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerwindow));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.registerusername = new System.Windows.Forms.TextBox();
            this.registerpass = new System.Windows.Forms.TextBox();
            this.registermail = new System.Windows.Forms.TextBox();
            this.registeroppass = new System.Windows.Forms.TextBox();
            this.registerbttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(308, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(110, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(110, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(110, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "E-mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(110, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 38);
            this.label4.TabIndex = 4;
            this.label4.Text = "OPPassword:";
            // 
            // registerusername
            // 
            this.registerusername.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registerusername.Location = new System.Drawing.Point(330, 173);
            this.registerusername.Name = "registerusername";
            this.registerusername.Size = new System.Drawing.Size(298, 45);
            this.registerusername.TabIndex = 5;
            // 
            // registerpass
            // 
            this.registerpass.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registerpass.Location = new System.Drawing.Point(330, 246);
            this.registerpass.Name = "registerpass";
            this.registerpass.Size = new System.Drawing.Size(298, 45);
            this.registerpass.TabIndex = 6;
            // 
            // registermail
            // 
            this.registermail.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registermail.Location = new System.Drawing.Point(330, 312);
            this.registermail.Name = "registermail";
            this.registermail.Size = new System.Drawing.Size(298, 45);
            this.registermail.TabIndex = 7;
            this.registermail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // registeroppass
            // 
            this.registeroppass.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registeroppass.Location = new System.Drawing.Point(330, 386);
            this.registeroppass.Name = "registeroppass";
            this.registeroppass.Size = new System.Drawing.Size(298, 45);
            this.registeroppass.TabIndex = 8;
            // 
            // registerbttn
            // 
            this.registerbttn.Location = new System.Drawing.Point(330, 466);
            this.registerbttn.Name = "registerbttn";
            this.registerbttn.Size = new System.Drawing.Size(297, 54);
            this.registerbttn.TabIndex = 9;
            this.registerbttn.Text = "Kayıt Ol";
            this.registerbttn.UseVisualStyleBackColor = true;
            // 
            // registerwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 609);
            this.Controls.Add(this.registerbttn);
            this.Controls.Add(this.registeroppass);
            this.Controls.Add(this.registermail);
            this.Controls.Add(this.registerpass);
            this.Controls.Add(this.registerusername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "registerwindow";
            this.Text = "Kayıt Ol";
            this.Load += new System.EventHandler(this.registerwindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox registerusername;
        private System.Windows.Forms.TextBox registerpass;
        private System.Windows.Forms.TextBox registermail;
        private System.Windows.Forms.TextBox registeroppass;
        private System.Windows.Forms.Button registerbttn;
    }
}