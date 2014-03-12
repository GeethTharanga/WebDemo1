<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAttendee.aspx.cs" Inherits="WebDemo1.CreateAttendee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>
        Create an attendee
    </h3>

     <div class="alert alert-danger" runat="server" ID="DivError" visible="false">
      <strong>Error occured</strong> <br />
      <span runat="server" ID="spanError"></span>
    </div>

    <table class="table table-responsive" rules="none">
        <tr>
            <th>
            <asp:Label ID="Label0" runat="server" Text="Name"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtName" runat="server" width="218px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
            <asp:Label ID="Label1" runat="server" Text="email"></asp:Label>
            </th><td>
            <asp:TextBox ID="txtEmail" runat="server" width= "218px" ></asp:TextBox>
            </td>
        </tr>
        
    </table>
    <div>
        <asp:Button ID="btnAttendee" runat="server" Text="Create" 
            class="btn btn-primary" 
            onclick="btnAttendee_Click" />
        <a href="ViewMeeting.aspx" class="btn btn-warning">Cancel</a>
    </div>
    
</asp:Content>

