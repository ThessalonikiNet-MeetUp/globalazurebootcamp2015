using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySQLTestApp.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("id_customer")]
        public int id { get; set; }

        public string customer { get; set; }

        public string address { get; set; }
        [Column("total_revenue")]
        public decimal TotalRevenue { get; set; }
    }
}