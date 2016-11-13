using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ALendB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!IsPostBack)

        {

            int i;

            string sqlselect = "select * from State";                            //新建查找状态的语句

            DataTable dt1 = new DataTable();

            dt1 = Class1.select(sqlselect);                                        //查找出状态

            for (i = 0; i < dt1.Rows.Count; i++)

            {

                string sid = dt1.Rows[i][0].ToString();

                string state = dt1.Rows[i][1].ToString();

                ListItem a = new ListItem("" + state + "", "" + sid + "");

                Aste.Items.Add(a);                                                //用循环动态绑定借阅状态这一数据并以下拉框的形式显现出来
            }

            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string sqls = "select * from View_3 where ID='" + id + "'";

            DataTable dt = Class1.select(sqls);

            Alname.Text = dt.Rows[0][2].ToString();

            Albname.Text = dt.Rows[0][7].ToString();

            Alauthor.Text = dt.Rows[0][8].ToString();

            Alpress.Text = dt.Rows[0][9].ToString();

            Aldate.Text = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");                          //把逾期时间设成当前日期加30天

        }
    }


    protected void quit_Click(object sender, EventArgs e)           //注销函数 使session为空
    {

        Session["name"] = null;

        Session["type"] = null;

        Response.Redirect("MyLogin.aspx");

    }

    protected void Aleditor_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);

        string lstate = Aste.SelectedValue;

        string ldate = Aldate.Text.Trim();


        if (ldate.Length > 0)
        {

            string sqlupdate = "update LendBooks set State='" + lstate + "',Dates='" + ldate + "' where ID='" + id + "'";

            int result = Class1.sqlhelp(sqlupdate);

            if (result > 0)

                Response.Write("<script>alert('修改成功！');location='ALibrary.aspx'</script>");

            else

                Response.Write("<script>alert('修改失败！');location='ALendB.aspx'</script>");
        }

        else

            Response.Write("<script>alert('不能为空！');location='ALendB.aspx'</script>");

    }
}