<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengPostalCalculatrHelperMethod.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Tolu
    
        Postar Calculator<br />
        <br />
        Width:
        <asp:TextBox ID="widthTextBox" runat="server" OnTextChanged="handleChange"></asp:TextBox>
        <br />
        <br />
        Height:
        <asp:TextBox ID="heightTextBox" runat="server" OnTextChanged="handleChange"></asp:TextBox>
        <br />
        <br />
        Length:
        <asp:TextBox ID="lengthTextBox" runat="server" style="margin-left: 0px" OnTextChanged="handleChange"></asp:TextBox>
        <br />
        <br />
        <asp:RadioButton ID="groundRadioButton" runat="server" AutoPostBack="True" GroupName="From Group" OnCheckedChanged="handleChange" Text="Ground" />
&nbsp;
        <br />
        <asp:RadioButton ID="airRadioButton" runat="server" AutoPostBack="True" GroupName="From Group" OnCheckedChanged="handleChange" Text="Air" />
        <br />
        <asp:RadioButton ID="nextDayRadioButton" runat="server" AutoPostBack="True" GroupName="From Group" OnCheckedChanged="handleChange" Text="Next Day" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
