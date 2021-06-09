<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="Project.Bills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- filteri -->
    <!-- odabir države -->

    <div class="container">
        <asp:DropDownList runat="server" ID="ddlCountries" AutoPostBack="true"
            CssClass="container" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <!-- odabir grada -->
    <div class="container">
        <asp:DropDownList runat="server" ID="ddlCities" AutoPostBack="true"
            CssClass="container" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <br />
    <!-- prikaz kupaca -->
    <div class="container">
        <asp:Repeater runat="server" ID="repeaterBuyers">
            <HeaderTemplate>
                <table class="table table-primary table-hover">
                    <tr>
                        <th>ID</th>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>E-mail</th>
                        <th>Grad</th>
                        <th>Država</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("IDBuyer") %></td>
                    <td><%# Eval("FirstName") %></td>
                    <td><%# Eval("LastName") %></td>
                    <td><%# Eval("Email") %></td>
                    <td><%# Eval("CityName") %></td>
                    <td><%# Eval("CountryName") %></td>
                    <td>
                        <asp:LinkButton Text="Prikaži račune" runat="server" CssClass="btn btn-primary btn-sm"
                            ID="lbShowBills" CommandArgument='<%# Eval("IDBuyer") %>' 
                            OnClick="lbShowBills_Click"/>
                    </td>
                    <td>
                        <asp:LinkButton Text="Ažuriraj podatke" runat="server" CssClass="btn btn-default btn-sm"
                            ID="lbEditBuyer" CommandArgument='<%# Eval("IDBuyer") %>' 
                            OnClick="lbEditBuyer_Click"/>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr>
                    <td><%# Eval("IDBuyer") %></td>
                    <td><%# Eval("FirstName") %></td>
                    <td><%# Eval("LastName") %></td>
                    <td><%# Eval("Email") %></td>
                    <td><%# Eval("CityName") %></td>
                    <td><%# Eval("CountryName") %></td>
                    <td>
                        <asp:LinkButton Text="Prikaži račune" runat="server" CssClass="btn btn-primary btn-sm"
                            ID="lbShowBills" CommandArgument='<%# Eval("IDBuyer") %>' 
                            OnClick="lbShowBills_Click"/>
                    </td>
                    <td>
                        <asp:LinkButton Text="Ažuriraj podatke" runat="server" CssClass="btn btn-default btn-sm"
                            ID="lbEditBuyer" CommandArgument='<%# Eval("IDBuyer") %>' 
                            OnClick="lbEditBuyer_Click"/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!-- prikaz računa kupca -->
        <div class="container">
        <asp:Repeater runat="server" ID="repeaterBills">
            <HeaderTemplate>
                <table class="table table-primary">
                    <tr>
                        <th>ID</th>
                        <th>Datum izdavanja</th>
                        <th>Broj računa</th>
                        <th>&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("IDBill") %></td>
                    <td><%# Eval("DateOfIssue") %></td>
                    <td><%# Eval("BillNumber") %></td>
                    <td>
                        <asp:LinkButton Text="Prikaži detalje" runat="server" CssClass="btn btn-primary btn-sm"
                            ID="lbShowBillDetails" CommandArgument='<%# Eval("IDBill") %>' 
                            OnClick="lbShowBillDetails_Click"/>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr>
                    <td><%# Eval("IDBill") %></td>
                    <td><%# Eval("DateOfIssue") %></td>
                    <td><%# Eval("BillNumber") %></td>
                    <td>
                        <asp:LinkButton Text="Prikaži detalje" runat="server" CssClass="btn btn-primary btn-sm"
                            ID="lbShowBillDetails" CommandArgument='<%# Eval("IDBill") %>' 
                            OnClick="lbShowBillDetails_Click"/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!-- prikaz detalja računa -->
        <div class="container">
        <asp:Repeater runat="server" ID="repeaterBillDetails">
            <HeaderTemplate>
                <table class="table table-primary">
                    <tr>
                        <th>ID</th>
                        <th>Proizvod</th>
                        <th>Naziv potkategorije</th>
                        <th>Naziv kategorije</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Product") %></td>
                    <td><%# Eval("Subcategory") %></td>
                    <td><%# Eval("Category") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Product") %></td>
                    <td><%# Eval("Subcategory") %></td>
                    <td><%# Eval("Category") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <asp:Label ID="lblInfo" runat="server" />
</asp:Content>
