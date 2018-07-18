using Newtonsoft.Json.Linq;

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
        /// <param name="obj">The C# object that is about to be presented as a response to the consumer.</param>
        /// <returns></returns>
        string Serialize(object obj);
    }
}
