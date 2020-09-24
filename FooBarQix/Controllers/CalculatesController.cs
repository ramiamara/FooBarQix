using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooBarQix.Models;
using FooBarQix.Services;
using Microsoft.AspNetCore.Mvc;

namespace FooBarQix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatesController : ControllerBase
    {
        private readonly IFooBarQix _fooBarQix;

        public CalculatesController(IFooBarQix fooBarQix)
        {
            _fooBarQix = fooBarQix;
        }

        // Post api/Calculates/?
        [HttpPost]
        public ActionResult<string> Change(Entry entry)
        {
            if (entry.ANumber > int.MaxValue)
                return null;
            var result = _fooBarQix.Calculate(entry);
            return result;
        }



    }
}
