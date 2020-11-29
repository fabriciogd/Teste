using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using MediatR;
using Queries.Messages;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Handlers
{
    public class FindAllClassificationsQueryHandler : IRequestHandler<FindAllClassificationsQuery, IList<ClassificationDTO>>
    {
        private readonly IRepositoryListQuery<Classification, ClassificationDTO> _repositoryQuery;

        public FindAllClassificationsQueryHandler(IRepositoryListQuery<Classification, ClassificationDTO> repositoryQuery)
        {
            _repositoryQuery = repositoryQuery;
        }

        public async Task<IList<ClassificationDTO>> Handle(FindAllClassificationsQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryQuery.GetAll();
        }
    }
}
