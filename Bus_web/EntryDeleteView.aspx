<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntryDeleteView.aspx.cs" Inherits="Bus_web.EntryDeleteUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EntryDeleteUpdate</title>
    <link href="EntryDeleteView.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="edvmain"> 
            <div class="edvprevious">
                <asp:Button ID="Previous" runat="server" Text="Previous" OnClick="Previous_Click" PostBackUrl="admin_login.aspx" />
            </div>

            <div class="edvtextboxtable">
                <div class="edvtext" style="float:left">
                    <ul>
                        <li>
                            <p>Entry Buses Information</p>
                        </li>

                        <li>
                            <p>Bus Id</p>
                        </li>

                        <li>
                            <p>Name of Bus</p>
                        </li>

                        <li>
                            <p>From</p>
                        </li>

                        <li>
                            <p>To</p>
                        </li>

                        <li>
                            <p>Date of journey</p>
                        </li>

                        <li>
                            <p>Dep. Time</p>
                        </li>

                        <li>
                            <p>Arr. Time</p>
                        </li>

                        <li>
                            <p>Available Seat</p>
                        </li>

                        <li>
                            <p>Fare</p>
                        </li>
                    </ul>
                </div>

                <div class="edvbox">
                    <ul>
                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Bus_Id" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Name_of_Bus" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="From" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="To" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Date_of_journey" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Dep_Time" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Arr_time" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Available_Seat" runat="server"></asp:TextBox>
                            
                        </li>

                        <li class="margin_top_li">
                            
                            <asp:TextBox ID="Fare" runat="server"></asp:TextBox>
                            
                        </li>
                    </ul>
                </div>

                <div class="edvtable">
                    <p>Bus information</p>

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
                            <asp:ButtonField Text="Click" CommandName="Select" ItemStyle-Width="30"  />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="edvselectarowtext">
                <p>Select a row before update or delete a schedule</p>
            </div>

            <div class="edvallbutton">

                <asp:Button ID="Insert" runat="server" Text="Insert Bus Schedule" OnClick="Insert_Click" />

                <asp:Button ID="Delete" runat="server" Text="Delete Bus Schedule" OnClick="Delete_Click" />

                <asp:Button ID="Update" runat="server" Text="Update Records" OnClick="Update_Click" />

                <asp:Button ID="View" runat="server" Text="View Customer Details" PostBackUrl="CustomerDetails.aspx" />

            </div>
        </div>
    </form>
</body>
</html>