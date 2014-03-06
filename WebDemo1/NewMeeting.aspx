<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMeeting.aspx.cs" Inherits="WebDemo1.NewMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>       New Meeting   </h2>

    <div class="alert alert-warning" runat="server" ID="DivError" visible="false">
      <h3>Error occured</h3>
      <span runat="server" ID="spanError"></span>
    </div>

    <table class="table table-responsive ">
        <tr>
            <th>
            <asp:Label ID="Label1" runat="server" Text="Topic"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtTopic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label2" runat="server" Text="Date and Time"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtDateTime" runat="server" placeholder="format: YYYY-MM-DD  HH:MM:SS"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label3" runat="server" Text="Duration (minutes)"></asp:Label>
            </th><td>
            <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
            </td>
        </tr>
         <tr>
            <th>
            <asp:Label ID="Label4" runat="server" Text="Attendees"></asp:Label>
            </th><td>
            <asp:TextBox ID="TextBox1" runat="server" 
                     placeholder="Email addresses seperated by commas" Height="45px" Rows="3" 
                     TextMode="MultiLine" Width="218px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnCreate" runat="server" Text="Create Meeting" class="btn btn-primary" />
        <a href="Default.aspx" class="btn btn-warning">Back</a>
    </div>
    

</asp:Content>
