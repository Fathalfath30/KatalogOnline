<%@ Page Title="" Language="C#" MasterPageFile="~/Master_page/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="ModifikasiPromo.aspx.cs" Inherits="KatalogOnline.Main_asp.DataPromo.ModifikasiPromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <table style="width:56%; height: 444px;" border="1">
        <tr>
            <td colspan="3">
                <center><h3><u>MODIFIKASI PROMO</u></h3></center>
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
                <asp:TextBox ID="txtCariNama" runat="server" AutoPostBack="True"
                             ontextchanged="txtCariNama_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True"
                              AutoGenerateColumns="False" CellPadding="4"
                              EmptyDataText="DATA TIDAK ADA" PageSize="5"
                              onselectedindexchanged="gvBarang_SelectedIndexChanged"
                              DataKeyNames="PKdBrg" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
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
                Barang Promosi
            </td>
            <td>
                :
            </td>
            <td>
                <asp:DetailsView ID="dvPromo" runat="server" AutoGenerateRows="False" EmptyDataText="TIDAK ADA PROMO"
                                 Height="50px" Width="50%"
                                 DataKeyNames="PKdBrg" onpageindexchanging="dvPromo_PageIndexChanging"
                                 OnModeChanging="dvPromo_ModeChanging"
                                 OnItemDeleting="dvPromo_ItemDeleting"
                                 OnItemUpdating="dvPromo_ItemUpdating">
                    <Fields>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" ReadOnly="True" />
                        <asp:BoundField DataField="PInfoPromo" HeaderText="Info Promo" />
                        <asp:BoundField DataField="PHrgPromo" HeaderText="Harga Promo" />
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>
