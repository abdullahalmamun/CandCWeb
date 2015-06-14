<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityEntry.aspx.cs" Inherits="CandCWeb.UI.CityEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="City Entry"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="cityNameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="About"></asp:Label>
        <asp:TextBox ID="cityAboutTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="No.of dwellers"></asp:Label>
        <asp:TextBox ID="dwellersTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="locationTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Weather"></asp:Label>
        <asp:TextBox ID="weatherTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Country"></asp:Label>
        <asp:DropDownList ID="countryDropDownList" runat="server">
            
        </asp:DropDownList>
        <br />
        <asp:Label ID="cityMagLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="saveCityButton" runat="server" Text="Save" OnClick="saveCityButton_Click" />
        <asp:Button ID="cancelCityButton" runat="server" Text="Cancel" />
    
        <br />
        <asp:GridView ID="cityGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="serial" HeaderText="Serial No" SortExpression="serial" />
                <asp:BoundField DataField="Name" HeaderText="City Name" SortExpression="Name" />
                <asp:BoundField DataField="Dwellers" HeaderText="No of Dwellers" SortExpression="Dwellers" />
                <asp:BoundField DataField="ACountry.countryName" HeaderText="Country" SortExpression="ACountry.countryName" />
                <asp:BoundField DataField="ACountry.aboutCountry" HeaderText="About" SortExpression="ACountry.aboutCountry" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
