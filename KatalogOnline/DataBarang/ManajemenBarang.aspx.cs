using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogOnline.DataBarang {
    public partial class ManajemenBarang : System.Web.UI.Page {
        ClsBarang _barang = new ClsBarang();
        ClsKategori _kategori = new ClsKategori();
        private void BindDropDownKategori() {
            Dlist_nama_kategori.DataSource = _kategori.TampilData("");
            Dlist_nama_kategori.DataValueField = "PIdKat";
            Dlist_nama_kategori.DataTextField = "PNmKat";
            Dlist_nama_kategori.DataBind();

            Dlist_cari_kategori.DataSource = _kategori.TampilData("");
            Dlist_cari_kategori.DataValueField = "PIdKat";
            Dlist_cari_kategori.DataTextField = "PNmKat";
            Dlist_cari_kategori.DataBind();
        }

        private void BindGrid() {
            Gview_manajemen_barang.DataSource = _barang.TampilData(Tbox_cari_nama.Text, Dlist_cari_kategori.SelectedItem.Value.ToString());
            //  Gview_manajemen_barang.DataSource = _barang.TampilData(Tbox_cari_nama.Text);
            Gview_manajemen_barang.SelectedIndex = -1;
            Gview_manajemen_barang.DataBind();
        }

        private void bersih() {
            Tbox_kode_barang.Text = "";
            Tbox_nama_barang.Text = "";
            Tbox_harga_barang.Text = "";
            Tbox_info_barang.Text = "";
            Tbox_stock_barang.Text = "";
            Tbox_cari_nama.Text = "";
            BindDropDownKategori();
            BindGrid();
        }

        protected void Page_Load(object sender, EventArgs e) {
            if(!this.IsPostBack) {
                /*if(Session["Hak"].ToString() == "2") {
                    string pesan = "alert(\"Tidak Mempunyai Hak\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "HAK AKSES", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }*/

                Tbox_nama_barang.Focus();
                bersih();
                Tbox_kode_barang.Text = _barang.Autonumber();
            }
        }

        protected void Gview_manajemen_barang_SelectedIndexChanged(object sender, EventArgs e) {
            Tbox_kode_barang.Text = Gview_manajemen_barang.SelectedDataKey["PKdBrg"].ToString();
            Dlist_nama_kategori.SelectedItem.Value = Gview_manajemen_barang.SelectedDataKey["PIdKat"].ToString();
            Tbox_nama_barang.Text = Gview_manajemen_barang.SelectedRow.Cells[1].Text.ToString();
            Tbox_harga_barang.Text = Gview_manajemen_barang.SelectedRow.Cells[2].Text.ToString();
            Tbox_info_barang.Text = Gview_manajemen_barang.SelectedRow.Cells[3].Text.ToString();
            Tbox_stock_barang.Text = Gview_manajemen_barang.SelectedRow.Cells[4].Text.ToString();
        }

        protected void Gview_manajemen_barang_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            Gview_manajemen_barang.PageIndex = e.NewPageIndex;
            Gview_manajemen_barang.DataSource = _barang.TampilData("", "");
            //  Gview_manajemen_barang.DataSource = _barang.TampilData("");
            Gview_manajemen_barang.DataBind();
            Gview_manajemen_barang.SelectedIndex = -1;
        }

        protected void Btn_simpan_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _barang.PKdBrg = Tbox_kode_barang.Text;
                _barang.PNmBrg = Tbox_nama_barang.Text;
                _barang.PHrgBrg = System.Convert.ToDouble(Tbox_harga_barang.Text);
                _barang.PInfoBrg = Tbox_info_barang.Text;
                string GbrBrg = "";
                if(Fupload_foto_barang.HasFile == true) {
                    GbrBrg = System.IO.Path.GetFileName(Fupload_foto_barang.PostedFile.FileName);
                    Fupload_foto_barang.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBrg);
                }

                _barang.PGbrBrg = GbrBrg;
                _barang.PStokBrg = System.Convert.ToInt32(Tbox_stock_barang.Text);
                _barang.PIdKat = Dlist_nama_kategori.SelectedItem.Value.ToString();
                _hasil = _barang.Simpan();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Berhasil Disimpan\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "SIMPAN DATA", pesan, true);
                    bersih();
                    Tbox_kode_barang.Text = _barang.Autonumber();
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

        protected void Btn_ubah_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _barang.PKdBrg = Tbox_kode_barang.Text;
                _barang.PNmBrg = Tbox_nama_barang.Text;
                _barang.PHrgBrg = System.Convert.ToDouble(Tbox_harga_barang.Text);
                _barang.PInfoBrg = Tbox_info_barang.Text;
                string GbrBrg = "";
                if(Fupload_foto_barang.HasFile == true) {
                    GbrBrg = System.IO.Path.GetFileName(Fupload_foto_barang.PostedFile.FileName);
                    Fupload_foto_barang.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBrg);
                } else {
                    GbrBrg = Gview_manajemen_barang.SelectedDataKey["PGbrBrg"].ToString();
                }

                _barang.PGbrBrg = GbrBrg;
                _barang.PStokBrg = System.Convert.ToInt32(Tbox_stock_barang.Text);
                _barang.PIdKat = Dlist_nama_kategori.SelectedItem.Value.ToString();
                _hasil = _barang.Ubah();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Berhasil Diubah\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "UBAH DATA", pesan, true);
                    bersih();
                    Tbox_kode_barang.Text = _barang.Autonumber();
                } else {
                    string pesan = "alert(\"Data Tidak Berhasil Diubah\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "UBAH DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
            }
        }

        protected void Btn_hapus_Click(object sender, EventArgs e) {
            try {
                int _hasil;
                _barang.PKdBrg = Tbox_kode_barang.Text;
                _hasil = _barang.Hapus();
                if(_hasil == 1) {
                    string pesan = "alert(\"Data Berhasil DiHapus\");";
                    ScriptManager.RegisterStartupScript
                        (this, GetType(), "HAPUS DATA", pesan, true);
                    bersih();
                    Tbox_kode_barang.Text = _barang.Autonumber();

                } else {
                    string pesan = "alert(\"Data Tidak Berhasil DiHapus\");";
                    ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                }
            } catch(Exception ex) {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
            }
        }

        protected void Btn_batal_Click(object sender, EventArgs e) {
            bersih();
            Tbox_kode_barang.Text = _barang.Autonumber();
        }

        protected void Dlist_cari_kategori_SelectedIndexChanged(object sender, EventArgs e) {
            BindGrid();
        }
    }
}