using System;

namespace JsonCrafter.Demo.Api.Model
{
    public class User
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Gregor McFairlane";
        public string Occupation { get; set; } = "Skydiver";
        public DateTime RegisteredSince { get; set; } = DateTime.Parse("1997-03-01 23:01");
        public bool LikeShowTunes { get; set; } = true;
    }
}
