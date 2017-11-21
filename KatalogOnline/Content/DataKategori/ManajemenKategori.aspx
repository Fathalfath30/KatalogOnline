<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenKategori.aspx.cs" Inherits="KatalogOnline.Main_asp.DataKategori.ManajemenKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table id="Main-tables">
            <tr>
                <td colspan="4">
                    <center><h3><u>MANAJEMEN KATEGORI</u></h3></center></td>
            </tr>
            <tr>
                <td align="right">
                    Cari Berdasarkan Nama Kategori 
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_CariKategori" OnTextChanged="Txt_CariKategori_TextChanged" AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <u>
                        <asp:GridView runat="server" ID="Grid_Kategori" 
                            AllowPaging="true" 
                            PageSize="5" 
                            EmptyDataText="GRID TIDAK ADA DATA" 
                            AutoGenerateColumns="false"
                            BackColor="White" 
                            BorderColor="#CC9966" 
                            BorderStyle="None" 
                            BorderWidth="1px"
                            CellPadding="4" DataKeyNames="PIdKat,PNmKat,PInfoKat" OnPageIndexChanging="Grid_Kategori_PageIndexChanging" OnSelectedIndexChanged="Grid_Kategori_SelectedIndexChanged">
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
                <td align="right">Id Kategori</td>
                <td colspan="2">:</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_IdKategori" />
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_IdKategori" 
                        ControlToValidate="Txt_IdKategori"
                        ErrorMessage="Id Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td align="right">Nama Kategori</td>
                <td colspan="2">:</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_NmKategori" />
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_NmKategori" 
                        ControlToValidate="Txt_NmKategori"
                        ErrorMessage="Nama Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td align="right">Info Kategori</td>
                <td colspan="2">:</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_InfoKategori" />
                    <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_InfoKategori" 
                        ControlToValidate="Txt_InfoKategori"
                        ErrorMessage="Info Kategori harus di isi!"
                        ValidationGroup="F_ManajemenKategori"/>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                        <asp:Button runat="server" ID="BtnSimpan" Text="Simpan"
                            ValidationGroup="F_ManajemenKategori" OnClick="BtnSimpan_Click" />&nbsp;
                        <asp:Button runat="server" ID="BtnUbah" Text="Ubah" OnClick="BtnUbah_Click" />&nbsp;
                        <asp:Button runat="server" ID="BtnHapus" Text="Hapus" OnClick="BtnHapus_Click" />&nbsp;
                        <asp:Button runat="server" ID="BtnBatal" Text="Batal" OnClick="BtnBatal_Click" />
                    </center>
                </td>
            </tr>
        </table>
    </table>
</asp:Content>
