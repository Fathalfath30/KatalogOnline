<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ManajemenBarang.aspx.cs" Inherits="KatalogOnline.DataBarang.ManajemenBarang" %>

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
                <h4><u>MANAJEMEN BARANG</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Kategori</td>
            <td>:</td>
            <td>
                <asp:DropDownList runat="server"
                    ID="Dlist_cari_kategori" OnSelectedIndexChanged="Dlist_cari_kategori_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_cari_nama"
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="Gview_manajemen_barang" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False"
                    DataKeyNames="PKdBrg,PIdKat,PGbrBrg"
                    OnSelectedIndexChanged="Gview_manajemen_barang_SelectedIndexChanged"
                    OnPageIndexChanging="Gview_manajemen_barang_PageIndexChanging"
                    CssClass="table table-striped table-bordered table-hover"
                    EmptyDataText="DATA BARANG TIDAK ADA" PageSize="5"
                    CellPadding="4" 
                    ForeColor="#333333" 
                    EnableModelValidation="True">
                    <Columns>
                        <asp:ImageField DataImageUrlField="PGbrBrg"
                            DataImageUrlFormatString="~/Gambar/Upload/{0}" HeaderText="Gambar">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PInfoBrg" HeaderText="Info Barang" />
                        <asp:BoundField DataField="PStokBrg" HeaderText="Stok" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
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
            <td>Nama Kategori</td>
            <td>:</td>
            <td>
                <asp:DropDownList runat="server"
                    ID="Dlist_nama_kategori">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Kode Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_kode_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_kode_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Kode barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_nama_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_nama_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Nama barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Harga Barang</td>
            <td>:</td>
            <td>
                <asp:Label runat="server"
                    Text="Rp." />
                <asp:TextBox runat="server"
                    ID="Tbox_harga_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_harga_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Harga barang harus di isi!" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_harga_barang"
                    ValidationGroup="FrmEntry"
                    ValidationExpression="^[0-9]{1,7}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 7 karakter" />
            </td>
        </tr>
        <tr>
            <td>Info Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_info_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_info_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Info barang harus di isi!" />
            </td>
        </tr>
        <tr>
            <td>Gambar Barang</td>
            <td>:</td>
            <td>
                <asp:FileUpload runat="server"
                    ID="Fupload_foto_barang" />
            </td>
        </tr>
        <tr>
            <td>Stock Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server"
                    ID="Tbox_stock_barang" />
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="Tbox_stock_barang"
                    ValidationGroup="FrmEntry"
                    Display="Dynamic"
                    ErrorMessage="Stock barang harus di isi!" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="Tbox_stock_barang"
                    ValidationGroup="FrmEntry"
                    ValidationExpression="^[0-9]{1,3}$"
                    Display="Dynamic"
                    ErrorMessage="Hanya Menerima angka 0-9 sebanyak 3 karakter" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server"
                    ID="Btn_simpan"
                    CssClass="MainButton"
                    Text="Simpan"
                    ValidationGroup="FrmEntry" OnClick="Btn_simpan_Click" />
                <asp:Button runat="server"
                    ID="Btn_ubah"
                    CssClass="MainButton"
                    Text="Ubah"
                    ValidationGroup="FrmEntry" OnClick="Btn_ubah_Click" />
                <asp:Button runat="server"
                    ID="Btn_hapus"
                    CssClass="MainButton"
                    Text="Hapus" OnClick="Btn_hapus_Click" />
                <asp:Button runat="server"
                    ID="Btn_batal"
                    CssClass="MainButton"
                    Text="Batal" OnClick="Btn_batal_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
