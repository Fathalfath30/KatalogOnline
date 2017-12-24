<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenBarang.aspx.cs" Inherits="KatalogOnline.DataBarang.ManajemenBarang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table cellpading="10">
        <tr>
            <td colspan="3">
                <h4><u>MANAJEMEN BARANG</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Kategori</td>
            <td>:</td>
            <td>
                <asp:DropDownList runat="server"
                    ID="Dlist_cari_kategori">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_cari_nama"
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView runat="server"
                    ID="Gview_manajemen_barang">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Nama Kategori</td>
            <td>:</td>
            <td>
                <asp:DropDownList runat="server"
                    ID="Dlist_nama_kategori">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Kode Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_kode_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_kode_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Kode barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_nama_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_nama_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Nama barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Harga Barang</td>
            <td>:</td>
            <td>
                <asp:Label runat="server" 
                    Text="Rp." />
                <asp:TextBox runat="server" 
                    ID="Tbox_harga_barang"/>
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_harga_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Harga barang harus di isi!" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_stock_barang"
                    ValidationGroup="FrmEntry"
                    ValidationExpression="^[0-9]{1,7}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 7 karakter" />
            </td>
        </tr>
        <tr>
            <td>Info Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_info_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_info_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Info barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Gambar Barang</td>
            <td>:</td>
            <td>
                <asp:FileUpload runat="server"
                    ID="Fupload_foto_barang" />
            </td>
        </tr>
        <tr>
            <td>Stock Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_stock_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_stock_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Stock barang harus di isi!" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_stock_barang"
                    ValidationGroup="FrmEntry"
                    ValidationExpression="^[0-9]{1,3}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 3 karakter" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_simpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="Btn_ubah"
                    CssClass="MainButton"
                    Text="Ubah"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="Btn_hapus"
                    CssClass="MainButton"
                    Text="Hapus" />
                <asp:Button runat="server"
                    ID="Btn_batal"
                    CssClass="MainButton"
                    Text="Batal" />
            </td>
        </tr>
    </table>
</asp:Content>
