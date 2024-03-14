using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal static class Extensions
{
    public static string RemoveAccents(this string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var uc = CharUnicodeInfo.GetUnicodeCategory(c);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    public static string ToSlug(this string text)
    {
        return text.RemoveAccents().ToLower()
            .Replace(" ", "-")
            .Replace(".", "") // Remove pontuação
            .Replace(",", "") // Remove pontuação
            .Replace("!", "") // Remove pontuação
            .Replace("?", ""); // Remove pontuação
    }

    //returno the string limited to 252 characters and add ... if the string is bigger
    public static string ToSummary(this string text)
    {
        if (text.Length > 252)
        {
            return text.Substring(0, 252) + "...";
        }
        return text;
    }
}

