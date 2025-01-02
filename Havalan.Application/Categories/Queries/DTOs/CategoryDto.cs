using Havalan.Application.Common;

namespace Havalan.Application.Categories.Queries.DTOs;
public class CategoryDto : BaseDto
{
    public long? ParentId { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public List<SubCategoryDto> SubCategoriesDto { get; set; } = null!;
}