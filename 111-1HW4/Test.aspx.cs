using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _111_1HW4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Str = ConfigurationManager.ConnectionStrings["AAA"].ConnectionString;
            if (!IsPostBack)
            {
                try
                {
                    SqlConnection o_Str = new SqlConnection(s_Str);
                    o_Str.Open();
                    SqlDataAdapter o_A = new SqlDataAdapter("Select * from Users", o_Str);
                    DataSet o_D = new DataSet();
                    o_A.Fill(o_D, "ds_Res");//SQL轉接器物件名稱.Fill(資料集物件名稱, 資料表名稱);
                    gd_View.DataSource = o_D;
                    gd_View.DataBind();
                    o_Str.Close();
                }
                catch (Exception o_ex)
                {
                    Response.Write(o_ex.ToString());
                }
            }
        }
        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            string s_Str = ConfigurationManager.ConnectionStrings["AAA"].ConnectionString;
            try
            {
                SqlConnection o_Str = new SqlConnection(s_Str);
                o_Str.Open();
                string str_sql = "Insert into Users (Name, Birthday)" + "values(N'阿貓阿狗', '2000/10/10');";
                SqlCommand o_cmd = new SqlCommand(str_sql, o_Str);
                o_cmd.ExecuteNonQuery();
                Response.Redirect("https://localhost:44383/Test.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                o_Str.Close();
            }
            catch (Exception o_ex)
            {
                Response.Write(o_ex.ToString());
            }
        }
    }
}