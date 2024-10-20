using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisProject.Formlar
{
    public partial class FrmCariList : Form
    {
        public FrmCariList()
        {
            InitializeComponent();
        }

        DBTEKNİKSERVİSEntities db = new DBTEKNİKSERVİSEntities();

        void metot1()
        {
            var degerler = from u in db.TBLCARI
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.BANKA
                           };

            gridControl1.DataSource = degerler.ToList();
        }


            private void FrmCariList_Load(object sender, EventArgs e)
            {

            label12.Text = db.TBLCARI.Count().ToString();
            label14.Text = db.TBLCARI.Count().ToString();
            label16.Text = (from x in db.TBLCARI
                            select x.IL).Distinct().Count().ToString();

            metot1();

            }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();

            t.AD = TxtUrunAd.Text;
            t.SOYAD = TXTSOYAD.Text;
            t.TELEFON =texttelefon.Text;
            t.MAIL = textmail.Text;
            t.IL = textil.Text;
            t.ILCE = textilçe.Text;
            t.BANKA = textBanka.Text;   
            //Alttaki komutlar verileri veritabanına kaydetmemizi sağlar
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TXTSOYAD.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            texttelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            textmail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            textil.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            textilçe.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
            textBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtUrunAd.Text;
            deger.SOYAD = TXTSOYAD.Text;
            deger.TELEFON = texttelefon.Text;
            deger.MAIL = textmail.Text;
            deger.IL = textil.Text;
            deger.ILCE = textilçe.Text;
            deger.BANKA = textBanka.Text;
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    }



