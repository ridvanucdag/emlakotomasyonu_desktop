using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace emlakodev
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-EJ3J6CA\\SQLEXPRESS;Initial Catalog=emlak;Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from uye", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kullaniciadi"].ToString());
                ekle.SubItems.Add(oku["sifre"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                baglan.Open();
                string kayit = ("Insert into uye (id,kullaniciadi,sifre,adsoyad) values (@id,@kullaniciadi,@sifre,@adsoyad)");
                SqlCommand komut = new SqlCommand(kayit, baglan);

                komut.Parameters.AddWithValue("@id", textBox1.Text);
                komut.Parameters.AddWithValue("@kullaniciadi", textBox2.Text);
                komut.Parameters.AddWithValue("@sifre", textBox3.Text);
                komut.Parameters.AddWithValue("@adsoyad", textBox4.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
                verilerigoster();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        int id = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 anasayfa = new Form4();
            anasayfa.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from uye where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayit = ("Update uye set id=@id,kullaniciadi=@kullaniciadi,sifre=@sifre,adsoyad=@adsoyad where id=(" + id + ")");
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@kullaniciadi", textBox2.Text);
            komut.Parameters.AddWithValue("@sifre", textBox3.Text);
            komut.Parameters.AddWithValue("@adsoyad", textBox4.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Bilgiler Güncellendi.");
            verilerigoster();
        }
    }
}
