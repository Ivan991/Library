<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AEditor.aspx.cs" Inherits="AEditor" %>

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
         修改用户名
        用户名：<asp:TextBox ID="Atxtname" runat="server" TextMode="SingleLine"></asp:TextBox>
        


 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Atxtname" ErrorMessage="必须是数字下划线字母且长度为6-18" ValidationExpression="^[\w]{6,18}$" Display="Dynamic"></asp:RegularExpressionValidator>    

        <br />

        <br />
        真实姓名：<asp:TextBox ID="Atxtuname" runat="server" TextMode="SingleLine"></asp:TextBox>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Atxtuname" ErrorMessage="必须是中文且长度为1-10" ValidationExpression="^[\u4e00-\u9fa5]{1,10}$" Display="Dynamic"></asp:RegularExpressionValidator>    

        <br />

        <br />
        性别：<asp:RadioButtonList ID="Atxtsex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Selected="True">男</asp:ListItem><asp:ListItem>女</asp:ListItem></asp:RadioButtonList>
        <br />

        <br />
        手机号：<asp:TextBox ID="Atxttel" runat="server" TextMode="SingleLine"></asp:TextBox>
         <asp:RegularExpressionValidator ID="tel" runat="server" ControlToValidate="Atxttel" ErrorMessage="手机号必须为11位数字" Display="Dynamic" ValidationExpression="^[0-9]{11,11}$"></asp:RegularExpressionValidator>

        <br />
        <br />
        <asp:Button ID="Atxteditor" runat="server" Text="修改"  OnClick="Atxteditor_Click" />
        <asp:Button ID="Atxtback" runat="server" Text="返回" PostBackUrl="~/AUsersInf.aspx" />
    </div>
    </form>
</body>
</html>
