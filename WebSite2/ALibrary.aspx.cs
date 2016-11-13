using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABooks : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        if (!IsPostBack)

        {

            int i;

            string sqlselect = "select * from Category";                            //新建查找分类名的语句

            DataTable dt1 = new DataTable();

            dt1 = Class1.select(sqlselect);                                        //查找出书的分类

            for (i = 0; i < dt1.Rows.Count; i++)

            {

                string id = dt1.Rows[i][0].ToString();

                string category = dt1.Rows[i][1].ToString();

                ListItem a = new ListItem("" + category + "", "" + id + "");

                Afbook.Items.Add(a);                                                //用循环动态绑定书的分类这一数据并以下拉框的形式显现出来

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

    string Cbook()                                                        //构建一个按输入查找的函数
    {
        
        string sql;

        string cid = Afbook.SelectedValue;                                  //获取选择的分类

        string type = Abookauthor.SelectedValue;                            //获取是按书名还是按作者名查找

        string fb = Afbooks.Text;

        fb = fb.Replace(" ","");                                                         //去除输入框中的空格

        if (fb.Length == 0)                                                     //若输入框为空
        {
            if (cid == "所有图书")                                              //如果选择了所有图书则显示所有图书

                sql = "select * from View_1";

            else

                sql = "select * from View_1 where Category='" + cid + "'";       //显示所选分类的图书

        }

        else                                                                       //如果输入框中有文字

        {

            if (cid == "所有图书")                                                  //在所有图书中

            {

                if (type == "书名")                                                           //按书名查找

                    sql = "select * from View_1 where BookName like '%" + fb + "%'";

                else                                                                           //按作者名查找

                    sql = "select * from View_1 where Author like '%" + fb + "%'";

            }

            else if (type == "书名")                                                                                  //在所选分类中按书名或者作者名查找

                sql = "select * from View_1 where Category='" + cid + "' and  BookName like '%" + fb + "%'";

            else

                sql = "select * from View_1 where Category='" + cid + "' and  Author like '%" + fb + "%'";

        }

        return sql;

    }

    void DataBindToRepeater(int currentpage, string sqls)     //构建一个分页函数
    {

        DataTable dt = new DataTable();

        dt = Class1.select(sqls);                           //执行sql语句

        PagedDataSource Ainf = new PagedDataSource();

        Ainf.AllowPaging = true;                            //允许分页

        Ainf.PageSize = 5;                                  //  每页显示的书本数为5

        Ainf.DataSource = dt.DefaultView;


        lbTotal.Text = Ainf.PageCount.ToString();           //设置总页数

        Ainf.CurrentPageIndex = currentpage - 1;

        Abooks.DataSource = Ainf;

        Abooks.DataBind();                               //把图书信息显示出来

    }

    protected void Afindbook_Click(object sender, EventArgs e)
    {
        string sql1 = Cbook();

        DataBindToRepeater(1, sql1);                                            //显示查找出来的第一页

    }

    protected void Abooks_ItemCommand(object source, RepeaterCommandEventArgs e)           //删除这本书
    {

        if (e.CommandName == "Adelete")                                        //按删除

        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqld = "delete from Books where ID='" + id + "'";                //删除这本书

            int result = Class1.sqlhelp(sqld);

            if (result > 0)

                Response.Write("<script>alert('删除成功！');location='ALibrary'</script>");

            else

                Response.Write("<script>alert('删除失败！');location='ALibrary'</script>");

        }

    }


    

    protected void btnFirst_Click(object sender, EventArgs e)

    {

        string sqlf = Cbook();

        lbNow.Text = "1";

        DataBindToRepeater(1,sqlf);                                      //显示第一页

    }

    protected void btnUp_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lbNow.Text) > 1)                                             //如果当前页数不是首页

        {

            string sqlu = Cbook();

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);             //把当前页数-1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sqlu);

        }

    }

    protected void btnJump_Click(object sender, EventArgs e)                //按下跳转的按钮
    {

        string sqlj = Cbook();

        if (txtJump.Text.Trim().Length > 0)
        {
            int pages = Convert.ToInt32(txtJump.Text.Replace(" ", ""));      //去掉字符串中的空格

            if (pages <= Convert.ToInt32(lbTotal.Text) && pages >= 1)     //如果输入的页数不超过总页数的范围才执行
            {
                lbNow.Text = txtJump.Text;

                DataBindToRepeater(pages, sqlj);                         //把用户输入的页数显示出来
            }

            else

                Response.Write("<script>alert('输入有误')</script>");
        }

        else
            Response.Write("<script>alert('不能为空')</script>");

    }


    protected void btnDrow_Click(object sender, EventArgs e)                            //按下下一页按钮
    {

        if (Convert.ToInt32(lbNow.Text) < Convert.ToInt32(lbTotal.Text))                          //如果当前页数不是尾页         
                      
        {

            string sqld = Cbook();

            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);             //把当前页数+1

            DataBindToRepeater(Convert.ToInt32(lbNow.Text),sqld);

        }
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {

        string sqll = Cbook();

        lbNow.Text = lbTotal.Text;

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text),sqll);   //显示最后一页

    }





}
