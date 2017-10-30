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
    public class ClsKereta
    {
        private List<ClsItemKereta> PKeretaBelanja;

        public ClsKereta()
        {
            PKeretaBelanja = new List<ClsItemKereta>();

        }

        public int Counter
        {
            get
            {
                return PKeretaBelanja.Count;
            }
            set
            {
            }
        }

        public void AddItems(string _KdBrg, string _NmBrg, double _HrgBrg, int _JmlBrg)
        {
            bool barang_ada = false;
            foreach (ClsItemKereta item in PKeretaBelanja)
            {
                if (item.PKdBrg == _KdBrg)
                {
                    item.PJmlBrg += 1;
                    barang_ada = true;
                }
            }
            if (!barang_ada)
            {
                var item = new ClsItemKereta(_KdBrg, _NmBrg, _HrgBrg, 1);
                PKeretaBelanja.Add(item);
            }

        }

        public void DeleteItem(int _Index)
        {
            PKeretaBelanja.RemoveAt(_Index);

        }

        public List<ClsItemKereta> GetItem()
        {
            return PKeretaBelanja;

        }

        public void UpdateQty(int _Index, int _JmlBrg)
        {
            ClsItemKereta item;
            item = PKeretaBelanja[_Index];
            item.PJmlBrg = _JmlBrg;

        }
    }
}