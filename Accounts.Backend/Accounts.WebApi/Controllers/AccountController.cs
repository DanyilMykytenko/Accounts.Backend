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
using Microsoft.AspNetCore.Authorization;
using Accounts.Application.Accounts.Commands;
using Accounts.Application.Accounts.Commands.UpdateAccount;
using Accounts.Application.Accounts.Commands.DeleteAccount;
using Microsoft.AspNetCore.Http;

namespace Accounts.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of accounts
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /account
        /// </remarks>
        /// <returns>Returns AccountListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unathorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccountListVm>> GetAll()
        {
            var query = new GetAccountListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Gets the account by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /account/5526BCCB-8446-4B77-AF51-D006A1306E26
        /// </remarks>
        /// <returns>Returns AccountDetailsVm</returns>
        /// <param name="id">Account id(guid)</param>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unathorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <summary>
        /// Creates the account
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /account
        /// {
        ///     fullName: "user full name"
        ///     details: "account details"
        /// }
        /// </remarks>
        /// <returns>Returns id(guid)</returns>
        /// <param name="createAccountDto">createAccountDto object</param>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unathorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccountDto createAccountDto)
        {
            var command = _mapper.Map<CreateAccountCommand>(createAccountDto);
            command.UserId = UserId;
            var AccountId = await Mediator.Send(command);
            return Ok(AccountId);
        }
        /// <summary>
        /// Updates the account
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /account
        /// {
        ///     fullName: "updated user full name"
        ///     details: "updated account details"
        /// }
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <param name="updateAccountDto">updateAccountDto object</param>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unathorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateAccountDto updateAccountDto)
        {
            var command = _mapper.Map<UpdateAccountCommand>(updateAccountDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes the account
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /account/A07F9A0D-16A3-4A5E-9D0D-7FB844E23C32
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <param name="id">id of the account(guid)</param>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unathorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

