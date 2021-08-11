using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public class Serialize
    {
        private static readonly string _separator = ",";
        private static readonly string _endRow = "\n";
        private static readonly BindingFlags _bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public static string SerializeFromObjectToCsv(object obj)
        {
            var objectType = obj.GetType();
            var properties = objectType.GetProperties(_bindFlags).Select(p => new {name = p.Name, type = p.PropertyType, val = p.GetValue(obj)});
            var fields = objectType.GetFields(_bindFlags).Select(f => new {name = f.Name, type = f.FieldType, val = f.GetValue(obj)});

            var output = properties.Aggregate(string.Empty, (current, property) => current + RowGenerate(property.name, property.type, property.val));

            return fields.Aggregate(output, (current, field) => current + RowGenerate(field.name, field.type, field.val));
        }
        
        public static T DeserializeFromCsvToObject<T>(string csv) where T : class
        {
            return null;
        }

        private static string RowGenerate(string name, object type, object val)
        {
            return name + _separator + type + _separator + val + _endRow;
        }
    }
}