<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="Bus_web.CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cdmain">
            <div class="cdpreviousbuttontext">
                <div class="cdpreviousbutton" style="float:left">

                    <asp:Button ID="Previous" runat="server" Text="Previous" PostBackUrl="EntryDeleteView.aspx" />

                </div>

                <div class="cdtext">
                    <ul>
                        <li>
                            <h5>Admin</h5>
                        </li>

                        <li>
                            <p>Customer Details</p>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="cdtextboxsearchtable">
                <div class="cdtextboxsearch" style="float:left">
                    <div class="cdtextbox">
                        <ul style="float:left">
                            <li>
                                <p>Ticket Number</p>
                            </li>

                            <li>
                                <p>Passenger Name</p>
                            </li>
                        </ul>

                        <ul>
                            <li>

                                <asp:TextBox ID="Ticket_number" runat="server"></asp:TextBox>

                            </li>

                            <li>
                                <asp:TextBox ID="Passenger_name" runat="server"></asp:TextBox>
                            </li>
                        </ul>
                    </div>

                    <div class="cdsearchbutton">

                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />

                    </div>
                </div>

                <div class="cdtable">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ticket_no" HeaderText="ticket_no" SortExpression="ticket_no" />
                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                            <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                            <asp:BoundField DataField="seat_amount" HeaderText="seat_amount" SortExpression="seat_amount" />
                            <asp:BoundField DataField="bus_id" HeaderText="bus_id" SortExpression="bus_id" />
                            <asp:BoundField DataField="bus_name" HeaderText="bus_name" SortExpression="bus_name" />
                            <asp:BoundField DataField="from_where" HeaderText="from_where" SortExpression="from_where" />
                            <asp:BoundField DataField="to_where" HeaderText="to_where" SortExpression="to_where" />
                            <asp:BoundField DataField="dep_time" HeaderText="dep_time" SortExpression="dep_time" />
                            <asp:BoundField DataField="arr_time" HeaderText="arr_time" SortExpression="arr_time" />
                            <asp:BoundField DataField="date_of_journey" HeaderText="date_of_journey" SortExpression="date_of_journey" />
                            <asp:BoundField DataField="fare" HeaderText="fare" SortExpression="fare" />
                            <asp:BoundField DataField="total_fare" HeaderText="total_fare" SortExpression="total_fare" />
                            <asp:ButtonField Text="Delete" ButtonType="Button" CommandName="Select" ItemStyle-Width="30"  />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
