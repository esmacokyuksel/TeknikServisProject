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

namespace TeknikServisProject.Formlar
{
    public partial class FrmCariler : Form
    {
        public FrmCariler()
        {
            InitializeComponent();
        }
        DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=MNSTR;Initial Catalog=DBTEKNİKSERVİS;Integrated Security=True; ");

        private void FrmCariler_Load(object sender, EventArgs e)
        {
           
           
            //Cari il istatistiğinde data griddeki tablo
            gridControl1.DataSource = db.TBLCARI.OrderBy(x=>x.IL).GroupBy(y=>y.IL).Select(z=>new {İl=z.Key,Toplam=z.Count()}).ToList();   
       baglanti.Open();
            SqlCommand KOMUT = new SqlCommand("select IL,COUNT(*) FROM TBLCARI group by IL",baglanti);
      SqlDataReader dr=KOMUT.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
