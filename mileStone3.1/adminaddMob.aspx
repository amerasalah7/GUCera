<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminaddMob.aspx.cs" Inherits="mileStone3._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href ="adminaddMob.aspx"> Add mobile number </a></li>
                <li><a href ="issuePromo.aspx"> issue promo code to student </a></li>
                <li><a href ="allCourses.aspx"> View all Courses </a></li>
                <li><a href ="AdminAccRej.aspx"> Accept Courses </a></li>
                <li><a href ="CreatePromoCode.aspx"> Create PromoCode </a></li>
                <li><a href ="Login2.aspx"> Log in </a></li>
                <li><a href ="registeration.aspx"> registeration </a></li>
                <li><a href ="home.aspx">Home </a></li>
            </ul>
            <asp:Label ID="lbl2" runat="server" Text="MobileNumber : "></asp:Label>
              <br />
            <asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox>
            <br />
             <asp:Button ID="Button_Submit" runat="server" Text="Sumbit" onclick="Submit" />
        </div>
    </form>
</body>
</html>
