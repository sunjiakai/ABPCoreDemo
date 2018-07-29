using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBook.Persons;

namespace MPACore.PhoneBook.PhoneBook.PhoneNumbers
{
    public class PhoneNumber :Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// 电话
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public PhoneType Type { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>

        public virtual int PersonId { get; set; }
        /// <summary>
        /// 电话所属用户
        /// </summary>

        public Person Person { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime CreationTime { get; set; }
    }
}
