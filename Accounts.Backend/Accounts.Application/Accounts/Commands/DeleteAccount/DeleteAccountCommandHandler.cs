using Accounts.Application.Common.Exceptions;
using Accounts.Application.Interfaces;
using Accounts.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler
        : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountsDbContext _dbContext;
        public DeleteAccountCommandHandler(IAccountsDbContext dbContext) =>
            _dbContext = dbContext;
        //Unit represents a void type 
        public async Task<Unit> Handle(DeleteAccountCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Accounts
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }
            _dbContext.Accounts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
