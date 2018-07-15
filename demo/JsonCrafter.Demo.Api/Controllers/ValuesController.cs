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
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult<GetValuesOutputModel> Get()
        {
            var model = new GetValuesOutputModel();
            AddItems(model);
            return model;
        }

        public static void AddItems(GetValuesOutputModel model)
        {
            for (int i = 0; i < 400; i++)
            {
                model.Tests.Add(new Test { Name = "ChildTest" + i });
            }
        }
    }

    public class GetValuesOutputModel
    {
        public Guid ModelId { get; set; } = Guid.NewGuid();
        public IList<Test> Tests { get; set; } = new List<Test>();
    }

    public class Test
    {
        public string Miffo = "hrtehtre";
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "MyName";
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public ICollection<Test> TestTests { get; set; } = new List<Test>();

        public Baba MyBaba = new Baba();
    }

    public class Baba
    {
        public string BabaProperty { get; set; } = "BABA!!";
    }
}
