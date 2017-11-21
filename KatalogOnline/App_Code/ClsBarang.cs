using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace KatalogOnline
{
    public class ClsBarang
    {
        private string FGbrBrg;
        private double FHrgBrg;
        private string FIdKat;
        private string FInfoBrg;
        private string FKdBrg;
        private string FNmBrg;
        private int FStokBrg;
        private string Query;
        private string StrConn = WebConfigurationManager.ConnectionStrings["CS_Webonline"].ConnectionString;

        public string PGbrBrg
        {
            get
            {
                return FGbrBrg;
            }
            set
            {
                FGbrBrg = value;
            }
        }

        public double PHrgBrg
        {
            get
            {
                return FHrgBrg;
            }
            set
            {
                FHrgBrg = value;
            }
        }

        public string PIdKat
        {
            get
            {
                return FIdKat;
            }
            set
            {
                FIdKat = value;
            }
        }

        public string PInfoBrg
        {
            get
            {
                return FInfoBrg;
            }
            set
            {
                FInfoBrg = value;
            }
        }

        public string PKdBrg
        {
            get
            {
                return FKdBrg;
            }
            set
            {
                FKdBrg = value;
            }
        }

        public string PNmBrg
        {
            get
            {
                return FNmBrg;
            }
            set
            {
                FNmBrg = value;
            }
        }

        public int PStokBrg
        {
            get
            {
                return FStokBrg;
            }
            set
            {
                FStokBrg = value;
            }
        }

        public string Autonumber()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string ID = "BRG001";
                using (SqlConnection SqlConn = new SqlConnection(StrConn))
                {
                    Query = "SELECT TOP 1 RIGHT(KdBrg, 3) AS ID ";
                    Query += "FROM barang ORDER BY KdBrg DESC;";
                    SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                    SqlConn.Open();
                    SqlDataReader Reader = SqlCmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        ID = string.Format("BRG{0:000}", Convert.ToInt32(Reader["ID"].ToString()) + 1);
                    }
                }
                return ID;
            }


        }

        public int Hapus()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "DELETE FROM barang WHERE KdBrg=@p1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PKdBrg);
                SqlConn.Open();
                return SqlCmd.ExecuteNonQuery();
            }
        }

        public int Simpan()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "INSERT INTO barang(KdBrg, NmBrg, HrgBrg, InfoBrg, GbrBrg, StokBrg, IdKat) ";
                Query += "VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PKdBrg);
                SqlCmd.Parameters.AddWithValue("@p2", PNmBrg);
                SqlCmd.Parameters.AddWithValue("@p3", PHrgBrg);
                SqlCmd.Parameters.AddWithValue("@p4", PInfoBrg);
                SqlCmd.Parameters.AddWithValue("@p5", PGbrBrg);
                SqlCmd.Parameters.AddWithValue("@p6", PStokBrg);
                SqlCmd.Parameters.AddWithValue("@p7", PIdKat);
                SqlConn.Open();
                return SqlCmd.ExecuteNonQuery();
            }                                    
        }

        public List<ClsBarang> Tampil(string keyword = "")
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                SqlCommand SqlCmd;
                List<ClsBarang> MainDT = new List<ClsBarang>();
                if (keyword.Trim() != "")
                {
                    Query = "SELECT * FROM barang ";
                    Query += "WHERE KdBrg LIKE '%{0}%' OR NmBrg LIKE '%{0}%'";
                    SqlCmd = new SqlCommand(string.Format(Query, keyword), SqlConn);

                }
                else
                {
                    Query = "SELECT * FROM barang ";
                    SqlCmd = new SqlCommand(Query, SqlConn);
                }
                SqlConn.Open();
                SqlDataReader Reader = SqlCmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    MainDT.Clear();
                    while(Reader.Read())
                    {
                        ClsBarang TmpBarang = new ClsBarang();
                        TmpBarang.FIdKat = Reader["IdKat"].ToString();
                        TmpBarang.FKdBrg = Reader["KdBrg"].ToString();
                        TmpBarang.FNmBrg = Reader["NmBrg"].ToString();
                        TmpBarang.FInfoBrg = Reader["InfoBrg"].ToString();
                        TmpBarang.FHrgBrg = System.Convert.ToDouble(Reader["HrgBrg"]);
                        TmpBarang.FGbrBrg = Reader["GbrBrg"].ToString();
                        TmpBarang.FStokBrg = System.Convert.ToInt32(Reader["StokBrg"]);
                        MainDT.Add(TmpBarang);
                    }
                }
                return MainDT;
            }
        }

        public int Ubah()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                SqlCommand SqlCmd;
                if (PGbrBrg != "")
                {
                    Query = "UPDATE barang SET ";
                    Query += "NmBrg=@p1, InfoBrg=@p2, HrgBrg=@p3, ";
                    Query += "GbrBrg=@p4, StokBrg=@p5, IdKat=@p6 WHERE KdBrg=@p7";
                    SqlCmd = new SqlCommand(Query, SqlConn);
                    SqlCmd.Parameters.AddWithValue("@p1", PNmBrg);
                    SqlCmd.Parameters.AddWithValue("@p2", PInfoBrg);
                    SqlCmd.Parameters.AddWithValue("@p3", PHrgBrg);
                    SqlCmd.Parameters.AddWithValue("@p4", PGbrBrg);
                    SqlCmd.Parameters.AddWithValue("@p5", PStokBrg);
                    SqlCmd.Parameters.AddWithValue("@p6", PIdKat);
                    SqlCmd.Parameters.AddWithValue("@p7", PKdBrg);
                }
                 else
                {
                    Query = "UPDATE barang SET ";
                    Query += "NmBrg=@p1, InfoBrg=@p2, HrgBrg=@p3, ";
                    Query += "StokBrg=@p4, IdKat=@p5 WHERE KdBrg=@p6";
                    SqlCmd = new SqlCommand(Query, SqlConn);
                    SqlCmd.Parameters.AddWithValue("@p1", PNmBrg);
                    SqlCmd.Parameters.AddWithValue("@p2", PInfoBrg);
                    SqlCmd.Parameters.AddWithValue("@p3", PHrgBrg);
                    SqlCmd.Parameters.AddWithValue("@p4", PStokBrg);
                    SqlCmd.Parameters.AddWithValue("@p5", PIdKat);
                    SqlCmd.Parameters.AddWithValue("@p6", PKdBrg);
                }
                SqlConn.Open();
                return SqlCmd.ExecuteNonQuery();
            }
        }
    }
}