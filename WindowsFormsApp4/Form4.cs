using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti4 = new SqlConnection("Data Source=DESKTOP-6R1I3SI\\SQLEXPRESS;Initial Catalog=Uyeler;Integrated Security=True");
        
        public Form4()
        {

            InitializeComponent();
        }

        private void btn_yenisifre_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (string.IsNullOrEmpty(txt_yenisifre.Text) || string.IsNullOrWhiteSpace(txt_yenisifre.Text))
            {
                MessageBox.Show("Lütfen Yeni Şifrenizi Giriniz!");
            }
            else
            {
                if (baglanti4.State == ConnectionState.Closed)
                {
                    baglanti4.Open();
                }
                cmd.Connection = baglanti4;
                cmd.CommandText = "update Bilgiler set sifre='" + txt_yenisifre.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti4.Close();
                MessageBox.Show("Sifreniz Guncellenmiştir!");
                new Form1().Show();
                this.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

                if (checkBox1.Checked)
                {
                    txt_yenisifre.PasswordChar = '\0';

                }
                else
                {
                    txt_yenisifre.PasswordChar = '*';
                }
            }
        
    }
}
