using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MarkTheWorld.Context
{
    public class UserContext : DbContext
    {
        public DbSet<MarkTheWorld.Models.User> Users { get; set; }
    }
}