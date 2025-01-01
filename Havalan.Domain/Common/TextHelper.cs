namespace Havalan.Domain.Common;
internal static class TextHelper
{
    public static string ToSlug(this string url)
    {
        return url.Trim().ToLower()
            .Replace("$", "")
            .Replace("+", "")
            .Replace("%", "")
            .Replace("?", "")
            .Replace("^", "")
            .Replace("*", "")
            .Replace("@", "")
            .Replace("!", "")
            .Replace("#", "")
            .Replace("&", "")
            .Replace("~", "")
            .Replace("(", "")
            .Replace("=", "")
            .Replace(")", "")
            .Replace("/", "")
            .Replace(@"\", "")
            .Replace(".", "")
            .Replace(" ", "-");
    }
}