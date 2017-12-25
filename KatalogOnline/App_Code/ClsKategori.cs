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
    public class ClsKategori {
        private string FIdKat;
        private string FInfoKat;
        private string FNmKat;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public string PIdKat {
            get {
                return FIdKat;
            }
            set {
                FIdKat = value;
            }
        }

        public string PInfoKat {
            get {
                return FInfoKat;
            }
            set {
                FInfoKat = value;
            }
        }

        public string PNmKat {
            get {
                return FNmKat;
            }
            set {
                FNmKat = value;
            }
        }

        public string Autonumber() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string NilaiAwal, NilaiAsli, NilaiAuto;
                int NilaiTambah;
                string Query = "SELECT IdKat FROM kategori ORDER BY IdKat DESC";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.Read()) {
                    NilaiAsli = SReader["IdKat"].ToString();
                    NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                    NilaiAwal = System.Convert.ToString(NilaiTambah);
                    NilaiAuto = "CAT" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
                } else {
                    NilaiAuto = "CAT0001";
                }
                return NilaiAuto;
            }
        }

        public int Hapus() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "DELETE FROM kategori WHERE IdKat=@1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FIdKat);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public int Simpan() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "INSERT INTO kategori(IdKat,NmKat,InfoKat)VALUES(@1,@2,@3)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FIdKat);
                SqlCmd.Parameters.AddWithValue("@2", FNmKat);
                SqlCmd.Parameters.AddWithValue("@3", FInfoKat);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public List<ClsKategori> TampilData(string xNmKat) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT * FROM kategori WHERE NmKat LIKE '%" + xNmKat + "%'";
                List<ClsKategori> List_data = new List<ClsKategori>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);

                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsKategori Obj = new ClsKategori();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        Obj.FNmKat = SReader["NmKat"].ToString();
                        Obj.FInfoKat = SReader["InfoKat"].ToString();
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public int Ubah() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "UPDATE kategori SET NmKat=@1, InfoKat=@2  WHERE IdKat=@3";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FNmKat);
                SqlCmd.Parameters.AddWithValue("@2", FInfoKat);
                SqlCmd.Parameters.AddWithValue("@3", FIdKat);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}