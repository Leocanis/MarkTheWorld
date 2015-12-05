using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarkTheWorld.Context
{
    public class DotContext : DbContext
    {
        public System.Data.Entity.DbSet<MarkTheWorld.Models.Dot> Dots { get; set; }
    }
}