using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepository
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            var values = await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(z => z.Pricing)
                .Where(x => x.Pricing.Name == "Günlük")
                .ToListAsync(); // ToListAsync kullanarak verileri asenkron olarak alıyoruz.
            return values;
        }

		public Task<List<CarPricing>> GetCarPricingWithTimePeriod()
		{
			throw new NotImplementedException();
		}

		public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using var command = _context.Database.GetDbConnection().CreateCommand();
			{
				command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([5],[6],[1004])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;

				await _context.Database.OpenConnectionAsync(); // Asenkron olarak bağlantıyı açıyoruz
				using (var reader = await command.ExecuteReaderAsync()) // Asenkron olarak okuyucu kullanıyoruz
				{
					while (await reader.ReadAsync()) // Asenkron olarak okuma işlemi
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							BrandName = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
					{
							reader.IsDBNull(reader.GetOrdinal("5")) ? 0 : Convert.ToDecimal(reader["5"]),
							reader.IsDBNull(reader.GetOrdinal("6")) ? 0 : Convert.ToDecimal(reader["6"]),
							reader.IsDBNull(reader.GetOrdinal("1004")) ? 0 : Convert.ToDecimal(reader["1004"])
					}
						};
						values.Add(carPricingViewModel);
					}
				}
				await _context.Database.CloseConnectionAsync(); // Asenkron olarak bağlantıyı kapatıyoruz
			}
			return values;
		}



		//var values = from x in _context.CarPricings
		//			 group x by x.CarId into g
		//			 select new ResultCarPricingWithTimePeriodDto
		//			 {
		//				 CarId = g.Key,
		//				 DailyPrice = g.Where(y => y.PricingId == 2).Sum(z => z.Amount),
		//				 WeeklyPrice = g.Where(y => y.PricingId == 3).Sum(z => z.Amount),
		//				 MonthlyPrice = g.Where(y => y.PricingId == 4).Sum(z => z.Amount)
		//			 };

		//return values.ToListAsync();
	}
}
