﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ALibrary.aspx.cs" Inherits="ABooks" Debug="true" %>

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
            <asp:DropDownList ID="Afbook" runat="server">
            <asp:ListItem Selected="True">所有图书</asp:ListItem>            
            </asp:DropDownList>
        <asp:RadioButtonList ID="Abookauthor" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Selected="True" >书名</asp:ListItem><asp:ListItem >作者</asp:ListItem></asp:RadioButtonList> 
        <asp:TextBox ID="Afbooks" runat="server" TextMode="SingleLine"></asp:TextBox>
        <asp:Button ID="Afindbook" runat="server" Text="查找"  OnClick="Afindbook_Click" />
        <asp:Repeater ID="Abooks" runat="server" OnItemCommand="Abooks_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>书名</th>
                        <th>作者</th>
                        <th>出版社</th>
                        <th>类别</th>
                        <th>馆藏数量</th>
                        <th>可借数量</th>
                        <th>当前借阅用户</th>
                        <th>编辑图书信息</th>
                        <th>删除</th>
                    </tr>


            </HeaderTemplate>
            
            <ItemTemplate>
                
                <tr>
                    <td><%# Eval("BookName") %></td>
                     <td><%# Eval("Author") %></td>
                     <td><%# Eval("Press") %></td>
                     <td><%# Eval("Categ") %></td>
                     <td><%# Eval("Amount") %></td>
                     <td><%# Eval("Count") %></td>
                    <td><asp:LinkButton ID="Ausers" runat="server" Text="查看" PostBackUrl='<%#"AUsersB.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="Aebooks" runat="server" Text="编辑" PostBackUrl='<%#"ABooks.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="Adelete" runat="server" Text="删除" CommandName="Adelete" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton></td>
                </tr>

            </ItemTemplate>

            <FooterTemplate>

                </table>
            </FooterTemplate>

        </asp:Repeater>
        <asp:Button ID="Ainsertb" runat="server" Text="增加图书"  PostBackUrl="~/AInsertB.aspx" />
            <br />
        <asp:Button ID="btnFirst" runat="server" Text="首页"  OnClick="btnFirst_Click" />

        <asp:Button ID="btnUp" runat="server" Text="上一页"   OnClick="btnUp_Click"/>

        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" ></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="29px"></asp:TextBox>页  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtJump" ErrorMessage="必须为数字" Display="Dynamic" ValidationExpression="^[1-9]d*|0$"></asp:RegularExpressionValidator>

        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
              
        
        <asp:Button ID="btnDrow" runat="server" Text="下一页" OnClick="btnDrow_Click"/>
        
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
    </div>
    </form>
</body>
</html>
