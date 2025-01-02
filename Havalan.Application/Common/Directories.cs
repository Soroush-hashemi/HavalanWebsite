namespace Havalan.Application.Common;
public class Directories
{
    public const string PostImage = "wwwroot/images/post";

    public static string GetPostImage(string imageName) => $"{PostImage.Replace("wwwroot", "")}/{imageName}";
}
