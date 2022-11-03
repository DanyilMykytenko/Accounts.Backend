using Accounts.Application.Common.Mappings;
using Accounts.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountDetails
{
    public class AccountDetailsVm : IMapWith<Account>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            //Map from Account class into AccountDetailsVm-class
            profile.CreateMap<Account, AccountDetailsVm>()
                .ForMember(accountVm => accountVm.FullName,
                    opt => opt.MapFrom(account => account.FullName))
                .ForMember(accountVm => accountVm.Details,
                    opt => opt.MapFrom(account => account.Details))
                .ForMember(accountVm => accountVm.Id,
                    opt => opt.MapFrom(account => account.Id))
                .ForMember(accountVm => accountVm.CreationDate,
                    opt => opt.MapFrom(account => account.CreationDate))
                .ForMember(accountVm => accountVm.EditDate,
                    opt => opt.MapFrom(account => account.EditDate));
        }
    }
}
