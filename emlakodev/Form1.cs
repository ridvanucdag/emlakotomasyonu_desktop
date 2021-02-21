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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-EJ3J6CA\\SQLEXPRESS;Initial Catalog=emlak;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from uye where kullaniciadi='"+textBox1.Text+"' and sifre='"+textBox2.Text+"'", baglan);
            SqlDataReader dr = komut.ExecuteReader();


            if (dr.Read())
            {
                Form4 anasayfa = new Form4();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı yada şifreniz yanlış");
            }
            baglan.Close();
           
        }
    }
}
