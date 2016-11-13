using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindPwd : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Find_Click(object sender, EventArgs e)
    {
        string name = FindName.Text;
        string usersname = FindUsersName.Text;
        string tel = FindTel.Text;
        string sql;

        try
        {
            if (FUsers.SelectedValue == "普通用户")
                sql = "select Password from Users where Name='" + name + "'and Telephone='" + tel + "' and UsersName='" + usersname + "'";
            else
                sql = "select Password from Administrator where Name='" + name + "'and Telephone='" + tel + "' and UsersName='" + usersname + "'";
            if(Class1.select(sql).Rows.Count>0)
            {
                string result = Class1.select(sql).Rows[0][0].ToString();
                Response.Write("<script>alert('密码为：" + result + "');location='MyLogin.aspx'</script>");
            }
           else
                Response.Write("<script>alert('用户不存在！')</script>");
            
                
           
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

    }
}