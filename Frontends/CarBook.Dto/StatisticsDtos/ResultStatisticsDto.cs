﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AvgPriceForDaily { get; set; }
        public decimal AvgPriceForWeekly { get; set; }
        public decimal AvgPriceForMonthly { get; set; }
        public int CarCountByTransmissionIsAuto { get; set; }
        public int CarCountByKmSmallerThan1000 { get; set; }
        public int CarCountByGasolineOrDiesel { get; set; }
        public int CarCountByElectric { get; set; }
        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }


    }
}
