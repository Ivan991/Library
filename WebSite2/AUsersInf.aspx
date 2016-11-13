<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AUsersInf.aspx.cs" Inherits="AUsersInf" Debug="true" %>

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
            图书馆用户信息
         
            <br />
            <br />
            查找用户<asp:TextBox ID="funame" runat="server" TextMode="SingleLine"></asp:TextBox>
        <asp:Button ID="btnfuname" runat="server" Text="查找" OnClick="btnfuname_Click"/>   
    <asp:Repeater ID="Ausersinf" runat="server"  OnItemCommand="Ausersinf_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>用户名</th>
                    <th>密码</th>
                    <th>真实姓名</th>
                    <th>性别</th>
                    <th>手机号</th>
                    
                    
                </tr>

        </HeaderTemplate>
        
        <ItemTemplate>
        <tr>
            <td><%# Eval("Name") %></td>
            <td><%# Eval("Password") %></td>
            <td><%# Eval("UsersName") %></td>
            <td><%# Eval("Sex") %></td>
            <td><%# Eval("Telephone") %></td>
            <td><asp:LinkButton ID="Alend" runat="server" Text="借阅信息" PostBackUrl='<%#"AULend.aspx?id="+Eval("ID") %>'></asp:LinkButton></td>
            <td><asp:LinkButton ID="Aeditor" runat="server" Text="修改信息"  PostBackUrl= '<%#"AEditor.aspx?id="+Eval("ID") %>'></asp:LinkButton> </td>
            <td><asp:LinkButton ID="Aeditorpwd" runat="server" Text="修改密码"  PostBackUrl='<%#"AEditorPwd.aspx?ID="+Eval("ID") %>' />   </td>
            <td><asp:Button ID="deleteu" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("ID") %>' /></td>
  
        </tr>

        </ItemTemplate>

        <FooterTemplate>
        
            </table>
        </FooterTemplate>

    </asp:Repeater>
        <asp:Button ID="btnFirst" runat="server" Text="首页"  OnClick="btnFirst_Click" />
        <asp:Button ID="btnUp" runat="server" Text="上一页"  OnClick="btnUp_Click" />

        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" ></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="29px"></asp:TextBox>页  
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtJump" ErrorMessage="必须为数字" Display="Dynamic" ValidationExpression="^[1-9]d*|0$"></asp:RegularExpressionValidator>

<asp:Button ID="btnJump" runat="server"  Text="Go" OnClick="btnJump_Click1"/>

        
        <asp:Button ID="btnDrow" runat="server" Text="下一页" OnClick="btnDrow_Click"/>
        
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        
            <br />
        
        <asp:Button ID="Ausersback" runat="server" Text="返回" PostBackUrl="~/WelcomeA.aspx" />
    </div>
    </form>
</body>
</html>
