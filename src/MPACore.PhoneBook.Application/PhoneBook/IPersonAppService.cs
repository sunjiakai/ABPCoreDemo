using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBook
{
    public interface IPersonAppService:IApplicationService
    {
        /// <summary>
        /// 获取人员的相关信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);
        /// <summary>
        /// 根据ID获取人员信息
        /// </summary>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);
        /// <summary>
        /// 根据联系人ID获取编辑的联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task<GetPersonForEditOutput> GetPersonForEditByIdAsync(NullableIdDto input);

        /// <summary>
        /// 创建或修改人员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);
        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);
    }
}
