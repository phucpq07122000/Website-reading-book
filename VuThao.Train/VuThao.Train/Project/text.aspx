<%@ Page Title="Text" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="text.aspx.cs" Inherits="VuThao.Train.Project.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div id="Page" style="margin: 20px 15% 20px 15%; background: white; height: 1000px"></div>
    <script>
        $(window).load(function () {
            $("#Page").html(sessionStorage.getItem("Vol"));
            $("#Page").html($("#Page").text())
        });
     
    </script>


</asp:Content>
