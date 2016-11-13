using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AInsertB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        int i;

        string sqlselect = "select * from Category";                            //新建查找分类名的语句

        DataTable dt1 = new DataTable();

        dt1 = Class1.select(sqlselect);                                        //查找出书的分类

        for (i = 0; i < dt1.Rows.Count; i++)

        {

            string cid = dt1.Rows[i][0].ToString();

            string category = dt1.Rows[i][1].ToString();

            ListItem a = new ListItem("" + category + "", "" + cid + "");

            Aicategory.Items.Add(a);                                                //用循环动态绑定书的分类这一数据并以下拉框的形式显现出来
        }
    }


    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }

    protected void Aieditor_Click(object sender, EventArgs e)
    {
        string bname = Ainame.Text.Trim();          //获取输入信息

        string bauthor = Aiauthor.Text.Trim();

        string bpress = Aipress.Text.Trim();

        string bcateg = Aicategory.SelectedValue;

        if (Aiamount.Text.Trim().Length > 0 && Aicount.Text.Trim().Length > 0 && bname.Length > 0 && bauthor.Length > 0)
        {

            int amount = Convert.ToInt32(Aiamount.Text.Trim());

            int count = Convert.ToInt32(Aicount.Text.Trim());

            if (amount >= count)
            {



                string sqlinsert = "insert into Books(BookName,Author,Press,Category,Amount,Count) values('" + bname + "','" + bauthor + "','" + bpress + "','" + bcateg + "','" + amount + "','" + count + "')";//插入books表

                int result = Class1.sqlhelp(sqlinsert);

                if (result > 0)

                    Response.Write("<script>alert('增加成功！');location='ALibrary.aspx'</script>");

                else

                    Response.Write("<script>alert('增加失败！');location='AInsertB.aspx'</script>");

            }
            else

                Response.Write("<script>alert('增加失败！');location='AInsertB.aspx'</script>");
        }
        else

            Response.Write("<script>alert('不能为空！');location='AInsertB.aspx'</script>");


    }

    protected void Aicategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}