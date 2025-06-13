using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.User.Query
{
    public class GetUserByIdCommand : IRequest<string out>
    {
        public string Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, string out>
    {
        public Task<string> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
