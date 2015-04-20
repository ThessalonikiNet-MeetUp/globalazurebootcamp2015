using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHealthAgent.Models
{
    public class Status
    {
        public string ComputerName { get; set; }
        public DateTime LocalTime { get; set; }
        public int CPUThreasCount { get; set; }
        public long MemoryTotal { get; set; }
        public long MemoryFree { get; set; }
        public int Processes { get; set; }
        
    }
}
