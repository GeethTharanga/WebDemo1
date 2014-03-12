using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo1.Util;
using WebDemo1.Models;

namespace WebDemo1
{
    public partial class ViewMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyStr = Request.QueryString["key"];
            int key = 0;
            if (string.IsNullOrWhiteSpace(keyStr) || !int.TryParse(keyStr, out key))
            {
                DivError.Visible = true;
                DivInfo.Visible = false;
            }
            else
            {
                HrefUpdate.HRef = "Update.aspx?key=" + key;
                try
                {
                    Meeting meet = new WebExAdapter().GetMeeting(key);
                    
                    spanMeetingName.InnerText = meet.ConfName;
                    spanMeetingKey.InnerText = meet.MeetingKey.ToString();
                    spanMeetingDate.InnerText = meet.StartDate.ToString();
                    spanMeetingWebexID.InnerHtml = meet.HostWebExID;
                    spanMeetingDuration.InnerText = meet.Duration.ToString() + " minutes";
                    spanMeetingAttendees.InnerText = string.Join(", ", meet.Attendees);

                    hrefGuest.HRef = "RedirToMeeting.aspx?key=" + meet.MeetingKey;
                    hrefHost.HRef = "RedirToMeeting.aspx?ashost=true&key=" + meet.MeetingKey;
                    hrefAttendee.HRef = "CreateAttendee.aspx?key=" + meet.MeetingKey;
                    
                }
                catch (WebExException err)
                {
                    DivError.Visible = true;
                    DivInfo.Visible = false;
                    spanError.InnerText = err.Message;
                }
            }
        }
    }
}