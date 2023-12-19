using Business.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthService _authService;
        private readonly IBrandService _brandService;
        private readonly IOrderService _orderService;
        private readonly IPhoneService _phoneService;

        public ServiceManager(IAuthService authService, IBrandService brandService, IOrderService orderService, IPhoneService phoneService)
        {
            _authService = authService;
            _brandService = brandService;
            _orderService = orderService;
            _phoneService = phoneService;
        }

        public IAuthService AuthService => _authService;

        public IBrandService BrandService => _brandService;

        public IOrderService OrderService => _orderService;

        public IPhoneService PhoneService => _phoneService;

    }
}