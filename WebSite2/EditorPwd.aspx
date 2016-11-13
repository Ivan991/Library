<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditorPwd.aspx.cs" Inherits="EditorPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:LinkButton ID="welcome" runat="server" Text="图书馆首页"  OnClick="welcome_Click"></asp:LinkButton>
                        <asp:LinkButton ID="quit" runat="server" Text="注销"  OnClick="quit_Click"></asp:LinkButton>

          <br />
        <br />
        修改密码
         
        <br />
        <br />
        用户名：<asp:Label ID="eusersname" runat="server" ></asp:Label>
        <br />
        <br />
        旧密码：<asp:TextBox ID="euserspwd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        新密码：<asp:TextBox ID="eusersnpwd" runat="server" TextMode="Password"></asp:TextBox>

 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="eusersnpwd" ErrorMessage="必须是数字下划线字母且长度为6-18" ValidationExpression="^[\w]{6,18}$" Display="Dynamic"></asp:RegularExpressionValidator>    

        <br />
        <br />
        确认新密码：<asp:TextBox ID="eusersnpwd1" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="pwd" runat="server" ControlToCompare="eusersnpwd" ControlToValidate="eusersnpwd1" ErrorMessage="密码和重复密码必须相同" Display="Dynamic"></asp:CompareValidator>

        <br />
        <br />
        <asp:Button ID="eusers" runat="server" Text="提交" OnClick="eusers_Click" />

        <asp:Button ID="back" runat="server" Text="返回" PostBackUrl="~/Users.aspx" />

    </div>
    </form>
</body>
</html>
