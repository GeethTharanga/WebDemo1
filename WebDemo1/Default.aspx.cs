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
            repMeeting.DataSource = new WebExAdapter().GetMeetingList();
            repMeeting.DataBind();
        }
    }
}
