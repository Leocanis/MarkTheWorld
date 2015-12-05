using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkTheWorld.Models
{
    public class DotUser
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int dotID { get; set; }
        public bool isFirst { get; set; }
        public string desc { get; set; }
    }
}