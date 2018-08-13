<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="problem_feedback.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="PASSWORD:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="NAME:"></asp:Label>
    
        <asp:TextBox ID="TextBox3" runat="server" Height="23px"></asp:TextBox>
    
        <br />

        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="17px">
            <asp:ListItem Text="请选择部门" Value="请选择部门">
         </asp:ListItem>
        </asp:DropDownList>

        <br />
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" />
    
    </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button2" runat="server" Height="20px" Text="返回登录界面" Width="180px" OnClick="Button2_Click" />

        <br />
    </form>
</body>
</html>
