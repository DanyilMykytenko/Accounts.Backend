using Accounts.Application.Interfaces;
using Accounts.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Commands
{
    public class CreateAccountCommandHandler
        : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountsDbContext _dbContext;
        public CreateAccountCommandHandler(IAccountsDbContext dbContext) =>
            _dbContext = dbContext;

        //processing command logic
        public async Task<Guid> Handle(CreateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = new Account
            {
                UserId = request.UserId,
                FullName = request.FullName,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.Accounts.AddAsync(account, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return account.Id;
        }
    }
}
