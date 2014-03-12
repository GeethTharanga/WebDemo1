<%@ Page Title="WebEx Demo-Update Meeting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Update.aspx.cs" Inherits="WebDemo1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Update meeting
    </h3>

    <div class="alert alert-danger" runat="server" ID="DivError" visible="false">
      <strong>Error occured</strong> <br />
      <span runat="server" ID="spanError"></span>
    </div>

    <table class="table table-responsive" rules="none">
        <tr>
            <th>
            <asp:Label ID="Label0" runat="server" Text="Meeting Key"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtMeetingKey" runat="server" disabled="disabled" width="218px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
            <asp:Label ID="Label1" runat="server" Text="Topic"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtTopic" runat="server" CssClass="long-input" width= "218px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label6" runat="server" Text="Password (Optional)" ></asp:Label>
            </th><td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="long-input" width="218px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label2" runat="server" Text="Date and Time"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtDateTime" runat="server" placeholder="YYYY-MM-DD  HH:MM:SS" CssClass="long-input" width="218px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label3" runat="server" Text="Duration (minutes)"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtDuration" runat="server" width="218px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <th>
            <asp:Label ID="Label4" runat="server" Text="Attendees"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtAttendees" runat="server" 
                     placeholder="Email addresses seperated by commas" Height="45px" Rows="3" 
                     TextMode="MultiLine" Width="218px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label5" runat="server" Text="Agenda"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtAgenda" runat="server" 
                      Height="45px" Rows="3" 
                     TextMode="MultiLine" Width="218px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Meeting" 
            class="btn btn-primary" 
            onclick="btnUpdate_Click" />
        <a href="Default.aspx" class="btn btn-warning">Cancel</a>
    </div>
    

</asp:Content>
