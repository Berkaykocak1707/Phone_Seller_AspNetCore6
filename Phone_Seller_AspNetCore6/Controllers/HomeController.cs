using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Phone_Seller_AspNetCore6.Models;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _manager;

        public HomeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] PhoneRequestParameters requestParameters)
        {
            requestParameters.PageSize = 4;
            int totalItems;
            var brandId = requestParameters.BrandID;
            if (brandId == null)
            {
                brandId = 0;
                totalItems = _manager.PhoneService.GetAllPhones().Count();
            }
            else
            {
                totalItems = _manager.PhoneService.FindPhonesWithBrandForHome(requestParameters).Count();
            }
            var phones = _manager.PhoneService.FindAllPhoneWithBrandForHome(requestParameters);
            var brands = _manager.BrandService.GetAllBrands();
            var pagination = new Pagination()
            {
                CurrentPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = totalItems,
                ID = (int)brandId
            };
            return View(new PhoneAndBrandListViewModel()
            {
                Phones = phones,
                Pagination = pagination,
                Brands = brands
            });
        }
        public IActionResult Phone([FromRoute(Name = "slug")] string slug)
        {
            if (slug is not null)
            {
                var model = _manager.PhoneService.GetOnePhoneWithSlug(slug);
                var brands = _manager.BrandService.GetAllBrands();
                var phones = _manager.PhoneService.RandomPhonesForRelatedItem(model.PhoneID, 4);
                return View(new PhoneAndBrandListViewModel()
                {
                    Phone = model,
                    Brands = brands,
                    Phones = phones
                });
            }
            return View();
        }
    }
}
