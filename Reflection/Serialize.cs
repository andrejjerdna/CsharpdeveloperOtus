﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public class Serialize
    {
        private static readonly string _separator = ",";
        private static readonly string _endRow = "\n";
        private static readonly BindingFlags _bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public static string SerializeFromObjectToCsv(object? obj)
        {
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
        
        public static T DeserializeFromCsvToObject<T>(string csv) where T : new()
        {
            var targetObject = new T();
            var targetType = targetObject.GetType();

            var data = csv.Split(_endRow)
                .Select(r => r.Split(_separator))
                .Select(v => new {name = v.First(), val = v.Last()});

            foreach (var prop in data)
            {
                var propInfo = targetType.GetProperty(prop.name, _bindFlags);
                propInfo?.SetValue(targetObject,
                    Convert.ChangeType(prop.val, propInfo.PropertyType), null);
            }
            
            foreach (var prop in data)
            {
                var fieldInfo = targetType.GetField(prop.name, _bindFlags);
                fieldInfo?.SetValue(targetObject, Convert.ChangeType(prop.val, fieldInfo.FieldType));
            }

            return targetObject;
        }

        private static string RowGenerate(string name, object val)
        {
            return name + _separator + val + _endRow;
        }
    }
}