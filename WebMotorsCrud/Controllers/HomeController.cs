using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMotorsCrud.Models;
using WM.App.ViewModels;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WebMotorsCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnuncioService _anuncioService;
        private readonly IAnuncioRepository _anuncioRepository;



        public HomeController(ILogger<HomeController> logger,
            IAnuncioRepository IAnuncioRepository, 
            IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
            _anuncioRepository = IAnuncioRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<AnuncioModel> lsAnuncios = _anuncioRepository.getAnuncios();
            List<AnuncioViewModel> lsAnunciosVM = new List<AnuncioViewModel>();


            foreach (var item in lsAnuncios)
            {
                var AnuncioViewModel = new AnuncioViewModel();
                AnuncioViewModel.ID = item.ID;
                AnuncioViewModel.Make = item.Marca;
                AnuncioViewModel.Model = item.Modelo;
                AnuncioViewModel.KM = item.Quilometragem;
                AnuncioViewModel.Year = item.Ano;
                AnuncioViewModel.Obs = item.Observacao;
                AnuncioViewModel.Version = item.Versao;

                lsAnunciosVM.Add(AnuncioViewModel);
            }
            return View(lsAnunciosVM);
        }

      


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind] AnuncioViewModel _anuncioViewModel)
        {

            if(ModelState.IsValid)
            {

                var AnuncioModel = new AnuncioModel();
                AnuncioModel.Marca = _anuncioViewModel.Make.Split("|")[1];
                AnuncioModel.Modelo = _anuncioViewModel.Model.Split("|")[1];
                AnuncioModel.Versao = _anuncioViewModel.Version.Split("|")[1];
                AnuncioModel.Quilometragem = _anuncioViewModel.KM;
                AnuncioModel.Ano = _anuncioViewModel.Year;
                AnuncioModel.Observacao = _anuncioViewModel.Obs;

                int rows = _anuncioRepository.Add(AnuncioModel);

                RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            AnuncioModel anuncio = _anuncioRepository.Findby(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var AnuncioViewModel = new AnuncioViewModel();


            AnuncioViewModel.Make = anuncio.Marca;
            AnuncioViewModel.Model = anuncio.Modelo;
            AnuncioViewModel.Version = anuncio.Versao;
            AnuncioViewModel.Year = anuncio.Ano;
            AnuncioViewModel.Obs = anuncio.Observacao;
            AnuncioViewModel.Version = anuncio.Versao;
            AnuncioViewModel.ID = anuncio.ID;

          
            return View(AnuncioViewModel);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

             AnuncioModel anuncio = _anuncioRepository.Findby(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var AnuncioViewModel = new AnuncioViewModel();

            if (anuncio.Marca.Contains("|")  )
            {
                AnuncioViewModel.Make = anuncio.Marca.Split("|")[1];
                AnuncioViewModel.Model = anuncio.Modelo.Split("|")[1];
                AnuncioViewModel.Version = anuncio.Versao.Split("|")[1];
            }
            else
            {
                AnuncioViewModel.Make = anuncio.Marca;
                AnuncioViewModel.Model = anuncio.Modelo;
                AnuncioViewModel.Version = anuncio.Versao;
            }

            
            AnuncioViewModel.KM = anuncio.Quilometragem;
            AnuncioViewModel.Year = anuncio.Ano;
            AnuncioViewModel.Obs = anuncio.Observacao;


            return View(AnuncioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] AnuncioViewModel _anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                var AnuncioModel = new AnuncioModel();

                if (_anuncioViewModel.Make.Contains("|"))
                {
                    AnuncioModel.Marca = _anuncioViewModel.Make.Split("|")[1];
                    AnuncioModel.Modelo = _anuncioViewModel.Model.Split("|")[1];
                    AnuncioModel.Versao = _anuncioViewModel.Version.Split("|")[1];
                }
                else
                {
                    AnuncioModel.Marca = _anuncioViewModel.Make;
                    AnuncioModel.Modelo = _anuncioViewModel.Model;
                    AnuncioModel.Versao = _anuncioViewModel.Version;
                }


                AnuncioModel.Quilometragem = _anuncioViewModel.KM;
                AnuncioModel.Ano = _anuncioViewModel.Year;
                AnuncioModel.Observacao = _anuncioViewModel.Obs;
                AnuncioModel.ID = _anuncioViewModel.ID;


                int rows = _anuncioRepository.Update(AnuncioModel);

                RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var anuncio = _anuncioRepository.Findby(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            int rows = _anuncioRepository.Delete(anuncio);


            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
