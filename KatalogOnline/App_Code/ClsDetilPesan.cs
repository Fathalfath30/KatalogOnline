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
    public class ClsDetilPesan {
        private double FHrgPesan;
        private int FJmlPesan;
        private string FKdBrg;
        private string FKdPesan;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public double PHrgPesan {
            get {
                return FHrgPesan;
            }
            set {
                FHrgPesan = value;
            }
        }

        public int PJmlPesan {
            get {
                return FJmlPesan;
            }
            set {
                FJmlPesan = value;
            }
        }

        public string PKdBrg {
            get {
                return FKdBrg;
            }
            set {
                FKdBrg = value;
            }
        }

        public string PKdPesan {
            get {
                return FKdPesan;
            }
            set {
                FKdPesan = value;
            }
        }

        public int Simpan() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "INSERT INTO detil_pesan (KdPesan,KdBrg,HrgPesan,JmlPesan)" +
                    "VALUES(@1,@2,@3,@4)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FKdPesan);
                SqlCmd.Parameters.AddWithValue("@2", FKdBrg);
                SqlCmd.Parameters.AddWithValue("@3", FHrgPesan);
                SqlCmd.Parameters.AddWithValue("@4", FJmlPesan);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}