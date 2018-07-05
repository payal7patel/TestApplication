using System;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Mobile No.")]
        public int MobileNo { get; set; }
    }
}