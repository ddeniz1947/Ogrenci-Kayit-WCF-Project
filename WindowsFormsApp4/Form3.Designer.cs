namespace WindowsFormsApp4
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.txt_gonder = new System.Windows.Forms.TextBox();
            this.txt_dogrula = new System.Windows.Forms.TextBox();
            this.btn_gonder = new System.Windows.Forms.Button();
            this.btn_dogrula = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.provider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.provider)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_gonder
            // 
            this.txt_gonder.Location = new System.Drawing.Point(75, 62);
            this.txt_gonder.Name = "txt_gonder";
            this.txt_gonder.Size = new System.Drawing.Size(100, 20);
            this.txt_gonder.TabIndex = 0;
            // 
            // txt_dogrula
            // 
            this.txt_dogrula.Location = new System.Drawing.Point(242, 62);
            this.txt_dogrula.Name = "txt_dogrula";
            this.txt_dogrula.Size = new System.Drawing.Size(100, 20);
            this.txt_dogrula.TabIndex = 1;
            // 
            // btn_gonder
            // 
            this.btn_gonder.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_gonder.Location = new System.Drawing.Point(78, 107);
            this.btn_gonder.Name = "btn_gonder";
            this.btn_gonder.Size = new System.Drawing.Size(75, 33);
            this.btn_gonder.TabIndex = 2;
            this.btn_gonder.Text = "Gönder";
            this.btn_gonder.UseVisualStyleBackColor = true;
            this.btn_gonder.Click += new System.EventHandler(this.btn_gonder_Click);
            // 
            // btn_dogrula
            // 
            this.btn_dogrula.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_dogrula.Location = new System.Drawing.Point(251, 107);
            this.btn_dogrula.Name = "btn_dogrula";
            this.btn_dogrula.Size = new System.Drawing.Size(75, 33);
            this.btn_dogrula.TabIndex = 3;
            this.btn_dogrula.Text = "Doğrula";
            this.btn_dogrula.UseVisualStyleBackColor = true;
            this.btn_dogrula.Click += new System.EventHandler(this.btn_dogrula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gmail Adresi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(220, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Doğrulama Kodu";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(157, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "İptal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // provider
            // 
            this.provider.ContainerControl = this;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_dogrula);
            this.Controls.Add(this.btn_gonder);
            this.Controls.Add(this.txt_dogrula);
            this.Controls.Add(this.txt_gonder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 240);
            this.Name = "Form3";
            this.Text = "Şifremi Unuttum";
            ((System.ComponentModel.ISupportInitialize)(this.provider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_gonder;
        private System.Windows.Forms.TextBox txt_dogrula;
        private System.Windows.Forms.Button btn_gonder;
        private System.Windows.Forms.Button btn_dogrula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider provider;
    }
}