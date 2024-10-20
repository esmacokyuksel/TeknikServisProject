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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        DBTEKNİKSERVİSEntities db = new DBTEKNİKSERVİSEntities();

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLURUN.Count().ToString();
            label7.Text=db.TBLKATEGORİ.Count().ToString(); 
            //Stok sayısını hesaplama
            label5.Text=db.TBLURUN.Sum(x=>x.STOK).ToString();

            // En yüksek ve en düşük stoka göre sıralama

            label19.Text = (from x in db.TBLURUN
                           orderby x.STOK descending
                           select x.AD).FirstOrDefault();
            //First or default en üstteki adı verecek


            label15.Text=(from x in db.TBLURUN
                          orderby x.STOK ascending
                          select x.AD).FirstOrDefault();


            //En yüksek ve en düşük fiyatlı ürün 
            label17.Text = (from x in db.TBLURUN
                            orderby x.SATISFIYAT descending
                            select x.AD).FirstOrDefault();
            lbl1.Text=(from x in db.TBLURUN
                         orderby x.SATISFIYAT ascending
                         select x.AD).FirstOrDefault();
            //Toplam Marka Sayısı
            label29.Text=(from x in db.TBLURUN
                          select x.MARKA).Distinct().Count().ToString();    

        }
        

        private void pictureEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
