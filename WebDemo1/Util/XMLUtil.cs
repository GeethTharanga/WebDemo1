using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebDemo1.Util
{
    public class XMLUtil
    {

        public static string GetFullXML(XElement bodyContent,string requestType)
        {
            XNamespace nsServ = "http://www.webex.com/schemas/2002/06/service", nsXsi = "http://www.w3.org/2001/XMLSchema-instance";
            bodyContent = new XElement(bodyContent);
            bodyContent.Add(new XAttribute(nsXsi + "type", requestType));
            bodyContent.Name = "bodyContent";

            XElement bodyElem = new XElement("body", bodyContent);

            XElement headerElem = new XElement("header",
                                      new XElement("securityContext",
                                                new XElement("webExID", RequestManager.WebExHostID),
                                                new XElement("password", RequestManager.WebExHostPwd),
                                                new XElement("siteID", RequestManager.SiteID),
                                                new XElement("partnerID", RequestManager.PartnerID),
                                                new XElement("email", RequestManager.WebExEmail)
                                                )
                                               );

            XElement fullXml = new XElement(nsServ + "message", new XAttribute(XNamespace.Xmlns + "xsi", nsXsi),
                                                               new XAttribute(XNamespace.Xmlns + "serv", nsServ), 
                                                               
                                                               headerElem, bodyElem);
            return fullXml.ToString();
        }
    }
}