<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebDemo1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Meeting List
    </h2>
    <table>
        <thead>
        <tr>
        <th>Meeting Key</th>
        <th>Conference Name</th>
        <th>Host WebExID</th>
        <th>Start Date</th>
        <th>Duration</th>
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
                    </tr>                        
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
    </table>

</asp:Content>
