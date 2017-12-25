<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenKategori.aspx.cs" Inherits="KatalogOnline.DataKategori.ManajemenKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .MainButton {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table>
        <tr>
            <td colspan="3">
                <h4><u>MANAJEMEN FrmEntryEGORI</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Berdasarkan Nama kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtCariNama" runat="server" AutoPostBack="True" Style="margin-left: 0px" Width="342px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvKategori" runat="server" AllowPaging="True"
                    OnPageIndexChanging="gvKategori_PageIndexChanging"
                    AutoGenerateColumns="False" EmptyDataText="GRID TIDAK ADA DATA!"
                    PageSize="5"
                    CellPadding="4"
                    ForeColor="#333333"
                    EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                        <asp:BoundField DataField="PIdKat" HeaderText="Id Kategori" />
                        <asp:BoundField DataField="PNmKat" HeaderText="Nama Kategori" />
                        <asp:BoundField DataField="PInfoKat" HeaderText="Info Kategori" />
                    </Columns>

                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Id Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtIdKat" runat="server" Width="113px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID Kategori Tidak Boleh Kosong" ControlToValidate="txtIdKat" ValidationGroup="FrmEntry"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Nama Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNmKat" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nama Kategori Tidak Boleh Kosong" ControlToValidate="txtNmKat"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Info Kategori</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtInfoKat" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Info Kategori Tidak Boleh Kosong" ControlToValidate="txtInfoKat" ValidationGroup="FrmEntry"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="btnSimpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    OnClick="btnSimpan_Click"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="btnUbah"
                    CssClass="MainButton"
                    Text="Ubah"
                    OnClick="btnUbah_Click"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="BtnHapus"
                    CssClass="MainButton"
                    OnClick="btnHapus_Click"
                    Text="Hapus" />
                <asp:Button runat="server"
                    ID="BtnBatal"
                    CssClass="MainButton"
                    OnClick="btnBatal_Click"
                    Text="Batal" />
            </td>
        </tr>
    </table>
</asp:Content>
