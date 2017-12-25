<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ModifikasiPromo.aspx.cs" Inherits="KatalogOnline.DataPromo.ModifikasiPromo" %>

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
                <h4><u>MODIFIKASI PROMO</u></h4>
            </td>
        </tr>
        <tr>
            <td>Cari Nama Barang</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtCariNama" class="form-control col-6" runat="server"
                    OnTextChanged="txtCariNama_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4"
                    DataKeyNames="PKdBrg" EmptyDataText="Data Tidak Ada" PageSize="5"
                    CssClass="table table-light table-bordered"
                    OnSelectedIndexChanged="gvBarang_SelectedIndexChanged"
                    OnPageIndexChanging="gvBarang_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" DataFormatString="{0:C}"
                            HeaderText="Harga Barang" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>Barang Promosi</td>
            <td>:</td>
            <td>
                <asp:DetailsView ID="dvPromo" runat="server" AutoGenerateRows="False"
                    BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="PKdBrg"
                    CssClass="table table-striped table-bordered"
                    EmptyDataText="TIDAK ADA PROMO" Height="50px" Width="125px" OnPageIndexChanging="dvPromo_PageIndexChanging" OnModeChanging="dvPromo_ModeChanging" OnItemDeleting="dvPromo_ItemDeleting" OnItemUpdating="dvPromo_ItemUpdating">
                    <Fields>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PInfoPromo" HeaderText="Info Promo" />
                        <asp:BoundField DataField="PHrgPromo" DataFormatString="{0:C}"
                            HeaderText="Harga Promo" />
                        <asp:CommandField CancelText="Batal" EditText="Modifikasi"
                            ShowEditButton="True" UpdateText="Ubah" />
                        <asp:CommandField DeleteText="Hapus" ShowDeleteButton="True" />
                    </Fields>

                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
