<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCities.aspx.cs" Inherits="CandCWeb.UI.ViewCities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="View Cities"></asp:Label><br/>
        <legend><b>Search Criteria</b></legend><br/>
        <asp:RadioButton ID="cityRadioButton" runat="server" Text="City Name: " GroupName="Search" />
         <asp:TextBox ID="viewCityNameTextBox" runat="server"></asp:TextBox><br />
         <br />
         <asp:RadioButton ID="countryRadioButton" runat="server" Text="Country: " GroupName="Search" />
         <asp:DropDownList ID="viewCountryDropDownList" runat="server" Height="22px" Width="154px">
             
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
         <br />
         <br />
         <asp:GridView ID="viewCitiesGridView" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField DataField="Serial" HeaderText="Serial No" SortExpression="Serial" />
                 <asp:BoundField DataField="Name" HeaderText="City Name" SortExpression="Name" />
                 <asp:BoundField DataField="About" HeaderText="About" SortExpression="About" />
                 <asp:BoundField DataField="Dwellers" HeaderText="No of Dwellers" SortExpression="Dwellers" />
                 <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                 <asp:BoundField DataField="Weather" HeaderText="Weather" SortExpression="Weather" />
                 <asp:BoundField DataField="ACountry.countryName" HeaderText="Country" SortExpression="ACountry.countryName" />
                 <asp:BoundField DataField="ACountry.aboutCountry" HeaderText="About Country" SortExpression="ACountry.aboutCountry" />
             </Columns>
        </asp:GridView>
         <br />

    </div>
        
    </form>
</body>
</html>
