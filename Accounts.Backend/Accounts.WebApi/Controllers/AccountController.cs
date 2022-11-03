using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounts.Application.Accounts.Queries.GetAccountList;
using System.Threading.Tasks;
using Accounts.Application.Accounts.Queries.GetAccountDetails;
using AutoMapper;
using Accounts.WebApi.Models;
using Accounts.Application.Accounts.Commands;
using Accounts.Application.Accounts.Commands.UpdateAccount;
using Accounts.Application.Accounts.Commands.DeleteAccount;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<AccountListVm>> GetAll()
        {
            var query = new GetAccountListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetailsVm>> Get(Guid id)
        {
            var query = new GetAccountDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccountDto createAccountDto)
        {
            var command = _mapper.Map<CreateAccountCommand>(createAccountDto);
            command.UserId = UserId;
            var AccountId = await Mediator.Send(command);
            return Ok(AccountId);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateAccountDto updateAccountDto)
        {
            var command = _mapper.Map<UpdateAccountCommand>(updateAccountDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAccountCommand
            {
                Id = id,
                UserId = UserId,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

