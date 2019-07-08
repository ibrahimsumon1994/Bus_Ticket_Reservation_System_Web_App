<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="Bus_web.admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Log In</title>
    <link href="admin_login.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #000066">
        <div class="main">
            <div class="previous">
                
                <asp:Button ID="Previous" runat="server" Text="Previous" BackColor="Silver" BorderColor="#0066FF" ForeColor="Black" Height="40px" OnClick="Previous_Click" Width="130px" PostBackUrl="~/CustomerBooking.aspx" />
                
            </div>
            <div class="logpic">
                <div class="log">
                    <ul>
                        <li style="margin-left:20px; margin-top:40px">
                            <h1>Admin</h1>
                        </li>
                        <li style="margin-left:20px; margin-top:40px">
                            <p>Log In Page</p>
                        </li>
                        <li style="margin-left:20px; margin-top:40px">
                            <p>User Id<asp:TextBox ID="user_id" runat="server"></asp:TextBox>
                            </p>
                        </li>
                        <li style="margin-left:20px; margin-top:40px">
                            <p>Password<asp:TextBox ID="password" runat="server"></asp:TextBox>
                            </p>
                        </li>
                        <li style="margin-left:20px; margin-top:40px">
                            
                            <asp:Button ID="sign_in" runat="server" OnClick="sign_in_Click" Text="Sign In" Width="156px"/>
                            
                        </li>
                    </ul>
                </div>
                <div class="pic">
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
