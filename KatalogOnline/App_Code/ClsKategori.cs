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
    public class ClsKategori : KatalogOnlineModel<ClsKategori> {
        public string auto_number() {
            throw new NotImplementedException();
        }

        public List<ClsKategori> cari_data() {
            throw new NotImplementedException();
        }

        public bool hapus_data() {
            throw new NotImplementedException();
        }

        public bool simpan_data() {
            throw new NotImplementedException();
        }

        public List<ClsKategori> tampil_data() {
            throw new NotImplementedException();
        }

        public bool update_data() {
            throw new NotImplementedException();
        }
    }
}