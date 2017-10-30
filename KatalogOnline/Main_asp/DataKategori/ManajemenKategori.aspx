<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenKategori.aspx.cs" Inherits="KatalogOnline.Main_asp.DataKategori.ManajemenKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table style="width:100%;" border="1" cellpadding="2" cellspacing="0">
            <tr>
                <td colspan="4">
                    <center><h3><u>MANAJEMEN KATEGORI</u></h3></center></td>
            </tr>
            <tr>
                <td colspan="2">
                    Cari BerdaCari Berdasarkan Nama Kategori :</td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="Txt_CariKategori" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <u>
                        <asp:GridView runat="server" ID="Gview_Kategori" 
                            AllowPaging="true" 
                            PageSize="5" 
                            EmptyDataText="GRID TIDAK ADA DATA" 
                            AutoGenerateColumns="false"
                            BackColor="White" 
                            BorderColor="#CC9966" 
                            BorderStyle="None" 
                            BorderWidth="1px"
                            CellPadding="4">
                            <Columns>
                                <asp:BoundField DataField="PIdKat" HeaderText="Id Kategori" />
                                <asp:BoundField DataField="PNmKat" HeaderText="Nama Kategori" />
                                <asp:BoundField DataField="PInfoKat" HeaderText="Info Kategori" />
                                <asp:CommandField ShowSelectButton="True" SelectText="Pilih" />
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
                <td>Id Kategori             <td colspan="2">:</td>
                <td class="style1">
                    <asp:TextBox runat="server" ID="Txt_IdKategori" />
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_IdKategori" 
                        ControlToValidate="Txt_IdKategori"
                        ErrorMessage="Id Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td>Nama Kategori</td>
                <td colspan="2">:</td>
                <td class="style1">
                    <asp:TextBox runat="server" ID="Txt_NmKategori" />
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_NmKategori" 
                        ControlToValidate="Txt_NmKategori"
                        ErrorMessage="Nama Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td>Info Kategori</td>
                <td colspan="2">:</td>
                <td class="style1">
                    <asp:TextBox runat="server" ID="TextBox1" />
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" 
                        ControlToValidate="Txt_InfoKategori"
                        ErrorMessage="Info Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                        <asp:Button runat="server" ID="BtnSimpan" Text="Simpan"
                            ValidationGroup="F_ManajemenKategori" />&nbsp;
                        <asp:Button runat="server" ID="BtnUbah" Text="Ubah" />&nbsp;
                        <asp:Button runat="server" ID="BtnHapus" Text="Hapus" />&nbsp;
                        <asp:Button runat="server" ID="BtnBatal" Text="Batal" />
                    </center>
                </td>
            </tr>
        </table>
    </table>
</asp:Content>
