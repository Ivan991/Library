using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AUsersInf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)
        {

            string sql = "select * from Users";

            DataBindToRepeater(1,sql);   //显示第一页
            
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

        Ainf.PageSize = 5;                                  //  每页显示的用户数为5

        Ainf.DataSource = dt.DefaultView;


        lbTotal.Text = Ainf.PageCount.ToString();

        Ainf.CurrentPageIndex = currentpage - 1;            

        Ausersinf.DataSource = Ainf;

        Ausersinf.DataBind();                               //把用户信息显示出来

    }

    protected void Ausersinf_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName=="delete")

        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqld = "delete from Users where ID='" + id + "'";

           

            string sqlse = "select BookId from LendBooks where ReaderId='" + id + "'";

            DataTable dts = Class1.select(sqlse);


            int result = Class1.sqlhelp(sqld);
            string sqlu;

            int lid;

            int result1 = 0;


            if (result > 0)
            {


                for (int i = 0; i < dts.Rows.Count; i++)
                {

                    lid = Convert.ToInt32( dts.Rows[i][0].ToString());

                    sqlu = "update Books set Count=Count+1 where ID='" + lid + "'";

                    result1 = Class1.sqlhelp(sqlu);

                    if (result1 == 0)
                    {
                        Response.Write("<script>alert('修改图书信息失败')</script>");

                        break;
                    }

                }

                if (result1 == 0)
                {
                    Response.Write("<script>alert('修改图书信息失败')</script>");


                }

                else


                    Response.Write("<script>alert('删除成功！');location='AUsersInf.aspx'</script>");
            }

           

            else

                Response.Write("<script>alert('删除失败！')</script>");
        }
     
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lbNow.Text) > 1)                                             //如果当前页数不是首页

        {
            string sql;

            string uname = funame.Text.Replace(" ", "");

            if (uname.Length == 0)                                      //如果输入为0
                        
                sql = "select * from Users";                            //查找出所有用户的信息

            else                                                            //如果输入不为0

            {

                sql = "select * from Users where Name='" + uname + " ";     //查找出这个用户的信息

            }

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);             //把当前页数-1

            DataBindToRepeater(Convert.ToInt32( lbNow.Text),sql);

        }


    }


    protected void btnDrow_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lbNow.Text) < Convert.ToInt32(lbTotal.Text))                                             //如果当前页数不是尾页
        {

            string sql;

            string uname = funame.Text.Replace(" ", "");

            if (uname.Length == 0)                                      //如果输入为0

                sql = "select * from Users";                            //查找出所有用户的信息

            else                                                            //如果输入不为0

            {

                sql = "select * from Users where Name='" + uname + " ";     //查找出这个用户的信息

            }

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);             //把当前页数+1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sql);
        }
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {

        string sql;

        string uname = funame.Text.Replace(" ", "");

        if (uname.Length == 0)                                      //如果输入为0

            sql = "select * from Users";                            //查找出所有用户的信息

        else                                                            //如果输入不为0

        {

            sql = "select * from Users where Name='" + uname + " ";     //查找出这个用户的信息

        }

        lbNow.Text = "1";

        DataBindToRepeater(1,sql);   //显示第一页
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {

        string sql;

        string uname = funame.Text.Replace(" ", "");

        lbNow.Text = lbTotal.Text;                                   // 设定当前页数

        if (uname.Length == 0)                                      //如果输入为0

            sql = "select * from Users";                            //查找出所有用户的信息

        else                                                            //如果输入不为0

        {

            sql = "select * from Users where Name='" + uname + " ";     //查找出这个用户的信息

        }

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text),sql);   //显示最后一页

    }

    

    protected void btnfuname_Click(object sender, EventArgs e)
    {
        string uname = funame.Text.Replace(" ", "");

        string sql = "select * from Users where Name='" + uname + "'";                  //查找出输入的那个用户

        DataBindToRepeater(1, sql);
    }

    protected void btnJump_Click1(object sender, EventArgs e)
    {
        string sql;

        string uname = funame.Text.Replace(" ", "");

        if (uname.Length == 0)                                      //如果输入为0

            sql = "select * from Users";                            //查找出所有用户的信息

        else                                                            //如果输入不为0

        {

            sql = "select * from Users where Name='" + uname + " ";     //查找出这个用户的信息


        }

        if (txtJump.Text.Trim().Length > 0)
        {

            int pages = Convert.ToInt32(txtJump.Text.Replace(" ", ""));      //去掉字符串中的空格

            if (pages <= Convert.ToInt32(lbTotal.Text) && pages >= 1)     //如果输入的页数不超过总页数的范围才执行
            {

                DataBindToRepeater(pages, sql);                         //把用户输入的页数显示出来

                lbNow.Text = txtJump.Text.Replace(" ", "");
            }



            else

                Response.Write("<script>alert('输入有误')</script>");
        }
        else

            Response.Write("<script>alert('不能为空')</script>");


    }
}