using Havalan.Application.Categories.Commands.AddSubCategory;
using Havalan.Application.Categories.Commands.CreateCategory;
using Havalan.Application.Categories.Commands.Delete;
using Havalan.Application.Categories.Commands.Edit;
using Havalan.Application.Categories.Queries.GetList;
using Havalan.Web.Areas.Admin.Models.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
[Route("Admin/Category")]
public class CategoryController : AdminBaseController
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var category = await _mediator.Send(new GetListOfCategoriesQuery());
        return View(category);
    }

    [HttpGet("Add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(CreateCategoryViewModel model)
    {
        CreateCategoryCommand command = new CreateCategoryCommand(model.Title, model.Slug);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpGet("AddSubCategory/{parentId}")]
    public IActionResult AddSubCategory(long parentId)
    {
        return View();
    }

    [HttpPost("AddSubCategory/{parentId}")]
    public async Task<IActionResult> AddSubCategory(SubCategoryViewModel model)
    {
        AddSubCategoryCommand command = new AddSubCategoryCommand(model.ParentId, model.Title, model.Slug);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpGet("Edit/{Id}")]
    public IActionResult Edit(long Id)
    {
        return View();
    }

    [HttpPost("Edit/{Id}")]
    public async Task<IActionResult> Edit(EditCategoryViewModel model)
    {
        EditCategoryCommand command = new EditCategoryCommand(model.Id, model.Title, model.Slug);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpGet("Delete/{Id}")]
    public async Task<IActionResult> Delete(long Id)
    {
        DeleteCategoryCommand command = new DeleteCategoryCommand(Id);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }
}