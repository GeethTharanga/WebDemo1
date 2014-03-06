using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo1.Models
{
    public class MeetingSummary
    {
        public int MeetingKey { get; set; }
        public string ConfName { get; set; }
        public string HostWebExID { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
    }
}