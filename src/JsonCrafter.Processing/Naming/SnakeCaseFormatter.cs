using Soltys.ChangeCase;

namespace JsonCrafter.Processing.Naming
{
    /// <summary>
    /// SnakeCase IOC facade.
    /// </summary>
    public class SnakeCaseFormatter : ICaseFormatter
    {
        /// <inheritdoc />
        public string Format(string name) => name.SnakeCase();
    }
}
