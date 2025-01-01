using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havalan.Application.Categories.Queries.DTOs;
public class CategoryDto
{
    public long? ParentId { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public List<SubCategoryDto> SubCategoriesDto { get; set; } = null!;
}