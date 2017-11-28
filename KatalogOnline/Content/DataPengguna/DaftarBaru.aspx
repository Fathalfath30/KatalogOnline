<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="DaftarBaru.aspx.cs" Inherits="KatalogOnline.Main_asp.DataPengguna.DaftarBaru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table style="width:67%;" border="1">
        <tr>
            <td colspan="3">
                <center><h3><u>DAFTAR BARU</u></h3></center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Width="270px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtUsername" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="DAFTAR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nama"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNama" runat="server" Width="382px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtNama" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="DAFTAR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="201px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtPassword" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="DAFTAR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Konfirmasi Password"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" runat="server" TextMode="Password"
                             Width="199px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="txtKonfirmasi" Display="Dynamic"
                                            ErrorMessage="Tidak Boleh Kosong" ValidationGroup="DAFTAR"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                      ControlToCompare="txtPassword" ControlToValidate="txtKonfirmasi"
                                      Display="Dynamic" ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password"
                                      ValidationGroup="DAFTAR"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Nomor Telepon"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNoTelp" runat="server" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="txtNoTelp" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="DAFTAR" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                ControlToValidate="txtNoTelp" Display="Dynamic"
                                                ErrorMessage="Masukkan Angka, Maksimal 15 Digit"
                                                ValidationExpression="^[0-9]{1,15}$" ValidationGroup="DAFTAR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Nomor Kartu Kredit"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNoKartu" runat="server" Width="239px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="txtNoKartu" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="DAFTAR" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtNoKartu" Display="Dynamic"
                                                ErrorMessage="Masukkan Angka, Maksimal 16 Digit"
                                                ValidationExpression="^[0-9]{1,16}$" ValidationGroup="DAFTAR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnDaftar" runat="server" onclick="btnDaftar_Click"
                            Text="D A F T A R" ValidationGroup="DAFTAR" />
                &nbsp;<asp:Button ID="btnBatal" runat="server" onclick="btnBatal_Click" Text="B A T A L" />
            </td>
        </tr>
    </table>
</asp:Content>

