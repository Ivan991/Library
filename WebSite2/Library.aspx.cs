using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)

        {

            int i;

            string sqlselect = "select * from Category";                        //查找分类

            DataTable dt1 = new DataTable();

            dt1 = Class1.select(sqlselect);

            for (i = 0; i < dt1.Rows.Count; i++)                                //循环把各个分类显示在下拉框中

            {

                string id = dt1.Rows[i][0].ToString();

                string category = dt1.Rows[i][1].ToString();

                ListItem a = new ListItem("" + category + "", "" + id + "");

                fbook.Items.Add(a);

            }

            string sql = "select* from View_1";

            DataBindToRepeater(1, sql);
        }
        
    }



    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {
        Session["name"] = null;
        Session["type"] = null;
        Response.Redirect("MyLogin.aspx");
    }


    string cbook()                        //构建一个在各个分类中按书名或者作者名来模糊查找书籍的函数
    {

        string sql;

        string cid = fbook.SelectedValue;           //获取选择的分类

        string type = bookauthor.SelectedValue;     //获取是按书名查找还是按作者查找

        string fb = fbooks.Text;

        fb = fb.Trim();                             //把字符串中的空格去掉

        if (fb.Length == 0)                         //如果输入为空

        {

            if (cid == "所有图书")                  //显示出所有图书

                sql = "select * from View_1";

            else                                         //显示出各个分类的图书

                sql = "select * from View_1 where Category='" + cid + "'";

        }

        else                                        //输入不为空时

        {

            if (cid == "所有图书")                  //在所有图书中按书名或者作者名进行模糊查找

            {

                if (type == "书名")

                    sql = "select * from View_1 where BookName like '%" + fb + "%'";

                else

                    sql = "select * from View_1 where Author like '%" + fb + "%'";

            }

            else if (type == "书名")                  //在分类中按书名或者作者名进行模糊查找

                sql = "select * from View_1 where Category='" + cid + "' and  BookName like '%" + fb + "%'";

            else

                sql = "select * from View_1 where Category='" + cid + "' and  Author like '%" + fb + "%'";

        }

        return sql;                         //返回sql语句

    }

    protected void findbook_Click(object sender, EventArgs e)//显示查找出的第一页
    {

        string fsql = cbook();

        DataBindToRepeater(1, fsql);

    }

    protected void books_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        string name = Session["name"].ToString();

        if (e.CommandName == "lendbooks")     //按借书时

        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqlsn = "select ID from Users where Name='" + name + "'";

            DataTable dt4 = Class1.select(sqlsn);

            string readername = dt4.Rows[0][0].ToString();                                     //找出用户的id

            string sqlsate = "select State from LendBooks where ReaderName='" + name + "' ";//查找该用户的借阅状态

            DataTable dt3 = Class1.select(sqlsate);

            int state = 1;

            for(int i=0;i<dt3.Rows.Count;i++)           //如果该用户的有一本书的借阅状态为逾期则state为0
            {

                if (Convert.ToInt32(dt3.Rows[i][0].ToString()) == 0)
                {

                    state = 0;

                    break;
                }
                    
            }


            string sqls = "select * from Books where ID='" + id + "'";                    //获取可借数量

            string dates = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");              //获取当前日期加上三十天的日期，即逾期日期

            DataTable dt2 = new DataTable();

            dt2 = Class1.select(sqls);

            int count = Convert.ToInt32(dt2.Rows[0][6].ToString());

            if (count > 0 && state == 1 )                         //当可借数目大于0以及该用户没有逾期书籍时才可借书
            {

                count = count - 1;

                string sqlupdate = "update Books set Count='" + count + "' where ID='" + id + "'";//更新可借数目

                string sql = "insert into LendBooks(ReaderID,ReaderName,BookId,State,Dates) values ('"+readername+"','" + name + "','" + id + "','"+state+"','" + dates + "')";//插入借阅书籍

                int result = Class1.sqlhelp(sql);

                int result1 = Class1.sqlhelp(sqlupdate);

                if (result > 0 && result1 > 0)

                    Response.Write("<script>alert('借阅成功！');location='Library.aspx'</script>");

                else

                    Response.Write("<script>alert('借阅失败！')</script>");

            }

            else

                Response.Write("<script>alert('借阅失败！')</script>");
        }
    }


    void DataBindToRepeater(int currentpage,string sqls)     //构建一个分页函数
    {

        DataTable dt = new DataTable();

        dt = Class1.select(sqls);                   //查找出所有书本信息

        PagedDataSource Ainf = new PagedDataSource();

        Ainf.AllowPaging = true;//允许分页

        Ainf.PageSize = 5;                                  //  每页显示的书本数为5

        Ainf.DataSource = dt.DefaultView;


        lbTotal.Text = Ainf.PageCount.ToString();

        Ainf.CurrentPageIndex = currentpage - 1;

        books.DataSource = Ainf;                        //绑定数据源

        books.DataBind();                               //把书本信息显示出来

    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {

        string sql0 = cbook();

        lbNow.Text = "1";

        DataBindToRepeater(1,sql0);   //显示第一页

    }

    protected void btnUp_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lbNow.Text) > 1)                                             //如果当前页数不是首页

        {

            string sql0 = cbook();

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);             //把当前页数-1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sql0);

        }
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {

        string sql0 = cbook();

        if (txtJump.Text.Trim().Length > 0)
        {

            int pages = Convert.ToInt32(txtJump.Text.Replace(" ", ""));      //去掉字符串中的空格

            if (pages <= Convert.ToInt32(lbTotal.Text) && pages >= 1)     //如果输入的页数不超过总页数的范围才执行
            {

                DataBindToRepeater(pages, sql0);                         //把用户输入的页数显示出来

                lbNow.Text = txtJump.Text.Replace(" ", "");
            }



            else

                Response.Write("<script>alert('输入有误')</script>");

        }
        else

            Response.Write("<script>alert('不能为空')</script>");

    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lbNow.Text) < Convert.ToInt32(lbTotal.Text))                          //如果当前页数不是尾页              
                 
        {

            string sql0 = cbook();

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);             //把当前页数+1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sql0);

        }
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {

        string sql0 = cbook();

        lbNow.Text = "1";

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text),sql0);   //显示最后一页

    }
}