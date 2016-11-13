<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomeA.aspx.cs" Inherits="welcomea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                        <asp:LinkButton ID="quit" runat="server" Text="注销"  OnClick="quit_Click"></asp:LinkButton>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    管理用户信息&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎您<asp:Label ID="Aname" runat="server"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 管理图书馆<br />
        <br />
&nbsp;<asp:ImageButton ID="AUsers" runat="server"  ToolTip="管理用户信息" ImageUrl="~/2.jpg" PostBackUrl="~/AUsersInf.aspx" Height="80px" Width="382px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        信息名片
        <asp:ImageButton ID="Alibrary" runat="server" ToolTip="管理图书馆" ImageUrl="~/4.jpg" PostBackUrl="~/ALibrary.aspx" Height="84px" style="margin-left: 233px; margin-bottom: 0px" Width="380px" />
        &nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="AInf" runat="server" ToolTip="用户信息" ImageUrl="~/5.jpeg" PostBackUrl="~/Users.aspx" Height="336px" Width="261px" />
    </div>
    </form>
</body>
</html>
