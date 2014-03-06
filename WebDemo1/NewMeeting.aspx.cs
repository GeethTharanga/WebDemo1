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
    public partial class NewMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Meeting meet = new Meeting();

            meet.Agenda = txtAgenda.Text;
            meet.Attendees = txtAttendees.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToList() ;
            meet.ConfName = txtTopic.Text;
            meet.Duration = int.Parse(txtDuration.Text);
            meet.Password = txtPassword.Text;
            meet.StartDate = DateTime.Parse(txtDateTime.Text);

            try
            {
                int meetKey = new WebExAdapter().CreateMeeting(meet);
                Session["create_success"] = true;
                Response.Redirect("Default.aspx");
            }
            catch (WebExException wex)
            {
                DivError.Visible = true;
                spanError.InnerText = wex.Message;
            }
        }
    }
}