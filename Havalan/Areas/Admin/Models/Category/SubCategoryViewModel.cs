using System.ComponentModel.DataAnnotations;

namespace Havalan.Web.Areas.Admin.Models.Category;
public class SubCategoryViewModel
{
    public long ParentId { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Slug { get; set; } = null!;
}