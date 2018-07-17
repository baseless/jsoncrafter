using Soltys.ChangeCase;

namespace JsonCrafter.Processing.Naming
{
    /// <summary>
    /// CamelCase IOC facade.
    /// </summary>
    public class CamelCaseFormatter : ICaseFormatter
    {
        /// <inheritdoc />
        public string Format(string name) => name.CamelCase();
    }
}
