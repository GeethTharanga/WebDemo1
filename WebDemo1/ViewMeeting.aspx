<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMeeting.aspx.cs" Inherits="WebDemo1.ViewMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="alert alert-danger" runat="server" ID="DivError" visible="false">
      <strong>Error occured</strong><br />
      <span runat="server" ID="spanError">No key specified</span>
    </div>
    <div class="panel panel-info" runat="server" ID="DivInfo">
        <div class="panel-heading">
            <h3 class="panel-title">
                Meeting Details
            </h3>
        </div>
        <div class="panel-body">
            <div class="row">
            <section class="col-md-1"></section>
            <section class="col-md-4">
                <p>
                <span class="text-info">Meeting Key : </span><span runat="server" ID="spanMeetingKey"> </span>
                </p>

                <p>
                <span class="text-info">Conference Name : </span><span runat="server" ID="spanMeetingName"> </span>
                </p>

                <p>
                <span class="text-info">Host WebExID : </span> <span runat="server" ID="spanMeetingWebexID"> </span>
                </p>

                <p>
                <span class="text-info">Start Date : </span><span runat="server" ID="spanMeetingDate"> </span>
                </p>

                <p>
                <span class="text-info">Duration : </span><span runat="server" ID="spanMeetingDuration"> </span>
                </p>
                <p>
                <span class="text-info">Attendees : </span><span runat="server" ID="spanMeetingAttendees"> </span>
                </p>
            </section>
             <section class="col-md-4">
             <a href ="#" class="btn btn-primary" ID="hrefHost" runat="server"> Join as host</a>
             <br /><br />
             <a href ="#" class="btn btn-primary" ID="hrefGuest" runat="server"> Join as Guest</a>
             <br /><br />
             <a href = "CreateAttendee.aspx" class="btn btn-success" runat="server" ID ="hrefAttendee">Create an Attendee</a>
             </section>
            </div>
         </div>
    </div>
    <section>
    <a href="Default.aspx" class="btn btn-success">View all Meetings</a>
    <a href="Update.aspx" class="btn btn-success" runat="server" ID="HrefUpdate">Update meeting</a>
    </section>
</asp:Content>
