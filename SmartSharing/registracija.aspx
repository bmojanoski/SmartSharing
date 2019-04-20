<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="SmartSharing.Registracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href="css/registracija.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet"/>
</head>
<body>

    <form id="form1" runat="server">
        <div class="div1">
                    <h1>Регистрација</h1>
        
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Внесете Име"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Внесете Презиме"></asp:TextBox>
            <br /> <br />
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Внесете Град"></asp:TextBox>
            
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Внесете Улица"></asp:TextBox>
            
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Внесете Држава"></asp:TextBox>
            <br /> <br />
           <asp:TextBox ID="TextBox6" runat="server" placeholder="Внесете Корисничко име/Е-мајл"></asp:TextBox>
            
            <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" placeholder="Внесете Лозинка"></asp:TextBox>
             <br /> <br />
            <asp:TextBox ID="TextBox8" runat="server" placeholder="Внесете Телефон"></asp:TextBox>
            <br /> <br />
            <div id="div2">
            <asp:RadioButtonList ID="tip" runat="server" RepeatLayout="Flow">
                     <asp:ListItem Text="Donator">Donator</asp:ListItem>
                     <asp:ListItem Text="Baratel">Baratel na donacija</asp:ListItem>
            </asp:RadioButtonList>
            </div>
            
            <br /> <br /> 
            <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="Регистрирај се!" />
            <asp:Label ID="poraka" runat="server" Text=""></asp:Label>
            <br />
            
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label">Веќе сте член?</asp:Label>
             <asp:HyperLink ID="HyperLink1" NavigateUrl="home.aspx" runat="server">Најавете се!</asp:HyperLink>
            
    
        </div>
    </form>

</body>
</html>
