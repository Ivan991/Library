using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AULend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {

            int id = Convert.ToInt32(Request.QueryString["ID"]);                                       //获取读者id

            string sqlselect = "select * from View_3 where ReaderID='" + id + "'";          //建立查找借阅信息的语句   

            DataTable dt = new DataTable();

            dt = Class1.select(sqlselect);

            Aubooks.DataSource = dt;

            Aubooks.DataBind();

        }
       
           
        
    }

    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }

    protected void Aubooks_ItemCommand(object source, RepeaterCommandEventArgs e)               //删除该条借阅记录
    {

        if (e.CommandName == "Audelete")

        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqld = "delete from LendBooks where ID='" + id + "'";

            string sqlsb = "select BookId from LendBooks where ID='" + id + "'";

            DataTable dts = Class1.select(sqlsb);

            int bookid = Convert.ToInt32(dts.Rows[0][0].ToString());

            int result = Class1.sqlhelp(sqld);

            if (result > 0)

            {
                string sqlup = "update Books set Count=Count+1 where ID='" + bookid + "'";              //把可借数量加一

                int result2 = Class1.sqlhelp(sqlup);

                if (result2 > 0)

                    Response.Write("<script>alert('还书成功！');location='AUsersInf.aspx'</script>");

                else

                    Response.Write("<script>alert('还书失败！');location='AULend.aspx'</script>");
            }
            else

                Response.Write("<script>alert('还书失败！');location='AULend.aspx'</script>");

        }
    }
}