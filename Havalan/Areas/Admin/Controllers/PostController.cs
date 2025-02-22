using AutoMapper;
using Havalan.Application.Posts.Commands.Create;
using Havalan.Application.Posts.Commands.Delete;
using Havalan.Application.Posts.Commands.Edit;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Application.Posts.Queries.GetById;
using Havalan.Application.Posts.Queries.GetForAdmin;
using Havalan.Web.Areas.Admin.Models.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
[Route("Admin/Post")]
public class PostController : AdminBaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var postsDto = await _mediator.Send(new GetPostForAdminQuery());
        return View(postsDto);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePostViewModel model)
    {
        CreatePostCommand command = new CreatePostCommand(model.CategoryId,
            model.SubCategoryId, model.Title, model.Slug, model.Description,
            model.ImageFile, model.IsFeatured, model.IsSidebar);

        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpGet("Edit/{Id}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var postDto = await _mediator.Send(new GetPostByIdQuery(Id));
        var postMapped = _mapper.Map<PostDto>(postDto);
        return View(postMapped);
    }

    [HttpPost("Edit/{Id}")]
    public async Task<IActionResult> Edit(EditPostViewModel model)
    {
        EditPostCommand command = new EditPostCommand(model.Id, model.CategoryId,
            model.SubCategoryId, model.Title, model.Slug, model.Description,
            model.ImageFile, model.IsFeatured, model.IsSidebar);

        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(long Id)
    {
        DeletePostCommand Command = new DeletePostCommand(Id);
        var result = await _mediator.Send(Command);

        return ResultAlert(result);
    }
}