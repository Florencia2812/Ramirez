using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIRamirez.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIRamirez.Models.APIramirez> APIramirezs { get; set; }
    }
}