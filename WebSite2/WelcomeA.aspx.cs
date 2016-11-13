using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class welcomea : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        Aname.Text = Session["name"].ToString();


        string sqlselect = "select * from LendBooks";          //建立查找借阅信息的语句   

        DataTable dt = new DataTable();

        dt = Class1.select(sqlselect);

        string sql;

        for (int i = 0; i < dt.Rows.Count; i++)                                                        //更新借阅状态，若超出截止日期则定义为逾期
        {
            string dates = dt.Rows[i][5].ToString();

            string id = dt.Rows[i][0].ToString();

            if (string.Compare(dates, DateTime.Now.ToString("yyyy-MM-dd")) < 0)
            {

                sql = "update LendBooks set State = 0 where ID ='" + id + "'";
                int result = Class1.sqlhelp(sql);
                if (result > 0)
                    Response.Write("<script>alert('数据更新成功')</script>");

                else

                    Response.Write("<script>alert('数据更新错误')</script>");

            }

            


        }
    }

    protected void quit_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Session["type"] = null;
        Response.Redirect("MyLogin.aspx");
    }
}