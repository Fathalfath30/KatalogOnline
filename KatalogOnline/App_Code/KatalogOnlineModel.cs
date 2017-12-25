using System.Collections.Generic;

namespace KatalogOnline {
    public interface KatalogOnlineModel<T> {
        string auto_number();
        List<T> cari_data();
        bool hapus_data();
        bool simpan_data();
        List<T> tampil_data(string keyword);
        bool update_data();
    }
}