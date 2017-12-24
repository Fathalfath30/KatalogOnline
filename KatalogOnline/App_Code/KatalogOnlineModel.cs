using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace KatalogOnline {
    public interface KatalogOnlineModel<T> {
        List<T> tampil_data();
        List<T> cari_data();
        bool simpan_data();
        bool hapus_data();
        bool update_data();
        string auto_number();
    }
}