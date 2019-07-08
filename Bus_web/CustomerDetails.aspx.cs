using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Bus_web
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS; Initial Catalog=Bus_web; Integrated Security= true;");

        int ticketno;
        string name;
        int seat_amount;
        int bus_id;
        string bus_name;
        string from_where;
        string to_where;
        string dep_time;
        string arr_time;
        string date_of_journey;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadData();
            if (!IsPostBack)
                LoadData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (Ticket_number.Text != "" && Passenger_name.Text != "")
            {
                conn.Open();
                string queryy = "select * from passenger_info where ticket_no='" + Ticket_number.Text + "' and name='" + Passenger_name.Text + "'";
                SqlDataAdapter adp = new SqlDataAdapter(queryy, conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    conn.Close();

                    ClearData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This ticket is not exist.');", true);
                    conn.Close();

                    ClearData();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please provide the information!');", true);
            }
        }
        /*
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (name != "")
            {
                conn.Open();

                string query = "delete from passenger_info where ticket_no='" + ticketno + "' and name='" + name + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat + '" + seat_amount + "'  where bus_id ='" + bus_id + "'";
                SqlDataAdapter pq = new SqlDataAdapter(queryy, conn);
                pq.SelectCommand.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Delete successfully');", true);

                conn.Close();

                LoadData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Select Record to Delete');", true);
            }
        }
        */

        private void ClearData()
        {
            Ticket_number.Text = "";
            Passenger_name.Text = "";
        }
        /*
        private void LoadData()
        {
            string cmd = "select * from passenger_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
        }
        */
        private void LoadData()
        {
            DataTable dt = new DataTable();

            try
            {
                string sQuery = "select * from passenger_info";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                dt.Load(sdr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch { }
            finally
            {
                dt.Dispose();
                conn.Close();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ticketno = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
            name = GridView1.SelectedRow.Cells[1].Text;
            seat_amount = Convert.ToInt32(GridView1.SelectedRow.Cells[4].Text);
            bus_id = Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text);
            bus_name = GridView1.SelectedRow.Cells[6].Text;
            from_where = GridView1.SelectedRow.Cells[7].Text;
            to_where = GridView1.SelectedRow.Cells[8].Text;
            dep_time = GridView1.SelectedRow.Cells[9].Text;
            arr_time = GridView1.SelectedRow.Cells[10].Text;
            date_of_journey = GridView1.SelectedRow.Cells[11].Text;

            if (name != "")
            {
                conn.Open();

                string query = "delete from passenger_info where ticket_no='" + ticketno + "' and name='" + name + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat + '" + seat_amount + "'  where bus_id ='" + bus_id + "'";
                SqlDataAdapter pq = new SqlDataAdapter(queryy, conn);
                pq.SelectCommand.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Delete successfully');", true);

                conn.Close();

                LoadData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Select Record to Delete');", true);
            }
        }
    }
}