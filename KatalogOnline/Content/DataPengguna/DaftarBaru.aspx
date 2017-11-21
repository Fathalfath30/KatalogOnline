<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="DaftarBaru.aspx.cs" Inherits="KatalogOnline.Main_asp.DataPengguna.DaftarBaru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table id="MainForm" style="width:auto%;" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td colspan="3">
                <center><h3><u>DAFTAR BARU</u></h3></center>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label runat="server" ID="Lbl_Username" Text="Username" />
            </td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_Username" />&nbsp;
                <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_Username"
                                            ControlToValidate="Txt_Username"
                                            ErrorMessage="Username harus di isi!"
                                            ValidationGroup="F_DaftarBaru" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_Nama" runat="server" Text="Nama"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_Nama"/>&nbsp;
                <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_Nama"
                                            ControlToValidate="Txt_Nama"
                                            ErrorMessage="Nama harus di isi!"
                                            ValidationGroup="F_DaftarBaru" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_Password"
                    TextMode="Password"/>&nbsp;
                <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_Password"
                    ControlToValidate="Txt_Password"
                    ErrorMessage="Nama Kategori harus di isi!"
                    ValidationGroup="F_DaftarBaru" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label5" runat="server" Text="Konfirmasi Password"></asp:Label>
            </td>
            <td>:</td>
            <td>
                	<asp:TextBox runat="server" ID="Txt_Password2" 
                        TextMode="Password"/>&nbsp;
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_Password2" 
                        ControlToValidate="Txt_Password2"
                        ErrorMessage="Nama Kategori harus di isi!"
                        ValidationGroup="F_DaftarBaru"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" Text="Nomor Telepon"></asp:Label>
            </td>
            <td>:</td>
            <td>
                	<asp:TextBox runat="server" ID="Txt_Telephone" />&nbsp;
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_Telephone" 
                        ControlToValidate="Txt_Telephone"
                        ErrorMessage="Nama Kategori harus di isi!"
                        ValidationGroup="F_DaftarBaru"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" runat="server" Text="Nomor Kartu Kredit"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                	<asp:TextBox runat="server" ID="Txt_KartuKredit" />&nbsp;
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Txt_KartuKredit" 
                        ControlToValidate="Txt_KartuKredit"
                        ErrorMessage="Nama Kategori harus di isi!"
                        ValidationGroup="F_DaftarBaru"/>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
               <asp:Button runat="server" ID="BtnSimpan" 
                   Text="Simpan"
                   ValidationGroup="F_ManajemenBarang" 
                   CssClass="MainButton"/>&nbsp;
                <asp:Button runat="server" ID="BtnBatal" 
                    Text="Batal" 
                    CssClass="MainButton"/>
            </td>
        </tr>
    </table>
</asp:Content>
