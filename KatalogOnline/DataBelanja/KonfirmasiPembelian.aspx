<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="KonfirmasiPembelian.aspx.cs" Inherits="KatalogOnline.DataBelanja.KonfirmasiPembelian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width: 100%;
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
                <asp:DetailsView ID="dvPembeli" runat="server" Height="50px" 
                        Width="500px" AutoGenerateRows="False" 
                        CssClass="table table-bordered">
                    <Fields>
                        <asp:BoundField DataField="PUsername" HeaderText="Username" />
                        <asp:BoundField DataField="PNama" HeaderText="Nama" />
                        <asp:BoundField DataField="PNoTelp" HeaderText="No Telepon" />
                        <asp:BoundField DataField="PNoKartuKredit" HeaderText="Kartu Kredit" />
                    </Fields>
                    </asp:DetailsView>
                </td>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">Apakah anda yakin ingin membeli barang dengan rincian sebagai berikut :</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gvKeranjang" runat="server" 
                    OnRowCreated="gvKeranjang_RowCreated" 
                    OnPageIndexChanging="gvKeranjang_PageIndexChanging"
                    nnSelectedindexchanged="gvKeranjang_SelectedIndexChanged" 
                    CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="No" />
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PJmlBrg" HeaderText="Jumlah" />
                        <asp:BoundField DataField="PSubtotal" HeaderText="Jumlah Harga" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Jumlah Item</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblJmlItem" runat="server" Text="TAMPIL JUMLAH ITEM "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Total Bayar</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblTotalBayar" runat="server" Text="TAMPIL TOTAL BAYAR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnYaSimpan" runat="server" 
                    Text="Ya, Tagih dan Kirim Barangnya "  
                    onclick="btnYaSimpan_Click" class="MainButton"/>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnTidak" runat="server" ForeColor="White" 
                    Text="Tidak, Saya Ingin Batal" onclick="btnTidak_Click" class="MainButton"/>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnBelanjaLagi" runat="server" 
                    Text="Saya Masih Ingin Merubah Daftar Belanja"
                    onclick="btnBelanjaLagi_Click" class="MainButton"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>:</td>
            <td></td>
        </tr>
    </table>
</asp:Content>
