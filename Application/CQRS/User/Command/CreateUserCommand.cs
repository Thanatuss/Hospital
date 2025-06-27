using Application.DTO;
using Domain.SQL.Users;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.User.Command
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUser createUser { get; set; }
    }
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly ProgramDbContext _dbContext;

        public CreateUserHandler(ProgramDbContext programDbContext)
        {
            _dbContext = programDbContext;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new Domain.SQL.Users.User
                {
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Password = request.createUser.Password,
                    Role = UserRole.Patient,
                    Username = request.createUser.Username
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch(Exception ex)
            {
                return "Faild";
            }
            
        }
    }
}
