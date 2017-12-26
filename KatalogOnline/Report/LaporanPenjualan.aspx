<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="LaporanPenjualan.aspx.cs" Inherits="KatalogOnline.Report.LaporanPenjualan" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <BDP:BasicDatePicker ID="dtpTanggalAwal" runat="server" DateFormat="dd-MM-yyyy" />
    S/D<BDP:BasicDatePicker ID="dtpTanggalAkhir" runat="server" DateFormat="dd-MM-yyyy" />
    <br />
    <asp:Button ID="btnCetak" runat="server" Text="Cetak" OnClick="btnCetak_Click" />
    <br />
    <asp:ImageButton ID="lbpdf" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/PDF.png" Width="50px" OnClick="lbpdf_Click" />
    <asp:ImageButton ID="lbexcel" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/EXCEL.PNG" Width="50px" OnClick="lbexcel_Click" />
    <asp:ImageButton ID="lbword" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/WORD.PNG" Width="50px" OnClick="lbword_Click" />
    <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/RTF.png" Width="50px" OnClick="ImageButton1_Click" />
    <br />
    <div class="auto-style1">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayToolbar="False" ReuseParameterValuesOnRefresh="True" ToolPanelView="None" />
    </div>
</asp:Content>
