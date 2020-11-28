using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Queries.Messages
{
    public class FindAllClassificationsQuery : IRequest<IList<ClassificationDTO>>
    {
    }
}
