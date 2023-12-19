using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Phone_Seller_AspNetCore6.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        [Required(ErrorMessage = " Username is required.")]
        public string Username
        {
        get; set; }
        [Required(ErrorMessage = " Password is required.")]
        public string Password
        {
        get; set; }
        public string? ReturnUrl
        {
            get
            {
                if (_returnUrl == null)
                    return "/";
                else
                    return _returnUrl;
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}
