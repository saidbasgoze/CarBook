using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System.Collections.Generic;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
	{
		
	}
}