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
    public partial class Duzenle : Form
    {
        private readonly SqlConnection con;
        private readonly Kisi kisi;
        public Duzenle(SqlConnection con, Kisi kisi)
        {
            InitializeComponent();
            this.con = con;
            this.kisi = kisi;
            txtAd.Text = kisi.Ad;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string yeniAd = txtAd.Text.Trim();
            if (yeniAd == "") return;
            var cmd = new SqlCommand("UPDATE Kisiler SET Ad=@p1 WHERE Id=@P2", con);
            cmd.Parameters.AddWithValue("@p1", yeniAd);
            cmd.Parameters.AddWithValue("@p2",kisi.Id);
            cmd.ExecuteNonQuery();
            DialogResult = DialogResult.OK;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
