<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ALendB.aspx.cs" Inherits="ALendB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:LinkButton ID="welcome" runat="server" Text="图书馆首页"  PostBackUrl="~/WelcomeA.aspx"></asp:LinkButton>
                        <asp:LinkButton ID="quit" runat="server" Text="注销"  OnClick="quit_Click"></asp:LinkButton>
        修改借阅信息
        
        <br />
        借阅用户：<asp:Label ID="Alname" runat="server" ></asp:Label>

        <br />

        书名：<asp:Label ID="Albname" runat="server" ></asp:Label>
        <br />
        作者：<asp:Label ID="Alauthor" runat="server" ></asp:Label>
        <br />
        出版社<asp:Label ID="Alpress" runat="server" ></asp:Label>
        <br />
        分类：<asp:Label ID="Alcateg" runat="server" ></asp:Label>
        <br />
        借阅状态：<asp:DropDownList ID="Aste" runat="server" ></asp:DropDownList>
        <br />

        <br />
        逾期日期：<asp:TextBox ID="Aldate" runat="server" TextMode="SingleLine"></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Aldate" ErrorMessage="输入日期错误" ValidationExpression="^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$" Display="Dynamic"></asp:RegularExpressionValidator>    


        <br />

        <br />
        
        <asp:Button ID="Aleditor" runat="server" Text="修改"   OnClick="Aleditor_Click"/>
        <asp:Button ID="Alback" runat="server" Text="返回"  PostBackUrl="~/ALibrary.aspx" />
    </div>
    </form>
</body>
</html>
