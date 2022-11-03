using Accounts.Application.Accounts.Commands.UpdateAccount;
using Accounts.Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.WebApi.Models
{
    public class UpdateAccountDto : IMapWith<UpdateAccountCommand>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAccountDto, UpdateAccountCommand>()
                .ForMember(accountCommand => accountCommand.Id,
                    opt => opt.MapFrom(accountDto => accountDto.Id))
                .ForMember(accountCommand => accountCommand.FullName,
                    opt => opt.MapFrom(accountDto => accountDto.FullName))
                .ForMember(accountCommand => accountCommand.Details,
                    opt => opt.MapFrom(accountDto => accountDto.Details));
        }
    }
}
