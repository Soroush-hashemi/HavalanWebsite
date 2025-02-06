namespace Havalan.Web.Areas.Admin.Models.Category;
public class SubCategoryViewModel
{
    public long ParentId { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
}