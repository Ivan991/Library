using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditorPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)

    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        string usersname = Session["name"].ToString();

        eusersname.Text = usersname;                                //把用户名显示出来

    }


    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {
        Session["name"] = null;
        Session["type"] = null;
        Response.Redirect("MyLogin.aspx");
    }

    protected void eusers_Click(object sender, EventArgs e)
    {

        string usersname = Session["name"].ToString();                   //获取登录用户名

        string pwd = euserspwd.Text;

        string npwd = eusersnpwd.Text.Trim();


        string type = Session["type"].ToString();                 //确定是管理员还是普通用户

        string sql1;

        if (type == "普通用户")

            sql1 = "select Password from Users where Name = '" + usersname + "' ";

        else

            sql1 = "select Password from Administrator where Name='" + usersname + "'";               //普通用户、管理员分别显示信息


        string npwd1 = eusersnpwd1.Text;

        DataTable dt = new DataTable();

        dt = Class1.select(sql1);

        if (npwd.Length > 0)                      //当密码输入对了
        {
            if (pwd == dt.Rows[0][0].ToString())

            {

                string sqlupdate;
                if (type == "普通用户")

                    sqlupdate = "update Users set Password = '" + npwd + "' where Name='" + usersname + "' ";

                else

                    sqlupdate = "update Administrator set Password = '" + npwd + "' where Name='" + usersname + "'";

                int result = Class1.sqlhelp(sqlupdate);

                if (result > 0)
                {
                    Response.Write("<script>alert('修改密码成功，请重新登录');location='MyLogin.aspx'</script>");//修改成功并跳转到登录界面

                    Session["name"] = null;                             //并注销

                    Session["type"] = null;
                }

                else

                    Response.Write("<script>alert('修改失败')</script>");
            }

            else

                Response.Write("<script>alert('修改失败')</script>");

        }
        else

            Response.Write("<script>alert('不能为空')</script>");


      

    }

    protected void welcome_Click(object sender, EventArgs e)
    {
        string type = Session["type"].ToString();                 //确定是管理员还是普通用户

        if (type == "普通用户")

            Response.Redirect("Welcome.aspx");

        else

            Response.Redirect("WelcomeA.aspx");
    }
}