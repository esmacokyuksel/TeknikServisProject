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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }


        DBTEKNİKSERVİSEntities db = new DBTEKNİKSERVİSEntities(); 

        void metot1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORI=u.TBLKATEGORİ.AD,  
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };

            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //var degerler = db.TBLURUN.ToList();
            metot1();
         
            LkKategori.Properties.DataSource = db.TBLKATEGORİ.ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();

            t.AD = TxtUrunAd.Text;
            t.MARKA=TxtUrunMarka.Text;  
            t.ALISFIYAT=decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.DURUM = true;
            t.KATEGORI = byte.Parse( LkKategori.EditValue.ToString());

            //Alttaki komutlar verileri veritabanına kaydetmemizi sağlar
            db.TBLURUN.Add(t);  
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            metot1();
        }



        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtUrunMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id=int.Parse(TxtId.Text);
            var deger = db.TBLURUN.Find(id);
            deger.AD=TxtUrunAd.Text;
            deger.MARKA = TxtUrunMarka.Text;
            deger.STOK = short.Parse(TxtStok.Text);
            deger.ALISFIYAT=decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            deger.KATEGORI = byte.Parse(LkKategori.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
