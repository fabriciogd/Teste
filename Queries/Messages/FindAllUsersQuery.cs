using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Queries.Messages
{
    public class FindAllUsersQuery : IRequest<IList<UserDTO>>
    {
    }
}
