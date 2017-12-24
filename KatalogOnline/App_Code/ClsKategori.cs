using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;


namespace KatalogOnline {
    public class ClsKategori : Model<ClsKategori> {
        private string FIdKategori;
        private string FNmKategori;
        private string FInfoKategori;
        private string StrConn = WebConfigurationManager.ConnectionStrings["CS_Webonline"].ConnectionString;
        private string Query;

        public string PIdKategori {
            set { PIdKategori = value.Trim(); }
            get { return PIdKategori.Trim(); }
        }

        public string PNmKategori {
            set { FIdKategori = value.Trim(); }
            get { return FIdKategori.Trim(); }
        }

        public string PInfoKategori {
            set { FInfoKategori = value.Trim(); }
            get { return FInfoKategori.Trim(); }
        }

        public string auto_number() {
            string auto_id = "CAT0001";
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                Query = "SELECT TOP 1 RIGHT(IdKat, 4) AS ID FROM Kategori ORDER BY IdKat DESC";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlConn.Open();
                SqlDataReader sReader = SqlCmd.ExecuteReader();
                if(sReader.Read()) {
                    auto_id = string.Format(
                        "CAT{1:0000}",
                        Convert.ToDouble(sReader["ID"].ToString()) + 1
                        );
                }
            }
            return auto_id;
        }

        public bool hapus_data() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                Query = "DELETE FROM kategori WHERE IdKat=@p1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PIdKategori.Trim());
                SqlConn.Open();

                return (SqlCmd.ExecuteNonQuery() > 0);
            }
        }

        public List<ClsKereta> tampil_data() {
            throw new NotImplementedException();
        }

        public bool update_data() {
            throw new NotImplementedException();
        }

        public List<ClsKereta> tampil_data(string keyword) {
            throw new NotImplementedException();
        }

        public List<ClsKereta> tampil_data(string keyword1, string keyworkd2) {
            throw new NotImplementedException();
        }

        List<ClsKategori> Model<ClsKategori>.tampil_data() {
            throw new NotImplementedException();
        }

        List<ClsKategori> Model<ClsKategori>.tampil_data(string keyword1) {
            throw new NotImplementedException();
        }

        List<ClsKategori> Model<ClsKategori>.tampil_data(string keyword1, string keyworkd2) {
            throw new NotImplementedException();
        }
    }
}