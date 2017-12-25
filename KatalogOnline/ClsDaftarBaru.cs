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
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace KatalogOnline {
    public class ClsDaftarBaru {
        private string FHak;
        private string FNama;
        private string FNoKartuKredit;
        private string FNoTelp;
        private string FPassword;
        private string FUserName;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public string PHak {
            get {
                return FHak;
            }
            set {
                FHak = value;
            }
        }

        public string PNama {
            get {
                return FNama;
            }
            set {
                FNama = value;
            }
        }

        public string PNoKartuKredit {
            get {
                return FNoKartuKredit;
            }
            set {
                FNoKartuKredit = value;
            }
        }

        public string PNoTelp {
            get {
                return FNoTelp;
            }
            set {
                FNoTelp = value;
            }
        }

        public string PPassword {
            get {
                return FPassword;
            }
            set {
                FPassword = value;
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

        public int Simpan() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "INSERT INTO pengguna " +
                    "(UserName,Password,Nama,NoTelp,NoKartuKredit,Hak)" +
                    "VALUES(@1,@2,@3,@4,@5,@6)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FUserName);
                SqlCmd.Parameters.AddWithValue("@2", FPassword);
                SqlCmd.Parameters.AddWithValue("@3", FNama);
                SqlCmd.Parameters.AddWithValue("@4", FNoTelp);
                SqlCmd.Parameters.AddWithValue("@5", FNoKartuKredit);
                SqlCmd.Parameters.AddWithValue("@6", FHak);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}