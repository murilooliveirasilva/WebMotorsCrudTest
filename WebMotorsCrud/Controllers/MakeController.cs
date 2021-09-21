using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WM.App.Controllers
{
    public class MakeController : Controller
    {
        private readonly IAnuncioService _anuncioService;

        public MakeController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        [HttpPost]
        public async Task<IActionResult> callMakeAPI()
        {
            List<MakeModel> lsMakes = await _anuncioService.callMakeAPI();
            if(lsMakes != null)
            {
                return Json(new { isValid= true, lsMakes});
            }
            return Json(new { isValid = false });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
