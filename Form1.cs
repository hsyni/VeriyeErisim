using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAcalisma2
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Server=.; database=KisiDb; uid=sa; pwd=123");

        public Form2()
        {
            con.Open();
            InitializeComponent();
            VerileriListele();
        }

        private void VerileriListele()
        {
            lstKisiler.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT Id, Ad FROM Kisiler", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = (int)dr["Id"];
                string ad = (string)dr["Ad"];
                lstKisiler.Items.Add(new Kisi(id, ad));
            }
            dr.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KisiEkle();
            VerileriListele();
        }

        private void KisiEkle()
        {
            string ad = txtAd.Text.Trim();
            if (ad == "") return;
            SqlCommand cmd = new SqlCommand("INSERT INTO Kisiler(Ad) VALUES(@p1)", con);
            cmd.Parameters.AddWithValue("@p1", ad);
            cmd.ExecuteNonQuery();
            txtAd.Clear();

        }

        private void txtAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnEkle.PerformClick();
            }
        }

        private void lstKisiler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                KisiSil();
                VerileriListele();
            }
        }

        private void KisiSil()
        {
            if (lstKisiler.SelectedIndex == -1) return;
            Kisi kisi =(Kisi)lstKisiler.SelectedItem;
            SqlCommand cmd = new SqlCommand("DELETE FROM Kisiler WHERE Id=@id",con);
            cmd.Parameters.AddWithValue("@id",kisi.Id);
            cmd.ExecuteNonQuery();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (lstKisiler.SelectedIndex == -1) return;
            Kisi kisi = (Kisi)lstKisiler.SelectedItem;
            DialogResult cevap = new Duzenle(con,kisi).ShowDialog();
            if (cevap == DialogResult.OK) VerileriListele();
          
        }
    }
}
