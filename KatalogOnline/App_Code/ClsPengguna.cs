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
    public class ClsPengguna : Model<ClsPengguna> {
        public string auto_number() {
            throw new NotImplementedException();
        }

        public List<ClsPengguna> cari_data() {
            throw new NotImplementedException();
        }

        public bool hapus_data() {
            throw new NotImplementedException();
        }

        public List<ClsPengguna> tampil_data() {
            throw new NotImplementedException();
        }

        public List<ClsPengguna> tampil_data(string keyword1) {
            throw new NotImplementedException();
        }

        public List<ClsPengguna> tampil_data(string keyword1, string keyworkd2) {
            throw new NotImplementedException();
        }

        public bool update_data() {
            throw new NotImplementedException();
        }
    }
}