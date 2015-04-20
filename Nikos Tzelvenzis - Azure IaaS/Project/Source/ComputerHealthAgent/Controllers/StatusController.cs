using ComputerHealthAgent.Models;
using ComputerHealthAgent.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComputerHealthAgent.Controllers
{
    public class StatusController : ApiController
    {
        // GET api/values 
        public Status Get()
        {
            return new Status()
            {
                ComputerName = OSMetric.GetHostname(),
                CPUThreasCount = OSMetric.GetProcessorCount(),
                LocalTime = DateTime.Now,
                Processes = OSMetric.GetSystemProcesses(),
                MemoryFree = OSMetric.GetSystemMemoryAvailable(),
                MemoryTotal = OSMetric.GetSystemMemoryTotal(),
            };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }

    }


      




}
