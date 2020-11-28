using Domain.Entities;
using MediatR;

namespace Commands.Messages
{
    public class FindUserByEmailAndPasswordQuery : IRequest<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
