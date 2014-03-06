using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

namespace WebDemo1.Util
{
    public class RequestManager
    {
        #region configs
        public static string ApiUrl
        {
            get
            {
                return "https://apidemoeu.webex.com/WBXService/XMLService";
            }
        }

        public static string PartnerID
        {
            get {
                return "g0webx!";
            }
        }

        public static int SiteID
        {
            get
            {
                return 690319;
            }
        }
        public static string SiteUrl
        {
            get
            {
                return "https://apidemoeu.webex.com";
            }
        }
        public static string WebExHostID
        {
            get
            {
                return "GeethHost";
            }
        }
        public static string WebExHostPwd
        {
            get
            {
                return "KingPin3";
            }
        }
        public static string WebExEmail
        {
            get
            {
                return "geetht@irononetech.com";
            }
        }
        #endregion configs


        public string GetResponse(string xmlRequest)
        {
            WebRequest request = WebRequest.Create(ApiUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var xmlBytes = Encoding.UTF8.GetBytes(xmlRequest);

            request.ContentLength = xmlBytes.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(xmlBytes, 0, xmlBytes.Length);
            // Close the Stream object.
            dataStream.Close();

            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Clean up the streams.
                    reader.Close();

                    return responseFromServer;
                }
            }

        }
    }
}