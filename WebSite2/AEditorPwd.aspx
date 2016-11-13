<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AEditorPwd.aspx.cs" Inherits="AEditorPwd" %>

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
    修改密码
         
        <br />
        <br />
        用户名：<asp:Label ID="eAuname" runat="server" ></asp:Label>
        <br />
        <br />
        旧密码：<asp:Label ID="eApwd" runat="server" ></asp:Label>
        <br />
        <br />
        新密码：<asp:TextBox ID="eAupwd" runat="server" TextMode="Password"></asp:TextBox>


 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="eAupwd" ErrorMessage="必须是数字下划线字母且长度为6-18" ValidationExpression="^[\w]{6,18}$" Display="Dynamic"></asp:RegularExpressionValidator>    


        <br />
        <br />
        确认新密码：<asp:TextBox ID="eAupwd1" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="pwd" runat="server" ControlToCompare="eAupwd" ControlToValidate="eAupwd1" ErrorMessage="密码和重复密码必须相同" Display="Dynamic"></asp:CompareValidator>

        <br />
        <br />
        <asp:Button ID="eAusers" runat="server" Text="提交"  OnClick="eAusers_Click" />
        <asp:Button ID="eAback" runat="server" Text="返回" PostBackUrl="~/AUsersInf.aspx" />
    </div>
    </form>
</body>
</html>
