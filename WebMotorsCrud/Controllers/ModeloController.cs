using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WM.App.Controllers
{
    public class ModeloController : Controller
    {
        private readonly IAnuncioService _anuncioService;

        public ModeloController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }


        public async Task<IActionResult> callModelAPI(int id)
        {
            List<ModelModel> lsModel = await _anuncioService.callModelAPI(id);
            if (lsModel != null)
            {
                return Json(new { isValid = true, lsModel });
            }
            return Json(new { isValid = false });
        }
    }
}
