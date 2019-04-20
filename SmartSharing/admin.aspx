<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="SmartSharing.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/admin.css" />
    <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button_logout" />
            <br />

            <h1>Донации</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SelectionForeColor="White" CssClass="mygrdContent" PagerStyle-CssClass="pager" ToolTip="Сите донации" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" CellPadding="4" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>

                    <asp:TemplateField HeaderText="Тип на донација">
                        <EditItemTemplate>
                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("Tipnadonacija") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tipnadonacija") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Димензии">
                        <EditItemTemplate>
                            <asp:Label ID="Label16" runat="server" Text='<%# Eval("Dimenzii") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Dimenzii") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Состојба">
                        <EditItemTemplate>
                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("Sostojba") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sostojba") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Статус">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Vrednost") %>' Width="84px"></asp:TextBox>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Vrednost") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Примач">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("Baratel") %>' Width="84px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Baratel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Донатор">
                        <EditItemTemplate>

                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Donator") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Donator") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Админ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("Account") %>' Width="84px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Account") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Објавена на:">
                        <EditItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("Datum_objavuva") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Datum_objavuva") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Доделена на:">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("Datum_dodelena") %>' Width="84px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Datum_dodelena") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Operacii">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" ControlStyle-ForeColor="Black" CommandName="update">Update</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton4" runat="server" ControlStyle-ForeColor="Black" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" ControlStyle-ForeColor="Black" CommandName="Edit">Edit</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" ControlStyle-ForeColor="Black" CommandName="Delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="header"></HeaderStyle>
                <PagerStyle CssClass="pager"></PagerStyle>
                <RowStyle CssClass="rows"></RowStyle>
            </asp:GridView>


            <br />
            <asp:Label ID="tekst" runat="server" Text="Label"></asp:Label>
            <br />


            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegiConnectionString %>" DeleteCommand="DELETE FROM [Donacija] WHERE [ID_donacija] = @ID_donacija" InsertCommand="INSERT INTO [Donacija] ([Tipnadonacija], [Dimenzii], [Sostojba], [ID_status], [ID_korisnik_primac], [ID_korisnik_donator], [ID_admin], [Datum_objavuva], [Datum_dodelena]) VALUES (@Tipnadonacija, @Dimenzii, @Sostojba, @ID_status, @ID_korisnik_primac, @ID_korisnik_donator, @ID_admin, @Datum_objavuva, @Datum_dodelena)" SelectCommand="SELECT d.Tipnadonacija, d.Dimenzii, d.Sostojba, sd.Vrednost, k.Korisnickoime AS Baratel, kk.Korisnickoime AS Donator, a.Account, d.Datum_dodelena, d.Datum_objavuva FROM Donacija AS d INNER JOIN StatusNaDonacija AS sd ON d.ID_status = sd.ID_status LEFT JOIN Korisnik AS k ON d.ID_korisnik_primac = k.ID_korisnik INNER JOIN Korisnik AS kk ON d.ID_korisnik_donator = kk.ID_korisnik INNER JOIN Admin AS a ON d.ID_admin = a.ID_admin" UpdateCommand="UPDATE [Donacija] SET [Tipnadonacija] = @Tipnadonacija, [Dimenzii] = @Dimenzii, [Sostojba] = @Sostojba, [ID_status] = @ID_status, [ID_korisnik_primac] = @ID_korisnik_primac, [ID_korisnik_donator] = @ID_korisnik_donator, [ID_admin] = @ID_admin, [Datum_objavuva] = @Datum_objavuva, [Datum_dodelena] = @Datum_dodelena WHERE [ID_donacija] = @ID_donacija">
                <DeleteParameters>
                    <asp:Parameter Name="ID_donacija" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Tipnadonacija" Type="String" />
                    <asp:Parameter Name="Dimenzii" Type="String" />
                    <asp:Parameter Name="Sostojba" Type="String" />
                    <asp:Parameter Name="ID_status" Type="Int32" />
                    <asp:Parameter Name="ID_korisnik_primac" Type="Int32" />
                    <asp:Parameter Name="ID_korisnik_donator" Type="Int32" />
                    <asp:Parameter Name="ID_admin" Type="Int32" />
                    <asp:Parameter DbType="Date" Name="Datum_objavuva" />
                    <asp:Parameter DbType="Date" Name="Datum_dodelena" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Tipnadonacija" Type="String" />
                    <asp:Parameter Name="Dimenzii" Type="String" />
                    <asp:Parameter Name="Sostojba" Type="String" />
                    <asp:Parameter Name="ID_status" Type="Int32" />
                    <asp:Parameter Name="ID_korisnik_primac" Type="Int32" />
                    <asp:Parameter Name="ID_korisnik_donator" Type="Int32" />
                    <asp:Parameter Name="ID_admin" Type="Int32" />
                    <asp:Parameter DbType="Date" Name="Datum_objavuva" />
                    <asp:Parameter DbType="Date" Name="Datum_dodelena" />
                    <asp:Parameter Name="ID_donacija" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>


            <br />
            <h1>Поднесени барања за донации</h1>

            <asp:TextBox ID="baranje1" runat="server" placeholder="Внесете Тип на донација"></asp:TextBox>
            <asp:TextBox ID="baranje2" runat="server" placeholder="Внесете донатор"></asp:TextBox>
            <asp:Button ID="bbaranje" runat="server" Text="Пребарувај" OnClick="bbaranje_Click" />

            <br />
            <br />


            <asp:GridView ID="GridView3" runat="server" CaptionAlign="Top" HorizontalAlign="Justify" DataKeyNames="Тип_на_донација" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" ToolTip="Поднесени барања за донации" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:CommandField HeaderText="Потврда од УЈП" ShowSelectButton="True" ControlStyle-ForeColor="Red" SelectText="Симни документ" />
                </Columns>
            </asp:GridView>



            <br />
            <h1>Регистрирани корисници</h1>
            <asp:GridView ID="GridView4" runat="server" CaptionAlign="Top" HorizontalAlign="Justify" ToolTip="Корисници" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">

                <Columns>
                    <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime" />
                    <asp:BoundField DataField="Grad" HeaderText="Grad" SortExpression="Grad" />
                    <asp:BoundField DataField="Ulica" HeaderText="Ulica" SortExpression="Ulica" />
                    <asp:BoundField DataField="Drzava" HeaderText="Drzava" SortExpression="Drzava" />
                    <asp:BoundField DataField="Korisnickoime" HeaderText="Korisnickoime" SortExpression="Korisnickoime" />
                    <asp:BoundField DataField="Tip" HeaderText="Tip" SortExpression="Tip" />
                </Columns>
                <HeaderStyle CssClass="header"></HeaderStyle>
                <PagerStyle CssClass="pager"></PagerStyle>
                <RowStyle CssClass="rows"></RowStyle>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegiConnectionString %>" SelectCommand="SELECT [Ime], [Prezime], [Grad], [Ulica], [Drzava], [Korisnickoime], [Tip] FROM [Korisnik]"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
