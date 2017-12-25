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
    public class ClsPromo {
        private double FHrgPromo;
        private string FInfoPromo;
        private string FKdBrg;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public double PHrgPromo {
            get {
                return FHrgPromo;
            }
            set {
                FHrgPromo = value;
            }
        }

        public string PInfoPromo {
            get {
                return FInfoPromo;
            }
            set {
                FInfoPromo = value;
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

        public int Hapus() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "DELETE FROM promo WHERE KdBrg=@1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FKdBrg);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public int Simpan() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "INSERT INTO promo(KdBrg,InfoPromo,HrgPromo)VALUES(@1,@2,@3)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FKdBrg);
                SqlCmd.Parameters.AddWithValue("@2", FInfoPromo);
                SqlCmd.Parameters.AddWithValue("@3", FHrgPromo);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public List<ClsPromo> TampilData(string xKdBrg) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "SELECT * FROM promo WHERE KdBrg ='" + xKdBrg + "'";
                List<ClsPromo> List_data = new List<ClsPromo>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);

                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsPromo Obj = new ClsPromo();
                        Obj.FKdBrg = SReader["KdBrg"].ToString();
                        Obj.FInfoPromo = SReader["InfoPromo"].ToString();
                        Obj.FHrgPromo = System.Convert.ToDouble(SReader["HrgPromo"]);
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public int Ubah() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "UPDATE promo SET InfoPromo=@1, HrgPromo=@2 WHERE KdBrg=@3";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FInfoPromo);
                SqlCmd.Parameters.AddWithValue("@2", FHrgPromo);
                SqlCmd.Parameters.AddWithValue("@3", FKdBrg);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}