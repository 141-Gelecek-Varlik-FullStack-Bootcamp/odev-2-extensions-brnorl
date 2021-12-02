using System;
using System.ComponentModel.DataAnnotations;
//DataAnnotations dökümantasyon
//https://docs.microsoft.com/tr-tr/dotnet/api/system.componentmodel.dataannotations?view=net-5.0

namespace ExtensionsWebApi
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required"), MinLength(3)]
        [Display(Name = "User Name")]
        [StringLength(30, ErrorMessage = "Max length is 30 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required"), MinLength(2)]
        [Display(Name = "User Surname")]
        [StringLength(30, ErrorMessage = "Max length is 30 chars")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "E-Mail is required"), MinLength(11)]
        [Display(Name = "User Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Not a valid E-Mail")]//regex expression
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required"), MinLength(11)]
        [Display(Name = "User Phone Number")]
        public string PhoneNumber { get; set; }
    }
}