using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace KatalogOnline.DataPengguna {
    public partial class DaftarBaru : System.Web.UI.Page {
        ClsDaftarBaru _pengguna = new ClsDaftarBaru();

        private void bersih() {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNama.Text = "";
            txtNoTelp.Text = "";
            txtNoKartu.Text = "";
            txtKonfirmasi.Text = "";
            txtUsername.Focus();
        }


        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                txtUsername.Focus();
                bersih();
            }
        }


        protected void btnDaftar_Click(object sender, EventArgs e) {

            try {
                int _hasil;
                _pengguna.PUserName = txtUsername.Text;
                _pengguna.PPassword = txtPassword.Text;
                _pengguna.PNama = txtNama.Text;
                _pengguna.PNoTelp = txtNoTelp.Text;
                _pengguna.PNoKartuKredit = txtNoKartu.Text;
                _pengguna.PHak = "2";
                _hasil = _pengguna.Simpan();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Berhasil Disimpan\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "SIMPAN DATA", pesan, true);
                    bersih();
                } else {
                    string pesan = "alert(\"Data Tidak Berhasil Disimpan\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "SIMPAN DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
            }
        }

        protected void btnBatal_Click(object sender, EventArgs e) {
            bersih();
        }
    }
}