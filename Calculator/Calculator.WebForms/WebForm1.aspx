<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationCalc.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="DisplayTB" runat="server" Height="100px" Width="258px" Font-Size="40pt"></asp:TextBox>
            <br />
            <asp:Button ID="ClearB"  runat="server" Height="50px" Text="C" Width="50px" BackColor="#FF9933" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Clear_Click" />
            <asp:Button ID="Button1" runat="server" Height="50px" Text="←" Width="50px" BackColor="Lime" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" />
            <asp:Button ID="Button2" runat="server" Height="50px" Text="(" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" />
            <asp:Button ID="Button3" runat="server" Height="50px" Text=")" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" />
            <asp:Button ID="Button4" runat="server" Height="50px" Text="x^2" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="14pt" Font-Names="Adobe Song Std L" />
            <br />
            <asp:Button ID="Button"  runat="server" Height="50px" Text="7" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button6" runat="server" Height="50px" Text="8" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button7" runat="server" Height="50px" Text="9" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Number_Click" />
            <asp:Button ID="Button8" runat="server" Height="50px" Text="÷" Width="50px" BackColor="#FF9933" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Operator_Click" />
            <asp:Button ID="Button9" runat="server" Height="50px" Text="x^y" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="14pt" Font-Italic="False" Font-Names="Adobe Song Std L" OnClick="Operator_Click" />
             <br />           
            <asp:Button ID="Button10" runat="server" Height="50px" Text="4" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button11" runat="server" Height="50px" Text="5" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button12" runat="server" Height="50px" Text="6" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Number_Click" />
            <asp:Button ID="Button13" runat="server" Height="50px" Text="×" Width="50px" BackColor="#FF9933" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Operator_Click" />
            <asp:Button ID="Button14" runat="server" Height="50px" Text="1/x" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="14pt" Font-Names="Adobe Song Std L" />
            <br />            
            <asp:Button ID="Button15" runat="server" Height="50px" Text="1" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button16" runat="server" Height="50px" Text="2" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button17" runat="server" Height="50px" Text="3" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Number_Click" />
            <asp:Button ID="Button18" runat="server" Height="50px" Text="-" Width="50px" BackColor="#FF9933" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Operator_Click" />
            <asp:Button ID="Button19" runat="server" Height="50px" Text="ln" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="14pt" Font-Names="Adobe Song Std L" />
            <br />            
            <asp:Button ID="Button20" runat="server" Height="50px" Text="0" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button21" runat="server" Height="50px" Text="," Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="20pt" OnClick="Number_Click" />
            <asp:Button ID="Button22" runat="server" Height="50px" Text="=" Width="50px" BackColor="Lime" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Evaluate_Click" />
            <asp:Button ID="Button23" runat="server" Height="50px" Text="+" Width="50px" BackColor="#FF9933" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="18pt" OnClick="Operator_Click" />
            <asp:Button ID="Button24" runat="server" Height="50px" Text="±" Width="50px" BackColor="#99CCFF" BorderColor="#000066" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Font-Size="14pt" Font-Names="Adobe Song Std L" />
                        
        </div>
    </form>
</body>
</html>
