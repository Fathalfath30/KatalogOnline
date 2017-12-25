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
    public class ClsPesan {
        private string FKdPesan;
        private DateTime FTgl_Pesan;
        private string FUserName;
        private string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public string PKdPesan {
            get {
                return FKdPesan;
            }
            set {
                FKdPesan = value;
            }
        }

        public DateTime PTglPesan {
            get {
                return FTgl_Pesan;
            }
            set {
                FTgl_Pesan = value;
            }
        }

        public string PUserName {
            get {
                return FUserName;
            }
            set {
                FUserName = value;
            }
        }

        public String Autonumber() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string NilaiAwal, NilaiAsli, NilaiAuto;
                int NilaiTambah;
                string Query = "SELECT KdPesan FROM pesan ORDER BY KdPesan DESC";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader reader;
                SqlConn.Open();
                reader = SqlCmd.ExecuteReader();
                if(reader.Read()) {
                    NilaiAsli = reader["KdPesan"].ToString();
                    NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                    NilaiAwal = System.Convert.ToString(NilaiTambah);
                    NilaiAuto = "PSN" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
                } else {
                    NilaiAuto = "PSN0001";
                }
                return NilaiAuto;
            }
        }

        public int Simpan() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "INSERT INTO pesan(KdPesan,TglPesan,UserName)VALUES(@1,@2,@3)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FKdPesan);
                SqlCmd.Parameters.AddWithValue("@2", FTgl_Pesan);
                SqlCmd.Parameters.AddWithValue("@3", FUserName);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}