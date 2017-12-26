using System;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace KatalogOnline.Report {
    public partial class LaporanKategori : System.Web.UI.Page {
        string StrConn =
        WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
        ReportDocument cReport = new ReportDocument();
        void BindReport() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                SqlConn.Open();
                SqlCommand SqlCmd = new SqlCommand("select * from kategori", SqlConn);
                SqlDataAdapter Sql_adapter = new SqlDataAdapter();
                Sql_adapter.SelectCommand = SqlCmd;
                DataSet dSet = new DataSet();
                Sql_adapter.Fill(dSet, "kategori");
                cReport.Load(Server.MapPath("~/Report/CRKategori.rpt"));
                cReport.SetDataSource(dSet);
                CrystalReportViewer1.ReportSource = cReport;
            }
        }
        protected void lbexcel_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            cReport.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.ExcelRecord,
                Response, true, "LaporanKategori");
            cReport.Refresh();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if(!this.IsPostBack) {
                if(Session["Hak"] == null || Session["Hak"].ToString() != "1") {
                    string pesan = "alert(\"Tidak Mempunyai Hak\");";
                    ScriptManager.RegisterStartupScript
                        (this, typeof(string), "HAK AKSES", pesan, true);
                    Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                    return;
                }
                BindReport();
                cReport.Refresh();
            }
        }
        protected void lbword_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            cReport.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.WordForWindows,
                Response, true, "LaporanKategori");
            cReport.Refresh();
        }

        protected void lbpdf_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            cReport.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                Response, true, "LaporanKategori");
            cReport.Refresh();
        }

        protected void lbrtf_Click(object sender, ImageClickEventArgs e) {
            BindReport();
            cReport.ExportToHttpResponse(
                CrystalDecisions.Shared.ExportFormatType.RichText,
                Response, true, "LaporanKategori");
            cReport.Refresh();
        }
    }
}