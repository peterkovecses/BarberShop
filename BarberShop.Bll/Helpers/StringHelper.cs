
using System.Globalization;
using System.Text;

namespace BarberShop.Bll.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Shorten a string to a specified length.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="maxLenght"></param>
        /// <returns></returns>
        public static string Shorten(this string current, int maxLenght)
        {
            if (current == null)
                return "";
            if (current.Length < 201)
                return current;

            return current[0..(maxLenght - 1)] + "...";
        }

        /// <summary>
        /// Remove accents from string's characters.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var chr in normalized)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(chr);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(chr);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Remove more string from a string. The first parameter is the string what we want to modify, the second is a string array.
        /// </summary>
        /// <param name="stringToModify"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string RemoveStrings(this string stringToModify, string[] arr)
        {
            foreach (var str in arr)
            {
                stringToModify = stringToModify.Replace(str, "");
            }
            return stringToModify;
        }
    }


}
