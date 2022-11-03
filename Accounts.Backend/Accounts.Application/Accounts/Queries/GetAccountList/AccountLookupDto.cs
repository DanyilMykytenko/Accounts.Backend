using Accounts.Application.Common.Mappings;
using Accounts.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountList
{
    public class AccountLookupDto : IMapWith<Account>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountLookupDto>()
                .ForMember(accountDto => accountDto.Id,
                    opt => opt.MapFrom(account => account.Id))
                .ForMember(accountDto => accountDto.FullName,
                    opt => opt.MapFrom(account => account.FullName));
        }
    }
}
