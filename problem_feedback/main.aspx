<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="problem_feedback.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" Height="370px" Text="我要反馈" Width="600px" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Height="370px" Text="审批" Width="600px" OnClick="Button2_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" Height="370px" Text="我的反馈" Width="600px" />
        <asp:Button ID="Button4" runat="server" Height="370px" Text="所有反馈" Width="600px" OnClick="Button4_Click" />
        <br />
        <asp:Button ID="Button5" runat="server" Text="返回上一页面" OnClick="Button5_Click" />
    </form>
</body>
</html>
