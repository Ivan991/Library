using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)                                          //是否是第一次打开这个页面

        {

            string name = Session["name"].ToString();

            lname.Text = name;

            string sqleditor;

            if (Session["type"].ToString() == "普通用户")

                sqleditor = "select * from Users where Name='" + name + "'";   //查询用户信息

            else

                sqleditor = "select * from Administrator where Name='" + name + "'";

            DataTable dt = new DataTable();

            dt = Class1.select(sqleditor);                    

            txtuname.Text = dt.Rows[0][3].ToString();  //把获取的用户信息显示在文本框里

            txttel.Text = dt.Rows[0][5].ToString();

        }

    }


    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }


    protected void txteditor_Click(object sender, EventArgs e)
    {



        string name = Session["name"].ToString();          //获取name

        string sqlupdate;

        string uname = txtuname.Text.Trim();

        string tel = txttel.Text.Trim();

        string sex;

        if (txtsex.SelectedValue == "男")

            sex = "男";

        else

            sex = "女";

        if (Session["type"].ToString() == "普通用户")//分管理员和普通用户进行

            sqlupdate = "update Users set UsersName='" + uname + "',Telephone='" + tel + "',Sex='" + sex + "' where Name='" + name + "'";//新建更新的sql语句

        else

            sqlupdate = "update Administrator set UsersName='" + uname + "',Telephone='" + tel + "',Sex='" + sex + "' where Name='" + name + "'";

        if(uname.Length>0&&tel.Length>0)

        {

            int result = Class1.sqlhelp(sqlupdate);

            if (result > 0)

                Response.Write("<script>alert('修改成功！');location='Users.aspx'</script>");

            else

                Response.Write("<script>alert('修改失败！')</script>");

        }

        else

            Response.Write("<script>alert('不能为空！')</script>");


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