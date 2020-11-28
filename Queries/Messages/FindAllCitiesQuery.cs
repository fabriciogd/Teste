using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Queries.Messages
{
    public class FindAllCitiesQuery : IRequest<IList<CityDTO>>
    {
    }
}
