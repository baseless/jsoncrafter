using Soltys.ChangeCase;

namespace JsonCrafter.Processing.Naming
{
    /// <summary>
    /// PascalCase IOC facade.
    /// </summary>
    public class PascalCaseFormatter : ICaseFormatter
    {
        /// <inheritdoc />
        public string Format(string name) => name.PascalCase();
    }
}
