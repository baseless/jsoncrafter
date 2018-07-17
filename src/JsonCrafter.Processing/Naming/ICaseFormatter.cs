namespace JsonCrafter.Processing.Naming
{
    /// <summary>
    /// Casing IOC facade interface.
    /// </summary>
    public interface ICaseFormatter
    {
        /// <summary>
        /// Converts the name into specified format.
        /// </summary>
        /// <param name="name">The name that is to be formatted.</param>
        /// <returns>The formatted name.</returns>
        string Format(string name);
    }
}
