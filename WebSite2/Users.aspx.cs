using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)

        {

            string username = Session["name"].ToString();          //获取用户名    

            string type = Session["type"].ToString();                 //确定是管理员还是普通用户

            string sqlselect;

            if (type == "普通用户")

                sqlselect = "select * from Users where Name = '" + username + "' ";

            else

                sqlselect = "select * from Administrator where Name='" + username + "'";               //普通用户、管理员分别显示信息

            DataTable dt = new DataTable();

            dt = Class1.select(sqlselect);

            uname.Text = dt.Rows[0][1].ToString();

            usersname.Text = dt.Rows[0][3].ToString();

            usex.Text = dt.Rows[0][4].ToString();

            utel.Text = dt.Rows[0][5].ToString();

        }

    }



    protected void welcome_Click(object sender, EventArgs e)
    {

        string type = Session["type"].ToString();                 //确定是管理员还是普通用户

        if (type == "普通用户")

            Response.Redirect("Welcome.aspx");

        else

            Response.Redirect("WelcomeA.aspx");
    }

  

    protected void quit_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Session["type"] = null;
        Response.Redirect("MyLogin.aspx");
    }
}