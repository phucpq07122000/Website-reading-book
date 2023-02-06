<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VuThao.Train._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Demo sử dụng Api.</p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <p><a class="btn btn-primary btn-lg btnCallApiSuccess">Call api success &raquo;</a></p>
        <p><a class="btn btn-primary btn-lg btnCallApiFail">Call api fail &raquo;</a></p>
    </div>    

</asp:Content>
