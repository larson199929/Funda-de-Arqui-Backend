using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorship.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController
    {
        [HttpGet]
        public string Index()
        {
            return "Running...";
        }



    }
}
