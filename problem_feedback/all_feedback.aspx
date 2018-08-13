<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="all_feedback.aspx.cs" Inherits="problem_feedback.ALL_FEEDBACK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="140px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        <asp:ListItem Text="请选择部门" Value="*"></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="140px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
           <asp:ListItem Text="请选择问题类型" Value="*"></asp:ListItem>
            </asp:DropDownList>
        &nbsp;
       &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList4" runat="server" Height="25px" Width="140px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" >
          <asp:ListItem Text="请选择问题紧急程度" Value="*"></asp:ListItem>
            </asp:DropDownList>
             &nbsp;
        &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" >
                  <asp:ListItem Text="请选择问题完成度" Value="*"></asp:ListItem>
            </asp:DropDownList>
        
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-bottom: 0px" Text="查询" />
      
&nbsp;<br />
    
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="选择起始时间" />
    
        <asp:Label ID="Label2" runat="server" Text="0/0/0"></asp:Label>
    
        <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged"></asp:Calendar>
        <asp:Button ID="Button4" runat="server" Text="选择终止时间" OnClick="Button4_Click" />
        <asp:Label ID="Label1" runat="server" Text="0/0/0"></asp:Label>
        <asp:Calendar ID="Calendar4" runat="server" OnSelectionChanged="Calendar4_SelectionChanged"></asp:Calendar>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    &nbsp;<asp:GridView ID="GridView1" runat="server"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
        </asp:GridView>
    
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
    
        <br />
       
    
       
    
    </div>
    </form>
</body>
</html>
