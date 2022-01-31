<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project.Register" %>
<%@ Register Src="Controls/RegisterControl.ascx" TagName="RegisterControl" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RWA Projekt - Registracija</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:RegisterControl runat="server" ID="registerControl" />
    </form>
</body>
</html>
