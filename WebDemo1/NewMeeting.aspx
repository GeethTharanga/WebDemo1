<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMeeting.aspx.cs" Inherits="WebDemo1.NewMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>       New Meeting   </h3>

    <div class="alert alert-danger" runat="server" ID="DivError" visible="false">
      <strong>Error occured</strong> <br />
      <span runat="server" ID="spanError"></span>
    </div>

        <asp:ValidationSummary ID="NewValidationGroupSummary" runat="server" CssClass="failureNotification" 
            ValidationGroup="NewValidationGroup"/>

    <table class="table table-responsive">
        <tr>
            <th>
            <asp:Label ID="Label1" runat="server" Text="Topic"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtTopic" runat="server" CssClass="long-input" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="TopicRequired" runat="server" ControlToValidate="txtTopic" 
                        CssClass="failureNotification" ErrorMessage="Topic is required." 
                       ValidationGroup="NewValidationGroup"><span class="text-danger">Topic is required. </span></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label6" runat="server" Text="Password (Optional)" ></asp:Label>
            </th><td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="long-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label2" runat="server" Text="Date and Time"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtDateTime" runat="server" placeholder="YYYY-MM-DD  HH:MM:SS" CssClass="long-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            <asp:Label ID="Label3" runat="server" Text="Duration (minutes)"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtDuration" runat="server" ></asp:TextBox>
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
        <asp:Button ID="btnCreate" runat="server" Text="Create Meeting" 
            class="btn btn-primary" ValidationGroup="NewValidationGroup" 
            onclick="btnCreate_Click" />
        <a href="Default.aspx" class="btn btn-warning">Back</a>
    </div>
    

</asp:Content>
