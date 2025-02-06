namespace Havalan.Web.Areas.Admin.Models.Category;
public class EditCategoryViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
}