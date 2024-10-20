using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisProject.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities();

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler=db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka=z.Key,    
                Toplam=z.Count()
            }); 
            gridControl1.DataSource = degerler.ToList(); 

            //Marka sayısı
            label2.Text= db.TBLURUN.Count().ToString(); 

            //Ürün sayısı

            label7.Text =(from x in db.TBLURUN
                          select x.MARKA).Distinct().Count().ToString();

            //En Yüksek Fiyatlı Marka

            label5.Text = (from x in db.TBLURUN
                           orderby x.SATISFIYAT descending
                           select x.MARKA).FirstOrDefault();

            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 3);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Bosch", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Fakir", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Kumtel", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Samsung", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Xiaomi", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("BUZDOLABI", 3);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("TELEVİZYON", 1);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("FIRIN", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("DONDURUCU", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("ÜTÜ", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("KAHVE MAKİNESİ", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("SÜPÜRGE", 2);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("MUTFAK ROBOTU", 3);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("TOST MAKİNESİ", 1);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("OCAK", 2);
           

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
