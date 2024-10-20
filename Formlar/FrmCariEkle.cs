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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
  }
        DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities();

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = txturunad.Text;
            t.SOYAD = txtsoyad.Text;
            t.IL = txtil.Text;
            t.ILCE = textilce.Text;
            t.ADRES = textadres.Text;
            t.TELEFON = txtelefon.Text;
            t.MAIL = txtmail.Text;
            t.BANKA = textbanka.Text;
            t.VERGIDAIRESI = textvergidairesi.Text;
            t.VERGINO = textvergino.Text;
            t.STATUS = textstatu.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
