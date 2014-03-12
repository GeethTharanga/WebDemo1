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
    public partial class CreateAttendee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyStr = Request.QueryString["key"];
            int key = 0;
            if (string.IsNullOrWhiteSpace(keyStr) || !int.TryParse(keyStr, out key))
            {
                DivError.Visible = true;
            }
            else { 
                try
                {
                    Meeting meet = new WebExAdapter().GetMeeting(key);
            }
                 catch (WebExException err)
                {
                    DivError.Visible = true;
                    spanError.InnerText = err.Message;
                }
         }
        }

        protected void btnAttendee_Click(object sender, EventArgs e)
        {

            string name = null;
            string email = null;
            string meet = null;

            if (Request.QueryString["key"] != null) {
                meet = Request.QueryString["key"];
            } 

            name = txtName.Text;
            email = txtEmail.Text;

            try
            {
                bool success = new WebExAdapter().CreateAttendee(name, email,meet);
               // Response.Redirect("ViewMeeting.aspx?key=" + txtMeetingKey.Text);
            }
            catch(WebExException wex) { 
                 DivError.Visible = true;
                spanError.InnerText = wex.Message;
            }
            }
        }
    
}