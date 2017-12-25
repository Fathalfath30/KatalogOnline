using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogOnline.DataKategori {
    public partial class ManajemenKategori : System.Web.UI.Page {
        ClsKategori _kategori = new ClsKategori();

        private void BindGrid() {
            gvKategori.DataSource =
                _kategori.TampilData(txtCariNama.Text);
            gvKategori.SelectedIndex = -1;
            gvKategori.DataBind();
        }
        private void bersih() {
            txtIdKat.Text = "";
            txtNmKat.Text = "";
            txtInfoKat.Text = "";
            txtCariNama.Text = "";
            txtNmKat.Focus();
            BindGrid();
        }
        protected void Page_Load(object sender, EventArgs e) {

            if(!IsPostBack) {
                if(Session["Hak"] == null || Session["Hak"].ToString() != "1") {
                    string pesan = "alert(\"Tidak Mempunyai Hak\");";
                    ScriptManager.RegisterStartupScript
                    (this, typeof(string), "HAK AKSES", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }
                txtNmKat.Focus();
                bersih();
                txtIdKat.Text = _kategori.Autonumber();
            }
        }
        protected void btnSimpan_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _kategori.PIdKat = txtIdKat.Text;
                _kategori.PNmKat = txtNmKat.Text;
                _kategori.PInfoKat = txtInfoKat.Text;
                _hasil = _kategori.Simpan();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Behasil Disimpan\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "SIMPAN DATA", pesan, true);
                    bersih();
                    txtIdKat.Text = _kategori.Autonumber();
                } else {
                    string pesan = "alert(\"Data Tidak Berhasil Disimpan\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "SIMPAN DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
            }

        }
        protected void btnUbah_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _kategori.PIdKat = txtIdKat.Text;
                _kategori.PNmKat = txtNmKat.Text;
                _kategori.PInfoKat = txtInfoKat.Text;
                _hasil = _kategori.Ubah();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Behasil Diubah\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "UBAH DATA", pesan, true);
                    bersih();
                    txtIdKat.Text = _kategori.Autonumber();
                } else {
                    string pesan = "alert(\"Data Tidak Berhasil Diubah\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "UBAH DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
            }
        }
        protected void btnHapus_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _kategori.PIdKat = txtIdKat.Text;
                _hasil = _kategori.Hapus();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Behasil Dihapus\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "HAPUS DATA", pesan, true);
                    bersih();
                    txtIdKat.Text = _kategori.Autonumber();
                } else {
                    string pesan = "alert(\"Data Tidak Berhasil Dihapus\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "HAPUS DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
            }

        }
        protected void btnBatal_Click(object sender, EventArgs e) {
            bersih();
            txtIdKat.Text = _kategori.Autonumber();
        }
        protected void txtCariNama_TextChanged(object sender, EventArgs e) {
            BindGrid();
        }

        protected void gvKategori_SelectedIndexChanged(object sender, EventArgs e) {
            txtIdKat.Text = gvKategori.SelectedRow.Cells[1].Text.ToString();
            txtNmKat.Text = gvKategori.SelectedRow.Cells[2].Text.ToString();
            txtInfoKat.Text = gvKategori.SelectedRow.Cells[3].Text.ToString();

        }

        protected void gvKategori_PageIndexChanging(object sender,
            GridViewPageEventArgs e) {
            gvKategori.PageIndex = e.NewPageIndex;
            gvKategori.DataSource = _kategori.TampilData("");
            gvKategori.DataBind();
            gvKategori.SelectedIndex = -1;
        }
    }
}