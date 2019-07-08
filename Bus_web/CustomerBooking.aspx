<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBooking.aspx.cs" Inherits="Bus_web.CustomerBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Booking</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cbmain">
            <div class="cbpreviousadminbutton">

                <asp:Button ID="Previous" runat="server" Text="Previous" />
                <asp:Button ID="Admin" runat="server" Text="Admin" OnClick="Admin_Click" PostBackUrl="admin_login.aspx" />

            </div>

            <div class="cbtextsearchtable">
                <div class="cbtextsearch" style="float:left; width: 384px;">
                    <div class="cbtext">
                        <ul style="float:left">
                            <li>
                                <p>From</p>
                            </li>

                            <li>
                                <p>To</p>
                            </li>

                            <li>
                                <p>Date of Journey</p>
                            </li>
                        </ul>

                        <ul>
                            <li>

                                <asp:TextBox ID="From" runat="server"></asp:TextBox>

                            </li>

                            <li style="margin-top:17px">

                                <asp:TextBox ID="To" runat="server"></asp:TextBox>

                            </li>

                            <li style="margin-top:17px">

                                <asp:TextBox ID="DateofJourney" runat="server"></asp:TextBox>

                            </li>
                        </ul>
                    </div>

                    <div class="cbsearch">

                        <asp:Button ID="SearchBuses" runat="server" Text="Search Buses" OnClick="SearchBuses_Click" />

                    </div>
                </div>

                <div class="cbtable">
                   
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="bus_id" HeaderText="bus_id" SortExpression="bus_id" />
                            <asp:BoundField DataField="bus_name" HeaderText="bus_name" SortExpression="bus_name" />
                            <asp:BoundField DataField="from_where" HeaderText="from_where" SortExpression="from_where" />
                            <asp:BoundField DataField="to_where" HeaderText="to_where" SortExpression="to_where" />
                            <asp:BoundField DataField="dep_time" HeaderText="dep_time" SortExpression="dep_time" />
                            <asp:BoundField DataField="arr_time" HeaderText="arr_time" SortExpression="arr_time" />
                            <asp:BoundField DataField="avai_seat" HeaderText="avai_seat" SortExpression="avai_seat" />
                            <asp:BoundField DataField="fare" HeaderText="fare" SortExpression="fare" />
                            <asp:BoundField DataField="date_of_journey" HeaderText="date_of_journey" SortExpression="date_of_journey" />
                            <asp:ButtonField Text="Seat Booking" ButtonType="Button" CommandName="Select" ItemStyle-Width="30"  />
                        </Columns>
                    </asp:GridView>                 
                </div>
            </div>

            <div class="cbtext">
                <p>If you want to book seat then please select a row from the table and fill up the boxes below</p>
            </div>

            <div class="cbboxbooking">
                <ul style="float:left">
                    <li>
                        <p>Name</p>
                    </li>

                    <li>
                        <p>Contact No.</p>
                    </li>
                </ul>

                <ul style="float:left">
                    <li>
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                    </li>

                    <li>
                        <asp:TextBox ID="Contactno" runat="server"></asp:TextBox>
                    </li>
                </ul>

                <ul style="float:left">
                    <li>
                        <p>How many seat?</p>
                    </li>

                    <li>
                        <p>Email Address</p>
                    </li>
                </ul>

                <ul>
                    <li>
                        <asp:TextBox ID="SeatAmount" runat="server"></asp:TextBox>
                    </li>

                    <li>
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                    </li>
                </ul>
                
                
            </div>
        </div>
    </form>
</body>
</html>
