using Havalan.Application.Comments.Commands.Delete;
using Havalan.Application.Comments.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
[Route("Admin/Comment")]
public class CommentController : AdminBaseController
{
    private readonly IMediator _mediator;
    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var Comments = await _mediator.Send(new GetAllCommentQuery());
        return View(Comments);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(long Id)
    {
        var result = await _mediator.Send(new DeleteCommentsCommand(Id));
        return ResultAlert(result);
    }
}