<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AULend.aspx.cs" Inherits="AULend" %>

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
            <asp:Repeater ID="Aubooks" runat="server" OnItemCommand="Aubooks_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                       
                        <th>书名</th>
                        <th>作者</th>
                        <th>出版社</th>
                        <th>类别</th>
                        <th>状态</th>
                        <th>逾期日期</th>
                        <th>编辑</th>
                        <th>删除</th>
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
              
                    <td><asp:LinkButton ID="Aubooks" runat="server" Text="编辑" PostBackUrl='<%#"AUsersInf.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>

                    <td><asp:LinkButton ID="Audelete" runat="server" Text="还书" CommandName="Audelete" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton></td>

                   
                </tr>

            </ItemTemplate>

            <FooterTemplate>

                </table>
            </FooterTemplate>

        </asp:Repeater>

         <asp:Button ID="back" runat="server" Text="返回"  PostBackUrl="~/AUsersInf.aspx" />
    </div>
    </form>
</body>
</html>
