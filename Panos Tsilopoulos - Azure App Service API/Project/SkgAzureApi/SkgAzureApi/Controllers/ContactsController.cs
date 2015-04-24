using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkgAzureApi.Models;

namespace SkgAzureApi.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return new Contact[]{
                new Contact { Id = 1, EmailAddress = "babis@skg.netmeetup", Name = "Charalampos Karypidis"},
                new Contact { Id = 2, EmailAddress = "nikos@skg.netmeetup", Name = "Nikos Tzelvenzis"},
                new Contact { Id = 3, EmailAddress = "panos@skg.netmeetup", Name = "Panos Tsilopoulos"},
                new Contact { Id = 4, EmailAddress = "konstantinos@skg.netmeetup", Name = "Konstantinos Ziazios"},
                new Contact { Id = 5, EmailAddress = "dimitris@skg.netmeetup", Name = "Dimitris Batsougiannis"}
            };
        }
    }
}