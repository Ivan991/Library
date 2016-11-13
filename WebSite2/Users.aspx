<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="users" %>

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
        <asp:LinkButton ID="quit" runat="server" Text="注销"  OnClick="quit_Click"></asp:LinkButton>
        <br />
        修改个人信息
     
        <br />
        <br />
        用户名：<asp:Label ID="uname" runat="server" ></asp:Label>
        <br />
        真实姓名：<asp:Label ID="usersname" runat="server" ></asp:Label>
        <br />
        性别：<asp:Label ID="usex" runat="server" ></asp:Label>
        <br />
        手机号：<asp:Label ID="utel" runat="server" ></asp:Label>
        <br />
        <asp:LinkButton ID="editorinf" runat="server" Text="修改信息" PostBackUrl="~/Editor.aspx"></asp:LinkButton>
        <br />
        <asp:LinkButton ID="editorpwd" runat="server" Text="修改密码" PostBackUrl="~/EditorPwd.aspx"></asp:LinkButton>

 
        
    
    </div>
    </form>
</body>
</html>
