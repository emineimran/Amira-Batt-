namespace AmiralBattıForm
{
    partial class GirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            this.sifreTxt = new System.Windows.Forms.TextBox();
            this.kullaniciAditxt = new System.Windows.Forms.TextBox();
            this.sifreLbl = new System.Windows.Forms.Label();
            this.kullaniciLbl = new System.Windows.Forms.Label();
            this.sifreGosterCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logoPB = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kapatPB = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapatPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // sifreTxt
            // 
            this.sifreTxt.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreTxt.Location = new System.Drawing.Point(193, 127);
            this.sifreTxt.Name = "sifreTxt";
            this.sifreTxt.Size = new System.Drawing.Size(205, 26);
            this.sifreTxt.TabIndex = 20;
            this.sifreTxt.TextChanged += new System.EventHandler(this.SifreTxt_TextChanged);

            // 
            // kullaniciAditxt
            // 
            this.kullaniciAditxt.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciAditxt.Location = new System.Drawing.Point(193, 95);
            this.kullaniciAditxt.Name = "kullaniciAditxt";
            this.kullaniciAditxt.Size = new System.Drawing.Size(205, 26);
            this.kullaniciAditxt.TabIndex = 19;

            // 
            // sifreLbl
            // 
            this.sifreLbl.AutoSize = true;
            this.sifreLbl.BackColor = System.Drawing.Color.Transparent;
            this.sifreLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreLbl.ForeColor = System.Drawing.Color.DarkOrange;
            this.sifreLbl.Location = new System.Drawing.Point(122, 130);
            this.sifreLbl.Name = "sifreLbl";
            this.sifreLbl.Size = new System.Drawing.Size(50, 23);
            this.sifreLbl.TabIndex = 18;
            this.sifreLbl.Text = "Şifre";
            // 
            // kullaniciLbl
            // 
            this.kullaniciLbl.AutoSize = true;
            this.kullaniciLbl.BackColor = System.Drawing.Color.Transparent;
            this.kullaniciLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciLbl.ForeColor = System.Drawing.Color.DarkOrange;
            this.kullaniciLbl.Location = new System.Drawing.Point(78, 98);
            this.kullaniciLbl.Name = "kullaniciLbl";
            this.kullaniciLbl.Size = new System.Drawing.Size(103, 23);
            this.kullaniciLbl.TabIndex = 17;
            this.kullaniciLbl.Text = "Kullanıcı Adı";
            // 
            // sifreGosterCheck
            // 
            this.sifreGosterCheck.AutoSize = true;
            this.sifreGosterCheck.BackColor = System.Drawing.Color.Transparent;
            this.sifreGosterCheck.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreGosterCheck.ForeColor = System.Drawing.Color.DarkOrange;
            this.sifreGosterCheck.Location = new System.Drawing.Point(310, 155);
            this.sifreGosterCheck.Name = "sifreGosterCheck";
            this.sifreGosterCheck.Size = new System.Drawing.Size(88, 17);
            this.sifreGosterCheck.TabIndex = 23;
            this.sifreGosterCheck.Text = "Şifreyi Göster";
            this.sifreGosterCheck.UseVisualStyleBackColor = false;
            this.sifreGosterCheck.CheckedChanged += new System.EventHandler(this.SifreGosterCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(117, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 65);
            this.label1.TabIndex = 24;
            this.label1.Text = "Amiral Battı ";
            // 
            // logoPB
            // 
            this.logoPB.BackColor = System.Drawing.Color.Transparent;
            this.logoPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPB.BackgroundImage")));
            this.logoPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPB.Location = new System.Drawing.Point(12, 12);
            this.logoPB.Name = "logoPB";
            this.logoPB.Size = new System.Drawing.Size(64, 57);
            this.logoPB.TabIndex = 25;
            this.logoPB.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(153, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 72);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // kapatPB
            // 
            this.kapatPB.BackColor = System.Drawing.Color.Transparent;
            this.kapatPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kapatPB.BackgroundImage")));
            this.kapatPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.kapatPB.Location = new System.Drawing.Point(309, 178);
            this.kapatPB.Name = "kapatPB";
            this.kapatPB.Size = new System.Drawing.Size(89, 67);
            this.kapatPB.TabIndex = 27;
            this.kapatPB.TabStop = false;
            this.kapatPB.Click += new System.EventHandler(this.KapatPB_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(193, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 39);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(509, 313);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.kapatPB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logoPB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreGosterCheck);
            this.Controls.Add(this.sifreTxt);
            this.Controls.Add(this.kullaniciAditxt);
            this.Controls.Add(this.sifreLbl);
            this.Controls.Add(this.kullaniciLbl);
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GirisForm";
            this.Load += new System.EventHandler(this.GirisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapatPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox sifreTxt;
        private System.Windows.Forms.TextBox kullaniciAditxt;
        private System.Windows.Forms.Label sifreLbl;
        private System.Windows.Forms.Label kullaniciLbl;
        private System.Windows.Forms.CheckBox sifreGosterCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logoPB;
        private System.Windows.Forms.PictureBox kapatPB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}