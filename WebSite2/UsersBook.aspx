<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersBook.aspx.cs" Inherits="usersbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <asp:LinkButton ID="wel" runat="server" Text="图书馆首页" PostBackUrl="~/Welcome.aspx"></asp:LinkButton>

        <asp:LinkButton ID="quit" runat="server" Text="注销"  OnClick="quit_Click"></asp:LinkButton>
        借阅图书

    <asp:Repeater ID="usersb" runat="server" OnItemCommand="usersb_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>图书名</th>
                    <th>作者</th>
                    <th>出版社</th>
                    <th>分类</th>
                    <th>借阅状态</th>
                    <th>逾期日期</th>
                </tr>
           
        </HeaderTemplate>
    <ItemTemplate>
        
        <tr>
            <td><%# Eval("BookName") %></td>
            <td><%# Eval("Author") %></td>
            <td><%# Eval("Press") %></td>
            <td><%# Eval("Category") %></td>
             <td><%# Eval("States") %></td>
             <td><%# Eval("Dates") %></td>
            <td><asp:LinkButton ID="renew" runat="server" Text="续借" CommandName="renewb" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
            <td><asp:LinkButton ID="return" runat="server" Text="还书" CommandName="returnb" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
        </tr>

    </ItemTemplate>
    
        <FooterTemplate>

 </table>
        </FooterTemplate>
    </asp:Repeater>
        <asp:Button ID="backw" runat="server" Text="返回" PostBackUrl="~/Welcome.aspx" />
    </div>
    </form>
</body>
</html>
