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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-EJ3J6CA\\SQLEXPRESS;Initial Catalog=emlak;Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from ev", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text= oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());     
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["sehir"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());
                ekle.SubItems.Add(oku["aciklama"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 anasayfa = new Form4();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
            {

                    baglan.Open();
                    string kayit = ("insert into ev (id,site,blok,no,satkira,oda,metre,fiyat,adsoyad,telefon,sehir,adres,aciklama) values (@id,@site,@blok,@no,@satkira,@oda,@metre,@fiyat,@adsoyad,@telefon,@sehir,@adres,@aciklama)");
                SqlCommand komut = new SqlCommand(kayit, baglan);

                komut.Parameters.AddWithValue("@id", textBox1.Text);
                komut.Parameters.AddWithValue("@site", comboBox1.Text);
                komut.Parameters.AddWithValue("@blok", comboBox2.Text);
                komut.Parameters.AddWithValue("@no", textBox2.Text);
                komut.Parameters.AddWithValue("@satkira", comboBox3.Text);
                komut.Parameters.AddWithValue("@oda", comboBox4.Text);
                komut.Parameters.AddWithValue("@metre", textBox3.Text);
                komut.Parameters.AddWithValue("@fiyat", textBox4.Text);
                komut.Parameters.AddWithValue("@adsoyad", textBox5.Text);
                komut.Parameters.AddWithValue("@telefon", textBox6.Text);
                komut.Parameters.AddWithValue("@sehir", textBox7.Text);
                komut.Parameters.AddWithValue("@adres", textBox8.Text);
                komut.Parameters.AddWithValue("@aciklama", textBox9.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from ev where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text; 
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[10].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[11].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[12].Text;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayit = ("update ev set id=@id,site=@site,blok=@blok,no=@no,satkira=@satkira,metre=@metre,fiyat=@fiyat,adsoyad=@adsoyad,telefon=@telefon,sehir=@sehir,adres=@adres,aciklama=@aciklama where id=(" + id + ")");
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@site", comboBox1.Text);
            komut.Parameters.AddWithValue("@blok", comboBox2.Text);
            komut.Parameters.AddWithValue("@no", textBox2.Text);
            komut.Parameters.AddWithValue("@satkira", comboBox3.Text);
            komut.Parameters.AddWithValue("@oda", comboBox4.Text);
            komut.Parameters.AddWithValue("@metre", textBox3.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox4.Text);
            komut.Parameters.AddWithValue("@adsoyad", textBox5.Text);
            komut.Parameters.AddWithValue("@telefon", textBox6.Text);
            komut.Parameters.AddWithValue("@sehir", textBox7.Text);
            komut.Parameters.AddWithValue("@adres", textBox8.Text);
            komut.Parameters.AddWithValue("@aciklama", textBox9.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Bilgiler Güncellendi.");
            verilerigoster();
        }
    }
}
