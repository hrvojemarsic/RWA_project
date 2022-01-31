<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <p>
            Dobrodošli <asp:Label ID="lblUser" runat="server" CssClass="badge bg-info"/>
        </p>
        <p>
            Datum i vrijeme prijave: <asp:Label ID="lblDate" Text="" runat="server"/>
        </p>
        <asp:Button ID="btnLogout" Text="Odjavite se" runat="server" CssClass="btn btn-danger" OnClick="btnLogout_Click"/>
    </div>
</asp:Content>
