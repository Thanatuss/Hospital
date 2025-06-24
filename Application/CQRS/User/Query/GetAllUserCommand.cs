using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.User.Query
{
    public class GetAllUserCommand : IRequest<List<Domain.SQL.Users.User>>
    {
    }

    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, List<Domain.SQL.Users.User>>
    {
        private readonly ProgramDbContext _dbcontext;

        public GetAllUserHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Domain.SQL.Users.User>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _dbcontext.Users
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}