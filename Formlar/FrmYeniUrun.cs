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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            DBTEKNİKSERVİSEntities db=new DBTEKNİKSERVİSEntities(); 
            TBLURUN t = new TBLURUN();
            t.AD = txturunad.Text;
            t.ALISFIYAT = decimal.Parse(txtalis.Text);
            t.SATISFIYAT = decimal.Parse(txtsatis.Text);
            t.STOK = short.Parse(txtstok.Text);
            t.KATEGORI = byte.Parse(txtkategori.Text);
            t.MARKA=txtmarka.Text;  
            db.TBLURUN.Add(t);  
            db.SaveChanges();
            MessageBox.Show("Ürünler Başarıyla Eklendi");


        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {

        }
    }
}
