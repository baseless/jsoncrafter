using System.Reflection;

namespace JsonCrafter.Processing.Contracts.Members.Info
{
    public sealed class PropertyValueInfo : IValueInfo
    {
        private readonly PropertyInfo _info;

        public PropertyValueInfo(PropertyInfo info)
        {
            _info = info;
        }

        public object GetValue(object obj) => _info.GetValue(obj);
    }
}
