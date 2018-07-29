using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBook.Dto;
using MPACore.PhoneBook.PhoneBook.Persons;

namespace MPACore.PhoneBook.PhoneBook
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person>  personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
           if(input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAsync(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
               
            }
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id);
            if(entity==null)
            {
                throw new UserFriendlyException("该数据已经不存在，无法进行二次删除！");
            }
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAll();
            var personCount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<PersonListDto>>();

            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);

            return entity.MapTo<PersonListDto>();
        }
        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);
            var dto = input.MapTo(entity);
            await _personRepository.UpdateAsync(entity);

        }
        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            var entity =  input.MapTo<Person>();
            await _personRepository.InsertAsync(entity);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetPersonForEditOutput> GetPersonForEditByIdAsync(NullableIdDto input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto personEditDto;
            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAsync(input.Id.Value);
                personEditDto = entity.MapTo<PersonEditDto>();
            }
            else
            {
                personEditDto = new PersonEditDto();
            }
            output.Person = personEditDto;
            return output;
        }
    }
}
