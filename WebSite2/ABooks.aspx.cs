using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Abooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)                                          //是否是第一次打开这个页面
        {


            int i;

            string sqlselect = "select * from Category";                            //新建查找分类名的语句

            DataTable dt1 = new DataTable();

            dt1 = Class1.select(sqlselect);                                        //查找出书的分类

            for (i = 0; i < dt1.Rows.Count; i++)

            {

                string cid = dt1.Rows[i][0].ToString();

                string category = dt1.Rows[i][1].ToString();

                ListItem a = new ListItem("" + category + "", "" + cid + "");

                Acategory.Items.Add(a);                                                //用循环动态绑定书的分类这一数据并以下拉框的形式显现出来
            }

            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sqlbeditor = "select * from Books where ID='" + id + "'";    //在books的表中查找信息

            DataTable dt = new DataTable();

            dt = Class1.select(sqlbeditor);

            Abname.Text = dt.Rows[0][1].ToString();                  //把获取的书籍信息显示在文本框里

            Aauthor.Text = dt.Rows[0][2].ToString();

            Apress.Text = dt.Rows[0][3].ToString();

            Aamount.Text = dt.Rows[0][5].ToString();

            Acount.Text = dt.Rows[0][6].ToString();


        }
    }



    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }





    protected void Abditor_Click(object sender, EventArgs e)                //按修改的按钮
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string bname = Abname.Text.Trim();                                          //获取修改后的信息

        string bauthor = Aauthor.Text.Trim();

        string bpress = Apress.Text.Trim();

        string bcateg = Acategory.SelectedValue;

        if (bname.Length > 0 && bauthor.Length > 0 && bpress.Length > 0 && Aamount.Text.Trim().Length > 0 && Acount.Text.Trim().Length > 0)

        {

            int amount = Convert.ToInt32(Aamount.Text.Trim());

            int count = Convert.ToInt32(Acount.Text.Trim());

            if (amount >= count)
            {

                string sqlupdate = "update Books set BookName='" + bname + "',Author='" + bauthor + "',Press='" + bpress + "',Amount='" + amount + "',Count='" + count + "',Category='" + bcateg + "' where ID='" + id + "'";

                int result = Class1.sqlhelp(sqlupdate);

                if (result > 0)

                    Response.Write("<script>alert('修改成功！');location='ALibrary.aspx'</script>");

                else

                    Response.Write("<script>alert('修改失败！');location='ABooks.aspx'</script>");

            }
            else
                Response.Write("<script>alert('修改失败！');location='ABooks.aspx'</script>");

        }
        else

            Response.Write("<script>alert('不能为空！');location='ABooks.aspx'</script>");

    }
}
