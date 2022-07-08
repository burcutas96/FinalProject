using Core.Entities.Abstract;

namespace Entities.DTOs
{
    //Sisteme giriş yapacak kişiden email ve password isteriz.
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
