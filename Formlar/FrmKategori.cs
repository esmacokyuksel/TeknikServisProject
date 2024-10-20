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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities();

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLKATEGORİ
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList(); 
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLKATEGORİ t=new TBLKATEGORİ();
            t.AD = TxtUrunAd.Text;
            db.TBLKATEGORİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Eklendi");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLKATEGORİ
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //ID VE KATEGORİ ADI GRİDE TAŞIMA
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger=db.TBLKATEGORİ.Find(id);
            db.TBLKATEGORİ.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id=int.Parse(TxtId.Text);
            var deger = db.TBLKATEGORİ.Find(id);
            deger.AD = TxtUrunAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
