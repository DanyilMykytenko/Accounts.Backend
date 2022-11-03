using MediatR;
using System;

namespace Accounts.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
