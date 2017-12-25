<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="DaftarBaru.aspx.cs" Inherits="KatalogOnline.DataPengguna.DaftarBaru" %>
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
                <h4><u>DAFTAR BARU</u></h4>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td>Username</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtUsername" CssClass="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtUsername" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtPassword" CssClass="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DBTextBoxPassword" runat="server" 
                    ErrorMessage="Password Tidak Boleh Kosong" ControlToValidate="txtPassword" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td>Konfirmasi Password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" CssClass="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DBTextBoxKonfirm" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKonfirmasi" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password" ControlToCompare="txtPassword" 
                    ControlToValidate="txtKonfirmasi" Display="Dynamic" ValidationGroup="DB"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Nama</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNama" CssClass="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DBtextboxNama" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNama" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td>No Telepon</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNoTelp" CssClass="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DBTextBoxNomorTelepon" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoTelp" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DBTextBoxNoTelepon" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 15 Digit" 
                    ControlToValidate="txtNoTelp" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,15}$" ValidationGroup="DB"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Nomor Kartu Kredit</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNoKartu" CssClass="form-control col-6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DBTextBoxNoKartuKredit" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoKartu" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DBTextBokNomorKartuKredits" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 16 Digit" 
                    ControlToValidate="txtNoKartu" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,16}$" ValidationGroup="DB"></asp:RegularExpressionValidator>
            
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_simpan"
                    CssClass="MainButton"
                    Text="Daftar"
                    ValidationGroup="FrmEntry" OnClick="btnDaftar_Click" />
                <asp:Button runat="server"
                    ID="Btn_ubah"
                    CssClass="MainButton"
                    Text="Batal"
                    ValidationGroup="FrmEntry" OnClick="btnBatal_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
