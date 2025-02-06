using Havalan.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Havalan.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBaseController : Controller
{
    protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return View();

        return redirectPath;
    }

    protected void SuccessAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    protected void ErrorAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    public IActionResult ResultAlert(OperationResult result)
    {
        if (result.Status != OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction("Index");
        }

        SuccessAlert(result.Message);
        return RedirectToAction("Index");
    }
}