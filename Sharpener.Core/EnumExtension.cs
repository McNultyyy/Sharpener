using System;
using System.Collections;
using System.Collections.Generic;

namespace Sharpener.Core
{
    public static class EnumExtension
    {
        public static IEnumerable<EnumValue> GetValues<TEnum>()
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            foreach (var itemType in Enum.GetValues(typeof(TEnum)))
            {
                var value = new EnumValue
                {
                    Name = Enum.GetName(typeof(TEnum), itemType),
                    Value = (int)itemType
                };
                yield return value;
            }
        }

        public class EnumValue
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }

}