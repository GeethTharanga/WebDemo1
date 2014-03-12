using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace WebDemo1.Util
{
    public class XMLUtil
    {

        public static string GetFullXML(XElement bodyContent,string requestType)
        {
            //XNamespace nsServ = "http://www.webex.com/schemas/2002/06/service", nsXsi = "http://www.w3.org/2001/XMLSchema-instance";
            //bodyContent = new XElement(bodyContent);
            //bodyContent.Add(new XAttribute(nsXsi + "type", requestType));
            //bodyContent.Name = "bodyContent";

            //XElement bodyElem = new XElement("body", bodyContent);

            //XElement headerElem = new XElement("header",
            //                          new XElement("securityContext",
            //                                    new XElement("webExID", RequestManager.WebExHostID),
            //                                    new XElement("password", RequestManager.WebExHostPwd),
            //                                    new XElement("siteID", RequestManager.SiteID),
            //                                    new XElement("partnerID", RequestManager.PartnerID),
            //                                    new XElement("email", RequestManager.WebExEmail)
            //                                    )
            //                                   );

            //XElement fullXml = new XElement(nsServ + "message", new XAttribute(XNamespace.Xmlns + "xsi", nsXsi),
            //                                                   new XAttribute(XNamespace.Xmlns + "serv", nsServ), 
                                                               
            //                                                   headerElem, bodyElem);



            string path = "~/Resources/XMLFile.xml";

            var doc = XDocument.Load(HttpContext.Current.Server.MapPath(path));

            XNamespace nsXsi = "http://www.w3.org/2001/XMLSchema-instance";

            var WebExID = doc.Descendants("webExID").First();

            WebExID.Add(RequestManager.WebExHostID);


            var password = doc.Descendants("password").First();

            password.Add(RequestManager.WebExHostPwd);


            var siteID = doc.Descendants("siteID").First();

            siteID.Add(RequestManager.SiteID);


            var partnerID = doc.Descendants("partnerID").First();

            partnerID.Add(RequestManager.PartnerID);


            var email = doc.Descendants("email").First();

            email.Add(RequestManager.WebExEmail);


            var bodyElem = doc.Descendants("body").First();

            bodyElem.Add(bodyContent);


            bodyContent.Add(new XAttribute(nsXsi + "type", requestType));

            return doc.ToString();
        }
    }
}