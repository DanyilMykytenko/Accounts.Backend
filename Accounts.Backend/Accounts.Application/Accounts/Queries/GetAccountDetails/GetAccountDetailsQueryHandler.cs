using System.Threading;
using System.Threading.Tasks;
using Accounts.Application.Common.Exceptions;
using Accounts.Application.Interfaces;
using Accounts.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Application.Accounts.Queries.GetAccountDetails
{
    public class GetAccountDetailsQueryHandler
        : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
    {
        private readonly IAccountsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAccountDetailsQueryHandler(IAccountsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Accounts
                .FirstOrDefaultAsync(account =>
                account.Id == request.Id, cancellationToken);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }

            return _mapper.Map<AccountDetailsVm>(entity);
        }
    }
}
