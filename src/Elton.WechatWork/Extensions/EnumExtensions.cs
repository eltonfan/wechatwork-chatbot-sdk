using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Elton
{
    /// <summary>
    /// extension methods
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get <see cref="DescriptionAttribute" />.Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var memInfo = value.GetType().GetMember(value.ToString())?.FirstOrDefault();
            return memInfo?.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }

        /// <summary>
        /// Get <see cref="EnumMemberAttribute" />.Value or Enum.ToString()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEnumMemberValue(this Enum value)
        {
            var memInfo = value.GetType().GetMember(value.ToString())?.FirstOrDefault();
            return memInfo?.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
        }

        /// <summary>
        /// Parse from <see cref="EnumMemberAttribute" />.Value or Enum.ToString() or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AsEnumMemberValue<T>(this string value)
            where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException("T must be an enumerated type");
            }

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (attribute.Value == value)
                    {
                        return (T)field.GetRawConstantValue();
                    }
                }
                else
                {
                    if (field.Name == value)
                    {
                        return (T)field.GetRawConstantValue();
                    }
                }
            }

            return default;
        }
    }
}
