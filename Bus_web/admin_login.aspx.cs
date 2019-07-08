using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bus_web
{
    public partial class admin_login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS; Initial Catalog=Bus_web; Integrated Security= true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Previous_Click(object sender, EventArgs e)
        {

        }

        protected void sign_in_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select admin_id,password from login where admin_id='" + user_id.Text + "'and password='" + password.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Log In Sucessfully');window.location ='EntryDeleteView.aspx';",true);
                conn.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Id or Password is invalid');", true);
                conn.Close();
            }
        }
    }
}