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
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace KatalogOnline
{
    public class ClsBarang
    {
        private string FKdBrg;
        private string FNmBrg;
        private double FHrgBrg;
        private string FInfoBrg;
        private string FGbrBrg;
        private int FStokBrg;
        private string FIdKat;
        string StrConn =
        WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;


        public string PIdKat
        {
            get { return FIdKat; }
            set { FIdKat = value; }
        }

        public string PKdBrg
        {
            get { return FKdBrg; }
            set { FKdBrg = value; }
        }

        public string PNmBrg
        {
            get { return FNmBrg; }
            set { FNmBrg = value; }
        }

        public double PHrgBrg
        {
            get { return FHrgBrg; }
            set { FHrgBrg = value; }
        }

        public string PInfoBrg
        {
            get { return FInfoBrg; }
            set { FInfoBrg = value; }
        }

        public string PGbrBrg
        {
            get { return FGbrBrg; }
            set { FGbrBrg = value; }
        }

        public int PStokBrg
        {
            get { return FStokBrg; }
            set { FStokBrg = value; }
        }



        public int Simpan()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query =
                "INSERT INTO barang(Kdbrg,NmBrg,HrgBrg,InfoBrg,GbrBrg,StokBrg,IdKat) " +
                "VALUES(@1,@2,@3,@4,@5,@6,@7)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", FKdBrg);
                cmd.Parameters.AddWithValue("@2", FNmBrg);
                cmd.Parameters.AddWithValue("@3", FHrgBrg);
                cmd.Parameters.AddWithValue("@4", FInfoBrg);
                cmd.Parameters.AddWithValue("@5", FGbrBrg);
                cmd.Parameters.AddWithValue("@6", FStokBrg);
                cmd.Parameters.AddWithValue("@7", FIdKat);
                int Hasil = 0;
                conn.Open();
                Hasil = cmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public int Ubah()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query =
                "UPDATE barang SET NmBrg=@1, InfoBrg=@2, HrgBrg=@3, " +
                "GbrBrg=@4, StokBrg=@5, IdKat=@6 WHERE KdBrg=@7";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", FNmBrg);
                cmd.Parameters.AddWithValue("@2", FInfoBrg);
                cmd.Parameters.AddWithValue("@3", FHrgBrg);
                cmd.Parameters.AddWithValue("@4", FGbrBrg);
                cmd.Parameters.AddWithValue("@5", FStokBrg);
                cmd.Parameters.AddWithValue("@6", FIdKat);
                cmd.Parameters.AddWithValue("@7", FKdBrg);
                int Hasil = 0;
                conn.Open();
                Hasil = cmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public int Hapus()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "DELETE FROM barang WHERE KdBrg=@1";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", FKdBrg);
                int Hasil = 0;
                conn.Open();
                Hasil = cmd.ExecuteNonQuery();
                return Hasil;
            }
        }

        public string Autonumber()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string NilaiAwal, NilaiAsli, NilaiAuto;
                int NilaiTambah;
                string Query = "SELECT KdBrg FROM barang ORDER BY KdBrg DESC";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NilaiAsli = reader["KdBrg"].ToString();
                    NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                    NilaiAwal = System.Convert.ToString(NilaiTambah);
                    NilaiAuto = "BRG" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
                }
                else
                {
                    NilaiAuto = "BRG0001";
                }
                return NilaiAuto;
            }
        }

        public List<ClsBarang> TampilData(string xNmBrg, string xIdKat)
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT * FROM barang " +
                "WHERE NmBrg LIKE '%" + xNmBrg + "%' AND IdKat='" + xIdKat + "'";
                List<ClsBarang> tmpBaca = new List<ClsBarang>();
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsBarang objTemp = new ClsBarang();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FInfoBrg = reader["InfoBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FStokBrg = System.Convert.ToInt32(reader["StokBrg"]);
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }

        public List<ClsBarang> TampilData2(string xNmBrg)
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT * FROM barang " +
                "WHERE NmBrg LIKE '%" + xNmBrg + "%' AND " +
                "KdBrg NOT IN(SELECT KdBrg FROM promo)";
                List<ClsBarang> tmpBaca = new List<ClsBarang>();
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsBarang objTemp = new ClsBarang();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FInfoBrg = reader["InfoBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FStokBrg = System.Convert.ToInt32(reader["StokBrg"]);
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }

        public List<ClsBarang> TampilData3(string xNmBrg)
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT barang.IdKat,barang.KdBrg,barang.NmBrg," +
                "barang.InfoBrg,barang.HrgBrg,barang.GbrBrg,barang.StokBrg " +
                "FROM barang LEFT OUTER JOIN promo " +
                "ON barang.KdBrg=promo.KdBrg " +
                "WHERE barang.NmBrg LIKE '%" + xNmBrg + "%'";
                List<ClsBarang> tmpBaca = new List<ClsBarang>();
                SqlCommand cmd = new SqlCommand(Query, conn);

                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsBarang objTemp = new ClsBarang();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FInfoBrg = reader["InfoBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FStokBrg = System.Convert.ToInt32(reader["StokBrg"]);
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }
    }
}