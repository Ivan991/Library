<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        图书馆注册界面
         
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        用户名:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextName" runat="server" TextMode="SingleLine"></asp:TextBox>



 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextName" ErrorMessage="必须是数字下划线字母且长度为6-18且不能为空" ValidationExpression="^[\w]{6,18}$" Display="Dynamic"></asp:RegularExpressionValidator>    
       &nbsp;&nbsp;&nbsp;   
         
 
         <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     密码：&nbsp;&nbsp;&nbsp; 
        
      <asp:TextBox ID="TextPwd" runat="server" TextMode="Password"></asp:TextBox>



 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextPwd" ErrorMessage="必须是数字下划线字母且长度为6-18" ValidationExpression="^[\w]{6,18}$" Display="Dynamic"></asp:RegularExpressionValidator>    

&nbsp;&nbsp;&nbsp;&nbsp;    


        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        重复密码:
        
        <asp:TextBox ID="TextPwd1" runat="server" TextMode="Password" ></asp:TextBox>

        <asp:CompareValidator ID="pwd" runat="server" ControlToCompare="TextPwd" ControlToValidate="TextPwd1" ErrorMessage="密码和重复密码必须相同" Display="Dynamic"></asp:CompareValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        真实姓名:&nbsp;&nbsp; <asp:TextBox ID="TextUsersName" runat="server" TextMode="SingleLine"></asp:TextBox>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextUsersName" ErrorMessage="必须是中文且长度为1-10" ValidationExpression="^[\u4e00-\u9fa5]{1,10}$" Display="Dynamic"></asp:RegularExpressionValidator>    

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        性别:&nbsp;&nbsp;&nbsp;&nbsp; 
        
        <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal"  RepeatLayout="Flow"><asp:ListItem>女</asp:ListItem><asp:ListItem>男</asp:ListItem></asp:RadioButtonList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        手机号:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextTel"   runat="server" TextMode="SingleLine"></asp:TextBox>

        <asp:RegularExpressionValidator ID="tel" runat="server" ControlToValidate="TextTel" ErrorMessage="手机号必须为11位数字" Display="Dynamic" ValidationExpression="^[0-9]{11,11}$"></asp:RegularExpressionValidator>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Button ID="BtnRegister" runat="server" Text="注册" OnClick="BtnRegister_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnBack" runat="server" Text="返回" PostBackUrl="~/MyLogin.aspx" />

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
