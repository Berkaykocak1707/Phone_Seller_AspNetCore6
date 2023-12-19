using Business;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IServiceManager _manager;

        public BrandController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var Message = TempData["Message"] as string;
            ViewData["Message"] = Message;
            var model = _manager.BrandService.GetAllBrands();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]BrandDtoForCreation brandDtoForCreation)
        {
            if(ModelState.IsValid)
            {
                _manager.BrandService.CreateBrand(brandDtoForCreation);
                TempData["Message"] = "Brand created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _manager.BrandService.DeleteBrand(id);
            TempData["Message"] = "Brand deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit([FromRoute]int id)
        {
            var model = _manager.BrandService.GetBrandByIdForUpdate(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]BrandDtoForUpdate brandDtoForUpdate)
        {
            if(ModelState.IsValid)
            {
                _manager.BrandService.UpdateBrand(brandDtoForUpdate.BrandID, brandDtoForUpdate);
                TempData["Message"] = "Brand updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
