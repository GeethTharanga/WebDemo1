using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo1.Util;

namespace WebDemo1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //success message of create meeting
            if (Session["create_success"] != null)
            {
                DivSuccess.Visible = true;
                Session.Remove("create_success");
            }
            else
            {
                DivSuccess.Visible = false;
            }


            try
            {
                repMeeting.DataSource = new WebExAdapter().GetMeetingList();
                repMeeting.DataBind();
            }
            catch (WebExException ex)
            {
                DivError.Visible = true;
                spanError.InnerText = ex.Message;
                DivResults.Visible = false;
            }
        }
    }
}
