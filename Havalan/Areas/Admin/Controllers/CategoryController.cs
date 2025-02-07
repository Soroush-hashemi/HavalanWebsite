using AutoMapper;
using Havalan.Application.Categories.Commands.AddSubCategory;
using Havalan.Application.Categories.Commands.CreateCategory;
using Havalan.Application.Categories.Commands.Delete;
using Havalan.Application.Categories.Commands.Edit;
using Havalan.Application.Categories.Queries.GetById;
using Havalan.Application.Categories.Queries.GetList;
using Havalan.Web.Areas.Admin.Models.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
[Route("Admin/Category")]
public class CategoryController : AdminBaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
        return View(new SubCategoryViewModel());
    }

    [HttpPost("AddSubCategory/{parentId}")]
    public async Task<IActionResult> AddSubCategory(SubCategoryViewModel model)
    {
        AddSubCategoryCommand command = new AddSubCategoryCommand(model.ParentId, model.Title, model.Slug);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpGet("Edit/{Id}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(Id));
        var categoryMapped = _mapper.Map<EditCategoryViewModel>(category);
        return View(categoryMapped);
    }

    [HttpPost("Edit/{Id}")]
    public async Task<IActionResult> Edit(EditCategoryViewModel model)
    {
        EditCategoryCommand command = new EditCategoryCommand(model.Id,
             model.Title, model.Slug);

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