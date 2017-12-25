<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenPengguna.aspx.cs" Inherits="KatalogOnline.DataPengguna.ManajemenPengguna" %>
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
                <h4><u>MANAJEMEN PENGGUNA</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Pengguna</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_cari_nama_pengguna"
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:DataList runat="server"
                    ID="Dlist_manajemen_pengguna">
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>Username</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_username" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_username"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Username harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" 
                    ID="Tbox_password"
                    TextMode="Password" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_password"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Password harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Konfirmasi Password</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_konfirmasi_password"
                    TextMode="Password" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_konfirmasi_password"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Konfirmasi password harus di isi!" />
                <asp:CompareValidator runat="server"
                    ControlToValidate="Tbox_konfirmasi_password"
                    ControlToCompare="Tbox_password"
                    ValidationGroup="Frmentry"
                    Display="Dynamic"
                    ErrorMessage="Sesuaikan dengan password sebelumnya" />
            </td>
        </tr>
        <tr>
            <td>Nama</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_nama" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_nama"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Nama harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>No Telepon</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_notelp" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_notelp"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Nomor telephone harus di isi" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_notelp"
                    ValidationExpression="^[0-9]{1,13}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 13 karakter" />
            </td>
        </tr>
        <tr>
            <td>Nomor Kartu Kredit</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_kredit" />
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="Tbox_kredit"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Nomor kartu kredit harus di isi !"/>
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_kredit"
                    ValidationExpression="^[0-9]{1,13}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 13 karakter" />
            </td>
        </tr>
        <tr>
            <td>Hak Admin</td>
            <td>:</td>
            <td>
                <asp:CheckBox runat="server"
                    ID="Cbox_hak_admin"
                    Text="YES" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_simpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="Btn_ubah"
                    CssClass="MainButton"
                    Text="Ubah"
                    ValidationGroup="FrmEntry" />
                <asp:Button runat="server"
                    ID="Btn_hapus"
                    CssClass="MainButton"
                    Text="Hapus" />
                <asp:Button runat="server"
                    ID="Btn_batal"
                    CssClass="MainButton"
                    Text="Batal" />
            </td>
        </tr>
    </table>
</asp:Content>
