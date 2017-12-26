using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Configuration;
using System.Data;

namespace KatalogOnline.Report {
    public partial class LaporanPenjualan : System.Web.UI.Page {
        string StrConn =
        WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
        ReportDocument rptDoc = new ReportDocument();

        void BindReport() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {

                SqlCommand SqlCmd = new SqlCommand();
                DateTime _TglAwal =
                    DateTime.ParseExact(dtpTanggalAwal.Text,
                    "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                DateTime _TglAkhir =
                        DateTime.ParseExact(dtpTanggalAkhir.Text,
                    "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "SELECT Pesan.KdPesan, Pesan.TglPesan, " +
                    "Pesan.UserName,barang.NmBrg,detil_pesan.JmlPesan, " +
                    "detil_pesan.HrgPesan,detil_pesan.SubTotal FROM pesan " +
                    "INNER JOIN detil_pesan ON pesan.KdPesan=detil_pesan.KdPesan " +
                    "INNER JOIN barang ON barang.KdBrg=detil_pesan.KdBrg " +
                    "WHERE pesan.TglPesan BETWEEN '" + _TglAwal +
                    "' AND '" + _TglAkhir + "'";
                SqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = SqlCmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "penjualan");
                rptDoc.Load(Server.MapPath("~/Report/CRLapPenjualan.rpt"));
                rptDoc.SetDataSource(ds);
                rptDoc.SetParameterValue("PAwal", _TglAwal.Date);
                rptDoc.SetParameterValue("PAkhir", _TglAkhir.Date);
                CrystalReportViewer1.ReportSource = rptDoc;
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if(!this.IsPostBack) {
               /* if(Session["Hak"] == null || Session["Hak"].ToString() == "2") {
                    string pesan = "alert(\"Tidak Mempunyai Hak\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "HAK AKSES", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }*/
            }
        }

        protected void btnCetak_Click(object sender, EventArgs e) {
            BindReport();
            CrystalReportViewer1.RefreshReport();
            rptDoc.Refresh();
        }

        protected void lbpdf_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                Response, true, "LaporanPenjualan");
            rptDoc.Refresh();
        }

        protected void lbexcel_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.ExcelRecord,
                Response, true, "LaporanPenjualan");
            rptDoc.Refresh();
        }

        protected void lbword_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.WordForWindows,
                Response, true, "LaporanPenjualan");
            rptDoc.Refresh();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.RichText,
                Response, true, "LaporanPenjualan");
            rptDoc.Refresh();
        }
    }
}