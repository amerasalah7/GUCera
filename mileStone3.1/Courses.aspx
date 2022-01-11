<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="milestone3.Courses" %>

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
            <asp:Button ID="Button11" runat="server" Text="View Grade" OnClick="ViewGrade" />
           
            <br />
            <br />
            <br />
            <br />
            <br />
            Click on A course to view it is information
            <br />
            <asp:DropDownList ID="list" runat="server"   OnSelectedIndexChanged="OnSelectedIndexChangedMethod" AutoPostBack="true" >
                
                
            </asp:DropDownList>
            <br />
            click on the button to view the courses' instructors 
            <br />
            <asp:Button ID="Button5" runat="server" Text="Enroll in this Course" OnClick="ViewContent" />
            <br />
             <asp:DropDownList ID="list2" runat="server"    AutoPostBack="true" 
         Visible    ="false">             
                    
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button6" runat="server" Text="submit Enrollment" OnClick="enroll" Visible="false" />
        </div>
    </form>
</body>
</html>
 