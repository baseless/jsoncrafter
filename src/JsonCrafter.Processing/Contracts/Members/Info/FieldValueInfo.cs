using System.Reflection;

namespace JsonCrafter.Processing.Contracts.Members.Info
{
    public sealed class FieldValueInfo : IValueInfo
    {
        private readonly FieldInfo _info;

        public FieldValueInfo(FieldInfo info)
        {
            _info = info;
        }

        public object GetValue(object obj) => _info.GetValue(obj);
    }
}
