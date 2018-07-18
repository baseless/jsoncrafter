using JsonCrafter.Core.Enums;

namespace JsonCrafter.Processing.Configuration
{
    public interface IConfigurationBuilder : IFor
    {
        /// <summary>
        /// Sets what casing should be used by JsonCrafter.
        ///
        /// CamelCase => 'camelCase' (default)
        /// PascalCase => 'PascalCase'
        /// SnakeCase => 'snake_case'
        /// ParamCase => 'param-case'
        /// </summary>
        /// <param name="format">The desired casing format.</param>
        void SetCasing(JsonCrafterCasing format);

        /// <summary>
        /// Enables JSON processing for a supported format.
        /// </summary>
        /// <param name="type">The format that is intended to be enabled.</param>
        void EnableMediaType(JsonCrafterMediaType type);
    }
}
