<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenBarang.aspx.cs" Inherits="KatalogOnline.Main_asp.DataBarang.ManajemenBarang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
    <style type="text/css">
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <td>
    <table style="width:100%;" border="1" cellpadding="2" cellspacing="0">
        <tr>
            <td class="style1" colspan="3">MANAJEMEN DATA BARANG</td>
        </tr>
        <tr>
            <td class="style4">Cari Kategori</td>
            <td class="style3">:</td>
            <td>
                <asp:DropDownList runat="server" id="Ddown_CariKategori"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Cari Nama Barang
            </td>
            <td class="style3">:</td>
            <td>
                <asp:TextBox ID="Txt_CariNmBarang" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td class="style2" colspan="3">
                <asp:GridView runat="server" ID="Gview_Barang"
                    AllowPaging="true" 
                    PageSize="5" 
                    EmptyDataText="GRID TIDAK ADA DATA" 
                    AutoGenerateColumns="false"
                    BackColor="White" 
                    BorderColor="#CC9966" 
                    BorderStyle="None" 
                    BorderWidth="1px"
                    CellPadding="4">
                    <Columns>
                        <asp:ImageField 
                            DataImageUrlFormatString="~/User_files/Upload/{0}" 
                            HeaderText="Gambar" 
                            DataImageUrlField="PGbrBrg">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PInfoBrg" HeaderText="Info Barang" />
                        <asp:BoundField DataField="PStokBrg" HeaderText="Stok" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Nama Kategori
            </td>
            <td class="style3">:</td>
            <td>
                <asp:DropDownList runat="server" ID="Ddown_NamaKategori"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Kode Barang
            </td>
            <td class="style3">:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_IdBarang" />
                <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_IdBarang" ControlToValidate="Txt_IdBarang" ValidationGroup="F_ManajemenBarang" ErrorMessage="Id Barang harus di isi !" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Nama Barang
            </td>
            <td class="style3">:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_NmBarang" />
                <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_NmBarang" ControlToValidate="Txt_NmBarang" ValidationGroup="F_ManajemenBarang" ErrorMessage="Nama barang harus di isi !" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Harga Barang
            </td>
            <td class="style3">:</td>
            <td>
                <asp:Label runat="server" ID="Lbl_Currency" Text="Rp." />&nbsp;
                <asp:TextBox runat="server" ID="Txt_HargaBarang" Text="0" />
                <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_HargaBarang"  ControlToValidate="Txt_HargaBarang" ErrorMessage="Harga Barang harus di isi, Maksimal 7 Digit"/>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Info Barang
            </td>
            <td class="style3">:</td>
            <td>
                <asp:TextBox runat="server" ID="Txt_InfoBarang" />
                <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_InfoBarang" ControlToValidate="Txt_InfoBarang" ValidationGroup="F_ManajemenBarang" ErrorMessage="Informasi Barang harus di isi !" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Gambar Barang
            </td>
            <td class="style3">
                &nbsp;
            </td>
            <td>
                <asp:FileUpload ID="Fu_GbrBarang" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Stok Barang
            </td>
            <td class="style3">
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" ID="Txt_stock" MaxLength="3" />
                <asp:RegularExpressionValidator runat="server" ID="REV_Txt_stock" ControlToValidate="Txt_stock" ErrorMessage="Hanya dapat menerima angka 0 - 9, Maksimal 3 digit" ValidationExpression="^[0-9]{1,3}$" ValidationGroup="F_ManajemenBarang" />
                <asp:RequiredFieldValidator runat="server" ID="RVF_Txt_stock" ControlToValidate="Txt_stock" ErrorMessage="Harap isi jumlah stock barang" ValidationGroup="F_ManajemenBarang" />
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                        <asp:Button runat="server" ID="BtnSimpan" Text="Simpan"
                            ValidationGroup="F_ManajemenBarang" />&nbsp;
                        <asp:Button runat="server" ID="BtnUbah" Text="Ubah" 
                            ValidationGroup="F_ManajemenBarang"/>&nbsp;
                        <asp:Button runat="server" ID="BtnHapus" Text="Hapus" />&nbsp;
                        <asp:Button runat="server" ID="BtnBatal" Text="Batal" />
            </td>
        </tr>
    </table>
    </td>
</asp:Content>
