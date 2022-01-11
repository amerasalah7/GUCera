<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myProfile.aspx.cs" Inherits="GUCera1.myProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="instructorsLinks2.aspx">Back</a><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; My Profile<br />
            <br />
            <br />
            <br />
            First Name :-&nbsp;&nbsp;&nbsp;
            <asp:Label ID="firstName" runat="server" Text=""></asp:Label>
        &nbsp;
            <br />
            <br />
            Last Name :-&nbsp;
            <asp:Label ID="lastName" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Gender :-
            <asp:Label ID="gender" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Email :-
            <asp:Label ID="email" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Address :-
            <asp:Label ID="address" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Rating :-
            <asp:Label ID="rating" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Mobile Number/s :-&nbsp;
            <br />
            <br />
            <asp:Label ID="mobile" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
