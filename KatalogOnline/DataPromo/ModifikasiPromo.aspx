<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ModifikasiPromo.aspx.cs" Inherits="KatalogOnline.DataPromo.ModifikasiPromo" %>
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
                <h4><u>MODIFIKASI PROMO</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_cari_nama_barang"
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView runat="server" 
                    ID="Gview_modifikasi_promo">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Barang Promosi</td>
            <td>:</td>
            <td>
                <asp:DetailsView runat="server"
                    ID="Dview_barang_promosi">
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
