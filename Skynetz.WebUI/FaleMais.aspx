<%@ Page Title="Planos Fale Mais" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FaleMais.aspx.cs" Inherits="Skynetz.WebUI.FaleMais" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:GridView runat="server" ID="GridFaleMais" class="table table-striped"></asp:GridView>
</asp:Content>