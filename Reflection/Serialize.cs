using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public class Serialize
    {
        private const string Separator = ",";
        private const string EndRow = "\n";
        private static readonly BindingFlags _bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        
        public static string SerializeFromObjectToCsv(object? obj)
        {
            if(obj == null)
                return string.Empty;
            
            var objectType = obj.GetType();
            var properties = objectType.GetProperties(_bindFlags)
                .Select(p => new {name = p.Name, type = p.PropertyType, val = p.GetValue(obj)});
            var fields = objectType.GetFields(_bindFlags)
                .Select(f => new {name = f.Name, type = f.FieldType, val = f.GetValue(obj)});

            var output = properties.Aggregate(string.Empty, (current, property) => 
                current + RowGenerate(property.name, property.val));

            output = fields.Aggregate(output, (current, field) => 
                current + RowGenerate(field.name, field.val));

            return output.Trim();
        }
        
        public static T DeserializeFromCsvToObject<T>(string csv) where T: class, new()
        {
            if(string.IsNullOrEmpty(csv))
                return null;
            
            var targetObject = new T();
            var targetType = targetObject.GetType();

            var data = csv.Split(EndRow)
                .Select(r => r.Split(Separator))
                .Select(v => new {name = v.First(), val = v.Last()});

            foreach (var prop in data)
            {
                var propInfo = targetType.GetProperty(prop.name, _bindFlags);
                propInfo?.SetValue(targetObject,
                    Convert.ChangeType(prop.val, propInfo.PropertyType), null);
                
                var fieldInfo = targetType.GetField(prop.name, _bindFlags);
                fieldInfo?.SetValue(targetObject, Convert.ChangeType(prop.val, fieldInfo.FieldType));
            }

            return targetObject;
        }

        private static string RowGenerate(string name, object? val)
        {
            return name + Separator + val + EndRow;
        }
    }
}