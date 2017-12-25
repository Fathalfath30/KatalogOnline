<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="InfoProduk.aspx.cs" Inherits="KatalogOnline.DataBelanja.InfoProduk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width: 100px;
        }
         .MainButton2 {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table cellpading="10">
        <tr>
            <td align="center">
                <h4><u>INFO PRODUK</u></h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater runat="server"
                    ID="Repeat_produk" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server"
                    CssClass="MainButton2"
                    ID="Btn_tambah_keranjang"
                    Text="TAMBAH KERANJANG" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server"
                    CssClass="MainButton"
                    ID="Btn_kembali"
                    Text="KEMBALI" />
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
