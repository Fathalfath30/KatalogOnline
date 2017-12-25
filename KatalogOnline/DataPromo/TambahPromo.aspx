<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="TambahPromo.aspx.cs" Inherits="KatalogOnline.DataPromo.TambahPromo" %>

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
                <h4><u>TAMBAH DATA BARANG PROMO</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtCariBarang" class="form-control col-6" runat="server" AutoPostBack="True"
                    OnTextChanged="txtCariBarang_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4"
                    EmptyDataText="Data Tidak Ada"
                    OnSelectedIndexChanged="gvBarang_SelectedIndexChanged" PageSize="5"
                    OnPageIndexChanging="gvBarang_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Kode Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtKdBarang" runat="server" class="form-control col-6" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="txtKdBarang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Kode barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNmBarang" class="form-control col-6" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Harga Barang</td>
            <td>:</td>
            <td>
                <asp:Label runat="server"
                    Text="Rp." />
                <asp:TextBox ID="txtHrgBarang" class="form-control col-6" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Info Promo</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtInfoPromo" class="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TextBoxHargaPromo" runat="server"
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtInfoPromo"
                    Display="Dynamic" ValidationGroup="PRO"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Harga Promo</td>
            <td>:</td>
            <td>
                <asp:Label runat="server"
                    Text="Rp." />
                <asp:TextBox ID="txtHrgPromo" class="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtHrgPromo"
                    Display="Dynamic" ValidationGroup="PRO"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Masukkan Angka, Minimal 7 Digit"
                    ControlToValidate="txtHrgPromo" Display="Dynamic"
                    ValidationExpression="^[0-9]{1,7}$" ValidationGroup="PRO"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ErrorMessage="Harga Promo Lebih Besar Dari Harga Barang" ControlToCompare="txtHrgPromo"
                    ControlToValidate="txtInfoPromo" Display="Dynamic"
                    Operator="LessThanEqual" Type="Integer" ValueToCompare="PRO"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="btnSimpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    OnClick="btnSimpan_Click"
                    ValidationGroup="PRO" />
                <asp:Button runat="server"
                    ID="btnBatal"
                    OnClick="btnBatal_Click"
                    CssClass="MainButton"
                    Text="Batal" />
            </td>
        </tr>
    </table>
</asp:Content>
