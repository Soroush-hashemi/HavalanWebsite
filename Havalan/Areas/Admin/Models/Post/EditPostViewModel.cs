using System.ComponentModel.DataAnnotations;

namespace Havalan.Web.Areas.Admin.Models.Post;
public class EditPostViewModel
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Slug { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public IFormFile ImageFile { get; set; } = null!;
    public int View { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsSidebar { get; set; }

}