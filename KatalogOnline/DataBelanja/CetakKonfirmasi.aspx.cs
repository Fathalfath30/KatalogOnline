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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Configuration;

namespace KatalogOnline.DataBelanja {
    public partial class CetakKonfirmasi : System.Web.UI.Page {
        string StrConn =
    WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
        ReportDocument rptDoc = new ReportDocument();

        void BindReport() {
            using(SqlConnection conn = new SqlConnection(StrConn)) {
                SqlCommand cmd = new SqlCommand();
                string _KdPesan = Session["xKdPesan"].ToString();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT pesan.KdPesan,pesan.TglPesan," +
                "pengguna.UserName, pengguna.Nama,pengguna.NoTelp," +
                "pengguna.NoKartuKredit, detil_pesan.KdBrg, barang.NmBrg," +
                "detil_pesan.HrgPesan,detil_pesan.JmlPesan,detil_pesan.SubTotal" +
                " FROM pengguna INNER JOIN Pesan ON" +
                " pengguna.UserName=Pesan.UserName INNER JOIN detil_pesan" +
                " ON pesan.KdPesan=detil_pesan.KdPesan INNER JOIN barang" +
                " ON detil_pesan.KdBrg=barang.KdBrg" +
                " WHERE pesan.KdPesan='" + _KdPesan + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Konfirmasi");
                rptDoc.Load(Server.MapPath("~/DataBelanja/CRKonfirmasi.rpt"));
                rptDoc.SetDataSource(ds);
                rptDoc.SetParameterValue("PKdPesan", _KdPesan);
                CrystalReportViewer1.ReportSource = rptDoc;
            }
        }


        protected void Page_Load(object sender, EventArgs e) {
            if(!this.IsPostBack) {
                if(Session["Username"] == null || Session["Username"].ToString() == null) {
                    string pesan = "alert(\"Sudah Tidak Bisa Mencetak\");";
                    ScriptManager.RegisterStartupScript
                         (this, typeof(string), "Tidak Bisa Cetak", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }
                BindReport();
            }
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e) {

        }
        protected void lblPdf_Click1(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
               CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
               Response, true, "Konfirmasi");
            rptDoc.Refresh();
        }
        protected void lblExcel_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
               CrystalDecisions.Shared.ExportFormatType.ExcelRecord,
               Response, true, "Konfirmasi");
            rptDoc.Refresh();
        }
        protected void lblWord_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
               CrystalDecisions.Shared.ExportFormatType.WordForWindows,
               Response, true, "Konfirmasi");
            rptDoc.Refresh();
        }
        protected void lblRtf_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            rptDoc.ExportToHttpResponse(
               CrystalDecisions.Shared.ExportFormatType.RichText,
               Response, true, "Konfirmasi");
            rptDoc.Refresh();
        }
    }
}