using MediatR;
using System;

namespace Accounts.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Details { get; set; }
    }
}
