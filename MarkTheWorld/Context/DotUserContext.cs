using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarkTheWorld.Context
{
    public class DotUserContext : DbContext
    {
        public System.Data.Entity.DbSet<MarkTheWorld.Models.DotUser> DotUsers { get; set; }
    }
}