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
    public class GetCarCountByGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByGasolineOrDieselQuery, GetCarCountByGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByGasolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByGasolineOrDieselQueryResult> Handle(GetCarCountByGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByGasolineOrDiesel();
            return new GetCarCountByGasolineOrDieselQueryResult
            {
                CarCountByGasolineOrDiesel = value
            };
        }
    }
}
