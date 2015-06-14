<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCountries.aspx.cs" Inherits="CandCWeb.UI.ViewCountries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="View Countries"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
&nbsp;<asp:TextBox ID="countryNameTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <br />
        <br />
        <asp:GridView ID="countryGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MyCountry.serial" HeaderText="Serial No" SortExpression="MyCountry.serial" />
                <asp:BoundField DataField="MyCountry.countryName" HeaderText="Country Name" />
                <asp:BoundField DataField="MyCountry.aboutCountry" HeaderText="About" SortExpression="MyCountry.aboutCountry" />
                <asp:BoundField DataField="CityCount" HeaderText="City Count" SortExpression="CityCount" />
                <asp:BoundField DataField="TotalDwellers" HeaderText="No of Dwellers" SortExpression="TotalDwellers" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
