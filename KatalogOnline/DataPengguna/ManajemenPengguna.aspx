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
                <asp:TextBox ID="txtCariNama" runat="server" OnTextChanged="txtCariNama_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:DataList ID="dlPengguna" runat="server" CellPadding="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlPengguna_SelectedIndexChanged" Visible="False" ForeColor="#333333">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <ItemTemplate>
                        <table class="auto-style12" border="1">
                            <tr>
                                <td class="auto-style10">Username</td>
                                <td class="auto-style11">:</td>
                                <td class="auto-style18">
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("PUserName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">Nama</td>
                                <td class="auto-style16">:</td>
                                <td class="auto-style17">
                                    <asp:Label ID="lblNama" runat="server" Text='<%# Eval("PNama") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">No Telepon</td>
                                <td class="auto-style14">:</td>
                                <td class="auto-style2">
                                    <asp:Label ID="lblNoTelp" runat="server" Text='<%# Eval("PNoTelp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td class="auto-style13">No Kartu Kredit</td>
                                <td class="auto-style14">:</td>
                                <td class="auto-style2">
                                    <asp:Label ID="lblNoKartu" runat="server" Text='<%# Eval("PNoKartuKredit") %>'></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td class="auto-style13">
                                    <asp:HiddenField ID="hfPassword" runat="server" Value='<%# Eval("PPassword") %>' />
                                </td>
                                <td class="auto-style14"></td>
                                <td class="auto-style2">
                                    <asp:HiddenField ID="hfHak" runat="server" Value='<%# Eval("PHak") %>' />
                                </td>
                            </tr>
                            <tr>

                                <td class="auto-style2" colspan="3">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">Select</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>Username</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtUsername" ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtPassword" ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Konfirmasi Password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKonfirmasi" Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password" ControlToCompare="txtPassword" ControlToValidate="txtKonfirmasi" Display="Dynamic" ValidationGroup="USR"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Nama</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNama" ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>No Telepon</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNoTelp" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoTelp" Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Masukkan Angka, Minimal 15 Digit" ControlToValidate="txtNoTelp" Display="Dynamic" ValidationExpression="^[0-9]{1,15}$ " ValidationGroup="USR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Nomor Kartu Kredit</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtNoKK" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoKK" Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Masukkan Angka, Minimal 16 Digit" ControlToValidate="txtNoKK" Display="Dynamic" ValidationGroup="USR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Hak Admin</td>
            <td>:</td>
            <td>
                <asp:CheckBox ID="chkHak" runat="server" Text="Yes" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_simpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    ValidationGroup="FrmEntry" OnClick="btnSimpan_Click" />
                <asp:Button runat="server"
                    ID="Btn_ubah"
                    CssClass="MainButton"
                    Text="Ubah"
                    ValidationGroup="FrmEntry" OnClick="btnUbah_Click" />
                <asp:Button runat="server"
                    ID="Btn_hapus"
                    CssClass="MainButton"
                    Text="Hapus" OnClick="btnHapus_Click" />
                <asp:Button runat="server"
                    ID="Btn_batal"
                    CssClass="MainButton"
                    Text="Batal" OnClick="btnBatal_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
