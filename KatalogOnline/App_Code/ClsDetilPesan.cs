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
    public class ClsDetilPesan
    {
        private double FHrgPesan;
        private int FJmlPesan;
        private string FKdBrg;
        private string FKdPesan;
        private string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public double PHrgPesan
        {
            get
            {
                return FHrgPesan;
            }
            set
            {
                FHrgPesan = value;
            }
        }

        public int PJmlPesan
        {
            get
            {
                return FJmlPesan;
            }
            set
            {
                FJmlPesan = value;
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

        public string PKdPesan
        {
            get
            {
                return FKdPesan;
            }
            set
            {
                FKdPesan = value;
            }
        }

        public int Simpan()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                String Query =
                   "INSERT INTO detil_pesan(KdPesan,KdBrg,HrgBrg,JmlPesan)" + "VALUES(@1,@2,@3,@4)";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", FKdPesan);
                cmd.Parameters.AddWithValue("@2", FKdBrg);
                cmd.Parameters.AddWithValue("@3", FHrgPesan);
                cmd.Parameters.AddWithValue("@4", FJmlPesan);
                int Hasil = 0;
                conn.Open();
                Hasil = cmd.ExecuteNonQuery();
                return Hasil;

            }
        }
    }
}