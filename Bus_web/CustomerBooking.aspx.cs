using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Bus_web
{
    public partial class CustomerBooking : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS;Initial Catalog=Bus_web;Integrated Security= true;");
        int bus_id1;
        string bus_name;
        string from_where;
        string to_where;
        string dep_time;
        string arr_time;
        string date_of_journey;
        int amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadData();
            if (!IsPostBack)
                LoadData();
        }

        protected void Admin_Click(object sender, EventArgs e)
        {

        }

        protected void SearchBuses_Click(object sender, EventArgs e)
        {
            if (From.Text != "" && To.Text != "" && DateofJourney.Text != "")
            {
                conn.Open();
                string queryy = "select * from new_bus_info where from_where='" + From.Text + "'and to_where='" + To.Text + "'and date_of_journey='" + DateofJourney.Text + "'";
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
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('There have no such schedule');", true);
                    conn.Close();

                    ClearData();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please provide the information!');", true);
            }
        }

        private void ClearData()
        {
            From.Text = "";
            To.Text = "";
            DateofJourney.Text = "";
            Name.Text = "";
            Contactno.Text = "";
            SeatAmount.Text = "";
            Email.Text = "";
        }

        /*protected void SeatBooking_Click(object sender, EventArgs e)
        {
            if (Name.Text != "" && Contactno.Text != "" && SeatAmount.Text != "" && bus_id1 > 0 && bus_name != "" && from_where != "" && to_where != "" && dep_time != "" && arr_time != "" && date_of_journey != "")
            {
                //total fare for selected seat amount
                int total_amount;
                total_amount = amount * Convert.ToInt32(SeatAmount.Text);

                //random ticket number
                Random RandomNumber = new Random();
                int no = RandomNumber.Next(10000000, 99999999);

                conn.Open();
                string query = "INSERT INTO passenger_info (ticket_no, name, contact_no, email, seat_amount, bus_id, bus_name, from_where, to_where, dep_time, arr_time, date_of_journey, fare, total_fare)VALUES (@ticket_no, @name, @contact_no, @email, @seat_amount, @bus_id, @bus_name, @from_where, @to_where, @dep_time, @arr_time, @date_of_journey, @fare, @total_fare) ";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@ticket_no", no);
                bcmd.Parameters.AddWithValue("@name", Name.Text);
                bcmd.Parameters.AddWithValue("@contact_no", Contactno.Text);
                bcmd.Parameters.AddWithValue("@email", Email.Text);
                bcmd.Parameters.AddWithValue("@seat_amount", SeatAmount.Text);
                bcmd.Parameters.AddWithValue("@bus_id", bus_id1);
                bcmd.Parameters.AddWithValue("@bus_name", bus_name);
                bcmd.Parameters.AddWithValue("@from_where", from_where);
                bcmd.Parameters.AddWithValue("@to_where", to_where);
                bcmd.Parameters.AddWithValue("@dep_time", dep_time);
                bcmd.Parameters.AddWithValue("@arr_time", arr_time);
                bcmd.Parameters.AddWithValue("@date_of_journey", date_of_journey);
                bcmd.Parameters.AddWithValue("@fare", amount);
                bcmd.Parameters.AddWithValue("@total_fare", total_amount);
                bcmd.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat - '" + SeatAmount.Text + "'  where bus_id ='" + bus_id1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, conn);
                sda.SelectCommand.ExecuteNonQuery();

                //pdf format
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("C:/Users/USER/Desktop/" + Name.Text + ".pdf", FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("Ticket Number= " + no + "" + Environment.NewLine + " Name= " + Name.Text + "" + Environment.NewLine + " Contact Number= " + Contactno.Text + "" + Environment.NewLine + "Seat Amount= " + SeatAmount.Text + "" + Environment.NewLine + " Bus Id= " + bus_id1 + "" + Environment.NewLine + "Bus Name= " + bus_name + "" + Environment.NewLine + "From= " + from_where + "" + Environment.NewLine + "To= " + to_where + "" + Environment.NewLine + "Departure time= " + dep_time + "" + Environment.NewLine + "Arrival time= " + arr_time + "" + Environment.NewLine + "Total fare= " + total_amount + "");
                document.Add(p);
                document.Close();

                conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Successfully booked and generated your ticket in your home screen(desktop).');", true);

                LoadData();
                ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please provide or select the information correctly');", true);
            }
        }*/
        /*
        private void LoadData()
        {
            string cmd = "select * from new_bus_info";
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
        /*
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bus_id1 = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
            bus_name = GridView1.SelectedRow.Cells[1].Text;
            from_where = GridView1.SelectedRow.Cells[2].Text;
            to_where = GridView1.SelectedRow.Cells[3].Text;
            dep_time = GridView1.SelectedRow.Cells[4].Text;
            arr_time = GridView1.SelectedRow.Cells[5].Text;
            amount = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
            date_of_journey = GridView1.SelectedRow.Cells[8].Text;
        }
        */
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
            bus_id1 = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
            bus_name = GridView1.SelectedRow.Cells[1].Text;
            from_where = GridView1.SelectedRow.Cells[2].Text;
            to_where = GridView1.SelectedRow.Cells[3].Text;
            dep_time = GridView1.SelectedRow.Cells[4].Text;
            arr_time = GridView1.SelectedRow.Cells[5].Text;
            amount = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
            date_of_journey = GridView1.SelectedRow.Cells[8].Text;

            if (Name.Text != "" && Contactno.Text != "" && SeatAmount.Text != "" && bus_id1 > 0 && bus_name != "" && from_where != "" && to_where != "" && dep_time != "" && arr_time != "" && date_of_journey != "")
            {
                //total fare for selected seat amount
                int total_amount;
                total_amount = amount * Convert.ToInt32(SeatAmount.Text);

                //random ticket number
                Random RandomNumber = new Random();
                int no = RandomNumber.Next(10000000, 99999999);

                conn.Open();
                string query = "INSERT INTO passenger_info (ticket_no, name, contact_no, email, seat_amount, bus_id, bus_name, from_where, to_where, dep_time, arr_time, date_of_journey, fare, total_fare)VALUES (@ticket_no, @name, @contact_no, @email, @seat_amount, @bus_id, @bus_name, @from_where, @to_where, @dep_time, @arr_time, @date_of_journey, @fare, @total_fare) ";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@ticket_no", no);
                bcmd.Parameters.AddWithValue("@name", Name.Text);
                bcmd.Parameters.AddWithValue("@contact_no", Contactno.Text);
                bcmd.Parameters.AddWithValue("@email", Email.Text);
                bcmd.Parameters.AddWithValue("@seat_amount", SeatAmount.Text);
                bcmd.Parameters.AddWithValue("@bus_id", bus_id1);
                bcmd.Parameters.AddWithValue("@bus_name", bus_name);
                bcmd.Parameters.AddWithValue("@from_where", from_where);
                bcmd.Parameters.AddWithValue("@to_where", to_where);
                bcmd.Parameters.AddWithValue("@dep_time", dep_time);
                bcmd.Parameters.AddWithValue("@arr_time", arr_time);
                bcmd.Parameters.AddWithValue("@date_of_journey", date_of_journey);
                bcmd.Parameters.AddWithValue("@fare", amount);
                bcmd.Parameters.AddWithValue("@total_fare", total_amount);
                bcmd.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat - '" + SeatAmount.Text + "'  where bus_id ='" + bus_id1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, conn);
                sda.SelectCommand.ExecuteNonQuery();

                //pdf format
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("C:/Users/USER/Desktop" + Name.Text + ".pdf", FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("Ticket Number= " + no + "" + Environment.NewLine + " Name= " + Name.Text + "" + Environment.NewLine + " Contact Number= " + Contactno.Text + "" + Environment.NewLine + "Seat Amount= " + SeatAmount.Text + "" + Environment.NewLine + " Bus Id= " + bus_id1 + "" + Environment.NewLine + "Bus Name= " + bus_name + "" + Environment.NewLine + "From= " + from_where + "" + Environment.NewLine + "To= " + to_where + "" + Environment.NewLine + "Departure time= " + dep_time + "" + Environment.NewLine + "Arrival time= " + arr_time + "" + Environment.NewLine + "Total fare= " + total_amount + "");
                document.Add(p);
                document.Close();

                conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Successfully booked and generated your ticket in your home screen(desktop).');", true);

                LoadData();
                ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please provide or select the information correctly');", true);
            }
        }
    }
}