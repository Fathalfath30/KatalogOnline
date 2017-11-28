<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenKategori.aspx.cs" Inherits="KatalogOnline.Main_asp.DataKategori.ManajemenKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .style1 {
            width : 268435488px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <center style="height: 565px; width: 977px">
        &nbsp;<table style="width:83%;" border="1">
            <tr>
                <td colspan="4">
                    <center><h3><u>MANAJEMEN KATEGORI</u></h3></center>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Cari Berdasarkan Nama Kategori :
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtCariNama" runat="server"
                                 ontextchanged="txtCariNama_TextChanged" Width="369px"
                                 AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <u>
                        <asp:GridView ID="gvKategori" runat="server" AllowPaging="True"
                                      OnPageIndexChanging="gvKategori_PageChanging" PageSize="5"
                                      BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                                      CellPadding="4" onselectedindexchanged="gvKategori_SelectedIndexChanged"
                                      EmptyDataText="GRID TIDAK ADA DATA" AutoGenerateColumns="False">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="PIdKat" HeaderText="Id Kategori" />
                                <asp:BoundField DataField="PNmKat" HeaderText="Nama Kategori" />
                                <asp:BoundField DataField="PInfoKat" HeaderText="Info Kategori" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </u>
                </td>
            </tr>
            <tr>
                <td>
                    Id Kategori
                </td>
                <td colspan="2">
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtIdKat" runat="server" ontextchanged="txtIdKat_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtIdKat"
                                                ErrorMessage="ID Kategori Tidak Boleh Kosong" ValidationGroup="KAT"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Nama Kategori
                </td>
                <td colspan="2">
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtNmKat" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="txtNmKat"
                                                ErrorMessage="Nama Kategori Tidak Boleh Kosong" ValidationGroup="KAT"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Info Kategori
                </td>
                <td colspan="2">
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtInfoKat" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="txtInfoKat"
                                                ErrorMessage="Info Kategori Tidak Boleh Kosong" ValidationGroup="KAT"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                        <asp:Button ID="btnSimpan" runat="server" onclick="btnSimpan_Click"
                                    Text="S I M P A N" ValidationGroup="KAT" />
                        &nbsp;<asp:Button ID="btnUbah" runat="server" onclick="btnUbah_Click"
                                          Text="U B A H" />
                        &nbsp;<asp:Button ID="btnHapus" runat="server" onclick="btnHapus_Click" Text="H A P U S" />
                        &nbsp;<asp:Button ID="btnBatal" runat="server" Text="B A T A L" onclick="btnBatal_Click" />
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
