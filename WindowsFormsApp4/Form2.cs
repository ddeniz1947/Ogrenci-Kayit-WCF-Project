using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        SqlConnection baglanti1 = new SqlConnection("Data Source=DESKTOP-6R1I3SI\\SQLEXPRESS;Initial Catalog=Uyeler;Integrated Security=True");
        public Form2()
        {

            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            SqlParameter prm1 = new SqlParameter("@kadi", txt_kadi.Text);
            SqlParameter prm2 = new SqlParameter("@sifre", txt_sifre.Text);
            string sql = "";
            sql = "SELECT * FROM bilgiler WHERE kadi = @kadi AND sifre =@sifre";
            SqlCommand cmd = new SqlCommand(sql, baglanti1);/*Sql Sorgusu ve baglantı degıskenının bırbırıne baglamak */
            cmd.Parameters.Add(prm1);
            cmd.Parameters.Add(prm2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti1.State == ConnectionState.Closed)
            {
                baglanti1.Open();
            }
            if (string.IsNullOrEmpty(txt_kadi.Text) || string.IsNullOrWhiteSpace(txt_kadi.Text) || string.IsNullOrEmpty(txt_sifre.Text) || string.IsNullOrWhiteSpace(txt_sifre.Text))
            {
                provider.SetError(txt_kadi, "Bu alan boş geçilemez");
                provider.SetError(txt_sifre, "Bu alan boş geçilemez");

                return;
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Giriş Başarılı!", "Hosgeldiniz!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Form1().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bilgiler Hatalıdır!");
                }
            }
            provider.Clear();
            baglanti1.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txt_sifre.PasswordChar = '\0';

            }
            else
            {
                txt_sifre.PasswordChar = '*' ;
            }
        }

        private void btn_sifre_unuttum_Click(object sende, EventArgs e) {

            new Form3().Show();
            this.Hide();
         
        }
        }
        }

        
    


    

