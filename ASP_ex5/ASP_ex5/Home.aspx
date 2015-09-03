<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASP_ex5.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownListWithRESX" runat="server" AutoPostBack="True" ValidationGroup="g1">
        </asp:DropDownList>
    
        
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListWithRESX" ErrorMessage="Has not any files" ForeColor="Red">Has not any files</asp:RequiredFieldValidator>
    
        
    
    </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" Height="160px" Width="661px" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="key" SortExpression="key">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("key") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("key") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                            <asp:TextBox ID="TextBoxInsertedKey" Text="Default" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorInsertKey" runat="server" ErrorMessage = "Record key should not be empty" 
                            ControlToValidate = "TextBoxInsertedKey" Text="*" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="value" SortExpression="value">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("value") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("value") %>'></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                            <asp:TextBox ID="TextBoxInsertedValue" Text="Default" runat="server"></asp:TextBox>                        
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="comment" SortExpression="comment">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("comment") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("comment") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                            <asp:TextBox ID="TextBoxInsertedComment" Text="Default" runat="server"></asp:TextBox>                        
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Обновить"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Отмена"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Правка"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Удалить"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                            <asp:Button ID="ButtonAdd" Text="Add New Field" runat="server" OnClick = "ButtonAdd_Click" ></asp:Button>                        
                     </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" ConflictDetection="CompareAllValues" DeleteMethod="DeleteEmployee" InsertMethod="InsertEmployee" SelectMethod="GetEmployees" TypeName="ASP_ex5.ResourceObj" UpdateMethod="UpdateEmployee" OnDeleting="ObjectDataSource1_Deleting" OnInserting="ObjectDataSource1_Inserting" OnUpdating="ObjectDataSource1_Updating">
            <DeleteParameters>
                <asp:Parameter Name="key" Type="String" />
                <asp:Parameter Name="value" Type="String" />
                <asp:Parameter Name="comment" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="key" Type="String" />
                <asp:Parameter Name="value" Type="String" />
                <asp:Parameter Name="comment" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListWithRESX" Name="f" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="key" Type="String" />
                <asp:Parameter Name="value" Type="String" />
                <asp:Parameter Name="comment" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
