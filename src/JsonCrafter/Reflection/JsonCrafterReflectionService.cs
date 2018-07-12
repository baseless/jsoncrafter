using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonCrafter.Reflection
{
    public class JsonCrafterReflectionService : IJsonCrafterReflectionService
    {
        public IDictionary<Type, string> GetChildren(Type type)
        {
            var allChildren = type.GetMembers();
            var childClasses = type.GetFields().Where(t => t.FieldType.IsClass);
            var childLists = type.GetProperties().Where(t => t.PropertyType.IsArray);
            var childMembers = type.GetMembers();

            var childColl = type.GetMembers().Where(t => t.GetType().IsArray);


            var children = Enumerable.Range(1, 1000)
                .SelectMany(i => Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.IsClass && type.IsAssignableFrom(t) && t != type)
                    .Select(t => t.Name));
            
            return null;
        }
    }
}
