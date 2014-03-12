using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo1.Models;
using WebDemo1.Util;

namespace WebDemo1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string keyStr = Request.QueryString["key"];
            int key = 0;
            if (string.IsNullOrWhiteSpace(keyStr) || !int.TryParse(keyStr, out key))
            {
                DivError.Visible = true;
            }
            else
            {
                try
                {
                    Meeting meet = new WebExAdapter().GetMeeting(key);

                    txtMeetingKey.Text = meet.MeetingKey.ToString();
                    txtTopic.Text = meet.ConfName;
                    txtPassword.Text = meet.Password;
                    txtDateTime.Text = meet.StartDate.ToString();
                    txtDuration.Text = meet.Duration.ToString();
                    txtAttendees.Text = string.Join(", ", meet.Attendees);
                    txtAgenda.Text = meet.Agenda;

                }
                catch (WebExException err)
                {
                    DivError.Visible = true;
                    spanError.InnerText = err.Message;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Meeting meet = new Meeting();

            meet.Agenda = txtAgenda.Text;
            meet.Attendees = txtAttendees.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToList();
            meet.ConfName = txtTopic.Text;
            meet.Duration = int.Parse(txtDuration.Text);
            meet.Password = txtPassword.Text;
            meet.StartDate = DateTime.Parse(txtDateTime.Text);
            meet.MeetingKey = int.Parse(txtMeetingKey.Text);

            try
            {
                bool success = new WebExAdapter().UpdateMeeting(meet);
                //Session["create_success"] = true;
                Response.Redirect("ViewMeeting.aspx?key="+txtMeetingKey.Text );
            }
            catch (WebExException wex)
            {
                DivError.Visible = true;
                spanError.InnerText = wex.Message;
            }
        }
    }
}