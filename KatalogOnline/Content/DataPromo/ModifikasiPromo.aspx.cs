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

namespace KatalogOnline.Main_asp.DataPromo
{
    public partial class ModifikasiPromo : System.Web.UI.Page
    {
        ClsBarang _barang = new ClsBarang();
        ClsPromo _promo = new ClsPromo();

        private void bersih()
        {
            txtCariNama.Text = "";
            BindGrid();
        }

        private void BindGrid()
        {
            gvBarang.DataSource = _barang.TampilData3(txtCariNama.Text);
            gvBarang.SelectedIndex = -1;
            gvBarang.DataBind();
        }

        private void BindDetailView()
        {
            dvPromo.DataSource =
                                _promo.TampilData(gvBarang.SelectedDataKey["PKdBrg"].ToString());
            dvPromo.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["Hak"].ToString() == "2")
                {
                    string pesan = "alert(\"Tidak Mempunyai Hak\");";
                    ScriptManager.RegisterStartupScript
                                        (this, typeof(string), "HAK AKSES", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }
                bersih();
            }
        }


        protected void gvBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDetailView();
            dvPromo.Visible = true;
        }

        protected void dvPromo_PageIndexChanging(object sender,
                            DetailsViewPageEventArgs e)
        {
            dvPromo.PageIndex = e.NewPageIndex;
            BindDetailView();
        }

        protected void dvPromo_ItemDeleting(object sender,
                            DetailsViewDeleteEventArgs e)
        {
            try
            {
                int _hasil;
                _promo.PKdBrg = dvPromo.DataKey["PKdBrg"].ToString();
                _hasil = _promo.Hapus();
                if (_hasil == 1)
                {
                    string pesan = "alert(\"Data Berhasil Dihapus\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                        "HAPUS DATA", pesan, true);
                    BindDetailView();
                    dvPromo.Visible = false;
                    gvBarang.SelectedIndex = -1;
                }
                else
                {
                    string pesan = "alert(\"Data Tidak Berhasil Dihapus\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                        "HAPUS DATA", pesan, true);
                }

            }
            catch (Exception ex)
            {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA: '" + errorex + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                    "HAPUS DATA", pesan, true);
            }
        }

        protected void dvPromo_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvPromo.ChangeMode(e.NewMode);
            BindDetailView();
        }

        protected void dvPromo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            try
            {
                int _hasil;
                _promo.PKdBrg = dvPromo.DataKey["PKdBrg"].ToString();
                _promo.PInfoPromo =
                                    ((TextBox)dvPromo.Rows[1].Cells[1].Controls[0]).Text;
                _promo.PHrgPromo =
                                    System.Convert.ToDouble(
                                    ((TextBox)dvPromo.Rows[2].Cells[1].Controls[0]).Text);
                _hasil = _promo.Ubah();
                if (_hasil == 1)
                {
                    string pesan = "alert(\"Data Berhasil Diubah\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                        "UBAH DATA", pesan, true);
                    dvPromo.ChangeMode(DetailsViewMode.ReadOnly);
                    BindDetailView();
                    dvPromo.Visible = false;
                    gvBarang.SelectedIndex = -1;
                }
                else
                {
                    string pesan = "alert(\"Data Tidak Berhasil Diubah\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                        "UBAH DATA", pesan, true);
                }
            }
            catch (Exception ex)
            {
                string errorex = ex.Message;
                string pesan = "alert(\"ERROR LAINNYA: '" + errorex + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                    "UBAH DATA", pesan, true);
            }
        }
        protected void txtCariNama_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
            dvPromo.Visible = false;
        }
    }
}