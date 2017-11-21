using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace KatalogOnline
{
    public class ClsKategori
    {
        private string FIdKat;
        private string FInfoKat;
        private string FNmKat;
        private string StrConn =
            WebConfigurationManager.ConnectionStrings["CS_Webonline"].ConnectionString;
        private string Query = "";

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

        public string PInfoKat
        {
            get
            {
                return FInfoKat;

            }
            set
            {
                FInfoKat = value;
            }
        }

        public string PNmKat
        {
            get
            {
                return FNmKat;

            }
            set
            {
                FNmKat = value;
            }
        }

        public string Autonumber()
        {
            string ID = "CAT001";
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "SELECT TOP 1 RIGHT(IdKat, 3) AS ID ";
                Query += "FROM kategori ORDER BY IdKat DESC;";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlConn.Open();
                SqlDataReader Reader = SqlCmd.ExecuteReader();
                if (Reader.Read())
                {
                    ID = string.Format("CAT{0:000}", Convert.ToInt32(Reader["ID"].ToString()) + 1);
                }
            }
            return ID;
        }

        public int Hapus()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "DELETE FROM kategori WHERE IdKat=@p1";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlConn.Open();
                SqlCmd.Parameters.AddWithValue("@p1", PIdKat);
                return SqlCmd.ExecuteNonQuery();
            }
        }

        public int Simpan()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "INSERT INTO kategori (IdKat, NmKat, InfoKat) VALUES ";
                Query += "(@p1, @p2, @p3)";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PIdKat);
                SqlCmd.Parameters.AddWithValue("@p2", PNmKat);
                SqlCmd.Parameters.AddWithValue("@p3", PInfoKat);
                SqlConn.Open();
                return SqlCmd.ExecuteNonQuery();
            }
        }
        public List<ClsKategori> Tampil(string keyword = "")
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                SqlCommand SqlCmd;
                if (keyword.Trim() == "")
                {
                    Query = "SELECT * FROM kategori";
                    SqlCmd = new SqlCommand(Query, SqlConn);
                }
                else
                {
                    Query = "SELECT * FROM kategori WHERE IdKat=@p1";
                    SqlCmd = new SqlCommand(Query, SqlConn);
                    SqlCmd.Parameters.AddWithValue("@p1", keyword.Trim());
                }
                SqlConn.Open();
                List<ClsKategori> DbData = new List<ClsKategori>();
                SqlDataReader Reader = SqlCmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClsKategori CKategori = new ClsKategori();
                        CKategori.PIdKat = Reader["IdKat"].ToString();
                        CKategori.PNmKat = Reader["NmKat"].ToString();
                        CKategori.PInfoKat = Reader["Infokat"].ToString();
                        DbData.Add(CKategori);
                    }
                }
                return DbData;
            }
        }

        public int Ubah()
        {
            using (SqlConnection SqlConn = new SqlConnection(StrConn))
            {
                Query = "UPDATE kategori SET NmKat=@p1, InfoKat=@p2 ";
                Query += "WHERE IdKat=@p3";
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@p1", PNmKat);
                SqlCmd.Parameters.AddWithValue("@p2", PNmKat);
                SqlCmd.Parameters.AddWithValue("@p3", PIdKat);
                SqlConn.Open();
                return SqlCmd.ExecuteNonQuery();
            }
        }
    }
}