<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrade.aspx.cs" Inherits="GUCera.ViewGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="ViewPromoCode" OnClick="ViewPromo" />
            <br />
           
            <asp:Button ID="Button2" runat="server" Text="View  Profile" OnClick="ViewProfile" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Add Credit Card" OnClick="AddCreditCard" />
           
            <br />
            <asp:Button ID="Button12" runat="server" Text="View All Courses" OnClick="ViewCourses" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="Add Mobile Number" OnClick="MobileNumber" />
            <br />
            <asp:Button ID="Button9" runat="server" Text="Add Feedback" OnClick="AddFeedback" />
           
            <br />
            <asp:Button ID="Button4" runat="server" Text="View List Of Certificates" OnClick="ListCertificates" />
           
            <br />
            <asp:Button ID="Button8" runat="server" Text="Submit Assignment" OnClick="SubmitAssignment" />
           
            <br />
            <asp:Button ID="Button10" runat="server" Text="View Assignment" OnClick="ViewAssignment" />
           
            <br />
            <asp:Button ID="Button11" runat="server" Text="View Grade" OnClick="viewGrade" />
           <br />
            <br />
            <br />

            Please Enter Assignment number:<br />
            <asp:TextBox ID="Assnum" runat="server"></asp:TextBox>
            <br />
            Please Enter Assignment Type:<br />
            <asp:TextBox ID="AssType" runat="server"></asp:TextBox>
            <br />
            Please Enter Course Id:<br />
            <asp:TextBox ID="CourseId" runat="server"></asp:TextBox>
            <br />
            
            <br />
            <asp:Button ID="Grade" runat="server" Text="Get Grade" OnClick="Grade_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

