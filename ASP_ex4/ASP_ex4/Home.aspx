<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASP_ex4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Upload.aspx">Upload</asp:HyperLink>
        <br />
        <br />
    
        <asp:DropDownList ID="DropDownListOfImages" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
        
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        
    </div>
    </form>
</body>
</html>
