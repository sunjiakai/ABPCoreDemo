using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBook.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPACore.PhoneBook.PhoneBook.Dto
{
    [AutoMapFrom(typeof(Person))]
    public  class PersonListDto:FullAuditedEntityDto
    {
        // <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }
}
