using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AEditorPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        if (!IsPostBack)
        {

            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sqls = "select * from Users where ID='" + id + "'";

            DataTable dt = Class1.select(sqls);

            eAuname.Text = dt.Rows[0][1].ToString();

            eApwd.Text = dt.Rows[0][2].ToString();

        }
    }


    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }


    protected void eAusers_Click(object sender, EventArgs e)
    {

        string usersname = eAuname.Text;                   //获取用户名

        string npwd = eAupwd.Text.Trim();

        string npwd1 = eAupwd1.Text;

        string sql1 = "Update Users set Password='" + npwd + "' where Name='" + usersname + "'";

        if (npwd.Length > 0)
        {

            int result = Class1.sqlhelp(sql1);                                                //执行sql语句，把密码在数据库里进行修改

            if (result > 0)
            {

                Response.Write("<script>alert('修改密码成功!');location='AUsersInf.aspx'</script>");//修改成功并跳转到所有用户信息界面
            }
            else

                Response.Write("<script>alert('修改失败')</script>");
        }

        else

            Response.Write("<script>alert('不能为空')</script>");



    }
}