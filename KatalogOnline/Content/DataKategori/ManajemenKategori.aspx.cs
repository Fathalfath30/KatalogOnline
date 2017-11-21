using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogOnline.Main_asp.DataKategori
{
    public partial class ManajemenKategori : System.Web.UI.Page
    {
        private ClsKategori CKategori;
        private string pesan;

        /* ----- [ MAIN SCRIPT ] ----- */
        private void BindGrid_Kategori()
        {
            Grid_Kategori.DataSource = CKategori.Tampil();
            Grid_Kategori.SelectedIndex = -1;
            Grid_Kategori.DataBind();
        }

        private void Refresh_Page()
        {
            BindGrid_Kategori();

            Txt_IdKategori.Text = CKategori.Autonumber();
            Txt_NmKategori.Text = "";
            Txt_InfoKategori.Text = "";
        }

        private void Pagination(GridViewPageEventArgs e)
        {
            Grid_Kategori.PageIndex = e.NewPageIndex;
            Grid_Kategori.DataSource = CKategori.Tampil();
            Grid_Kategori.DataBind();
            Grid_Kategori.SelectedIndex = -1;
        }

        private void Pilih_data()
        {
            Txt_IdKategori.Text = Grid_Kategori.SelectedDataKey["PIdKat"].ToString();
            Txt_NmKategori.Text = Grid_Kategori.SelectedDataKey["PNmKat"].ToString();
            Txt_InfoKategori.Text = Grid_Kategori.SelectedDataKey["PInfoKat"].ToString();
        }

        private void Simpan_data ()
        {
            try
            {
                CKategori = new ClsKategori();
                CKategori.PIdKat = Txt_IdKategori.Text.Trim();
                CKategori.PNmKat = Txt_NmKategori.Text.Trim();
                CKategori.PInfoKat = Txt_InfoKategori.Text.Trim();
                if (CKategori.Simpan() > 0)
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
            }
            Refresh_Page();
        }
        
        private void Update_data()
        {
            try
            {
                CKategori = new ClsKategori();
                CKategori.PIdKat = Txt_IdKategori.Text.Trim();
                CKategori.PNmKat = Txt_NmKategori.Text.Trim();
                CKategori.PInfoKat = Txt_InfoKategori.Text.Trim();
                if (CKategori.Ubah() > 0)
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
                CKategori = new ClsKategori();
                CKategori.PIdKat = Txt_IdKategori.Text.Trim();
                if (CKategori.Hapus() > 0)
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
            Grid_Kategori.DataSource = CKategori.Tampil(Txt_CariKategori.Text);
            Grid_Kategori.SelectedIndex = -1;
            Grid_Kategori.DataBind();
        }
        /* ----- [ AUTO GENERATE SCRIPT ] ----- */
        protected void Page_Load(object sender, EventArgs e)
        {
            CKategori = new ClsKategori();
            if (!IsPostBack)
            {
                Refresh_Page();
            }
        }

        protected void Grid_Kategori_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Pagination(e);
        }

        protected void Grid_Kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pilih_data();
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

        protected void Txt_CariKategori_TextChanged(object sender, EventArgs e)
        {
            Search_data();
        }
    }
}