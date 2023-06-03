using System;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Models;
namespace Molla_Backend.ViewModels
{
    public class AboutVM
	{
        public WhoWeAreInfo WhoWeAre { get; set; }
        public IEnumerable<WhoWeAreImage> WhoWeAreImage { get; set; }
        public BrandsInfo BrandsInfo { get; set; }
        public IEnumerable<BrandsImage> BrandsImages { get; set; }
        public IEnumerable<TeamMembers> TeamMembers { get; set; }
        public IEnumerable<CustomersComment> CustomersComments { get; set; }
    }
}

