using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTestApp.Models
{

    public class Status
    {
        [Key]
        public string ComputerName { get; set; }
        public DateTime LocalTime { get; set; }
        public int CPUThreasCount { get; set; }
        public long MemoryTotal { get; set; }
        public long MemoryFree { get; set; }
        public int Processes { get; set; }
        
    }
}
