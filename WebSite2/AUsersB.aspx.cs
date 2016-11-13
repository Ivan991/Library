using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AUsersB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

            DataBindToRepeater(1,sql);              //显示第一页

        }

            

    }

    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }


    void DataBindToRepeater(int currentpage,string sqls)     //构建一个分页函数
    {

        DataTable dt = new DataTable();

        dt = Class1.select(sqls);                      

        PagedDataSource Ainf = new PagedDataSource();

        Ainf.AllowPaging = true;                            //允许分页

        Ainf.PageSize = 5;                                  //  每页显示的借阅信息数为5

        Ainf.DataSource = dt.DefaultView;

        lbTotal.Text = Ainf.PageCount.ToString();           //设置总页数

        Ainf.CurrentPageIndex = currentpage - 1;

        Aubooks.DataSource = Ainf;

        Aubooks.DataBind();                               //把用户信息显示出来


    }


    protected void btnUp_Click(object sender, EventArgs e)                               //按上一页
    {

        if (Convert.ToInt32(lbNow.Text) > 1)                                             //如果当前页数不是首页

        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sql;

            string uname = fubook.Text.Replace(" ", "");

            if(uname.Length==0)                              //如果输入为0

                sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

            else

            {

                

                sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

            }

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);             //把当前页数-1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sql);

        }
    }


    protected void btnDrow_Click(object sender, EventArgs e)                                //按下一页
    {

        if (Convert.ToInt32(lbNow.Text) < Convert.ToInt32(lbTotal.Text))                     //如果当前页数不是尾页

        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sql;

            string uname = fubook.Text.Replace(" ", "");

            if (uname.Length == 0)                              //如果输入为0

                sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

            else

                sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);             //把当前页数+1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sql);

        }

    }

    protected void btnFirst_Click(object sender, EventArgs e)                       //按首页
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string sql;

        string uname = fubook.Text.Replace(" ", "");

        if (uname.Length == 0)                              //如果输入为0

            sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

        else

            sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

        lbNow.Text = "1";

        DataBindToRepeater(1,sql);   //显示第一页

    }


    protected void btnLast_Click(object sender, EventArgs e)                        //按尾页
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string sql;

        string uname = fubook.Text.Replace(" ", "");

        if (uname.Length == 0)                              //如果输入为0

            sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

        else

            sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

        lbNow.Text = lbTotal.Text;

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text),sql);   //显示最后一页

    }


    protected void btnJump_Click(object sender, EventArgs e)                    //按跳页
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string sql;

        string uname = fubook.Text.Replace(" ", "");

        if (uname.Length == 0)                              //如果输入为0

            sql = "select * from View_3 where BookId='" + id + "'";        //查找出这本书的所有借阅信息

        else

            sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

        if (txtJump.Text.Trim().Length > 0)
        {
            int pages = Convert.ToInt32(txtJump.Text);

            if (pages <= Convert.ToInt32(lbTotal.Text) && pages >= 1)     //如果输入的页数不超过总页数的范围才执行
            {

                DataBindToRepeater(pages, sql);                         //把用户输入的页数显示出来

                lbNow.Text = txtJump.Text;
            }



            else

                Response.Write("<script>alert('输入有误')</script>");
        }

        else

            Response.Write("<script>alert('不能为空')</script>");

    }

    protected void Aubooks_ItemCommand(object source, RepeaterCommandEventArgs e)    //删除该条借阅记录
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

                    Response.Write("<script>alert('还书成功！');location='ALibrary.aspx'</script>");

                else

                    Response.Write("<script>alert('还书失败！');location='AUsersB.aspx'</script>");

            }



            else

                Response.Write("<script>alert('还书失败！');location='AUsersB'</script>");

        }
    }

    protected void btnfub_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string uname = fubook.Text.Replace(" ", "");

        string sql = "select * from View_3 where ReaderName='" + uname + "' and BookID='" + id + "'";

        DataBindToRepeater(1, sql);

    }
}
