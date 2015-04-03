using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseSchemaReader.DataSchema;

namespace DatabaseSchemaReader.Extensions
{
    public static class NamedObjectExtensions
    {

        public static void CloneTo(this NamedObject source, NamedObject target)
        {
            target.Name = source.Name;
        }
        
        public static T Get<T>(this IEnumerable<T> list, string itemName) where T : NamedObject
        {
            var ret = list.FirstOrDefault(c => c.Name == itemName);
            if (ret == null)
                throw new Exception("Елемент '" + itemName + "' не найден");
            return ret;
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> args, IEnumerable<string> useOnlyItemsWithNames) where T : NamedObject
        {
            return args.Where(arg => useOnlyItemsWithNames.Any(name => arg.Name == name));
        }

        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> args, IEnumerable<string> exludeItemsWithNames) where T : NamedObject
        {
            return args.Where(arg => exludeItemsWithNames.All(name => arg.Name != name));
        }

        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> args, IEnumerable<NamedObject> exludeItemsWithTheSameNames) where T : NamedObject
        {
            return args.Where(arg => exludeItemsWithTheSameNames.All(item => arg.Name != item.Name));
        }

        public static bool TryGet<T>(this IEnumerable<T> list, string itemName,  out T item) where T : NamedObject
        {
            item = list.FirstOrDefault(c => c.Name == itemName);
            return item != null;
        }

        public static string GetNameOrNull(this NamedObject obj)
        {
            return (obj != null) ? obj.Name : null;
        }

        public static bool ContainsItem<T>(this IEnumerable<T> list, string itemName) where T : NamedObject
        {
            return list.Any(p => p.Name == itemName);
        }
    }
}
