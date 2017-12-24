<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenKategori.aspx.cs" Inherits="KatalogOnline.DataKategori.ManajemenKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width:100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table cellpading="10">
        <tr>
            <td colspan="3"> 
                <h4><u>MANAJEMEN KATEGORI</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Berdasarkan Nama kategori</td>
            <td>:</td>
            <td><asp:TextBox runat="server" 
                ID="Tbox_cari" 
                AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView runat="server"
                    ID="Gview_kategori">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Id Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" 
                ID="Tbox_id_kategori" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_id_kategori"
                    ValidationGroup="FrmEntry"
                    ErrorMessage="Id kategori harus di isi" />
            </td>
        </tr>
        <tr>
            <td>Nama Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                ID="Tbox_nama_kategori" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_nama_kategori"
                    ValidationGroup="FrmEntry"
                    ErrorMessage="Nama kategori harus di isi !" />
            </td>
        </tr>
        <tr>
            <td>Info Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                ID="Tbox_info_kategori" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_info_kategori"
                    ValidationGroup="Frmentry"
                    ErrorMessage="Info kategori harus di isi !" />
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
