using System.ComponentModel.DataAnnotations;

namespace Havalan.Web.Areas.Admin.Models.TrendingNews;
public class TrendingNewsViewModel
{
    public long Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
}