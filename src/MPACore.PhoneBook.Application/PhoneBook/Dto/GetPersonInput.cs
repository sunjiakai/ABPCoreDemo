using Abp.Runtime.Validation;
using MPACore.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPACore.PhoneBook.PhoneBook.Dto
{
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string FilterText { get; set; }
        public void Normalize()
        {
           if(string.IsNullOrWhiteSpace(this.Sorting))
            {
                this.Sorting = "Id";
            }
        }
    }
}
