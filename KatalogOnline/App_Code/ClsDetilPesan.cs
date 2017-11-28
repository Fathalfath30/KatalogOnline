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

namespace KatalogOnline
{
    public class ClsDetilPesan
    {
        private string FKdPesan;
        private string FKdBrg;
        private int FJmlPesan;
        private double FHrgPesan;
        string StrConn =
        WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public string PKdPesan
        {
            get { return FKdPesan; }
            set { FKdPesan = value; }
        }

        public string PKdBrg
        {
            get { return FKdBrg; }
            set { FKdBrg = value; }
        }

        public int PJmlPesan
        {
            get { return FJmlPesan; }
            set { FJmlPesan = value; }
        }

        public double PHrgPesan
        {
            get { return FHrgPesan; }
            set { FHrgPesan = value; }
        }

        public int Simpan()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query =
             "INSERT INTO detil_pesan(KdPesan,KdBrg,HrgPesan,JmlPesan) " +
                "VALUES(@1,@2,@3,@4)";
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