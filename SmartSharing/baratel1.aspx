<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baratel1.aspx.cs" Inherits="SmartSharing.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/baratel1.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button_logout" />
            <asp:Label ID="Label1" runat="server" Text="Добредојдовте  "></asp:Label>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegiConnectionString %>" SelectCommand="SELECT [Tipnadonacija], [Dimenzii], [Sostojba] FROM [Donacija] WHERE ID_status='1'"></asp:SqlDataSource>

            <h1>Активни огласи</h1>

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  CellPadding="10" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:CommandField SelectText="Одбери" ShowSelectButton="True" />
                    <asp:BoundField HeaderText="Tipnadonacija" DataField="Tipnadonacija" />
                    <asp:BoundField HeaderText="Dimenzii" DataField="Dimenzii" />
                    <asp:BoundField HeaderText="Sostojba" DataField="Sostojba" />
                </Columns>
                <HeaderStyle CssClass="header"></HeaderStyle>
                <PagerStyle CssClass="pager"></PagerStyle>
                <RowStyle CssClass="rows"></RowStyle>
                <SelectedRowStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
            </asp:GridView>

            <asp:Label ID="tekst" runat="server" Text="  "></asp:Label>

            <br /><br /><br /><br /> <br /> <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button_sledno" Text="Следно" />

        </div>
    </form>
</body>
</html>
