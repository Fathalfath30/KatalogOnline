<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="LaporanKategori.aspx.cs" Inherits="KatalogOnline.Report.LaporanKategori" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <asp:ImageButton ID="lbpdf" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/PDF.png" Width="50px" OnClick="lbpdf_Click" />
    <asp:ImageButton ID="lbexcel" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/EXCEL.PNG" Width="50px" OnClick="lbexcel_Click" />
    <asp:ImageButton ID="lbword" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/WORD.PNG" Width="50px" OnClick="lbword_Click" />
    <asp:ImageButton ID="lbrtf" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/RTF.png" Width="50px" OnClick="lbrtf_Click" /> 
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
