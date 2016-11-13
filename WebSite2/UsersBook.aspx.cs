using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usersbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string name = Session["name"].ToString();                                         //获取登录名

            string sqlselect = "select * from View_3 where ReaderName='" + name + "'";          //建立查找借阅信息的语句   

            DataTable dt = new DataTable();

            dt = Class1.select(sqlselect);

            usersb.DataSource = dt;

            usersb.DataBind();
        }
       

    }

    protected void quit_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Session["type"] = null;
        Response.Redirect("MyLogin.aspx");
    }


    protected void usersb_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       


        if(e.CommandName=="renewb")                                                             //如果按续借
        {
           
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqlstate = "select State from View_3 where ID='" + id + "'";

            DataTable dts = Class1.select(sqlstate);

            if (Convert.ToInt32(dts.Rows[0][0].ToString()) == 1)                                    //如果借阅状态为正常方可续借（只能续借一次）

            {
                string dates = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");                  //获取当前日期

                string sql = "update LendBooks set Dates='" + dates + "' where ID='" + id + "'";     //新建把逾期日期更新到当前时间的三十天后

                int result = Class1.sqlhelp(sql);

                if (result > 0)
                {

                    string sqlu = "update LendBooks set state='2' where ID='" + id + "'";

                    int result1 = Class1.sqlhelp(sqlu);

                    if(result>0)

                        Response.Write("<script>alert('续借成功');location='UsersBook.aspx'</script>");

                    else

                        Response.Write("<script>alert('续借失败');location='UsersBook.aspx'</script>");


                }



                else


                    Response.Write("<script>alert('续借失败');location='UsersBook.aspx'</script>");

            }

            else

                Response.Write("<script>alert('不可续借！');location='UsersBook.aspx'</script>");
                   
        }

        if(e.CommandName=="returnb")                                                //如果按还书

        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sqlstate = "select * from View_3 where ID='" + id + "'";     //查找该书的解约状态

            DataTable dts = Class1.select(sqlstate);

            int bookid = Convert.ToInt32(dts.Rows[0][3].ToString());

            if (Convert.ToInt32(dts.Rows[0][4].ToString()) == 0)                    //若为该本书为逾期状态则不可还书

            {
                Response.Write("<script>alert('不可还书！请找管理员解除限制！');location='UsersBook.aspx'</script>");
        
            }
            
            else

            {
                string sql1 = "delete from LendBooks where ID='" + id + "'";                     //把该条借阅信息从借阅信息表中删除



                int result1 = Class1.sqlhelp(sql1);

                if (result1 > 0)
                {
                    

                    string sqlup = "update Books set Count=Count+1 where ID='" + bookid + "'";              //把可借数量加一

                    int result2 = Class1.sqlhelp(sqlup);

                    if(result2>0)

                            Response.Write("<script>alert('还书成功！');location='UsersBook.aspx'</script>");

                    else

                        Response.Write("<script>alert('还书失败！');location='UsersBook.aspx'</script>");

                }



                else

                    Response.Write("<script>alert('还书失败！');location='UsersBook.aspx'</script>");
            }
               

        }

    }
}