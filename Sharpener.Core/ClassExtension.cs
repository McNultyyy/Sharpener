using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sharpener.Core
{
    public static class ClassExtension
    {
        public static bool IsIn<T>(this T needle, IEnumerable<T> haystack)
        {
            return haystack.Contains(needle);
        }

        public static bool IsIn<T>(this T needle, T first, T second, params T[] remainder)
        {
            return new[] { first, second }.Contains(needle) || remainder.Contains(needle);
        }

        public static void ThrowIfNull<T>(this T obj, [CallerMemberName]string callingObjectName = null)
        {
            if (obj == null) throw new NullReferenceException(callingObjectName ?? "obj");
        }

        public static T As<T>(this object instance) where T : class
        {
            return instance as T;
        }

        public static void SetPropertyValue<TSource, TProperty>(this TSource target,
            Expression<Func<TSource, TProperty>> memberLamda, TProperty value)
        {
            var propertyName = memberLamda.GetMemberName();
            var property = typeof(TSource).GetProperty(propertyName);

            property.SetValue(target, value);
        }

        public static T DeepCopy<T>(this T original)
        {
            return (T)Copy((object)original);
        }
        
        #region Internal Classes/Methods
        private static object Copy(this object originalObject)
        {
            return InternalCopy(originalObject, new Dictionary<object, object>(new ReferenceEqualityComparer()));
        }

        private static readonly MethodInfo CloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        private static object InternalCopy(object originalObject, IDictionary<object, object> visited)
        {
            if (originalObject == null) return null;
            var typeToReflect = originalObject.GetType();
            if (typeToReflect.IsPrimitiveOrString()) return originalObject;
            if (visited.ContainsKey(originalObject)) return visited[originalObject];
            if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (arrayType.IsPrimitiveOrString() == false)
                {
                    var clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                }

            }
            visited.Add(originalObject, cloneObject);
            CopyFields(originalObject, visited, cloneObject, typeToReflect);
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
            return cloneObject;
        }

        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType != null)
            {
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        }

        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false) continue;
                if (fieldInfo.FieldType.IsPrimitiveOrString()) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        }


        private class ReferenceEqualityComparer : EqualityComparer<object>
        {
            public override bool Equals(object x, object y)
            {
                return ReferenceEquals(x, y);
            }
            public override int GetHashCode(object obj)
            {
                if (obj == null) return 0;
                return obj.GetHashCode();
            }
        }
        #endregion
    }
}
