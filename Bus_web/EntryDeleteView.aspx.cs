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
    public partial class EntryDeleteUpdate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS;Initial Catalog=Bus_web;Integrated Security= true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadData();
            if (!IsPostBack)
                LoadData();
        }

        protected void Previous_Click(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {   /*
            Database C = new Database();
            Business B = new Business();
            string bus_id1 = Bus_Id.Text;
            string bus_name = Name_of_Bus.Text;
            string from_where = From.Text;
            string to_where = To.Text;
            string date_of_journey = Date_of_journey.Text;
            string dep_time = Dep_Time.Text;
            string arr_time = Arr_time.Text;
            string avai_seat1 = Available_Seat.Text;
            string fare1 = Fare.Text;
            //B.entrybus(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);

            LoadData();
            ClearData();
            */
            if (Bus_Id.Text != "" && Name_of_Bus.Text != "" && From.Text != "" && To.Text != "" && Date_of_journey.Text != "" && Dep_Time.Text != "" && Arr_time.Text != "" && Available_Seat.Text != "" && Fare.Text != "")
            {
                conn.Open();
                string query1 = "select * from new_bus_info where bus_id = '" + Bus_Id.Text + "'";
                string query = "INSERT INTO new_bus_info (bus_id,bus_name,from_where,to_where,date_of_journey,dep_time,arr_time,avai_seat,fare)VALUES (@bus_id,@bus_name,@from_where,@to_where,@date_of_journey,@dep_time,@arr_time,@avai_seat,@fare) ";
                SqlCommand bcmd = new SqlCommand(query, conn);
                SqlCommand bcmd1 = new SqlCommand(query1, conn);
                SqlDataAdapter da = new SqlDataAdapter(bcmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Error: This bus id exists in database");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: This bus id exists in database');", true);
                    conn.Close();
                }
                else
                {
                    bcmd.Parameters.AddWithValue("@bus_id", Convert.ToInt32(Bus_Id.Text));
                    bcmd.Parameters.AddWithValue("@bus_name", Name_of_Bus.Text);
                    bcmd.Parameters.AddWithValue("@from_where", From.Text);
                    bcmd.Parameters.AddWithValue("@to_where", To.Text);
                    bcmd.Parameters.AddWithValue("@date_of_journey", Date_of_journey.Text);
                    bcmd.Parameters.AddWithValue("@dep_time", Dep_Time.Text);
                    bcmd.Parameters.AddWithValue("@arr_time", Arr_time.Text);
                    bcmd.Parameters.AddWithValue("@avai_seat", Convert.ToInt32(Available_Seat.Text));
                    bcmd.Parameters.AddWithValue("@fare", Convert.ToInt32(Fare.Text));
                    bcmd.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Information Inserted Successfully');", true);
                    //MessageBox.Show("Information Inserted Successfully");
                    conn.Close();
                    LoadData();
                    ClearData();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Provide Details!');", true);
                //MessageBox.Show("Please Provide Details!");
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            /*
            string bus_id1 = Bus_Id.Text;
            Business B = new Business();
            B.deletebus(bus_id1);
            LoadData();
            ClearData();
            */
            if (Bus_Id.Text != "")
            {
                conn.Open();
                string query = "delete from new_bus_info where bus_id='" + Bus_Id.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Delete successfully');", true);
                //MessageBox.Show("Delete successfully");
                conn.Close();
                LoadData();
                ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Select Record to Delete');", true);
                //MessageBox.Show("Please Select Record to Delete");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            /*
            Business B = new Business();
            string bus_id1 = Bus_Id.Text;
            string bus_name = Name_of_Bus.Text;
            string from_where = From.Text;
            string to_where = To.Text;
            string date_of_journey = Date_of_journey.Text;
            string dep_time = Dep_Time.Text;
            string arr_time = Arr_time.Text;
            string avai_seat1 = Available_Seat.Text;
            string fare1 = Fare.Text;
            B.updatebus(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
            LoadData();
            ClearData();
            */
            if (Bus_Id.Text != "" && Name_of_Bus.Text != "" && From.Text != "" && To.Text != "" && Date_of_journey.Text != "" && Dep_Time.Text != "" && Arr_time.Text != "" && Available_Seat.Text != "" && Fare.Text != "")
            {
                conn.Open();
                string query = "update new_bus_info set bus_id = '" + Bus_Id.Text + "', bus_name = '" + Name_of_Bus.Text + "', from_where = '" + From.Text + "', to_where = '" + To.Text + "', dep_time = '" + Dep_Time.Text + "', arr_time = '" + Arr_time.Text + "', avai_seat = '" + Available_Seat.Text + "', fare = '" + Fare.Text + "', date_of_journey = '" + Date_of_journey.Text + "'  where bus_id = '" + Bus_Id.Text + "'";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@bus_id", Convert.ToInt32(Bus_Id.Text));
                bcmd.Parameters.AddWithValue("@bus_name", Name_of_Bus.Text);
                bcmd.Parameters.AddWithValue("@from_where", From.Text);
                bcmd.Parameters.AddWithValue("@to_where", To.Text);
                bcmd.Parameters.AddWithValue("@date_of_journey", Date_of_journey.Text);
                bcmd.Parameters.AddWithValue("@dep_time", Dep_Time.Text);
                bcmd.Parameters.AddWithValue("@arr_time", Arr_time.Text);
                bcmd.Parameters.AddWithValue("@avai_seat", Convert.ToInt32(Available_Seat.Text));
                bcmd.Parameters.AddWithValue("@fare", Convert.ToInt32(Fare.Text));
                bcmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated successfully');", true);
                //MessageBox.Show("Updated successfully");
                conn.Close();
                LoadData();
                ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Select Record To Update');", true);
                //MessageBox.Show("Please Select Record To Update");
            }
        }
        /*
        public bool LoadData()
        {
            string cmd = "select * from new_bus_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            return true;
        }
        */
        public void ClearData()
        {
            Bus_Id.Text = "";
            Name_of_Bus.Text = "";
            From.Text = "";
            To.Text = "";
            Date_of_journey.Text = "";
            Dep_Time.Text = "";
            Arr_time.Text = "";
            Available_Seat.Text = "";
            Fare.Text = "";
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            try
            {
                string sQuery = "select * from new_bus_info";

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
            Bus_Id.Text = GridView1.SelectedRow.Cells[0].Text;
            Name_of_Bus.Text = GridView1.SelectedRow.Cells[1].Text;
            From.Text = GridView1.SelectedRow.Cells[2].Text;
            To.Text = GridView1.SelectedRow.Cells[3].Text;
            Dep_Time.Text = GridView1.SelectedRow.Cells[4].Text;
            Arr_time.Text = GridView1.SelectedRow.Cells[5].Text;
            Available_Seat.Text = GridView1.SelectedRow.Cells[6].Text;
            Fare.Text = GridView1.SelectedRow.Cells[7].Text;
            Date_of_journey.Text = GridView1.SelectedRow.Cells[8].Text;
        }
    }
}