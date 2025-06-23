using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.CQRS.User.Query
{
    public class GetAllUserCommand : IRequest<Domain.SQL.Users.User>
    {
        public GetAllUserCommand()
        {
            
        }
    }
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, Domain.SQL.Users.User>
    {
        private readonly ProgramDbContext _dbcontext;

        public GetAllUserHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Domain.SQL.Users.User> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbcontext.Users.AsNoTracking().Where(x => x.IsDeleted == false).tolist();
            return user;
        }
    }
}
