using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogOnline.DataKategori {
    public partial class ManajemenKategori : System.Web.UI.Page {
        private ClsKategori _kategori;
        private string strPesan;

        private void refresh_form() {
            Tbox_cari.Text = "";
            Tbox_id_kategori.Text = "";
            Tbox_nama_kategori.Text = "";
            Tbox_info_kategori.Text = "";

            Tbox_nama_kategori.Focus();
            Tbox_id_kategori.Text = _kategori.auto_number();

            bind_grid();
        }

        private void bind_grid() {
            Gview_kategori.DataSource = _kategori.tampil_data(Tbox_cari.Text);
            Gview_kategori.SelectedIndex = -1;
            Gview_kategori.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e) {
            _kategori = new ClsKategori();
           if (!IsPostBack) {
                refresh_form();
            }
        }

        protected void Btn_simpan_Click(object sender, EventArgs e) {
            try {
                ClsKategori Obj = new ClsKategori();
                Obj.PIdKategori = Obj.auto_number();
                Obj.PNmKategori = Tbox_nama_kategori.Text;
                Obj.PInfoKategori = Tbox_info_kategori.Text;
                if(Obj.simpan_data()) {
                    strPesan = "Data berhasil di simpan.";
                } else {
                    strPesan = "Data tidak berhasil di simpan.";
                }
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
                refresh_form();
            } catch(Exception ex) {
                strPesan = "Error : " + ex.Message;
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
            }
        }

        protected void Btn_ubah_Click(object sender, EventArgs e) {
            try {
                ClsKategori Obj = new ClsKategori();
                Obj.PIdKategori = Tbox_id_kategori.Text;
                Obj.PNmKategori = Tbox_nama_kategori.Text;
                Obj.PInfoKategori = Tbox_info_kategori.Text;
                if(Obj.update_data()) {
                    strPesan = "Data berhasil di update.";
                } else {
                    strPesan = "Data tidak berhasil di update.";
                }
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
                refresh_form();
            } catch(Exception ex) {
                strPesan = "Error : " + ex.Message;
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
            }
        }

        protected void Btn_hapus_Click(object sender, EventArgs e) {
            try {
                ClsKategori Obj = new ClsKategori();
                Obj.PIdKategori = Tbox_id_kategori.Text;
                if(Obj.hapus_data()) {
                    strPesan = "Data berhasil di hapus.";
                } else {
                    strPesan = "Data tidak berhasil hapus.";
                }
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
                refresh_form();
            } catch(Exception ex) {
                strPesan = "Error : " + ex.Message;
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Informasi",
                    string.Format("alert(\"{0}\");", strPesan),
                    true
                  );
            }
        }

        protected void Btn_batal_Click(object sender, EventArgs e) {
            refresh_form();
        }

        protected void Tbox_cari_TextChanged(object sender, EventArgs e) {
            Gview_kategori.DataSource = _kategori.tampil_data(Tbox_cari.Text);
            Gview_kategori.SelectedIndex = -1;
            Gview_kategori.DataBind();
        }

        protected void Gview_kategori_SelectedIndexChanged(object sender, EventArgs e) {
            Tbox_id_kategori.Text = Gview_kategori.SelectedDataKey["PIdKategori"].ToString();
            Tbox_nama_kategori.Text = Gview_kategori.SelectedDataKey["PNmKategori"].ToString();
            Tbox_info_kategori.Text = Gview_kategori.SelectedDataKey["PInfoKategori"].ToString();
        }

        protected void Gview_kategori_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            Gview_kategori.PageIndex = e.NewPageIndex;
            Gview_kategori.DataSource = _kategori.tampil_data(Tbox_cari.Text);
            Gview_kategori.DataBind();
            Gview_kategori.SelectedIndex = -1;
        }
    }
}