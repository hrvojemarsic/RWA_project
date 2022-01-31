<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="Project.Controls.LoginControl" %>

<div class="container">

    <h2 style="text-align: center">RWA Projekt - Prijava</h2>

    <div class="form-group row">
        <label for="txtEmail" class="col-sm-2 col-form-label">Email adresa:</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" Display="Dynamic" Text="E-mail adresa je obavezna" CssClass="form-text text-danger" />
            <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic"
                Text="Unešena e-mail adresa nije ispravna" CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="form-group row">
        <label for="txtUserPass" class="col-sm-2 col-form-label">Lozinka</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" ID="txtUserPass" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPass" Display="Dynamic" Text="Lozinka je obavezna" CssClass="form-text text-danger" />
        </div>
    </div>

    <div class="btn-group">
        <asp:Button runat="server" ID="btnLogin" Text="Prijavi se" CssClass="btn btn-success" OnClick="btnLogin_Click" />
        <asp:Button runat="server" ID="btnRegister" Text="Registriraj se" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnRegister_Click" />
    </div>

    <asp:Label ID="lblError" runat="server" Text="" CssClass="alert alert-danger" />
</div>
