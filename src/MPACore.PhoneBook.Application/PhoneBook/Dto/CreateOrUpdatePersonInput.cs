using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBook.Dto
{
    public class CreateOrUpdatePersonInput
    {
        public PersonEditDto PersonEditDto { get; set; }
    }
}
