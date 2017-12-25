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
    public class ClsBarang {
        private string FGbrBrg;
        private double FHrgBrg;
        private string FIdKat;
        private string FInfoBrg;
        private string FKdBrg;
        private string FNmBrg;
        private int FStokBrg;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public string PGbrBrg {
            get {
                return FGbrBrg;
            }
            set {
                FGbrBrg = value;
            }
        }

        public double PHrgBrg {
            get {
                return FHrgBrg;
            }
            set {
                FHrgBrg = value;
            }
        }

        public string PIdKat {
            get {
                return FIdKat;
            }
            set {
                FIdKat = value;
            }
        }

        public string PInfoBrg {
            get {
                return FInfoBrg;
            }
            set {
                FInfoBrg = value;
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

        public string PNmBrg {
            get {
                return FNmBrg;
            }
            set {
                FNmBrg = value;
            }
        }

        public int PStokBrg {
            get {
                return FStokBrg;
            }
            set {
                FStokBrg = value;
            }
        }

        public string Autonumber() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string NilaiAwal, NilaiAsli, NilaiAuto;
                int NilaiTambah;
                string Query = "SELECT KdBrg FROM barang ORDER BY KdBrg DESC";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.Read()) {
                    NilaiAsli = SReader["KdBrg"].ToString();
                    NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                    NilaiAwal = System.Convert.ToString(NilaiTambah);
                    NilaiAuto = "BRG" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
                } else {
                    NilaiAuto = "BRG0001";
                }
                return NilaiAuto;
            }
        }

        public int Hapus() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "DELETE FROM barang WHERE KdBrg=@1";
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
                    "INSERT INTO barang(KdBrg,NmBrg,HrgBrg,InfoBrg,GbrBrg,StokBrg,IdKat)" + "VALUES(@1,@2,@3,@4,@5,@6,@7)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FKdBrg);
                SqlCmd.Parameters.AddWithValue("@2", FNmBrg);
                SqlCmd.Parameters.AddWithValue("@3", FHrgBrg);
                SqlCmd.Parameters.AddWithValue("@4", FInfoBrg);
                SqlCmd.Parameters.AddWithValue("@5", FGbrBrg);
                SqlCmd.Parameters.AddWithValue("@6", FStokBrg);
                SqlCmd.Parameters.AddWithValue("@7", FIdKat);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public List<ClsBarang> TampilData(string xNmBrg, string xIdKat)
          //  public List<ClsBarang> TampilData(string xNmBrg)
          {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT * FROM barang " + "WHERE NmBrg LIKE '%" + xNmBrg + "%' AND IdKat='" + xIdKat + "'";
                //string Query = "SELECT * FROM barang " + "WHERE NmBrg LIKE '%" + xNmBrg + "%'";
                List<ClsBarang> List_data = new List<ClsBarang>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsBarang Obj = new ClsBarang();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        Obj.FKdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FInfoBrg = SReader["InfoBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FStokBrg = System.Convert.ToInt32(SReader["StokBrg"]);
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public List<ClsBarang> TampilData2(string xNmBrg) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "SELECT * FROM barang " + "WHERE NmBrg LIKE '%" + xNmBrg + "%' AND " + "KdBrg NOT IN (SELECT KdBrg FROM promo)";
                List<ClsBarang> List_data = new List<ClsBarang>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsBarang Obj = new ClsBarang();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        Obj.FKdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FInfoBrg = SReader["InfoBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FStokBrg = System.Convert.ToInt32(SReader["StokBrg"]);
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public List<ClsBarang> TampilData3(string xNmBrg) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT barang.IdKat, barang.KdBrg, barang.NmBrg, " +
                               "barang.InfoBrg, barang.HrgBrg, barang.GbrBrg, barang.StokBrg " +
                               "FROM barang LEFT OUTER JOIN promo " +
                               "ON barang.KdBrg = promo.KdBrg " +
                               "Where barang.NmBrg Like '%" + xNmBrg + "%'";




                List<ClsBarang> List_data = new List<ClsBarang>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsBarang Obj = new ClsBarang();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        Obj.FKdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FInfoBrg = SReader["InfoBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FStokBrg = System.Convert.ToInt32(SReader["StokBrg"]);
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public int Ubah() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query =
                    "UPDATE barang SET NmBrg=@1, InfoBrg=@2, HrgBrg=@3," +
                    "GbrBrg=@4, StokBrg=@5, IdKat=@6 WHERE KdBrg=@7";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FNmBrg);
                SqlCmd.Parameters.AddWithValue("@2", FInfoBrg);
                SqlCmd.Parameters.AddWithValue("@3", FHrgBrg);
                SqlCmd.Parameters.AddWithValue("@4", FGbrBrg);
                SqlCmd.Parameters.AddWithValue("@5", FStokBrg);
                SqlCmd.Parameters.AddWithValue("@6", FIdKat);
                SqlCmd.Parameters.AddWithValue("@7", FKdBrg);
                int Hasil = 0;
                SqlConn.Open();
                Hasil = SqlCmd.ExecuteNonQuery();
                return Hasil;
            }
        }
    }
}