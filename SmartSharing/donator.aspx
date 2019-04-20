<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="donator.aspx.cs" Inherits="SmartSharing.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="css/donator.css" />
      <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Види твои донации" />
            <asp:Button ID="Button_logout1" runat="server" Text="Log out" OnClick="Button_logout" />
            
            
            <br />
            <br />
            <br />
            <h1>Поднеси донација</h1>
            <asp:Label ID="tekst" runat="server" Text=""></asp:Label><br /><br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Тип на донација"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Димензии пример: ДОЛЖИНА x ШИРИНА x ВИСИНА"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Состојба"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Поднеси донација" OnClick="Button1_Click" />
            
        </div>
    </form>
</body>
</html>
