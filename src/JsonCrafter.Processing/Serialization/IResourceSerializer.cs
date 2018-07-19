using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace JsonCrafter.Processing.Serialization
{
    public interface IResourceSerializer
    {
        /// <summary>
        /// The name of the mediatype format.
        /// </summary>
        string FormatName { get; }

        /// <summary>
        /// The headervalue for the current mediatype.
        /// </summary>
        string MediaTypeHeaderValue { get; }

        /// <summary>
        /// Initializes the serialization chain using the recieved object.
        /// </summary>
        /// <param name="context">The context of the formatter request</param>
        /// <param name="selectedEncoding">The requested encoding</param>
        /// <returns></returns>
        Task<string> SerializeAsync(OutputFormatterWriteContext context, Encoding selectedEncoding);
    }
}
