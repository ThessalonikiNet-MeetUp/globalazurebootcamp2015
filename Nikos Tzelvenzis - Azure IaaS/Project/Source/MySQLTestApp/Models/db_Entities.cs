using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySQLTestApp.Models
{
    public partial class db_Entities : DbContext
    {
        public db_Entities() : base(nameOrConnectionString: "IaaSDemoPrivate") {
         
        }

        public db_Entities(string conn)
            : base(nameOrConnectionString: conn)
        {

        }

        public DbSet<Customer> Customer { get; set; }
    }
}