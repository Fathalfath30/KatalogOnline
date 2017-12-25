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
    public class ClsItemKereta {
        private string FGbrBrg;
        private double FHrgBrg;
        private double FHrgPromo;
        private string FIdKat;
        private string FInfoPromo;
        private int FJmlBrg;
        private string FkdBrg;
        private string FNmBrg;
        string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;


        public ClsItemKereta(string PKdBrg, string PNmBrg, double PHrgBrg, int PJmlBrg) {
            this.PKdBrg = PKdBrg;
            this.PNmBrg = PNmBrg;
            this.PHrgBrg = PHrgBrg;
            this.PJmlBrg = PJmlBrg;
        }

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

        public double PHrgPromo {
            get {
                return FHrgPromo;
            }
            set {
                FHrgPromo = value;
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

        public string PInfoPromo {
            get {
                return FInfoPromo;
            }
            set {
                FInfoPromo = value;
            }
        }

        public int PJmlBrg {
            get {
                return FJmlBrg;
            }
            set {
                FJmlBrg = value;
            }
        }

        public string PKdBrg {
            get {
                return FkdBrg;
            }
            set {
                FkdBrg = value;
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

        public double PSubtotal {
            get {
                return FHrgBrg * FJmlBrg;
            }
            set {
            }
        }

        public bool CariItem() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                              "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                              "FROM barang LEFT OUTER JOIN promo " +
                              "ON barang.KdBrg = promo.KdBrg WHERE barang.KdBrg=@1";

                List<ClsItemKereta> List_data = new List<ClsItemKereta>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.Parameters.AddWithValue("@1", FkdBrg);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    SReader.Read();
                    FkdBrg = SReader["KdBrg"].ToString();
                    FNmBrg = SReader["NmBrg"].ToString();
                    FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                    FGbrBrg = SReader["GbrBrg"].ToString();
                    FIdKat = SReader["IdKat"].ToString();
                    if(SReader["HrgPromo"] == DBNull.Value) {
                        FHrgPromo = 0;
                        FInfoPromo = "-";
                    } else {
                        FHrgPromo = System.Convert.ToDouble(SReader["HrgPromo"]);
                        FInfoPromo = SReader["InfoPromo"].ToString();
                    }
                    SReader.Close();
                    return true;
                } else {
                    SReader.Close();
                    return false;
                }
            }
        }

        public List<ClsItemKereta> TampilDataBarang(string xIdKat) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                              "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                              "FROM barang LEFT OUTER JOIN promo " +
                              "ON barang.KdBrg = promo.KdBrg " +
                              "Where barang.IdKat= '" + xIdKat + "'";

                List<ClsItemKereta> List_data = new List<ClsItemKereta>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsItemKereta Obj = new ClsItemKereta("", "", 0, 0);
                        Obj.FkdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        if(SReader["HrgPromo"] == DBNull.Value) {
                            Obj.FHrgPromo = 0;
                            Obj.FInfoPromo = "-";
                        } else {
                            Obj.FHrgPromo = System.Convert.ToDouble(SReader["HrgPromo"]);
                            Obj.FInfoPromo = SReader["InfoPromo"].ToString();
                        }
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public List<ClsItemKereta> TampilDataDetil(string xKdBrg) {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                              "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                              "FROM barang LEFT OUTER JOIN promo " +
                              "ON barang.KdBrg = promo.KdBrg WHERE barang.KdBrg='" + xKdBrg + "'";

                List<ClsItemKereta> List_data = new List<ClsItemKereta>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsItemKereta Obj = new ClsItemKereta("", "", 0, 0);
                        Obj.FkdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        if(SReader["HrgPromo"] == DBNull.Value) {
                            Obj.FHrgPromo = 0;
                            Obj.FInfoPromo = "-";
                        } else {
                            Obj.FHrgPromo = System.Convert.ToDouble(SReader["HrgPromo"]);
                            Obj.FInfoPromo = SReader["InfoPromo"].ToString();
                        }
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }

        public List<ClsItemKereta> TampilDataPromo() {
            using(SqlConnection SqlConn = new SqlConnection(StrConn)) {
                string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg, " +
                              "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                              "FROM barang INNER JOIN promo " +
                              "ON barang.KdBrg = promo.KdBrg ";

                List<ClsItemKereta> List_data = new List<ClsItemKereta>();
                SqlCommand SqlCmd = new SqlCommand(Query, SqlConn);
                SqlDataReader SReader;
                SqlConn.Open();
                SReader = SqlCmd.ExecuteReader();
                if(SReader.HasRows) {
                    while(SReader.Read()) {
                        ClsItemKereta Obj = new ClsItemKereta("", "", 0, 0);
                        Obj.FkdBrg = SReader["KdBrg"].ToString();
                        Obj.FNmBrg = SReader["NmBrg"].ToString();
                        Obj.FHrgBrg = System.Convert.ToDouble(SReader["HrgBrg"]);
                        Obj.FGbrBrg = SReader["GbrBrg"].ToString();
                        Obj.FIdKat = SReader["IdKat"].ToString();
                        if(SReader["HrgPromo"] == DBNull.Value) {
                            Obj.FHrgPromo = 0;
                            Obj.FInfoPromo = "-";
                        } else {
                            Obj.FHrgPromo = System.Convert.ToDouble(SReader["HrgPromo"]);
                            Obj.FInfoPromo = SReader["InfoPromo"].ToString();
                        }
                        List_data.Add(Obj);
                    }
                }
                return List_data;
            }
        }
    }
}