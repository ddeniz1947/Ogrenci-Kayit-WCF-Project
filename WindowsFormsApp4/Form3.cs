using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp4
{

    public partial class Form3 : Form
    {
        SqlConnection baglanti3 = new SqlConnection("Data Source=DESKTOP-6R1I3SI\\SQLEXPRESS;Initial Catalog=Uyeler;Integrated Security=True");
   
        Form2 frm2 = new Form2();
        public Form3()
        {

            InitializeComponent();
        }
        int sayi;
        Random rnd = new Random();

        private void btn_gonder_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (baglanti3.State == ConnectionState.Closed)
            {
                baglanti3.Open();
            }
            cmd.Connection = baglanti3;
            sayi = rnd.Next(10000, 90000);
            cmd.CommandText = "update dogrulama set dogrulama='" + sayi + "'";
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            MailMessage msg = new MailMessage();
            SmtpClient sc = new SmtpClient();

            sc.Credentials = new System.Net.NetworkCredential("dd2894802@gmail.com", "deneme47");// İnternet Kimliği

     
            if (string.IsNullOrEmpty(txt_gonder.Text) || string.IsNullOrWhiteSpace(txt_gonder.Text))
            {
                provider.SetError(txt_gonder, "Lütfen E posta adresinizi giriniz!");
               
            }
            else
            {
                SqlParameter prmm = new SqlParameter("@eposta",txt_gonder.Text);
                string sql = "";
                sql = "SELECT * FROM eposta WHERE eposta = @eposta";
                SqlCommand cmd1 = new SqlCommand(sql, baglanti3);
                cmd1.Parameters.Add(prmm);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                if(baglanti3.State == ConnectionState.Closed)
                {
                    baglanti3.Open();
                }
                if (dt2.Rows.Count > 0)
                {
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;
                    msg.To.Add(txt_gonder.Text);
                    msg.From = new MailAddress("dd2894802@gmail.com", "deneme47");
                    msg.Subject = "Güvenlik Kodu";
                    msg.Body = "Bilgiler Programı Guvenlik Kodunuz" + " " + sayi.ToString() + " ";
                    sc.Send(msg);
                    MessageBox.Show("Mail Gönderildi!");
                }
                else
                    MessageBox.Show("Kayıtlı Kullanıcı Epostası Yanlış!");
            }
            baglanti3.Close();
            
        }

        private void btn_dogrula_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_gonder.Text) || string.IsNullOrWhiteSpace(txt_gonder.Text) || string.IsNullOrEmpty(txt_dogrula.Text) || string.IsNullOrWhiteSpace(txt_dogrula.Text))
            {
                provider.SetError(txt_gonder, "Bu alan boş bırakılamaz!");
                provider.SetError(txt_dogrula, "Bu alan boş bırakılamaz!");
            }
            else
            {
                if (txt_dogrula.Text == sayi.ToString())
                {
                    new Form4().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yanlıs Guvenlık Kodu");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Hide();

        }
    }
}
