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

        const string strReqMeetingList = "java:com.webex.service.binding.meeting.LstsummaryMeeting";
        const string strReqMeeting = "java:com.webex.service.binding.meeting.GetMeeting";
        const string strReqHostUrl = "java:com.webex.service.binding.meeting.GethosturlMeeting";
        const string strReqJoinUrl = "java:com.webex.service.binding.meeting.GetjoinurlMeeting";
        const string strReqCreateMeeting = "java:com.webex.service.binding.meeting.CreateMeeting";

        const string strNamespaceServ = "http://www.webex.com/schemas/2002/06/service", 
            strNamespaceMeet = "http://www.webex.com/schemas/2002/06/service/meeting",
            strNamespaceCom = "http://www.webex.com/schemas/2002/06/common",
            strNamespaceAtt ="http://www.webex.com/schemas/2002/06/service/attendee";

        /// <summary>
        /// Check if the request is valid
        /// </summary>
        /// <param name="xdoc"></param>
        /// <returns>Error if request failed, null on successful request</returns>
        private WebExErrorDetails GetErrorDetails(XDocument xdoc)
        {
            XNamespace nsServ = strNamespaceServ;

            XElement respNode = xdoc.Descendants(nsServ + "response").FirstOrDefault();

            if (respNode != null && respNode.Element(nsServ + "result").Value != "FAILURE")
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

        /// <summary>
        /// Get the complete list of meetings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeetingSummary> GetMeetingList()
        {
            var bodyContentElem = new XElement(strBodyContent);
            string xml = XMLUtil.GetFullXML(bodyContentElem, strReqMeetingList);
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


        /// <summary>
        /// Get a meeting by ID
        /// </summary>
        /// <param name="meetingKey"></param>
        /// <returns></returns>
        public Meeting GetMeeting(int meetingKey)
        {
            var bodyContentElem = new XElement(strBodyContent, new XElement("meetingKey",meetingKey));
            string xml = XMLUtil.GetFullXML(bodyContentElem, strReqMeeting);
            string result = new RequestManager().GetResponse(xml);
            System.IO.File.WriteAllText("C:/ztmp/aa2.xml", result);

            XDocument doc = XDocument.Parse(result);
            WebExErrorDetails err = GetErrorDetails(doc);
            if (err != null)
            {
                throw new WebExException(err);
            }
            XNamespace nsMeet = strNamespaceMeet, nsAtt = strNamespaceAtt;
            XNamespace nsServ = strNamespaceServ, nsCom = strNamespaceCom;
            Meeting meet = new Meeting();

            XElement elemContent = doc.Descendants(nsServ + "bodyContent").FirstOrDefault();

            meet.ConfName = elemContent.Element(nsMeet + "metaData").Element(nsMeet + "confName").Value;
            meet.MeetingKey = int.Parse(elemContent.Element(nsMeet + "meetingkey").Value);
            meet.HostWebExID = elemContent.Element(nsMeet + "schedule").Element(nsMeet + "hostWebExID").Value;
            meet.StartDate = DateTime.ParseExact(elemContent.Element(nsMeet + "schedule").Element(nsMeet + "startDate").Value
                                                     ,dateFormat,CultureInfo.InvariantCulture)   ;
            meet.Duration = int.Parse(elemContent.Element(nsMeet + "schedule").Element(nsMeet + "duration").Value);

            meet.Attendees = elemContent.Element(nsMeet + "participants").Element(nsMeet + "attendees")
                                        .Elements(nsMeet + "attendee")
                                        .Select(attendeeElem => attendeeElem.Element(nsAtt + "person")
                                                .Element(nsCom + "email").Value)
                                         .ToList();
            return meet;

        }

        public string GetUrlOfMeeting(bool joinAsHost,int meetingKey)
        {
            var bodyContentElem = new XElement(strBodyContent, new XElement("meetingKey", meetingKey));
            string xml = XMLUtil.GetFullXML(bodyContentElem, joinAsHost ? strReqHostUrl : strReqJoinUrl);
            string result = new RequestManager().GetResponse(xml);
            System.IO.File.WriteAllText("C:/ztmp/aa2.xml", result);

            XDocument doc = XDocument.Parse(result);
            WebExErrorDetails err = GetErrorDetails(doc);
            if (err != null)
            {
                throw new WebExException(err);
            }
            XNamespace nsMeet = strNamespaceMeet;
            XNamespace nsServ = strNamespaceServ;

            XElement elemContent = doc.Descendants(nsServ + "bodyContent").FirstOrDefault();

            string nodeName = joinAsHost ? "hostMeetingURL" :"joinMeetingURL";

            string url = elemContent.Element(nsMeet + nodeName).Value;

            return url;

        }

        /// <summary>
        /// Create a meeting
        /// </summary>
        /// <param name="meet"></param>
        /// <returns>Meeting key</returns>
        public int CreateMeeting(Meeting meet)
        {

            XElement elemAccessControl = new XElement("accessControl", new XElement("meetingPassword", meet.Password));
            XElement elemMetaData = new XElement("metaData", new XElement("confName", meet.ConfName)
                                                           , new XElement("agenda", meet.Agenda));
            XElement elemParticipant = new XElement("participants",
                                            new XElement("attendees",
                                                meet.Attendees.Select(em => new XElement("attendee", new XElement("person",
                                                                                                        new XElement("email", em)
                                                                                                                )
                                                                                        )
                                                                    )
                                                        )
                                                    );

            XElement elemEnableOption = new XElement("enableOptions", new[] { "chat", "poll", "audioVideo" }.Select(e => new XElement(e, "true")));
            XElement elemSchedule = new XElement("schedule",
                                           new XElement("startDate", meet.StartDate.ToString(dateFormat,CultureInfo.InvariantCulture)),
                                           new XElement("duration", meet.Duration)
                                           );


            var bodyContentElem = new XElement(strBodyContent,elemAccessControl,elemMetaData,elemParticipant,elemEnableOption,elemSchedule);

            string xml = XMLUtil.GetFullXML(bodyContentElem,strReqCreateMeeting);
            System.IO.File.WriteAllText("C:/ztmp/req3.xml", xml);
            string result = new RequestManager().GetResponse(xml);
            System.IO.File.WriteAllText("C:/ztmp/aa3.xml", result);

            XDocument doc = XDocument.Parse(result);
            WebExErrorDetails err = GetErrorDetails(doc);
            if (err != null)
            {
                throw new WebExException(err);
            }
            XNamespace nsMeet = strNamespaceMeet;
            XNamespace nsServ = strNamespaceServ;

            XElement elemContent = doc.Descendants(nsServ + "bodyContent").FirstOrDefault();

            int meetingID = int.Parse(elemContent.Element(nsMeet + "meetingkey").Value);

            return meetingID;

        }
    }
}