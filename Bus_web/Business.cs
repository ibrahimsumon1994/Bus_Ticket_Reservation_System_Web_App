using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bus_web
{
    public class Business
    {
        public int entrybus(string bus_id1, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, string avai_seat1, string fare1)
        {
            Database C = new Database();
            if (bus_id1 != "" && bus_name != "" && from_where != "" && to_where != "" && date_of_journey != "" && dep_time != "" && arr_time != "" && avai_seat1 != "" && fare1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                int avai_seat = C.Conv(avai_seat1);
                int fare = C.Conv(fare1);
                C.entrybusdata(bus_id, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat, fare);
                C.Nullcheck(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
                return 1;
            }
            else
            {
                //Response.Write("<script>alert('Error: Please Provide Details!');</script>");
                throw new ArgumentNullException("Error: Please Provide Details!");
            }
        }

        public int updatebus(string bus_id1, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, string avai_seat1, string fare1)
        {
            Database C = new Database();
            if (bus_id1 != "" && bus_name != "" && from_where != "" && to_where != "" && date_of_journey != "" && dep_time != "" && arr_time != "" && avai_seat1 != "" && fare1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                int avai_seat = C.Conv(avai_seat1);
                int fare = C.Conv(fare1);
                C.updatebusdata(bus_id, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat, fare);
                C.Nullcheck(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
                return 1;
            }
            else
            {
                //Response.Write("<script>alert('Error: Please Select Record To Update');</script>");
                throw new ArgumentNullException("Error: Please Provide Details!");
            }
        }

        public int deletebus(string bus_id1)
        {
            Database C = new Database();
            if (bus_id1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                C.deletebusdata(bus_id);
                C.Nullcheck1(bus_id1);
                return 1;
            }
            else
            {
                //Response.Write("<script>alert('Error: Provide bus id to Delete');</script>");
                throw new ArgumentNullException("Error: Provide bus id to Delete");
            }
        }
    }
}