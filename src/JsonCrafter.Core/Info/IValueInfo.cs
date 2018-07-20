using System;

namespace JsonCrafter.Core.Info
{
    /// <summary>
    /// Capsulates a propertyinfo or a fieldinfo so that the may be treated in the same fashion.
    /// </summary>
    public interface IValueInfo
    {
        /// <summary>
        /// Fetch the value corresponing to the stored Info object.
        /// </summary>
        /// <param name="obj">The object from which the value should be retrieved</param>
        /// <returns></returns>
        object GetValue(object obj);

        Type MemberType { get; }

        string Name { get; }
    }
}
