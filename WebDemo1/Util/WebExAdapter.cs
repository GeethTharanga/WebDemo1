using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo1.Models;
using System.Xml.Linq;
using System.Globalization;

namespace WebDemo1.Util
{
    [Serializable]
    public class WebExException : Exception
    {
        public WebExErrorDetails WebExError { get; set; }

        public WebExException(WebExErrorDetails err) : base(err.Reason) { WebExError = err; }
        public WebExException(WebExErrorDetails err, Exception inner) : base(err.Reason, inner) { WebExError = err; }
        protected WebExException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class WebExErrorDetails
    {
        public int ExceptionID { get; set; }
        public string Reason { get; set; }
    }

    public class WebExAdapter
    {
        const string strBodyContent = "bodyContent";
        const string dateFormat = "MM/dd/yyyy HH:mm:ss";

        const string strReqMeelingList = "java:com.webex.service.binding.meeting.LstsummaryMeeting";

        const string strNamespaceServ = "http://www.webex.com/schemas/2002/06/service", strNamespaceMeet = "http://www.webex.com/schemas/2002/06/service/meeting";


        private WebExErrorDetails GetErrorDetails(XDocument xdoc)
        {
            XNamespace nsServ = strNamespaceServ;

            XElement respNode = xdoc.Element(nsServ + "response");

            if (respNode.Element(nsServ + "result").Value != "FAILURE")
            {
                return null;
            }
            else
            {
                var error = new WebExErrorDetails {  ExceptionID = int.Parse(respNode.Element(nsServ + "exceptionID").Value),
                                              Reason = respNode.Element(nsServ + "reason").Value };

                return error;
            }

        }


        public IEnumerable<MeetingSummary> GetMeetingList()
        {
            var bodyContentElem = new XElement(strBodyContent);

            string xml = XMLUtil.GetFullXML(bodyContentElem, strReqMeelingList);

            string result = new RequestManager().GetResponse(xml);

            System.IO.File.WriteAllText("C:/ztmp/aa.xml", result);


            XDocument doc = XDocument.Parse(result);

            WebExErrorDetails err = GetErrorDetails(doc);

            if (err != null)
            {
                throw new WebExException(err);
            }

            XNamespace nsMeet = strNamespaceMeet;
            var nodes = doc.Descendants(nsMeet + "meeting").Select(elem => new MeetingSummary
                                    {
                                        ConfName = elem.Element(nsMeet + "confName").Value,
                                        HostWebExID = elem.Element(nsMeet + "hostWebExID").Value,
                                        MeetingKey = int.Parse(elem.Element(nsMeet + "meetingKey").Value),
                                        StartDate = DateTime.ParseExact(elem.Element(nsMeet + "startDate").Value, dateFormat, CultureInfo.InvariantCulture),
                                        Duration = int.Parse(elem.Element(nsMeet + "duration").Value)
                                    }).ToList();
                        return nodes;
        }
    }
}