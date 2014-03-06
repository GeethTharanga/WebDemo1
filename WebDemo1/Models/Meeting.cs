using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo1.Models
{
    public class Meeting
    {
        public int MeetingKey { get; set; }
        public string ConfName { get; set; }
        public string HostWebExID { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }


        public string Agenda { get; set; }
        public IEnumerable<string> Attendees { get; set; }
        public string Password { get; set; }
    }
}