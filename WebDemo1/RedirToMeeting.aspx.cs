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
    public partial class redirToMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyStr = Request.QueryString["key"];
            bool asHost = Request.QueryString["ashost"] != null;

            int key;

            if (keyStr != null && int.TryParse(keyStr, out key))
            {
                try
                {
                    string url = new WebExAdapter().GetUrlOfMeeting(asHost, key);

                    IFrameWebex.Attributes.Add("src", url);

                    DivError.Visible = false;
                    DivSucess.Visible = true;

                }
                catch (WebExException err)
                {
                    
                    spanError.InnerText = err.Message;
                }
            }

        }
    }
}