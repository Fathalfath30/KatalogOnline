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
    public class ClsItemKereta
    {
        private string FGbrBrg;
        private double FHrgBrg;
        private double FHrgPromo;
        private string FIdKat;
        private string FInfoPromo;
        private int FJmlBrg;
        private string FKdBrg;
        private string FNmBrg;
        private string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

        public ClsItemKereta(string PKdBrg, string PNmBrg, double PHrgBrg, int PJmlBrg)
        {
            this.PKdBrg = PKdBrg;
            this.PNmBrg = PNmBrg;
            this.PHrgBrg = PHrgBrg;
            this.PJmlBrg = PJmlBrg;

        }

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

        public double PHrgPromo
        {
            get
            {
                return FHrgPromo;
            }
            set
            {
                FHrgPromo = value;
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

        public string PInfoPromo
        {
            get
            {
                return FInfoPromo;
            }
            set
            {
                FInfoPromo = value;
            }
        }

        public int PJmlBrg
        {
            get
            {
                return FJmlBrg;
            }
            set
            {
                FJmlBrg = value;
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

        public double PSubTotal
        {
            get
            {
                return FHrgBrg * FJmlBrg;
            }

        }

        public bool CariItem()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT barang.KdBrg, barang.NmBrg,barang.HrgBrg, " +
                    "barang.GbrBrg, barang.IdKat, promo.HrgPromo, " +
                    "promo.InfoPromo FROM barang LEFT OUTER JOIN promo " +
                    "ON barang.KdBrg=promo.KdBrg WHERE barang.KdBrg=@1";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", FKdBrg);

                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    reader.Read();
                    FKdBrg = reader["KdBrg"].ToString();
                    FNmBrg = reader["NmBrg"].ToString();
                    FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                    FGbrBrg = reader["GbrBrg"].ToString();
                    FIdKat = reader["IdKat"].ToString();
                    if (reader["HrgPromo"] == DBNull.Value)
                    {
                        FHrgPromo = 0;
                        FInfoPromo = "-";
                    }
                    else
                    {
                        FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                        FInfoPromo = reader["InfoPromo"].ToString();
                    }
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }

        }

        public List<ClsItemKereta> TampilDataBarang(string xIdKat)
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT barang.KdBrg, barang.NmBrg,barang.HrgBrg, " +
                    " barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                    " FROM barang LEFT OUTER JOIN promo " +
                    " ON barang.KdBrg=promo.KdBrg WHERE barang.IdKat= '" + xIdKat + "'";

                List<ClsItemKereta> tmpBaca = new List<ClsItemKereta>();
                SqlCommand cmd = new SqlCommand(Query, conn);

                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsItemKereta objTemp = new ClsItemKereta("", "", 0, 0);
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        if (reader["HrgPromo"] == DBNull.Value)
                        {
                            objTemp.FHrgPromo = 0;
                            objTemp.FInfoPromo = "-";
                        }
                        else
                        {
                            objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                            objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                        }
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }

        public List<ClsItemKereta> TampilDataDetil(string xKdBrg)
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT barang.KdBrg, barang.NmBrg,barang.HrgBrg, " +
                    "barang.GbrBrg, barang.IdKat, promo.HrgPromo, " +
                    "promo.InfoPromo FROM barang LEFT OUTER JOIN promo " +
                    "ON barang.KdBrg=promo.KdBrg WHERE barang.KdBrg='" + xKdBrg + "'";

                List<ClsItemKereta> tmpBaca = new List<ClsItemKereta>();
                SqlCommand cmd = new SqlCommand(Query, conn);

                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsItemKereta objTemp = new ClsItemKereta("", "", 0, 0);
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        if (reader["HrgPromo"] == DBNull.Value)
                        {
                            objTemp.FHrgPromo = 0;
                            objTemp.FInfoPromo = "-";
                        }
                        else
                        {
                            objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                            objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                        }
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }

        public List<ClsItemKereta> TampilDataPromo()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                string Query = "SELECT barang.KdBrg, barang.NmBrg,barang.HrgBrg, " +
                    " barang.GbrBrg, barang.IdKat, promo.HrgPromo, " +
                    "promo.InfoPromo FROM barang INNER JOIN promo " +
                    "ON barang.KdBrg=promo.KdBrg";

                List<ClsItemKereta> tmpBaca = new List<ClsItemKereta>();
                SqlCommand cmd = new SqlCommand(Query, conn);

                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClsItemKereta objTemp = new ClsItemKereta("", "", 0, 0);
                        objTemp.FKdBrg = reader["KdBrg"].ToString();
                        objTemp.FNmBrg = reader["NmBrg"].ToString();
                        objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                        objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                        objTemp.FIdKat = reader["IdKat"].ToString();
                        if (reader["HrgPromo"] == DBNull.Value)
                        {
                            objTemp.FHrgPromo = 0;
                            objTemp.FInfoPromo = "-";
                        }
                        else
                        {
                            objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                            objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                        }
                        tmpBaca.Add(objTemp);
                    }
                }
                return tmpBaca;
            }
        }
    }
}