using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Profile.Query
{
    class GetProfileCommand : IRequest<string>
    {
    }
    public class GetProfileHandler : IRequestHandler<GetProfileCommand, string>
    {
        private readonly ProgramDbContext _dbContext;

        public GetProfileHandler(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        Task<string> IRequestHandler<GetProfileCommand, string>.Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            var data = _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == );
        }
    }
}
