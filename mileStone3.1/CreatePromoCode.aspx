<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePromoCode.aspx.cs" Inherits="mileStone3._1.CreatePromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Create a new PromoCode<br />
            <br />
            Code:<asp:TextBox ID="code" runat="server"></asp:TextBox>
            <br />
            <br />
            Issue Date:<asp:TextBox ID="issdate" runat="server"></asp:TextBox>
            <br />
            <br />
            Expiry Date:<asp:TextBox ID="expdate" runat="server"></asp:TextBox>
            <br />
            <br />
            Discount:<asp:TextBox ID="discount" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Create" runat="server" OnClick="CreatePromo" Text="Create" />
            <ul>
                <li><a href ="adminaddMob.aspx"> Add mobile number </a></li>
                <li><a href ="issuePromo.aspx"> issue promo code to student </a></li>
                <li><a href ="allCourses.aspx"> View all Courses </a></li>
                <li><a href ="AdminAccRej.aspx"> Accept Courses </a></li>
                <li><a href ="CreatePromoCode.aspx"> Create PromoCode </a></li>
                <li><a href ="Login2.aspx"> Log in </a></li>
                <li><a href ="Default.aspx"> Regester </a></li>
                <li><a href ="home.aspx">Home </a></li>
            </ul>
        </div>
    </form>
</body>
</html>
