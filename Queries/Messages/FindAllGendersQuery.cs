using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries.Messages
{
    public class FindAllGendersQuery : IRequest<IList<GenderDTO>>
    {
    }
}
