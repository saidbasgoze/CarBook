using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BannerDtos
{
    public class CreateBannerDto
    {
       
        public String Title { get; set; }
        public String Description { get; set; }
        public String VideoDescription { get; set; }
        public String VideoUrl { get; set; }
    }
}
