<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="KeranjangBelanja.aspx.cs" Inherits="KatalogOnline.DataBelanja.KeranjangBelanja" %>

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
                <h4><u>KERANJANG BELANJA</u></h4>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView runat="server"
                    ID="Gview_keranjang">
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
                    Text="KONFIRMASI PEMBELIAN" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%">
                    <tr>
                        <td>Nama Barang</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server"
                                ID="Lbl_nama_barang"
                                Text="TAMPIL NAMA BARANG" />
                        </td>
                    </tr>
                    <tr>
                        <td>Jumlah barang</td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList runat="server"
                                ID="Dlist_jumlah_barang">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button runat="server"
                                ID="Btn_update_jumlah_barang"
                                Width="100%"
                                Text="UPDATE JUMLAH BARANG" />
                        </td>
                    </tr>
                </table>
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
