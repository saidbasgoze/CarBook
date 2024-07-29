using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;
		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingWithTimePeriod1(); // await kullanarak asenkron metod çağrısı
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				BrandName = x.BrandName, 
				Model = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2]
			}).ToList();
		}
	}
}


