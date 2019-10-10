using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using WebReactApp.Models;

namespace WebReactApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string message = exceptionFeature.Error.Message;
            return View(new ErrorViewModel
            {
                Exception = message,
                Path = exceptionFeature.Path
            });
        }

        [Route("status")]
        public IActionResult HttpError([FromQuery] int code)
        {
            //Add Custom error pages
            return View(new HttpErrorViewModel
            {
                Code = code
            });
        }
    }
}