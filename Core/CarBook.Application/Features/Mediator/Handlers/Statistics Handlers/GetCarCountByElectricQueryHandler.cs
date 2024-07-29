using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.Statistics_Handlers
{
    public class GetCarCountByElectricQueryHandler : IRequestHandler<GetCarCountByElectricQuery, GetCarCountByElectricQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public async Task<GetCarCountByElectricQueryResult> Handle(GetCarCountByElectricQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByElectric();
            return new GetCarCountByElectricQueryResult
            {
                CarCountByElectric = value
            };
        }
    }
}
