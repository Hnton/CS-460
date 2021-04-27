using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Controllers
{
    public class ExtrasController : Controller
    {
        public IActionResult SurveyLandingPage()
        {
            return View();
        }
    }
}
