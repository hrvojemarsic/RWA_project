<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterControl.ascx.cs" Inherits="Project.Controls.RegisterControl" %>

<div class="container">

    <h2 style="text-align: center">RWA Projekt - Registracija</h2>

    <div class="form-group row">
        <label for="txtUserName" class="col-sm-2 col-form-label">Nadimak:</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
            <asp:RequiredFieldValidator ControlToValidate="txtUserName" runat="server" Display="Dynamic" Text="Nadimak je obavezan" CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="form-group row">
        <label for="txtEmail" class="col-sm-2 col-form-label">E-mail adresa:</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" Display="Dynamic" Text="E-mail adresa je obavezna" CssClass="form-text text-danger" />
            <asp:CustomValidator ID="emailExists" ControlToValidate="txtEmail" runat="server" Display="Dynamic" Text="E-mail adresa je zauzeta" CssClass="form-text text-danger" />
            <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic" Text="E-mail adresa nije ispravna"
                CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="form-group row">
        <label for="txtUserPass" class="col-sm-2 col-form-label">Lozinka:</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtUserPass" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPass" Display="Dynamic" Text="Lozinka je obavezna" CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="form-group row">
        <label for="txtConfirmUserPass" class="col-sm-2 col-form-label">Ponovi lozinku:</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtConfirmUserPass" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmUserPass" Display="Dynamic" Text="Lozinka je obavezna" CssClass="form-text text-danger" />
            <asp:CompareValidator runat="server" ControlToValidate="txtConfirmUserPass" ControlToCompare="txtUserPass" Display="Dynamic" Text="Morate unijeti istu lozinku"
                CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="btn-group">
        <asp:Button runat="server" ID="btnRegister" Text="Registriraj se" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
        <asp:Button runat="server" ID="btnLogin" Text="Prijavi se" CssClass="btn btn-success" CausesValidation="false" OnClick="btnLogin_Click" />
    </div>

<asp:Label ID="lblError" runat="server" Text="" CssClass="alert alert-danger" />
</div>
