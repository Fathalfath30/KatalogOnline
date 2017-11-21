using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogOnline.Main_asp.DataBarang
{
    public partial class ManajemenBarang : System.Web.UI.Page
    {
        private string pesan = "";
        private ClsKategori CKategori;
        private ClsBarang CBarang;

        /* ----- [ MAIN SCRIPT ] ----- */
        private void BindGrid_Kategori()
        {
            Grid_Barang.DataSource = CBarang.Tampil();
            Grid_Barang.SelectedIndex = -1;
            Grid_Barang.DataBind();
        }

        private void BindCmb_Kategori()
        {
            Cmb_Kategori.DataSource = CKategori.Tampil();
            Cmb_Kategori.DataValueField = "PIdKat";
            Cmb_Kategori.DataTextField = "PNmKat";
            Cmb_Kategori.DataBind();

            Cmb_Kategori2.DataSource = CKategori.Tampil();
            Cmb_Kategori2.DataValueField = "PIdKat";
            Cmb_Kategori2.DataTextField = "PNmKat";
            Cmb_Kategori2.DataBind();
        }

        private void Refresh_Page()
        {
            BindGrid_Kategori();
            BindCmb_Kategori();

            Txt_IdBarang.Text = CBarang.Autonumber();
            Txt_NmBarang.Text = "";
            Txt_HargaBarang.Text = "0";
            Txt_InfoBarang.Text = "";
            Txt_stock.Text = "0";

            Txt_NmBarang.Focus();
        }

        private void Pagination(GridViewPageEventArgs e)
        {
            Grid_Barang.PageIndex = e.NewPageIndex;
            Grid_Barang.DataSource = CBarang.Tampil();
            Grid_Barang.DataBind();
            Grid_Barang.SelectedIndex = -1;
        }

        private void Pilih_data()
        {
            Txt_IdBarang.Text = Grid_Barang.SelectedDataKey["PKdBrg"].ToString();
            Txt_NmBarang.Text = Grid_Barang.SelectedDataKey["PNmBrg"].ToString();
            Txt_HargaBarang.Text = Grid_Barang.SelectedDataKey["PHrgBrg"].ToString();
            Txt_InfoBarang.Text = Grid_Barang.SelectedDataKey["PInfoBrg"].ToString();
            Txt_stock.Text = Grid_Barang.SelectedDataKey["PStokBrg"].ToString();
        }

        private void Simpan_data()
        {
            try
            {
                CBarang = new ClsBarang();
                CBarang.PKdBrg = Txt_IdBarang.Text.Trim();
                CBarang.PNmBrg = Txt_NmBarang.Text.Trim();
                CBarang.PHrgBrg = Convert.ToInt32(Txt_HargaBarang.Text.Trim());
                CBarang.PInfoBrg = Txt_InfoBarang.Text.Trim();
                CBarang.PIdKat = Cmb_Kategori2.SelectedValue;
                if (Fu_GbrBarang.HasFile)
                {
                    CBarang.PGbrBrg = Path.GetFileName(Fu_GbrBarang.PostedFile.FileName);
                    Fu_GbrBarang.SaveAs(Server.MapPath(string.Format("~/User_files/Upload/{0}", CBarang.PGbrBrg)));
                }
                else
                {
                    CBarang.PGbrBrg = "default.jpg";
                }
                CBarang.PStokBrg = Convert.ToInt32(Txt_stock.Text.Trim());

                if (CBarang.Simpan() > 0)
                {
                    pesan = string.Format("alert('{0}');", "Data telah berhasil ditambahan.");
                }
                else
                {
                    pesan = string.Format("alert('{0}');", "Data gagal ditambahan.");
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);
            }
            catch (Exception ex)
            {
                pesan = string.Format("alert('{0}');", ex.Message.Replace("'", "\'"));
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            Refresh_Page();
        }

        private void Update_data()
        {
            try
            {
                CBarang = new ClsBarang();
                CBarang.PKdBrg = Txt_IdBarang.Text.Trim();
                CBarang.PNmBrg = Txt_NmBarang.Text.Trim();
                CBarang.PHrgBrg = Convert.ToInt32(Txt_HargaBarang.Text.Trim());
                CBarang.PInfoBrg = Txt_InfoBarang.Text.Trim();
                CBarang.PIdKat = Cmb_Kategori2.SelectedValue;
                if (Fu_GbrBarang.HasFile)
                {
                    CBarang.PGbrBrg = Path.GetFileName(Fu_GbrBarang.PostedFile.FileName);
                    Fu_GbrBarang.SaveAs(Server.MapPath(string.Format("~/User_files/Upload/{0}", CBarang.PGbrBrg)));
                }
                else
                {
                    CBarang.PGbrBrg = "";
                }
                CBarang.PStokBrg = Convert.ToInt32(Txt_stock.Text.Trim());

                if (CBarang.Ubah() > 0)
                {
                    pesan = string.Format("alert('{0}');", "Data telah berhasil diubah.");
                }
                else
                {
                    pesan = string.Format("alert('{0}');", "Data gagal diubah.");
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);
            }
            catch (Exception ex)
            {
                pesan = string.Format("alert('{0}');", ex.Message.Replace("'", "\'"));
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);
            }
            Refresh_Page();
        }

        private void Hapus_data()
        {
            try
            {
                CBarang = new ClsBarang();
                CBarang.PKdBrg = Txt_IdBarang.Text.Trim();
                if (CBarang.Hapus() > 0)
                {
                    pesan = string.Format("alert('{0}');", "Data telah berhasil dihapus.");
                }
                else
                {
                    pesan = string.Format("alert('{0}');", "Data gagal dihapus.");
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);
            }
            catch (Exception ex)
            {
                pesan = string.Format("alert('{0}');", ex.Message.Replace("'", "\'"));
                ScriptManager.RegisterStartupScript(this, typeof(string), "Pesan Server", pesan, true);
            }
            Refresh_Page();
        }

        private void Search_data()
        {
            /*
            Grid_Kategori.DataSource = CKategori.Tampil(Txt_CariKategori.Text);
            Grid_Kategori.SelectedIndex = -1;
            Grid_Kategori.DataBind();*/
        }
        /* ----- [ AUTO GENERATE SCRIPT ] ----- */
        protected void Page_Load(object sender, EventArgs e)
        {
            CBarang = new ClsBarang();
            CKategori = new ClsKategori();
            if (!IsPostBack)
            {
                Refresh_Page();
            }
        }

        protected void Grid_Barang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pilih_data();
        }

        protected void Grid_Barang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Pagination(e);
        }

        protected void BtnSimpan_Click(object sender, EventArgs e)
        {
            Simpan_data();
        }

        protected void BtnUbah_Click(object sender, EventArgs e)
        {
            Update_data();
        }

        protected void BtnHapus_Click(object sender, EventArgs e)
        {
            Hapus_data();
        }

        protected void BtnBatal_Click(object sender, EventArgs e)
        {
            Refresh_Page();
        }
    }
}