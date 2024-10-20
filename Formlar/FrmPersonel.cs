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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities();

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON
                              


                           };
            departman.Properties.DataSource =( from x in db.TBLDEPARTMAN
                                              select new
                                              {
                                                  x.ID,
                                                  x.AD
                                              }).ToList();
            gridControl1.DataSource = degerler.ToList();
            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            ad1=db.TBLPERSONEL.First(x=>x.ID==1).AD;
            soyad1 = db.TBLPERSONEL.First(x=>x.ID==1).SOYAD;
            label8.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;
            label9.Text = ad1 + " " + soyad1;
            label6.Text = db.TBLPERSONEL.First(x=>x.ID==1).MAIL;
            label5.Text = db.TBLPERSONEL.First(x => x.ID == 1).TELEFON;

            //2

            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            label14.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            label15.Text = ad2 + " " + soyad2;
            label12.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            lbl1.Text = db.TBLPERSONEL.First(x => x.ID == 2).TELEFON;
            //3
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            label22.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            label23.Text = ad3 + " " + soyad3;
            label21.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;
            label20.Text = db.TBLPERSONEL.First(x => x.ID == 3).TELEFON;
            //4
            ad4 = db.TBLPERSONEL.First(x => x.ID == 9).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 9).SOYAD;
            label30.Text = db.TBLPERSONEL.First(x => x.ID == 9).TBLDEPARTMAN.AD;
            label31.Text = ad4 + " " + soyad4;
            label29.Text = db.TBLPERSONEL.First(x => x.ID == 9).MAIL;
            label28.Text = db.TBLPERSONEL.First(x => x.ID == 9).TELEFON;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON

                           };
            gridControl1.DataSource = degerler.ToList();



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txtmaıl.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            telefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD=TxtAd.Text;    
            t.SOYAD=txtsoyad.Text;
            t.MAIL = txtmaıl.Text;
            t.TELEFON=telefon.Text;
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            deger.AD = TxtAd.Text;
            deger.SOYAD = txtsoyad.Text;
            deger.TELEFON = telefon.Text;
            deger.MAIL = txtmaıl.Text;
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
