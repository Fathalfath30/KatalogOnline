using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace KatalogOnline {
    public class ClsItemKereta : Model<ClsItemKereta> {
        public string auto_number() {
            throw new NotImplementedException();
        }

        public List<ClsItemKereta> cari_data() {
            throw new NotImplementedException();
        }

        public bool hapus_data() {
            throw new NotImplementedException();
        }

        public List<ClsItemKereta> tampil_data() {
            throw new NotImplementedException();
        }

        public List<ClsItemKereta> tampil_data(string keyword1) {
            throw new NotImplementedException();
        }

        public List<ClsItemKereta> tampil_data(string keyword1, string keyworkd2) {
            throw new NotImplementedException();
        }

        public bool update_data() {
            throw new NotImplementedException();
        }
    }
}