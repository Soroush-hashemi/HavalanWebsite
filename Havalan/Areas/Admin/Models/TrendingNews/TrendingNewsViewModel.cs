using System.ComponentModel.DataAnnotations;

namespace Havalan.Web.Areas.Admin.Models.TrendingNews;
public class TrendingNewsViewModel
{
    [Required]
    public string Title { get; set; } = null!;
}