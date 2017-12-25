<%@ Page Title="" Language="C#" MasterPageFile="~/Master/KatalogOnline.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KatalogOnline.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="server">
    <asp:Login runat="server"
        ID="LogWebOnline" FailureText="Username dan Password Tidak Sesuai"
        LoginButtonText="Masuk" PasswordRequiredErrorMessage="Masukkan Password" RememberMeText=" Ingat Aku"
        TitleText="LOGIN" UserNameRequiredErrorMessage="Masukkan Username" OnAuthenticate="LogWebOnline_Authenticate" />
</asp:Content>
