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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }
        DBTEKNİKSERVİSEntities db = new DBTEKNİKSERVİSEntities();

        private void btnkaydet_Click(object sender, EventArgs e)
        {
TBLURUNHAREKET t=new TBLURUNHAREKET();
            t.URUN = int.Parse(txturunıd.Text);
            t.MUSTERI = int.Parse(txtmusteri.Text);
            t.PERSONEL = short.Parse(txpersonel.Text);
            t.TARIH = DateTime.Parse(txttarih.Text);
            t.ADET = short.Parse(textadet.Text);
            t.FIYAT = decimal.Parse(textsatis.Text);
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün satışı yapıldı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
