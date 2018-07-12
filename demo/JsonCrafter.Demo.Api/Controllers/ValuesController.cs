using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static Test TestObj = CreateTest();

        // GET api/values
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            //return new {Apa = "a"};
            //var t = new Test();
            //t.TestTests.Add(new Test());
            return TestObj;
            //return new string[] { "value1", "value2" };
        }

        public static Test CreateTest()
        {
            var t = new Test();

            for (int i = 0; i < 2000; i++)
            {
                t.TestTests.Add(new Test { Name = "ChildTest" + i });
            }

            return t;
        }
    }
    
    public class Test
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "MyName";
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public ICollection<Test> TestTests { get; set; } = new List<Test>();

        public Baba BMyBaba = new Baba();
    }

    public class Baba
    {
        public string BabaProperty { get; set; } = "BABA!!";
    }
}
