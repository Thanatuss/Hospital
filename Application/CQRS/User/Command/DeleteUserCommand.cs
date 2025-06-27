using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.User.Command
{
    public class DeleteUserCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly ProgramDbContext _dbcontext;

        public DeleteUserHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _dbcontext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(request.Id));
                _dbcontext.Users.Remove(user);
                await _dbcontext.SaveChangesAsync();
                return "Successfull";
            }
            catch(Exception ex)
            {
                return "Failed";
            }
            
        }
    }
}
