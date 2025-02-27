<%@ Page Title="Tarifas Fixas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Taxas.aspx.cs" Inherits="Skynetz.WebUI.Taxas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>    
    <asp:GridView runat="server" ID="GridTaxas" class="table table-striped"></asp:GridView>
</asp:Content>