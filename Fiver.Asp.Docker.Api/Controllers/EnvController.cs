using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiver.Asp.Docker.Api.Controllers
{
    [Route("env")]
    public class EnvController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var dict = new Dictionary<string, string>();

            var enumerator = Environment.GetEnvironmentVariables().GetEnumerator();
            while (enumerator.MoveNext())
            {
                dict.Add(enumerator.Key.ToString(), enumerator.Value.ToString());
            }
            
            return Ok(dict);
        }
    }
}
