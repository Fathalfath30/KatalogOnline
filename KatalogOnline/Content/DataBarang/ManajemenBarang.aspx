<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenBarang.aspx.cs" Inherits="KatalogOnline.Main_asp.DataBarang.ManajemenBarang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
        .style2 {
            height : 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table style="width:70%;" border="1">
        <tr align="center">
            <td colspan="3">
                <center><h3><u>MANAJEMEN DATA BARANG</u></h3></center>
            </td>
        </tr>
        <tr>
            <td>
                Cari Kategori
            </td>
            <td>
                :
            </td>
            <td>
                <asp:DropDownList ID="ddCariKategori" runat="server"
                                  onselectedindexchanged="ddCariKategori_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Cari Nama Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtCariNmBarang" runat="server" AutoPostBack="True"
                             ontextchanged="txtCariNmBarang_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True" PageSize="5"
                              AutoGenerateColumns="False" CellPadding="4"
                              DataKeyNames="PKdBrg,PIdKat,PGbrBrg"
                              OnSelectedIndexChanged="gvBarang_SelectedIndexChanged"
                              OnPageIndexChanging="gvBarang_PageIndexChanging"
                              EmptyDataText="DATA BARANG TIDAK ADA" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:ImageField DataImageUrlField="PGbrBrg"
                                        DataImageUrlFormatString="~/Gambar/Upload/{0}" HeaderText="Gambar">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PInfoBrg" HeaderText="Info Barang" />
                        <asp:BoundField DataField="PStokBrg" HeaderText="Stok" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                Nama Kategori
            </td>
            <td>
                :
            </td>
            <td>
                <asp:DropDownList ID="ddNmKategori" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Kode Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtKdBarang" runat="server" Width="192px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKdBarang"
                                            ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Nama Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNmBarang" runat="server" Width="228px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNmBarang"
                                            ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Harga Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Rp. "></asp:Label>
                <asp:TextBox ID="txtHrgBarang" runat="server" Width="102px" MaxLength="7"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="txtHrgBarang" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="BRG" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                ControlToValidate="txtHrgBarang"
                                                ErrorMessage="Masukkan Angka, Maksimal 7 Digit"
                                                ValidationExpression="^[0-9]{1,7}$" ValidationGroup="BRG"
                                                Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Info Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtInfoBarang" runat="server" Width="262px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtInfoBarang"
                                            ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Gambar Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:FileUpload ID="fuGbrBarang" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Stok Barang
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtStok" runat="server" Width="60px" MaxLength="3"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtStok" Display="Dynamic"
                                                ErrorMessage="Masukkan Angka, Maksimal 3 Digit" SetFocusOnError="True"
                                                ValidationExpression="^[0-9]{1,3}$" ValidationGroup="BRG"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="txtStok" ErrorMessage="Tidak Boleh Kosong"
                                            ValidationGroup="BRG" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style2">
                <center>
                    <asp:Button ID="btnSimpan" runat="server" onclick="btnSimpan_Click"
                                Text="S I M P A N" ValidationGroup="SIMPAN" />
                    &nbsp;<asp:Button ID="btnUbah" runat="server" onclick="btnUbah_Click"
                                      Text="U B A H" />
                    &nbsp;<asp:Button ID="btnHapus" runat="server" onclick="btnHapus_Click" Text="H A P U S" />
                    &nbsp;<asp:Button ID="btnBatal" runat="server" Text="B A T A L" onclick="btnBatal_Click" />
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
