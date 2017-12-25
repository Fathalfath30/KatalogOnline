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
                <asp:Repeater ID="rptInfoProduk" runat="server"
                    OnItemCommand="rptInfoProduk_ItemCommand">
                    <ItemTemplate>
                        <table width="20%" border="1" class="table table-light table-bordered">
                            <tr>
                                <th align="left" width="20%">Nama Barang</th>
                                <th width="10px">:</th>
                                <th><%#Eval("PNmBrg")%></th>
                            </tr>

                            <tr>
                                <th align="left">Harga Barang</th>
                                <th>:</th>
                                <th><%#Eval("PHrgBrg","{0:C}")%></th>
                            </tr>

                            <tr>
                                <th align="left">Info Promo</th>
                                <th>:</th>
                                <th><%#Eval("PInfoPromo")%></th>
                            </tr>

                            <tr>
                                <th align="left">Harga Promo</th>
                                <th>:</th>
                                <th><%#Eval("PHrgPromo","{0:C}")%></th>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnTambah" runat="server" Text="TAMBAH KERANJANG" 
                    Width="340px" onclick="btnTambah_Click" class="MainButton2"/>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnKembali" runat="server" Text="KEMBALI" Width="106px" 
                    onclick="btnKembali_Click" class="MainButton2"/>
            </td>
        </tr>
    </table>
</asp:Content>
