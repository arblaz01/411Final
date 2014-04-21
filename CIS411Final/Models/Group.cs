using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS411Final.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingTime { get; set; }
        public string Location { get; set; }
        public virtual ICollection<ApplicationUser> Students { get; set; }
        public Group()
        {
            Students = new HashSet<ApplicationUser>();
        }
    }
}