<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="KonfirmasiPembelian.aspx.cs" Inherits="KatalogOnline.DataBelanja.KonfirmasiPembelian" %>

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
            <td colspan="3" align="center">
                <h4><u>KONFIRMASI PEMBELIAN</u></h4>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <h5>DATA PEMBELIAN</h5>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:DetailsView runat="server"
                    ID="Dview_pembeli"></asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">Apakah anda yakin ingin membeli barang dengan rincian sebagai berikut :</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView runat="server"
                    ID="Gview_rincian">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Jumlah Item</td>
            <td>:</td>
            <td>
                <asp:Label runat="server"
                    ID="Lbl_jumlah_item"
                    Text="TAMPIL JUMLAH ITEM" />
            </td>
        </tr>
        <tr>
            <td>Total Bayar</td>
            <td>:</td>
            <td>
                <asp:Label runat="server"
                    ID="Lbl_total_bayar"
                    Text="TAMPIL TOTAL BAYAR" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_konfirmasi"
                    Width="100%"
                    Text="Ya, Tagih dan Kirim Barangnya" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ForeColor="Red"
                    ID="Button1"
                    Width="100%"
                    Text="Tidak, Saya ingin batal" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Button2"
                    Width="100%"
                    Text="Saya masin ingin mengubah daftar belanja" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>:</td>
            <td></td>
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
