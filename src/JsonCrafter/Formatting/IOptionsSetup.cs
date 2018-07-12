using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Formatting
{
    public interface IOptionsSetup<T> : IConfigureOptions<MvcOptions> where T: class, new()
    {
    }
}
