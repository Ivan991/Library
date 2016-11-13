<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABooks.aspx.cs" Inherits="Abooks" %>

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

          <br />
          修改图书信息        
        <br />
        <br />
        图书名：<asp:TextBox ID="Abname" runat="server" TextMode="SingleLine"></asp:TextBox>

        <br />

        <br />
        作者名：<asp:TextBox ID="Aauthor" runat="server" TextMode="SingleLine"></asp:TextBox>

        <br />

        <br />
        
        出版社：<asp:TextBox ID="Apress" runat="server" TextMode="SingleLine"></asp:TextBox>      
  
        <br />
        分类：<asp:DropDownList ID="Acategory" runat="server"></asp:DropDownList>
        <br />
        馆藏数量：<asp:TextBox ID="Aamount" runat="server" TextMode="SingleLine"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="tel" runat="server" ControlToValidate="Aamount" ErrorMessage="必须为数字" Display="Dynamic" ValidationExpression="^[1-9]d*|0$"></asp:RegularExpressionValidator>

        <br />
        可借数量：<asp:TextBox ID="Acount" runat="server" TextMode="SingleLine"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Acount" ErrorMessage="必须为数字" Display="Dynamic" ValidationExpression="^[1-9]d*|0$"></asp:RegularExpressionValidator>

        <br />
        <asp:Button ID="Abditor" runat="server" Text="修改"   OnClick="Abditor_Click" />
        <asp:Button ID="Abback" runat="server" Text="返回"  PostBackUrl="~/ALibrary.aspx" />
    </div>
    </form>
</body>
</html>
