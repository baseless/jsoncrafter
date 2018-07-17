using Soltys.ChangeCase;

namespace JsonCrafter.Processing.Naming
{
    /// <summary>
    /// Param case (snake-case) IOC facade.
    /// </summary>
    public class ParamCaseFormatter : ICaseFormatter
    {
        /// <inheritdoc />
        public string Format(string name) => name.ParamCase();
    }
}
