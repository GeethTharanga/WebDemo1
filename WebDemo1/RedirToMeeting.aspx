<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedirToMeeting.aspx.cs" Inherits="WebDemo1.redirToMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="alert alert-warning" runat="server" ID="DivError" visible="true">
      <h3>Error occured</h3>
      <span runat="server" ID="spanError">Error getting the url</span>
    </div>

    <div class="alert alert-success" runat="server" ID="DivSucess" visible="false">
    <h3>Your sessions should start soon</h3>
    <span>Please wait</span>
    <iframe  runat="server" ID="IFrameWebex" sandbox="allow-scripts" ></iframe>
    </div>

    <section class="btn-group">
    <a href="Default.aspx" class="btn btn-success">View all Meetings</a>
    </section>

</asp:Content>
