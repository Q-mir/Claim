using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Querys.Object
{
    public class RegistrationDTO : IQuery
    {
        [Required(ErrorMessage = nameof(Name) + " not empty")]
        [Display(Name = "Логин")]
        public string Name { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Display(Name = "Пароль повторите")]
        public string PasswordAgain { get; set; }
    }
}
