using Domain.SQL.Users;
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
    public class GetUserByIdCommand : IRequest<Domain.SQL.Users.User>
    {
        public string Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, Domain.SQL.Users.User>
    {
        private readonly ProgramDbContext _dbcontext;

        public GetUserByIdHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Domain.SQL.Users.User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(request.Id));
            return user;
        }
    }
}
