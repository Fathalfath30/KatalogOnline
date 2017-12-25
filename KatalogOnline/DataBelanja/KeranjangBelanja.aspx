<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="KeranjangBelanja.aspx.cs" Inherits="KatalogOnline.DataBelanja.KeranjangBelanja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width: 100px;
        }
        .MainButton2 {
            width: 100%;
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
                <asp:GridView ID="gvKeranjang" runat="server" AutoGenerateColumns="False"
                    OnRowCreated="gvKeranjang_RowCreated"
                    OnRowDeleting="gvKeranjang_RowDeleting"
                    CssClass="table table-striped table-bordered"
                    OnSelectedIndexChanged="gvKeranjang_SelectedIndexChanged"
                    autopostback="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField HeaderText="No." />
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" DataFormatString="{0:C}"
                            HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PJmlBrg" HeaderText="Jumlah" />
                        <asp:BoundField DataField="PSubTotal" DataFormatString="{0:C}"
                            HeaderText="Jumlah Harga" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Jumlah Item</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblJumlahItem" runat="server" Text="TAMPIL JUMLAH ITEM"></asp:Label>
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
                <asp:Button ID="btnKonfirmasi" runat="server" Text="KONFIRMASI PEMBELIAN"
                    CssClass="MainButton2" OnClick="btnKonfirmasi_Click" />
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
                            <asp:Label ID="lblNmBrg" runat="server" Text="TAMPIL NAMA BARANG"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Jumlah barang</td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList class="form-control col-sm-1" ID="ddJmlBrg" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnUbah" runat="server" class="MainButton2" OnClick="btnUbah_Click"
                                PostBackUrl="~/DataBelanja/KeranjangBelanja.aspx" Text="EDIT JUMLAH BARANG" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
