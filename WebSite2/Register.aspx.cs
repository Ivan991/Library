using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string Name = TextName.Text.Trim();

        string Pwd = TextPwd.Text.Trim();

        string UsersName = TextUsersName.Text.Trim();

        string Sex = sex.SelectedValue;

        string Tel = TextTel.Text.Trim();


        if (Name.Length>0&&Pwd.Length>0&&UsersName.Length>0&&UsersName.Length>0&&Tel.Length>0 )
        {
            //try
            //{
            //    int a = Convert.ToInt32(phone.text);
            //}
            //catch
            //{
            //    弹窗不正确
            //}
            try
            {
                string sql = "insert into Users values ('" + Name + "','" + Pwd + "','" + UsersName + "','" + Sex + "','" + Tel + "')";
                string sql1 = "select * from Users where Name='" + Name + "'";
                DataTable dt = new DataTable();
                dt = Class1.select(sql1);
                int result = Class1.sqlhelp(sql);
                if (result == 1 && dt.Rows.Count == 0)
                    Response.Write("<script>alert('注册成功！');location='MyLogin.aspx'</script>");
                else
                    Response.Write("<script>alert('注册信息填写错误！')</script>");

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        else
            Response.Write("<script>alert('注册信息不能为空！')</script>");
    }




  
}