using System;
namespace Entities.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsEmptyObject(this IEntity entity) => entity.Id.Equals(Guid.Empty);

        public static bool IsEmptyGuid(this Guid guid) => guid.Equals(Guid.Empty);

        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        public static bool IsNullOrEmpty(this int i) => i == 0;

        public static string CapitalizeLetters(this string s)
        {
            char[] array = s.ToLower().ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

    }
}
