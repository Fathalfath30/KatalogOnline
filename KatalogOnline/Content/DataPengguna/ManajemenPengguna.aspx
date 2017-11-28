<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenPengguna.aspx.cs" Inherits="KatalogOnline.Main_asp.DataPengguna.ManajemenPengguna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table style="width:88%;" border="1">
        <tr>
            <td colspan="3">
                <center><h3><u>MANAJEMEN PENGGUNA</u></h3></center>
            </td>
        </tr>
        <tr>
            <td>
                Cari Nama Pengguna
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtCariNama" runat="server" AutoPostBack="True"
                             ontextchanged="txtCariNama_TextChanged" Width="219px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:DataList ID="dlPengguna" runat="server" RepeatDirection="Horizontal"
                              Visible="False" DataKeyField="PPassword"
                              onselectedindexchanged="dlPengguna_SelectedIndexChanged">
                    <ItemTemplate>
                        <table style="width:100%;" border="1">
                            <tr>
                                <td>
                                    Username
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("PUserName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nama
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblNama" runat="server" Text='<%# Eval("PNama") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No Telepon
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblNoTelp" runat="server" Text='<%# Eval("PNoTelp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No Kartu Kredit
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblNoKartu" runat="server" Text='<%# Eval("PNoKartuKredit") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hfPassword" runat="server"
                                                     Value='<%# Eval("PPassword") %>' />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfHak" runat="server" Value='<%# Eval("PHak") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Select">Select
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                Username
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtUsername" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="SIMPAN"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="254px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtPassword" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="SIMPAN"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Konfirmasi Password
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" runat="server" Width="250px"
                             TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server"
                                      ControlToCompare="txtPassword" ControlToValidate="txtKonfirmasi"
                                      Display="Dynamic" ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password"
                                      ValidationGroup="SIMPAN"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="txtKonfirmasi" Display="Dynamic"
                                            ErrorMessage="Tidak Boleh Kosong" ValidationGroup="SIMPAN"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Nama
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNama" runat="server" Width="237px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtNama" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="SIMPAN"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                No Telepon
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNoTlp" runat="server" Width="198px" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="txtNoTlp" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="SIMPAN" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                ControlToValidate="txtNoTlp" Display="Dynamic"
                                                ErrorMessage="Masukkan Angka, Maksimal 15 Digit"
                                                ValidationExpression="^[0-9]{1,15}$" ValidationGroup="SIMPAN"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                No Kartu Kredit
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNoKK" runat="server" Width="226px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="txtNoKK" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="SIMPAN" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtNoKK" Display="Dynamic"
                                                ErrorMessage="Masukkan Angka, Maksimal 16 Digit"
                                                ValidationExpression="^[0-9]{1,16}$" ValidationGroup="SIMPAN"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Hak Admin
            </td>
            <td>
                :
            </td>
            <td>
                <asp:CheckBox ID="chkHak" runat="server" Text="Yes" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSimpan" runat="server" Text="S I M P A N"
                            onclick="btnSimpan_Click" ValidationGroup="SIMPAN" />
                &nbsp;<asp:Button ID="btnUbah" runat="server" Text="U B A H" onclick="btnUbah_Click"
                                  style="height: 26px" />
                &nbsp;<asp:Button ID="btnHapus" runat="server" Text="H A P U S" onclick="btnHapus_Click" />
                &nbsp;<asp:Button ID="btnBatal" runat="server" Text="B A T A L" onclick="btnBatal_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
