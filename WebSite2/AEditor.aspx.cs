using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        if (!IsPostBack)
        {

            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sqls = "select * from Users where ID='" + id + "'";

            DataTable dt = Class1.select(sqls);

            Atxtname.Text = dt.Rows[0][1].ToString();

            Atxtuname.Text = dt.Rows[0][3].ToString();

            Atxttel.Text = dt.Rows[0][5].ToString();

            string sex = dt.Rows[0][4].ToString();

            if (sex == "男")

                Atxtsex.SelectedValue = "男";

            else

                Atxtsex.SelectedValue = "女";

        }
        

    }

    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }

    protected void Atxteditor_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string name = Atxtname.Text.Trim();

        

        string uname = Atxtuname.Text.Trim();

        string tel = Atxttel.Text.Trim();

        string sex;

        string sqlname = "select * from Users where Name='" + name + "'";

        DataTable dtname = Class1.select(sqlname);

        if (Atxtsex.SelectedValue == "男")

            sex = "男";

        else

            sex = "女";

        if(dtname.Rows.Count==0&&name.Length>0&&uname.Length>0&&tel.Length>0)                                                                    //如果用户名已存在或输入为空则修改不了

            Response.Write("<script>alert('修改失败！');location='AUsersInf.aspx'</script>");
        
        else
        {
            string sqlupdate = "update Users set Name='"+name+"', UsersName=N'" + uname + "',Telephone='" + tel + "',Sex='" + sex + "' where ID='" + id + "'";//新建更新的sql语句

            int result = Class1.sqlhelp(sqlupdate);                 //更新用户信息

            if (result > 0)

                Response.Write("<script>alert('修改成功！');location='AUsersInf.aspx'</script>");

            else

                Response.Write("<script>alert('修改失败！');location='AUsersInf.aspx'</script>");

        }

        
    }

   
}