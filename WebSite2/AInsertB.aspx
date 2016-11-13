<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AInsertB.aspx.cs" Inherits="AInsertB" %>

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

        增加新图书
     
         
        <br />
     
        <br />
        图书名：<asp:TextBox ID="Ainame" runat="server" TextMode="SingleLine"></asp:TextBox>

        <br />

        <br />
        作者名：<asp:TextBox ID="Aiauthor" runat="server" TextMode="SingleLine"></asp:TextBox>

        <br />

        <br />
        
        出版社：<asp:TextBox ID="Aipress" runat="server" TextMode="SingleLine"></asp:TextBox>        

        <br />

        分类：<asp:DropDownList ID="Aicategory" runat="server"></asp:DropDownList>
        <br />
        馆藏数量：<asp:TextBox ID="Aiamount" runat="server" TextMode="SingleLine"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Aiamount" ErrorMessage="必须是数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>    


        <br />
        可借数量：<asp:TextBox ID="Aicount" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Aicount" ErrorMessage="必须是数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>    

        <br />
        <asp:Button ID="Aieditor" runat="server" Text="增加"   OnClick="Aieditor_Click" />
        <asp:Button ID="Aiback" runat="server" Text="返回"  PostBackUrl="~/ALibrary.aspx" />
    </div>
    </form>
</body>
</html>
