﻿using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHealthAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://+:9000/agent";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                //HttpClient client = new HttpClient();

                //var response = client.GetAsync(baseAddress + "api/values").Result;

                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.ReadLine(); 
            }


        }
    }
}
