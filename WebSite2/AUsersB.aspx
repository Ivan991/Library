<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AUsersB.aspx.cs" Inherits="AUsersB"  Debug="true"%>

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
        查找用户<asp:TextBox ID="fubook" runat="server" TextMode="SingleLine"></asp:TextBox>
        <asp:Button ID="btnfub" runat="server" Text="查找"  OnClick="btnfub_Click"/>   
        <asp:Repeater ID="Aubooks" runat="server" OnItemCommand="Aubooks_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>借阅用户</th>
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
                    <td><%# Eval("ReaderName") %></td>
                    <td><%# Eval("BookName") %></td>
                     <td><%# Eval("Author") %></td>
                     <td><%# Eval("Press") %></td>
                     <td><%# Eval("Category") %></td>
                     <td><%# Eval("States") %></td>
                     <td><%# Eval("Dates") %></td>
              
                    <td><asp:LinkButton ID="Aubooks" runat="server" Text="编辑" PostBackUrl='<%#"ALendB.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="Audelete" runat="server" Text="还书" CommandName="Audelete" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton></td>
                </tr>

            </ItemTemplate>

            <FooterTemplate>

                </table>
            </FooterTemplate>

        </asp:Repeater>

        <asp:Button ID="btnFirst" runat="server" Text="首页"  OnClick="btnFirst_Click" />

        <asp:Button ID="btnUp" runat="server" Text="上一页"   OnClick="btnUp_Click"/>

        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" ></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="29px"></asp:TextBox>页  
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtJump" ErrorMessage="必须为数字" Display="Dynamic" ValidationExpression="^[1-9]d*|0$"></asp:RegularExpressionValidator>

        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
              
        
        <asp:Button ID="btnDrow" runat="server" Text="下一页" OnClick="btnDrow_Click"/>
        
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click" />

        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/ALibrary.aspx" />  
    </div>
    </form>
</body>
</html>
