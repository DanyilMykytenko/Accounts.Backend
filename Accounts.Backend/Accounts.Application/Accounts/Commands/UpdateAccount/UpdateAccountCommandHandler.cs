using Accounts.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Accounts.Application.Common.Exceptions;
using Accounts.Domain;
using Accounts.Application.Accounts.Commands.UpdateAccount;

namespace Accounts.Application.Accounts.Commands.UpdateCommand
{
    public class UpdateAccountCommandHandler
        : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountsDbContext _dbContext;
        public UpdateAccountCommandHandler(IAccountsDbContext dbContext) =>
            _dbContext = dbContext;

        //Unit represents a void type 
        public async Task<Unit> Handle(UpdateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Accounts.FirstOrDefaultAsync(acc =>
                    acc.Id == request.Id, cancellationToken);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }
            entity.Details = request.Details;
            entity.FullName = request.FullName;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
