using Business.Contracts;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthService AuthService
        {
        get; }
        IBrandService BrandService
        {
        get; }
        IOrderService OrderService
        {
        get; }
        IPhoneService PhoneService
        {
        get; }

    }
}