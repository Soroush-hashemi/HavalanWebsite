﻿using System.ComponentModel.DataAnnotations;

namespace Havalan.Web.Areas.Admin.Models.Category;
public class CreateCategoryViewModel
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Slug { get; set; } = null!;
}