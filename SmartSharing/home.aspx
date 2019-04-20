<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SmartSharing.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/home.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet" />
</head>
<body>
    <div id="div2">
        <form id="form1" runat="server">
            <div id="div1" >
                <h1>Добредојдовте!</h1>
                <br />
                <br />
                <asp:TextBox ID="TextBox11" runat="server" placeholder="Внесете корисничко име..."></asp:TextBox>
                <asp:Label ID="akaunt" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <br />
                <asp:TextBox ID="TextBox22" runat="server" TextMode="Password" placeholder="Внесете лозинка..."></asp:TextBox>
                <asp:Label ID="pasvord" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <br />
                <asp:RadioButtonList ID="tip" runat="server" RepeatLayout="Flow">
                    <asp:ListItem Text="Donator" Value="Donator">Донатор</asp:ListItem>
                    <asp:ListItem Text="Baratel" Value="Baratel na donacija">Барател на донација</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="kopcinja" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Најавете се!" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"> Не сте регистрирани?</asp:Label>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="registracija.aspx" runat="server">Регистрирај се!</asp:HyperLink>
                <br />
            </div>
        </form>
    </div>
</body>
</html>
