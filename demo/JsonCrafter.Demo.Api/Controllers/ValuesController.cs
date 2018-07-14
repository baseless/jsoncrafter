using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult<Test[]> Get()
        {
            return CreateTest().TestTests.ToArray();
        }

        public static Test CreateTest()
        {
            var t = new Test();

            for (int i = 0; i < 400; i++)
            {
                t.TestTests.Add(new Test { Name = "ChildTest" + i });
            }

            return t;
        }
    }
    
    public class Test
    {
        public string MIFFO = "hrtehtre";
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
