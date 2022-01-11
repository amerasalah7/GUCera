<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignment.aspx.cs" Inherits="GUCera.ViewAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="ViewPromoCode" OnClick="ViewPromo" />
            <br />
           
            <asp:Button ID="Button3" runat="server" Text="View  Profile" OnClick="ViewProfile" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Add Credit Card" OnClick="AddCreditCard" />
           
            <br />
            <asp:Button ID="Button12" runat="server" Text="View All Courses" OnClick="ViewCourses" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="Add Mobile Number" OnClick="MobileNumber" />
            <br />
            <asp:Button ID="Button9" runat="server" Text="Add Feedback" OnClick="AddFeedback" />
           
            <br />
            <asp:Button ID="Button5" runat="server" Text="View List Of Certificates" OnClick="ListCertificates" />
           
            <br />
            <asp:Button ID="Button8" runat="server" Text="Submit Assignment" OnClick="SubmitAssignment" />
           
            <br />
            <asp:Button ID="Button10" runat="server" Text="View Assignment" OnClick="viewAssignment" />
           
            <br />
            <asp:Button ID="Button11" runat="server" Text="View Grade" OnClick="ViewGrade" />
           <br />
            <br />
            <br />
            <br />
            <br />
            Please Enter Course Id:<br />
            <asp:TextBox ID="CourseId" runat="server"></asp:TextBox>
            <br />
            
        <asp:Button ID="Button1" runat="server" OnClick="ViewAss" Text="View" />
        <br />
    </form>
</body>
</html>
