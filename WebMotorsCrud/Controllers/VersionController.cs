using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WM.App.Controllers
{
    public class VersionController : Controller
    {
        private readonly IAnuncioService _anuncioService;

        public VersionController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }


        public async Task<IActionResult> callVersionAPI(int id)
        {
            List<VersionModel> lsVersion = await _anuncioService.callVersionAPI(id);
            if (lsVersion != null)
            {
                return Json(new { isValid = true, lsVersion });
            }
            return Json(new { isValid = false });
        }
    }
}
