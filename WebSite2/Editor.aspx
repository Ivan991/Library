<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor.aspx.cs" Inherits="Editor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <asp:LinkButton ID="welcome" runat="server" Text="图书馆首页" OnClick="welcome_Click"></asp:LinkButton>

        <br />
        <br />
        用户名：<asp:Label ID="lname" runat="server"></asp:Label>

        <br />

        <br />
        真实姓名：<asp:TextBox ID="txtuname" runat="server" TextMode="SingleLine"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtuname" ErrorMessage="必须是中文且长度为1-10" ValidationExpression="^[\u4e00-\u9fa5]{1,10}$" Display="Dynamic"></asp:RegularExpressionValidator>    


        <br />

        <br />
        性别：<asp:RadioButtonList ID="txtsex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Selected="True">男</asp:ListItem><asp:ListItem>女</asp:ListItem></asp:RadioButtonList>
        <br />

        <br />
        手机号：<asp:TextBox ID="txttel" runat="server" TextMode="SingleLine"></asp:TextBox>

                <asp:RegularExpressionValidator ID="tel" runat="server" ControlToValidate="txttel" ErrorMessage="手机号必须为11位数字" Display="Dynamic" ValidationExpression="^[0-9]{11,11}$"></asp:RegularExpressionValidator>


        <br />
        <br />
        <asp:Button ID="txteditor" runat="server" Text="修改" OnClick="txteditor_Click" />
        <asp:Button ID="back" runat="server" Text="返回" PostBackUrl="~/Users.aspx" />
    </div>
    </form>
</body>
</html>
