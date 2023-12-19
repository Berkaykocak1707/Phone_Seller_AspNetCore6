using Business;
using Entities.Dtos;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Phone_Seller_AspNetCore6.Models;
using Microsoft.AspNetCore.Authorization;

namespace Phone_Seller_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class PhoneController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly SlugService _slugService;

        public PhoneController(IServiceManager manager, SlugService slugService)
        {
            _manager = manager;
            _slugService = slugService;
        }

        // GET: Admin/Phone
        public IActionResult Index([FromQuery] PhoneRequestParameters requestParameters)
        {
            requestParameters.PageSize = 5;
            var phones = _manager.PhoneService.FindAllPhoneWithBrand(requestParameters,false);
            var pagination = new Pagination()
            {
                CurrentPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = _manager.PhoneService.GetAllPhones().Count()
            };
            return View(new PhoneListViewModel()
            {
                Phones = phones,
                Pagination = pagination
            });
        }

        // GET: Admin/Phone/Create
        public IActionResult Create()
        {
            ViewBag.Brands = GetBrandSelectList();
            return View();
        }
        // GET: Admin/Phone/Edit/5
        public IActionResult Edit(int id)
        {
            var phone = _manager.PhoneService.GetPhoneByIdForUpdate(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewBag.Brands = GetBrandSelectList();
            return View(phone);
        }

        // POST: Admin/Phone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, PhoneDtoForUpdate phoneUpdateDto, IFormFile file, string phoneCodeInModel)
        {
            if (phoneUpdateDto is not null)
            {
                var phoneSlug = _slugService.GenerateSlug(phoneUpdateDto.PhoneName);
                phoneUpdateDto.PhoneSlug = phoneSlug;
                if (phoneCodeInModel != phoneUpdateDto.PhoneCode)
                {
                    var brand = _manager.BrandService.GetBrandById(phoneUpdateDto.BrandID);
                    var brandCode = brand.BrandCode;
                    phoneUpdateDto.PhoneCode = $"{brandCode.ToUpper()}-{phoneUpdateDto.PhoneCode.ToUpper()}";
                    ModelState.SetModelValue("PhoneCode", new ValueProviderResult(phoneUpdateDto.PhoneCode));
                }

                ModelState.SetModelValue("PhoneSlug", new ValueProviderResult(phoneUpdateDto.PhoneSlug));

                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    if (file is not null && file.Length > 0)
                    {
                        // file operation
                        string originalFileName = file.FileName;
                        string fileExtension = Path.GetExtension(originalFileName);
                        string newFileName = phoneSlug + fileExtension;

                        string path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "img", newFileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        phoneUpdateDto.PhonePhotoUrl = String.Concat("/img/", newFileName);
                    }
                    _manager.PhoneService.UpdatePhone(id, phoneUpdateDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Brands = GetBrandSelectList();
            return View(phoneUpdateDto);
        }
        private SelectList GetBrandSelectList()
        {
            return new SelectList(_manager.BrandService.GetAllBrands(),"BrandID","BrandName","1");
        }
        // POST: Admin/Phone/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(PhoneDtoForCreation phone, IFormFile file)
        {
            if (phone is not null)
            {
                var phoneSlug = _slugService.GenerateSlug(phone.PhoneName);
                phone.PhoneSlug = phoneSlug;
                var brand = _manager.BrandService.GetBrandById(phone.BrandID);
                var brandCode = brand.BrandCode;
                phone.PhoneCode = $"{brandCode.ToUpper()}-{phone.PhoneCode.ToUpper()}";


                ModelState.SetModelValue("PhoneSlug", new ValueProviderResult(phone.PhoneSlug));
                ModelState.SetModelValue("PhoneCode", new ValueProviderResult(phone.PhoneCode));

                ModelState.Clear();
                if (ModelState.IsValid)
                {

                    // file operation
                    string originalFileName = file.FileName;
                    string fileExtension = Path.GetExtension(originalFileName);
                    string newFileName = phoneSlug + fileExtension;
                    
                    string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "img", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    phone.PhonePhotoUrl = String.Concat("/img/", newFileName);
                    _manager.PhoneService.CreatePhone(phone);
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return View(phone);
        }
        public IActionResult Delete([FromRoute]int id)
        {
            _manager.PhoneService.DeletePhone(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
