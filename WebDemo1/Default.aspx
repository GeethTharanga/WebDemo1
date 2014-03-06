<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebDemo1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Meeting List
    </h2>

    <div class="alert alert-warning" runat="server" ID="DivError" visible="false">
      <h3>Error occured</h3>
      <span runat="server" ID="spanError">No key specified</span>
    </div>

    <div class="alert alert-success" runat="server" ID="DivSuccess" visible="false">
      <h3>Success</h3>
      <span runat="server" ID="spanSuccess">Meeting Created successfully</span>
    </div>

    <div runat="server" ID="DivResults">
        <table class="table table-striped">
            <thead>
            <tr>
            <th>Meeting Key</th>
            <th>Conference Name</th>
            <th>Host WebExID</th>
            <th>Start Date</th>
            <th>Duration</th>
            <th></th>
             </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="repMeeting" runat="server">
                <ItemTemplate>
                        <tr>
                            <td><%# Eval("MeetingKey")%></td>
                            <td><%# Eval("ConfName")%></td>
                            <td><%# Eval("HostWebExID")%></td>
                            <td><%# Eval("StartDate")%></td>
                            <td><%# Eval("Duration")%> mins</td>
                            <td><a href="ViewMeeting.aspx?key=<%# Eval("MeetingKey")%>" class="btn btn-sm btn-info">View Meeting</a> </td>
                        </tr>                        
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
    </div>
    <p>
    <a href="NewMeeting.aspx" class="btn btn-success">Create Meeting</a>
    </p>
</asp:Content>
