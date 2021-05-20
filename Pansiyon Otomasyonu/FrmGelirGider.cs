using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Pansiyon;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            //Stokların giderleri
            int personel;
            personel = Convert.ToInt32(textBox1.Text);
            LblPersonelMaas.Text = (personel * 1500).ToString();

            Int32 sonuc;
            sonuc = Convert.ToInt32(LblKasaToplamTutar.Text) - (Convert.ToInt32(LblPersonelMaas.Text) + Convert.ToInt32(LblAlınanUrunler1.Text) + Convert.ToInt32(LblAlınanUrunler2.Text) + Convert.ToInt32(LblAlınanUrunler3.Text) + Convert.ToInt32(LblFatura1.Text) + Convert.ToInt32(LblFatura2.Text) + Convert.ToInt32(LblFatura3.Text));
            LblSonuc.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(Ucret) as toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblKasaToplamTutar.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            //Gida giderleri

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                LblAlınanUrunler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();

            //İçecek giderleri

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(Icecek) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                LblAlınanUrunler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();

            //Çerezler giderleri

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select sum(Cerezler) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                LblAlınanUrunler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            //elektrik Faturası

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                LblFatura1.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();

            //su Faturası

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select sum(Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                LblFatura2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();

            //İnternet Faturası

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select sum(Elektrik) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                LblFatura3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();

            
        }
    }
}
