using FluentValidation.Attributes;
using Kerdoivkezelo.DAL.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
