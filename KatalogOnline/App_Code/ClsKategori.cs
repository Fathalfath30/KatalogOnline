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
        private string FIdKategori = "";
        private string FNmKategori = "";
        private string FInfoKategori = "";
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
                SqlConn.Open();

                Query = "SELECT TOP 1 RIGHT(IdKat, 4) AS ID FROM Kategori ORDER BY IdKat DESC";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
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
                SqlConn.Open();

                Query = "DELETE FROM kategori WHERE IdKat=@p1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PIdKategori.Trim());

                return (SqlCmd.ExecuteNonQuery() > 0);
            }
        }

        public List<ClsKategori> tampil_data() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                SqlConn.Open();

                List<ClsKategori> dataList = new List<ClsKategori>();
                dataList.Clear();
                Query = "SELECT IdKat AS ID_KATEGORI, NmKat AS NAMA_KATEGORI, InfoKat AS INFO_KATEGORI FROM kategori";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader sreader = SqlCmd.ExecuteReader();

                if(sreader.HasRows) {
                    while(sreader.Read()) {
                        ClsKategori Obj = new ClsKategori();
                        Obj.PIdKategori = sreader["ID_KATEGORI"].ToString();
                        Obj.PNmKategori = sreader["NAMA_KATEGORI"].ToString();
                        Obj.PInfoKategori = sreader["INFO_KATEGORI"].ToString();
                        dataList.Add(Obj);
                    }
                }

                return dataList;
            }
        }

        public bool update_data() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                SqlConn.Open();
                Query = "UPDATE kategori SET NmKat=@pnama, InfoKat=@pinfo WHERE PidKat=@pid";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@pnama", PNmKategori);
                SqlCmd.Parameters.AddWithValue("@pinfo", PInfoKategori);
                SqlCmd.Parameters.AddWithValue("@pid", PIdKategori);
                return (SqlCmd.ExecuteNonQuery() > 0);
            }
        }

        public bool tambah_data() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                SqlConn.Open();
                Query = "INSERT INTO kategori (PidKat, NmKat, InfoKat) VALUES (@pnama, @pinfo, @pid)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@pnama", PNmKategori);
                SqlCmd.Parameters.AddWithValue("@pinfo", PInfoKategori);
                SqlCmd.Parameters.AddWithValue("@pid", PIdKategori);
                return (SqlCmd.ExecuteNonQuery() > 0);
            }
        }

        public List<ClsKategori> cari_data() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                SqlConn.Open();

                List<ClsKategori> dataList = new List<ClsKategori>();
                dataList.Clear();
                Query = "SELECT IdKat AS ID_KATEGORI, NmKat AS NAMA_KATEGORI, InfoKat AS INFO_KATEGORI FROM kategori ";
                Query += "WHERE IdKat LIKE '%{0}% OR Nmkat LIKE '%{1}%' OR InfoKat LIKE '%{2}%'";
                Query = string.Format(Query, PIdKategori, PNmKategori, PInfoKategori);

                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader sreader = SqlCmd.ExecuteReader();

                if(sreader.HasRows) {
                    while(sreader.Read()) {
                        ClsKategori Obj = new ClsKategori();
                        Obj.PIdKategori = sreader["ID_KATEGORI"].ToString();
                        Obj.PNmKategori = sreader["NAMA_KATEGORI"].ToString();
                        Obj.PInfoKategori = sreader["INFO_KATEGORI"].ToString();
                        dataList.Add(Obj);
                    }
                }

                return dataList;
            }
        }
    }
}