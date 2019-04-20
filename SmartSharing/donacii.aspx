<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="donacii.aspx.cs" Inherits="SmartSharing.Donacii" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/donacii.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Назад" />

            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <h1>Твоите донации</h1>
            <br />
            <asp:GridView ID="GridView2" runat="server" Caption="" CaptionAlign="Top" HorizontalAlign="Justify" DataKeyNames="Тип" ToolTip="Твои поднесени донации" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
