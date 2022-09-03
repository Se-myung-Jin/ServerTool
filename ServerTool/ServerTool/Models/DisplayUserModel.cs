using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace ServerTool
{
    public class DisplayUserModel
    {
        public long Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Input E-mail type!")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool Confirmed { get; set; }
        public bool Locked { get; set; }
    }
}
