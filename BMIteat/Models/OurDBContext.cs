using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BMIteat.Models
{
    public class OurDBContext : DbContext 
    {
        public DbSet<UserBMI> userBMI { get; set; }
    }


}