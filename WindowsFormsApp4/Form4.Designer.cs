namespace WindowsFormsApp4
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.txt_yenisifre = new System.Windows.Forms.TextBox();
            this.lbl_yenisifre = new System.Windows.Forms.Label();
            this.btn_yenisifre = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_yenisifre
            // 
            this.txt_yenisifre.Location = new System.Drawing.Point(231, 45);
            this.txt_yenisifre.Name = "txt_yenisifre";
            this.txt_yenisifre.PasswordChar = '*';
            this.txt_yenisifre.Size = new System.Drawing.Size(100, 20);
            this.txt_yenisifre.TabIndex = 0;
            this.txt_yenisifre.UseSystemPasswordChar = true;
            // 
            // lbl_yenisifre
            // 
            this.lbl_yenisifre.AutoSize = true;
            this.lbl_yenisifre.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_yenisifre.Location = new System.Drawing.Point(42, 44);
            this.lbl_yenisifre.Name = "lbl_yenisifre";
            this.lbl_yenisifre.Size = new System.Drawing.Size(152, 19);
            this.lbl_yenisifre.TabIndex = 1;
            this.lbl_yenisifre.Text = "Yeni Şifrenizi Giriniz";
            // 
            // btn_yenisifre
            // 
            this.btn_yenisifre.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yenisifre.Location = new System.Drawing.Point(161, 71);
            this.btn_yenisifre.Name = "btn_yenisifre";
            this.btn_yenisifre.Size = new System.Drawing.Size(75, 29);
            this.btn_yenisifre.TabIndex = 2;
            this.btn_yenisifre.Text = "Onayla";
            this.btn_yenisifre.UseVisualStyleBackColor = true;
            this.btn_yenisifre.Click += new System.EventHandler(this.btn_yenisifre_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(338, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_yenisifre);
            this.Controls.Add(this.lbl_yenisifre);
            this.Controls.Add(this.txt_yenisifre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Yeni Şifre Oluştur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_yenisifre;
        private System.Windows.Forms.Label lbl_yenisifre;
        private System.Windows.Forms.Button btn_yenisifre;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}