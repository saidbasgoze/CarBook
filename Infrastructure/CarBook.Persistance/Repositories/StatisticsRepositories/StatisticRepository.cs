using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId).
               Select(y => new
               {
                   BlogID = y.Key,
                   Count = y.Count()
               }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogId == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }
        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandID).
                Select(y => new
                {
                    BrandId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandId == values.BrandId).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id=_context.Pricings.Where(y=>y.Name=="Günlük").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByGasolineOrDiesel()
        {
            var value=_context.Cars.Where(x=>x.Fuel=="Benzin" || x.Fuel=="Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value=_context.Locations.Count();
            return value;
        }

        public string GetBrandAndModelByRentPriceMax()
        {

            // 'Günlük' isimli fiyatlandırma türünü al.
            int pricingId = _context.Pricings
                                    .Where(x => x.Name == "Günlük")
                                    .Select(y => y.PricingID)
                                    .FirstOrDefault();

            if (pricingId == 0)
            {
                throw new InvalidOperationException("No 'Günlük' pricing found.");
            }

            // En yüksek amount değerini al.
            decimal maxAmount = _context.CarPricings
                                        .Where(y => y.PricingId == pricingId)
                                        .Select(x => x.Amount)
                                        .Max();

            if (maxAmount == 0)
            {
                throw new InvalidOperationException("No car pricing found for the given 'Günlük' pricing.");
            }

            // En yüksek amount'a sahip carId'yi al.
            int carId = _context.CarPricings
                                .Where(x => x.Amount == maxAmount && x.PricingId == pricingId)
                                .Select(y => y.CarId)
                                .FirstOrDefault();

            if (carId == 0)
            {
                throw new InvalidOperationException("No car found with the highest amount for 'Günlük' pricing.");
            }

            // CarId'ye sahip arabanın markasını ve modelini al.
            string brandModel = _context.Cars
                                        .Where(x => x.CarID == carId)
                                        .Include(y => y.Brand)
                                        .Select(z => z.Brand.Name + " " + z.Model)
                                        .FirstOrDefault();

            if (string.IsNullOrEmpty(brandModel))
            {
                throw new InvalidOperationException("No car found with the given CarId.");
            }

            return brandModel;
        }

        public string GetBrandAndModelByRentPriceMin()
        {
            // 'Günlük' isimli fiyatlandırma türünü al.
            int pricingId = _context.Pricings
                                    .Where(x => x.Name == "Günlük")
                                    .Select(y => y.PricingID)
                                    .FirstOrDefault();

            if (pricingId == 0)
            {
                throw new InvalidOperationException("No 'Günlük' pricing found.");
            }

            // Minimum amount değerini al.
            decimal minAmount = _context.CarPricings
                                        .Where(y => y.PricingId == pricingId)
                                        .Select(x => x.Amount)
                                        .Min();

            if (minAmount == 0)
            {
                throw new InvalidOperationException("No car pricing found for the given 'Günlük' pricing.");
            }

            // Minimum amount'a sahip carId'yi al.
            int carId = _context.CarPricings
                                .Where(x => x.Amount == minAmount && x.PricingId == pricingId)
                                .Select(y => y.CarId)
                                .FirstOrDefault();

            if (carId == 0)
            {
                throw new InvalidOperationException("No car found with the lowest amount for 'Günlük' pricing.");
            }

            // CarId'ye sahip arabanın markasını ve modelini al.
            string brandModel = _context.Cars
                                        .Where(x => x.CarID == carId)
                                        .Include(y => y.Brand)
                                        .Select(z => z.Brand.Name + " " + z.Model)
                                        .FirstOrDefault();

            if (string.IsNullOrEmpty(brandModel))
            {
                throw new InvalidOperationException("No car found with the given CarId.");
            }

            return brandModel;
        }

      

       
    }
}
