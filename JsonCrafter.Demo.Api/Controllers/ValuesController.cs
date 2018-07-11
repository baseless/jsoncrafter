using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            //return new {Apa = "a"};
            var t = new Test();
            t.TestTests.Add(new Test());
            return t;
            //return new string[] { "value1", "value2" };
        }
    }

    public class Test
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "MyName";
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public ICollection<Test> TestTests { get; set; } = new List<Test>();
    }
}
