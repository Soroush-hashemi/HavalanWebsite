using AutoMapper;
using Havalan.Application.TrendingNews.Commands.Add;
using Havalan.Application.TrendingNews.Commands.Delete;
using Havalan.Application.TrendingNews.Commands.Edit;
using Havalan.Application.TrendingNews.Queries.GetById;
using Havalan.Application.TrendingNews.Queries.GetList;
using Havalan.Web.Areas.Admin.Models.TrendingNews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
[Route("Admin/TrendingNews")]
public class TrendingNewsController : AdminBaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public TrendingNewsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var TrendingNews = await _mediator.Send(new GetListOfNewsQuery());
        return View(TrendingNews);
    }

    [HttpGet("Add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(TrendingNewsViewModel model)
    {
        var command = new AddNewsCommand(model.Title);
        var result = await _mediator.Send(command);
        return ResultAlert(result);
    }

    [HttpPut("Edit/{Id}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var TrendingNewsDto = await _mediator.Send(new GetByIdNewsQuery(Id));
        var TrendingNewsMapped = _mapper.Map<TrendingNewsViewModel>(TrendingNewsDto);
        return View(TrendingNewsMapped);
    }

    [HttpPost("Edit/{Id}")]
    public async Task<IActionResult> Edit(TrendingNewsViewModel model)
    {
        var result = await _mediator.
            Send(new EditNewsCommand(model.Id, model.Title));

        return ResultAlert(result);
    }

    [HttpPost("Delete/{Id}")]
    public async Task<IActionResult> Delete(long Id)
    {
        var result = await _mediator.Send(new DeleteNewsCommand(Id));
        return ResultAlert(result);
    }
}