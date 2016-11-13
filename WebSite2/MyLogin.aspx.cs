using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyLogin : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {

        string name = TextName.Text;
        string pwd = TextPwd.Text;
        string sql;
        
        if (Users.SelectedValue == "普通用户")
            sql = "select * from Users where Name='" + name + "'and Password='" + pwd + "'";
        else
            sql = "select * from Administrator where Name='" + name + "'and Password='" + pwd + "'";

        try
        {
            if (Class1.select(sql).Rows.Count > 0)
            {
                string result = Class1.select(sql).Rows[0][0].ToString();
                
                Session["name"] = name;
                Session["type"] = Users.SelectedValue;
                if (Users.SelectedValue == "普通用户")            
                      Response.Write("<script>alert('登录成功!');location='Welcome.aspx'</script>");
                    
                else
                    Response.Write("<script>alert('登录成功!');location='WelcomeA.aspx'</script>");

            }
            else
                Response.Write("<script>alert('登录失败!信息错误!')</script>");
        }

        catch (Exception ex)
        {
            Response.Write(ex);
        }

    }

    
   
}