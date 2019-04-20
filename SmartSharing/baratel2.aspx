<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baratel2.aspx.cs" Inherits="SmartSharing.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/baratel2.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Button ID="Button_logout1" runat="server" Text="Log out" OnClick="Button_logout" />
            <br />
            
            <h1>Дополнителни податоци</h1>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Број на членови на семејство | пример: 4"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Просечни месечни примања | пример: 50000ден"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Дополнителен коментар"></asp:TextBox>
            <br />
            <br />
            Внесете документ - Потврда за остварени месечни примања издадена од УЈП<br /><br />
            Одберете документ:
             <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="" Style="height: 22px" />

            <br />
            <asp:Label ID="tekst" runat="server" Text=""></asp:Label>
            
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Назад" />
            <asp:Button ID="Button1" runat="server" Text="Поднеси барање" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
