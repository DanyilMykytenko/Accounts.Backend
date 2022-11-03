using System;
using MediatR;

namespace Accounts.Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Details { get; set; }
    }
}
