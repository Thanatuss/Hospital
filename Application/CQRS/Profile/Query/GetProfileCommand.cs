using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Profile.Query
{
    public class GetProfileCommand : IRequest<Domain.SQL.Users.User>
    {
    }
    public class GetProfileHandler : IRequestHandler<GetProfileCommand, Domain.SQL.Users.User>
    {
        private readonly ProgramDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetProfileHandler(ProgramDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        Task<Domain.SQL.Users.User> IRequestHandler<GetProfileCommand, Domain.SQL.Users.User>.Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            var nationalcode = _httpContextAccessor.HttpContext?.User?.FindFirst("nationalcode");
            var data = _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Nationalcode == nationalcode.ToString());
            return data; 
        }
    }
}
