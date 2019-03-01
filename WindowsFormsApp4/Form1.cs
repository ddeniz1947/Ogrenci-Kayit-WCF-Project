using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{

    public partial class Form1 : Form
    {
        DataTable tablo = new DataTable();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6R1I3SI\\SQLEXPRESS;Initial Catalog=VERİTABANI;Integrated Security=True");
        public Form1()

        {

            InitializeComponent();
        }
        void temizleme()
        {
            txt_isim.Text = "";
            txt_soyisim.Text = "";
            txt_not.Text = "";
        }


        private void txt_isim_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex(@"^[a-zA-ZğĞçÇöÖüÜşŞİı]*$");
            //e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            //            && !char.IsSeparator(e.KeyChar); 

            //e.Handled = ((e.KeyChar >= (char)21) && (e.KeyChar <= (char)64)) || ((e.KeyChar >= (char)91) && (e.KeyChar <= (char)96)) || ((e.KeyChar >= (char)123) && (e.KeyChar <= (char)126)) || ((e.KeyChar >= (char)130) && (e.KeyChar <= (char)134)) || ((e.KeyChar >= (char)136) && (e.KeyChar <= (char)152));
            //Regex r = new Regex(@"^[a-zA-ZğĞçÇöÖüÜşŞİı]*$");
            txt_isim.MaxLength = 30;

            if (txt_isim.TextLength >= 29 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Maksimum Karakter Sayısına Ulaştınız!");
            }


            if ((!r.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)/* && ((txt_isim.TextLength <= 15) || (txt_isim.TextLength >= 0))*/)
            {

                e.Handled = true;
            }
            //if (txt_isim.TextLength == 20)
            //{

            //    MessageBox.Show("Maksimum Karakter Sayısına Ulaştınız!");


            //}


        }
        private void txt_soyisim__KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_soyisim.MaxLength = 30;
            if (txt_soyisim.TextLength >= 29 && e.KeyChar != (char)Keys.Back)
            {

                MessageBox.Show("Maksimum Karakter Sayısına Ulaştınız!");

            }


            Regex w = new Regex(@"^[a-zA-ZğĞçÇöÖüÜşŞİı]*$");
            if ((!w.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }



        private void txt_not_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //bool durum = false;
            //int a = 0;
            //if (txt_not.Text != "")
            //    a = Convert.ToInt32(txt_not.Text);

            //if (a >= 0 && a <= 100)
            //{
            //    durum = true;
            //}
            //if (durum == true)
            //{
            //    e.Handled = true;
            //}

        }


        bool durum;
        void mukerrer()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand komut = new SqlCommand("select * from dene where isim = @p1 AND soyisim = @p2 AND notu = @p3", baglanti);

            komut.Parameters.AddWithValue("@p1", txt_isim.Text);
            komut.Parameters.AddWithValue("@p2", txt_soyisim.Text);
            komut.Parameters.AddWithValue("@p3", txt_not.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            dr.Close();
            baglanti.Close();

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            //ErrorProvider provider = new ErrorProvider();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
           // deneme();
            mukerrer();
        
            provider.Clear();
            if (durum == true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                if (string.IsNullOrEmpty(txt_isim.Text) || string.IsNullOrWhiteSpace(txt_isim.Text))
                {
                    provider.SetError(txt_isim, "Bu alan boş geçilemez");

                    return;
                }
                else
                    provider.Clear();

                if (string.IsNullOrEmpty(txt_soyisim.Text) || string.IsNullOrWhiteSpace(txt_soyisim.Text))
                {
                    provider.SetError(txt_soyisim, "Bu alan boş geçilemez");
                    return;
                }
                else
                    provider.Clear();

                if (string.IsNullOrEmpty(txt_not.Text) || string.IsNullOrWhiteSpace(txt_not.Text))
                {
                    provider.SetError(txt_not, "Bu alan boş geçilemez");
                    return;
                }
                else
                    provider.Clear();


                string s1 = txt_isim.Text;
                string s2 = txt_soyisim.Text;
                Regex r = new Regex(@"\s+");
                string s3 = r.Replace(s1, @" ");
                string s4 = r.Replace(s2, @" ");


                cmd.CommandText = "INSERT INTO dene(isim,soyisim,notu) VALUES ('" + s3.Trim() + "','" + s4.Trim() + "','" + int.Parse(txt_not.Text.Trim()) + "')";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listeleme();
                temizleme();
                MessageBox.Show("KAYIT TAMAMLANMIŞTIR!");
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //void deneme()
        //{
        //    if (baglanti.State == ConnectionState.Closed)
        //    {
        //        baglanti.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = baglanti;
        //    cmd.CommandText = "select * from dene  ";
        //    var data = cmd.ExecuteReader();
        //    var deneme = data.Read().ToString();
        //    baglanti.Close();

        //}

        void listeleme()
        {

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "select * from dene";
            SqlDataAdapter adpr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpr.Fill(ds, "dene");
            dataGridView1.DataSource = ds.Tables["dene"];
            dataGridView1.Columns[0].Visible = false;
            /* --TABLONUN İLK SÜTUNU OLAN ID KISMININ GÖZÜKMEMESİ İÇİN*/

            dataGridView1.ClearSelection();
            baglanti.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mukerrer();
            cmb_box_ara.Items.Add("İSİM VE SOYİSİM ARA");
            cmb_box_ara.Items.Add("NOTA GÖRE ARA");

            //lbl_not2.Visible = false;
            //lbl_isoyisim.Visible = false;
            //txt_filtre.Visible = false;
            //txt_not1.Visible = false;
            //txt_not2.Visible = false;
            btn_ara.Visible = false;
            panelnot.Visible = false;
            paneladsoyad.Visible = false;

            dataGridView1.ClearSelection();
            listeleme();
        }

        public void btn_sil_Click(object sender, EventArgs e)
        {
            mukerrer();


            if (durum == true)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                if (string.IsNullOrEmpty(txt_isim.Text) || string.IsNullOrWhiteSpace(txt_isim.Text))
                {
                    MessageBox.Show("Boş Değer Silinemez", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txt_soyisim.Text) || string.IsNullOrWhiteSpace(txt_soyisim.Text))
                {
                    MessageBox.Show("Boş Değer Silinemez", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txt_not.Text) || string.IsNullOrWhiteSpace(txt_not.Text))
                {
                    MessageBox.Show("Boş Değer Silinemez", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show("SİLMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "delete from dene where id=@notu";
                cmd.Parameters.AddWithValue("@notu", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("KAYIT SİLİNMİŞTİR");
                listeleme();
                temizleme();
            }


        }

        public void btn_guncelle_Click(object sender, EventArgs e)
        {
            mukerrer();

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            if (durum == true)
            {
                if (string.IsNullOrEmpty(txt_isim.Text) || string.IsNullOrWhiteSpace(txt_isim.Text))
                {
                    return;
                }
                if (string.IsNullOrEmpty(txt_soyisim.Text) || string.IsNullOrWhiteSpace(txt_soyisim.Text))
                {
                    return;
                }
                if (string.IsNullOrEmpty(txt_not.Text) || string.IsNullOrWhiteSpace(txt_not.Text))
                {
                    return;
                }




                SqlCommand cmd = new SqlCommand();
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                cmd.Connection = baglanti;
                cmd.CommandText = "update dene set isim ='" + txt_isim.Text + "',soyisim='" + txt_soyisim.Text + "',notu='" + int.Parse(txt_not.Text) + "'where id=@notu";
                cmd.Parameters.AddWithValue("@notu", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();

                MessageBox.Show("GUNCELLEME TAMAMLANMISTIR");
                temizleme();
                listeleme();

            }
            else
            {

                MessageBox.Show("Bu kayıt zaten var", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                temizleme();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_isim.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            txt_soyisim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            txt_not.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            mukerrer();
            dataGridView1.Columns[1].HeaderText = "İSİM";
            dataGridView1.Columns[2].HeaderText = "SOYİSİM";
            dataGridView1.Columns[3].HeaderText = "NOT";
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("'Segoe Script'", 12, FontStyle.Bold);


            dataGridView1.ClearSelection();

        }

        //private void txt_not_KeyUp(object sender, KeyEventArgs e)
        //{
        //    bool durum = false;
        //    int a = 0;

        //    var k = txt_not.Text;
        //    //a = Convert.ToInt32(txt_not.Text);

        //    //if (a < 0 || a > 100)
        //    //{
        //    //    e.Handled = true;
        //    //}
        //    ////if (durum == true)
        //    ////{
        //    ////    e.Handled = true;
        //    ////}

        //}

        //private void txt_not_KeyDown(object sender, KeyEventArgs e)
        //{
        //    int a = 0;
        //    var k = txt_not.Text;
        //    if()
        //    {

        //    }
        //    //a = Convert.ToInt32(txt_not.Text);

        //    //if (a < 0 || a > 100)
        //    //{
        //    //    e.Handled = true;
        //    //}

        //}

        private void txt_not_Leave(object sender, EventArgs e)
        {
            bool not = true;
            if (string.IsNullOrEmpty(txt_not.Text) || string.IsNullOrWhiteSpace(txt_not.Text))
            {
                return;
                not = false;
            }
            if (not = true)
            {
                if (Convert.ToInt32(txt_not.Text) < 0 || Convert.ToInt32(txt_not.Text) > 100)
                {
                    MessageBox.Show("Değer 0-100 arasında olmalı");
                    txt_not.Text = "";
                }
            }
        }
        int notu;
        void sil(int not)
        {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "delete from dene where id=@notu";
                cmd.Parameters.AddWithValue("@notu", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listeleme();
            
        }
    
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
           

            if (e.Button == MouseButtons.Right)
            {
                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (satir > -1)
                //{

                    dataGridView1.Rows[satir].Selected = true;
                    //txt_isim.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                    //txt_soyisim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                    //txt_not.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
                    notu = Convert.ToInt32(dataGridView1.Rows[satir].Cells["id"].Value);

               // }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            sil(notu);
         
        }
        //private DataView dtViewFilter(string filtre)
        //{
        //    DataView dv = new DataView(tablo);
        //    dv.RowFilter = "AD LIKE '" + dataGridView1 + "%'";
        //    return dv;
        //}
        private void txt_filtre_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "select * from dene  ";
            SqlDataAdapter adpr = new SqlDataAdapter(cmd);
            tablo.Clear();
            //DataTable ds = new DataTable();
            //adpr.Fill(ds);

            ////KISAYOL   SqlDataAdapter da = new SqlDataAdapter("select * from dene", baglanti);
            //   //tablo = new DataTable();
            adpr.Fill(tablo);


            DataView dv = tablo.DefaultView;


            // dv.RowFilter = "isim Like '" + txt_filtre.Text + "%' OR soyisim Like'" + txt_filtre.Text + "%'";

            //dv.RowFilter = "isim Like '%" + txt_filtre.Text + "%' ORD soyisim Like '%" + txt_filtre.Text + "%'";
            /*var s */
            dv.RowFilter = "isim  + ' ' + soyisim Like '%" + txt_filtre.Text + "%'";
            //dv.RowFilter = "isim Like '"+ txt_filtre.Text+ "% '";
            dataGridView1.DataSource = dv;
            baglanti.Close();
            cmd.Dispose();
        }


        private void cmb_box_ara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_box_ara.SelectedIndex == 0)
            {
                btn_ara.Visible = false;
                paneladsoyad.Visible = true;
                panelnot.Visible = false;
            }
            else if (cmb_box_ara.SelectedIndex == 1)
            {
                btn_ara.Visible = true;
                paneladsoyad.Visible = false;
                panelnot.Visible = true;
            }
        }



        private void btn_ara_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "select * from dene ";
            SqlDataAdapter adpr = new SqlDataAdapter(cmd);
            tablo.Clear();
            adpr.Fill(tablo);
            DataView dv = tablo.DefaultView;
            if (string.IsNullOrEmpty(txt_not1.Text) || string.IsNullOrWhiteSpace(txt_not1.Text) || string.IsNullOrEmpty(txt_not2.Text) || string.IsNullOrWhiteSpace(txt_not2.Text))
            {
                MessageBox.Show("Lütfen Değer Aralıklarını Giriniz!");
            }
            else
            {
                if (txt_not1.Text != null && txt_not2.Text != null)
                {
                    dv.RowFilter = "notu >= '" + txt_not1.Text + "' AND notu <='" + txt_not2.Text + "'";
                }
            }
            listeleme();
            dataGridView1.DataSource = dv;
            baglanti.Close();

        }
    }
}




