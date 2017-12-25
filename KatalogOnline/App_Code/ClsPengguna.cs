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
    public class ClsPengguna {
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

        public bool Cari() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {

                string Query = "SELECT * FROM pengguna WHERE UserName=@1 AND Password=@2";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FUserName);
                SqlCmd.Parameters.AddWithValue("@2", FPassword);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows == true) {
                    SReader.Read();
                    FUserName = SReader["UserName"].ToString();
                    FNama = SReader["Nama"].ToString();
                    FPassword = SReader["Password"].ToString();
                    FNoTelp = SReader["NoTelp"].ToString();
                    FNoKartuKredit = SReader["NoKartuKredit"].ToString();
                    FHak = SReader["Hak"].ToString();
                    SReader.Close();
                    return true;
                } else {
                    SReader.Close();
                    return false;
                }
            }
        }

        public int Hapus() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "DELETE FROM pengguna WHERE UserName=@1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FUserName);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
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

        public List<ClsPengguna> TampilData(string xNama) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "SELECT * FROM pengguna " + "WHERE Nama LIKE '%" + xNama + "%'";
                List<ClsPengguna> List_data = new List<ClsPengguna>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsPengguna Obj = new ClsPengguna();
                        Obj.FUserName = SReader["UserName"].ToString();
                        Obj.FPassword = SReader["Password"].ToString();
                        Obj.FNama = SReader["Nama"].ToString();
                        Obj.FNoTelp = SReader["NoTelp"].ToString();
                        Obj.FNoKartuKredit = SReader["NoKartuKredit"].ToString();
                        Obj.FHak = SReader["Hak"].ToString();
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public int Ubah() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "UPDATE pengguna SET Password=@1, Nama=@2, NoTelp=@3," +
                    "NoKartuKredit=@4, Hak=@5 WHERE UserName=@6";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@6", FUserName);
                SqlCmd.Parameters.AddWithValue("@1", FPassword);
                SqlCmd.Parameters.AddWithValue("@2", FNama);
                SqlCmd.Parameters.AddWithValue("@3", FNoTelp);
                SqlCmd.Parameters.AddWithValue("@4", FNoKartuKredit);
                SqlCmd.Parameters.AddWithValue("@5", FHak);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}