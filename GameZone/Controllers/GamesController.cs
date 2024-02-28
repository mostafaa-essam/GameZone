using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGameService _gameService;

        public GamesController(IDevicesService devicesService, ICategoriesService categoriesService, IGameService gameService)
        {

            _devicesService = devicesService;
            _categoriesService = categoriesService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View(_gameService.GetAll());
        }
        public IActionResult Details(int id)
        {
            var game=_gameService.GetById(id);
             if(game is null)
                return NotFound();
            return View(game);
        }
        [HttpGet]
        public IActionResult Create() {
            CreateGameViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectCategories(),

                Devices = _devicesService.GetSelectDevices()
            };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGameViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectCategories();
                model.Devices = _devicesService.GetSelectDevices();
                return View(model);
            }
               await  _gameService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var game= _gameService.GetById(id);
            if (game is null)
                return NotFound();
            UpdateGameViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Desciption=game.Description,
                CategoryId=game.CategoryId,
                SelectedDevices=game.GameDevices.Select(d=>d.DevicId).ToList(),
                Categories= _categoriesService.GetSelectCategories(),
                Devices= _devicesService.GetSelectDevices(),
                CurrentCover=game.Cover
            };
            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectCategories();
                model.Devices = _devicesService.GetSelectDevices();
                return View(model);
            }
            var game=await _gameService.Update(model);
            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
         public IActionResult Delete(int id)
        {
            var isDeleted= _gameService.Delete(id);

            return isDeleted? Ok():BadRequest();
        }
    }
  
}
