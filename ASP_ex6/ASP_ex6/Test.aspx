<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ASP_ex6.Test" %>

<%@ Register assembly="TestControl" namespace="TestControl" tagprefix="cc1" %>

<%@ Register assembly="mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System" tagprefix="cc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:ServerControl1 ID="ServerControl11" runat="server" />
    </form>
</body>
</html>
