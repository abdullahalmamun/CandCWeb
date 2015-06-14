<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountryEntry.aspx.cs" Inherits="CandCWeb.UI.CountryEntry1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox><br />
   
        <asp:Label ID="Label2" runat="server" Text="About"></asp:Label>
        <asp:TextBox ID="aboutTextBox" runat="server"></asp:TextBox>
        <br />
        <p>
            <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label> <br />
            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
            <asp:Button ID="cancelButton" runat="server" Text="Cancel" />
            
        </p>
        <p>
            <asp:GridView ID="countryGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="serial" HeaderText="Serial No" SortExpression="serial" />
                    <asp:BoundField DataField="countryName" HeaderText="Country Name" SortExpression="countryName" />
                    <asp:BoundField DataField="aboutCountry" HeaderText="About" SortExpression="aboutCountry" />
                </Columns>
            </asp:GridView>
            
        </p>
        <p>
            &nbsp;</p>
    </div>
    </form>
</body>
</html>
